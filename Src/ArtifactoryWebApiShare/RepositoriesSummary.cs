namespace ArtifactoryWebApi;

public class RepositoriesSummary
{
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
    public string? RepoKey { get; }

    public RepositoryType? RepoType { get; }

    public long? FoldersCount { get; }

    public long? FilesCount { get; }

    public string? UsedSpace { get; }

    public long? UsedSpaceInBytes { get; }

    public long? ItemsCount { get; }

    public PackageType? PackageType { get; }

    public string? ProjectKey { get; }

    public string? Percentage { get; }
}
