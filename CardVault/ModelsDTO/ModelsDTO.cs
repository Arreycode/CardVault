namespace BlazorServerAuthenticationAndAuthorization.ModelsDTO
{
    public class CardModelClass
    {
        public long Id { get; init; }
        public string Name { get; init; }
        public string? ManaCost { get; init; }
        public string ConvertedManaCost { get; init; }
        public string Type { get; init; }
        public string? RarityCode { get; init; }
        public string SetCode { get; init; }
        public string? Text { get; init; }
        public string? Flavor { get; init; }
        public string? Power { get; init; }
        public string? Toughness { get; init; }
        public string Layout { get; init; }
        public int? MultiverseId { get; init; }
        public string OriginalImageUrl { get; init; }
        public string Image { get; init; }
        public List<string> Colors { get; init; } = new List<string>();
        public List<string> Types { get; init; } = new List<string>();
    }

    public record CardModelRecord(long Id, string Name, string Image, string Color, string RarityCode, int ManaCost, string Type);

    public record CardSummaryModel(long IdCard, string ImageInfo, string CardName, string ArtistName) { }

    public record ArtistModel(long Id, string Name) { }
}
