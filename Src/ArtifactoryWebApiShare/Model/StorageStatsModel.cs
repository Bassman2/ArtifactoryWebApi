namespace ArtifactoryWebApi.Model;

internal class StorageStatsModel
{
    [JsonPropertyName("uri")]
    public Uri? Uri { get; set; }

    [JsonPropertyName("downloadCount")]
    public long? DownloadCount { get; set; }

    [JsonPropertyName("lastDownloaded")]
    public long? LastDownloaded { get; set; }

    [JsonPropertyName("lastDownloadedBy")]
    public string? LastDownloadedBy { get; set; }

    [JsonPropertyName("remoteDownloadCount")]
    public long? RemoteDownloadCount { get; set; }

    [JsonPropertyName("remoteLastDownloaded")]
    public long? RemoteLastDownloaded { get; set; }
}
