namespace Content.Server.DetailExaminable
{
    [RegisterComponent]
    public sealed partial class DetailExaminableComponent : Component
    {
        [DataField] // Nebulous - Removed some extra data
        public string Content = "";

        [DataField] // Nebulous
        public string OOCContent = "";
    }
}
