namespace ArtifactoryWebApi;

public class RepositoryInfo
{
    internal RepositoryInfo(RepositoryInfoModel model)
    {
        Key = model.Key;
        PackageType = model.PackageType;
        Description = model.Description;
        Notes = model.Notes;
        IncludesPattern = model.IncludesPattern;
        ExcludesPattern = model.ExcludesPattern;
    }

    public string? Key { get; }

    public PackageType PackageType { get; }

    public string? Description { get; }

    public string? Notes { get; }

    public string? IncludesPattern { get; }

    public string? ExcludesPattern { get; }
}
