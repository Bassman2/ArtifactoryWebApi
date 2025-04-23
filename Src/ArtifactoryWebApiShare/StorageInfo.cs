namespace ArtifactoryWebApi;

/// <summary>
/// Represents storage information in the Artifactory system, including repository summaries, file store details, and binary statistics.
/// </summary>
public class StorageInfo
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StorageInfo"/> class.
    /// </summary>
    /// <param name="model">The model containing the storage information data.</param>
    internal StorageInfo(StorageInfoModel model)
    {
        RepositoriesSummaryList = model.RepositoriesSummaryList.CastModel<RepositoriesSummary>();
        FileStoreSummary = model.FileStoreSummary.CastModel<FileStoreSummary>();
        BinariesSummary = model.BinariesSummary.CastModel<BinariesSummary>();
    }

    /// <summary>
    /// Gets the list of repository summaries, including metadata and usage statistics for each repository.
    /// </summary>
    public List<RepositoriesSummary>? RepositoriesSummaryList { get; }

    /// <summary>
    /// Gets the summary of the file store, including storage type and directory information.
    /// </summary>
    public FileStoreSummary? FileStoreSummary { get; }

    /// <summary>
    /// Gets the summary of binary and artifact statistics, including counts and sizes.
    /// </summary>
    public BinariesSummary? BinariesSummary { get; }
}
