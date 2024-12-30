namespace ArtifactoryWebApi.Service.Model;

internal class BinariesSummaryModel
{
    [JsonPropertyName("binariesCount")]
    public string? BinariesCount { get; set; }

    [JsonPropertyName("binariesSize")]
    public string? BinariesSize { get; set; }

    [JsonPropertyName("artifactsSize")]
    public string? ArtifactsSize { get; set; }

    [JsonPropertyName("optimization")]
    public string? Optimization { get; set; }

    [JsonPropertyName("itemsCount")]
    public string? ItemsCount { get; set; }

    [JsonPropertyName("artifactsCount")]
    public string? ArtifactsCount { get; set; }
}
