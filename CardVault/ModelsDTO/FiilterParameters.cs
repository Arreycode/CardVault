namespace CardVault.ModelsDTO

{
    public class FilterParameters
    {
        public string RarityCodeFilter { get; set; } = string.Empty;
        public string ColorFilter { get; set; } = string.Empty;
        public string ManaCostFilter { get; set; } = string.Empty;
        public string TypeFilter { get; set; } = string.Empty;
    }
}