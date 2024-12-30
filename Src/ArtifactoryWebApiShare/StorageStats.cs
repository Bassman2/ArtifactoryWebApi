namespace ArtifactoryWebApi;

public class StorageStats
{
    internal StorageStats(StorageStatsModel model)
    {
        Uri = model.Uri;
        DownloadCount = model.DownloadCount;
        LastDownloaded = model.LastDownloaded;
        LastDownloadedBy = model.LastDownloadedBy;
        RemoteDownloadCount = model.RemoteDownloadCount;
        RemoteLastDownloaded = model.RemoteLastDownloaded;
    }

    public Uri? Uri { get; }

    public long? DownloadCount { get; }

    public long? LastDownloaded { get; }

    public string? LastDownloadedBy { get; }

    public long? RemoteDownloadCount { get; }

    public long? RemoteLastDownloaded { get; }
}
