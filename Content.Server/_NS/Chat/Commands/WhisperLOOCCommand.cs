using Content.Server.Chat.Systems;
using Content.Shared.Administration;
using Robust.Shared.Console;
using Robust.Shared.Enums;

namespace Content.Server._NS.Chat.Commands
{
    [AnyCommand]
    internal sealed class WhisperLOOCCommand : IConsoleCommand
    {
        [Dependency] private readonly IEntityManager _e = default!;

        public string Command => "wlooc";
        public string Description => "Send Local Out Of Character chat messages, with the range of a whisper.";
        public string Help => "wlooc <text>";

        public void Execute(IConsoleShell shell, string argStr, string[] args)
        {
            if (shell.Player is not { } player)
            {
                shell.WriteError("This command cannot be run from the server.");
                return;
            }

            if (player.AttachedEntity is not { Valid: true } entity)
                return;

            if (player.Status != SessionStatus.InGame)
                return;

            if (args.Length < 1)
                return;

            var message = string.Join(" ", args).Trim();
            if (string.IsNullOrEmpty(message))
                return;

            _e.System<ChatSystem>().TrySendInGameOOCMessage(entity, message, InGameOOCChatType.WhisperLooc, false, shell, player);
        }
    }
}
