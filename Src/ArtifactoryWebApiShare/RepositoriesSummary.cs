namespace ArtifactoryWebApi;

/// <summary>
/// Represents a summary of a repository in the Artifactory system, including its metadata and usage statistics.
/// </summary>
public class RepositoriesSummary
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RepositoriesSummary"/> class.
    /// </summary>
    /// <param name="model">The model containing the repository summary data.</param>
    internal RepositoriesSummary(RepositoriesSummaryModel model)
    {
        RepoKey = model.RepoKey;
        RepoType = model.RepoType;
        FoldersCount = model.FoldersCount;
        FilesCount = model.FilesCount;
        UsedSpace = model.UsedSpace;
        UsedSpaceInBytes = model.UsedSpaceInBytes;
        ItemsCount = model.ItemsCount;
        PackageType = model.PackageType;
        ProjectKey = model.ProjectKey;
        Percentage = model.Percentage;
    }

    /// <summary>
    /// Gets the unique key of the repository.
    /// </summary>
    public string? RepoKey { get; }

    /// <summary>
    /// Gets the type of the repository (e.g., local, remote, virtual).
    /// </summary>
    public RepositoryType? RepoType { get; }

    /// <summary>
    /// Gets the number of folders in the repository.
    /// </summary>
    public long? FoldersCount { get; }

    /// <summary>
    /// Gets the number of files in the repository.
    /// </summary>
    public long? FilesCount { get; }

    /// <summary>
    /// Gets the used space in the repository as a human-readable string (e.g., "10 GB").
    /// </summary>
    public string? UsedSpace { get; }

    /// <summary>
    /// Gets the used space in the repository in bytes.
    /// </summary>
    public long? UsedSpaceInBytes { get; }

    /// <summary>
    /// Gets the total number of items (files and folders) in the repository.
    /// </summary>
    public long? ItemsCount { get; }

    /// <summary>
    /// Gets the type of packages stored in the repository (e.g., Maven, Docker, NPM).
    /// </summary>
    public PackageType? PackageType { get; }

    /// <summary>
    /// Gets the project key associated with the repository.
    /// </summary>
    public string? ProjectKey { get; }

    /// <summary>
    /// Gets the percentage of storage used by the repository as a string (e.g., "75%").
    /// </summary>
    public string? Percentage { get; }
}
