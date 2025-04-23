namespace ArtifactoryWebApi;

/// <summary>
/// Represents the configuration of a repository in the Artifactory system.
/// </summary>
public class RepositoryConfiguration
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RepositoryConfiguration"/> class.
    /// </summary>
    /// <param name="model">The model containing the repository configuration data.</param>
    internal RepositoryConfiguration(RepositoryConfigurationModel model)
    {
        Key = model.Key;
        PackageType = model.PackageType;
        Description = model.Description;
        Notes = model.Notes;
        IncludesPattern = model.IncludesPattern;
        ExcludesPattern = model.ExcludesPattern;
    }

    /// <summary>
    /// Gets the unique key of the repository.
    /// </summary>
    public string? Key { get; }

    /// <summary>
    /// Gets the type of packages stored in the repository (e.g., Maven, Docker, NPM).
    /// </summary>
    public PackageType PackageType { get; }

    /// <summary>
    /// Gets the description of the repository.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets additional notes or metadata about the repository.
    /// </summary>
    public string? Notes { get; }

    /// <summary>
    /// Gets the pattern used to include specific files or folders in the repository.
    /// </summary>
    public string? IncludesPattern { get; }

    /// <summary>
    /// Gets the pattern used to exclude specific files or folders from the repository.
    /// </summary>
    public string? ExcludesPattern { get; }
}
