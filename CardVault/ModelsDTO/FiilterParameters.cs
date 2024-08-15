namespace CardVault.ModelsDTO

{
    public class FilterParameters
    {
        public string SearchQuery { get; set; } = string.Empty;
        public string? RarityCodeFilter { get; set; } = null;
        public string? ColorFilter { get; set; } = null;
        public string? ManaCostFilter { get; set; } = null;
        public string? TypeFilter { get; set; } = null;
        public int? ConvertedManaCostFilter { get; set; } = null;
    }
}



