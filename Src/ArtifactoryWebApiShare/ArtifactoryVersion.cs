namespace ArtifactoryWebApi;

/// <summary>
/// Represents the version and revision information of the Artifactory server.
/// </summary>
public class ArtifactoryVersion
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ArtifactoryVersion"/> class.
    /// </summary>
    /// <param name="model">The model containing the project's data.</param>
    internal ArtifactoryVersion(ArtifactoryVersionModel model)
    {
        Version = model.Version;
        Revision = model.Revision;
    }
       
    /// <summary>
    /// Gets the version of the Artifactory server.
    /// </summary>
    public string? Version { get; }

    /// <summary>
    /// Gets the revision of the Artifactory server.
    /// </summary>
    public string? Revision { get; }

    /// <summary>
    /// Returns a string that represents the current <see cref="ArtifactoryVersion"/> instance,
    /// combining the <see cref="Version"/> and <see cref="Revision"/> properties.
    /// </summary>
    /// <returns>
    /// A string in the format "Version.Revision" representing the version and revision.
    /// </returns>
    public override string ToString() => $"{Version}.{Revision}";

    /// <summary>
    /// Implicitly converts an <see cref="ArtifactoryVersion"/> to a <see cref="Version"/>.
    /// </summary>
    /// <param name="v">The <see cref="ArtifactoryVersion"/> instance.</param>
    /// <returns>A <see cref="Version"/> instance representing the version and revision.</returns>
    public static implicit operator Version(ArtifactoryVersion v) => new(v.ToString());
}
