namespace ArtifactoryWebApi.Service.Model;

internal class StorageInfoModel
{
    [JsonPropertyName("repositoriesSummaryList")]
    public IEnumerable<RepositoriesSummaryModel>? RepositoriesSummaryList { get; set; }

    [JsonPropertyName("fileStoreSummary")]
    public FileStoreSummaryModel? FileStoreSummary { get; set; }

    [JsonPropertyName("binariesSummary")]
    public BinariesSummaryModel? BinariesSummary { get; set; }
}
