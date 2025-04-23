namespace ArtifactoryWebApi;

/// <summary>
/// Represents statistics related to the storage and usage of a file or resource in the Artifactory system.
/// </summary>
public class StorageStats
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StorageStats"/> class.
    /// </summary>
    /// <param name="model">The model containing the storage statistics data.</param>
    internal StorageStats(StorageStatsModel model)
    {
        Uri = model.Uri;
        DownloadCount = model.DownloadCount;
        LastDownloaded = model.LastDownloaded;
        LastDownloadedBy = model.LastDownloadedBy;
        RemoteDownloadCount = model.RemoteDownloadCount;
        RemoteLastDownloaded = model.RemoteLastDownloaded;
    }

    /// <summary>
    /// Gets the URI of the resource.
    /// </summary>
    public Uri? Uri { get; }

    /// <summary>
    /// Gets the total number of times the resource has been downloaded.
    /// </summary>
    public long? DownloadCount { get; }

    /// <summary>
    /// Gets the timestamp of the last time the resource was downloaded.
    /// </summary>
    public long? LastDownloaded { get; }

    /// <summary>
    /// Gets the username of the user who last downloaded the resource.
    /// </summary>
    public string? LastDownloadedBy { get; }

    /// <summary>
    /// Gets the total number of times the resource has been downloaded remotely.
    /// </summary>
    public long? RemoteDownloadCount { get; }

    /// <summary>
    /// Gets the timestamp of the last time the resource was downloaded remotely.
    /// </summary>
    public long? RemoteLastDownloaded { get; }
}
