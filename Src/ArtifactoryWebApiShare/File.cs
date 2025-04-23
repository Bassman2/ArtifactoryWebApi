namespace ArtifactoryWebApi;

/// <summary>
/// Represents a file or folder in the Artifactory system.
/// </summary>
[DebuggerDisplay("{Uri}")]
public class File
{
    /// <summary>
    /// Initializes a new instance of the <see cref="File"/> class.
    /// </summary>
    /// <param name="model">The model containing the file or folder's data.</param>
    internal File(FileModel model)
    {
        Uri = model.Uri;
        Size = model.Size;
        LastModified = model.LastModified;
        Folder = model.Folder;
        Sha1 = model.Sha1;
        Sha2 = model.Sha2;
        MdTimestamps = model.MdTimestamps.CastModel<MdTimestamps>();

        Name = model.Uri?.Substring(model.Uri.LastIndexOf('/') + 1);
    }

    /// <summary>
    /// Gets the name of the file or folder, extracted from the URI.
    /// </summary>
    public string? Name { get; }

    /// <summary>
    /// Gets the URI of the file or folder. This is not a full URI, but a relative path (e.g., "/folder/file.xxx").
    /// </summary>
    public string? Uri { get; }

    /// <summary>
    /// Gets the size of the file in bytes. This is null for folders.
    /// </summary>
    public long? Size { get; }

    /// <summary>
    /// Gets the last modified timestamp of the file or folder.
    /// </summary>
    public DateTime? LastModified { get; }

    /// <summary>
    /// Gets a value indicating whether the item is a folder.
    /// </summary>
    public bool Folder { get; }

    /// <summary>
    /// Gets the SHA-1 checksum of the file. This is null for folders.
    /// </summary>
    public string? Sha1 { get; }

    /// <summary>
    /// Gets the SHA-2 checksum of the file. This is null for folders.
    /// </summary>
    public string? Sha2 { get; }

    /// <summary>
    /// Gets the metadata timestamps associated with the file or folder.
    /// </summary>
    public MdTimestamps? MdTimestamps { get; }
}
