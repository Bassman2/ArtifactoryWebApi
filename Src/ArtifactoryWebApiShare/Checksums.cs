namespace ArtifactoryWebApi;

/// <summary>
/// Represents the checksum values for a file or artifact.
/// </summary>
public class Checksums
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Checksums"/> class.
    /// </summary>
    /// <param name="model">The model containing the checksum values.</param>
    internal Checksums(ChecksumsModel model)
    {
        Md5 = model.Md5;
        Sha1 = model.Sha1;
        Sha256 = model.Sha256;
    }

    /// <summary>
    /// Gets the MD5 checksum of the file or artifact.
    /// </summary>
    public string? Md5 { get; }

    /// <summary>
    /// Gets the SHA-1 checksum of the file or artifact.
    /// </summary>
    public string? Sha1 { get; }

    /// <summary>
    /// Gets the SHA-256 checksum of the file or artifact.
    /// </summary>
    public string? Sha256 { get; }
}
