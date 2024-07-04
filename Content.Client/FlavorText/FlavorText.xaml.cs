﻿using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.XAML;
using Robust.Shared.Player;
using Robust.Shared.Utility;

namespace Content.Client.FlavorText
{
    [GenerateTypedNameReferences]
    public sealed partial class FlavorText : Control
    {
        public Action<string>? OnFlavorTextChanged;
        public Action<string>? OnOOCFlavorTextChanged; // Nebulous

        public FlavorText()
        {
            RobustXamlLoader.Load(this);
            IoCManager.InjectDependencies(this);

            var loc = IoCManager.Resolve<ILocalizationManager>();
            CFlavorTextInput.Placeholder = new Rope.Leaf(loc.GetString("flavor-text-placeholder"));
            COOCFlavoTextInput.Placeholder = new Rope.Leaf(loc.GetString("ooc-flavor-text-placeholder")); // Nebulous
            CFlavorTextInput.OnTextChanged  += _ => FlavorTextChanged();
            COOCFlavoTextInput.OnTextChanged += _ => OOCFlavorTextChanged(); // Nebulous
        }

        public void FlavorTextChanged()
        {
            OnFlavorTextChanged?.Invoke(Rope.Collapse(CFlavorTextInput.TextRope).Trim());
        }

        public void OOCFlavorTextChanged() // Nebulous
        {
            OnOOCFlavorTextChanged?.Invoke(Rope.Collapse(COOCFlavoTextInput.TextRope).Trim());
        }
    }
}
