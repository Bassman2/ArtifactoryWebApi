namespace ArtifactoryWebApi.Service.Model;

internal class FileStoreSummaryModel
{
    [JsonPropertyName("storageType")]
    public string? StorageType { get; set; }

    [JsonPropertyName("storageDirectory")]
    public string? StorageDirectory { get; set; }
}
