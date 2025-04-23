namespace ArtifactoryWebApi;

/// <summary>
/// Represents storage information for a file or folder in the Artifactory system.
/// </summary>
public class Storage
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Storage"/> class.
    /// </summary>
    /// <param name="model">The model containing the storage data.</param>
    internal Storage(StorageModel model)
    {
        this.Repo = model.Repo;
        this.Path = model.Path;
        this.Created = model.Created;
        this.CreatedBy = model.CreatedBy;
        this.LastModified = model.LastModified;
        this.ModifiedBy = model.ModifiedBy;
        this.LastUpdated = model.LastUpdated;
        this.DownloadUri = model.DownloadUri!;
        this.MimeType = model.MimeType;
        this.Size = model.Size;
        this.Checksums = model.Checksums.CastModel<Checksums>();
        this.OriginalChecksums = model.OriginalChecksums.CastModel<Checksums>();
        this.Children = model.Children.CastModel<Child>();
        this.Uri = model.Uri;

        this.Name = model.Path?.Substring(model.Path.LastIndexOf('/') + 1);
    }

    /// <summary>
    /// Gets the name of the file or folder, extracted from the path.
    /// </summary>
    public string? Name { get; }

    /// <summary>
    /// Gets the repository where the file or folder is stored.
    /// </summary>
    public string? Repo { get; }

    /// <summary>
    /// Gets the path of the file or folder within the repository.
    /// </summary>
    public string? Path { get; }

    /// <summary>
    /// Gets the creation timestamp of the file or folder.
    /// </summary>
    public DateTime? Created { get; }

    /// <summary>
    /// Gets the user who created the file or folder.
    /// </summary>
    public string? CreatedBy { get; }

    /// <summary>
    /// Gets the last modified timestamp of the file or folder.
    /// </summary>
    public DateTime? LastModified { get; }

    /// <summary>
    /// Gets the user who last modified the file or folder.
    /// </summary>
    public string? ModifiedBy { get; }

    /// <summary>
    /// Gets the last updated timestamp of the file or folder.
    /// </summary>
    public DateTime? LastUpdated { get; }

    #region File

    /// <summary>
    /// Gets the URI to download the file.
    /// </summary>
    public Uri DownloadUri { get; }

    /// <summary>
    /// Gets the MIME type of the file.
    /// </summary>
    public string? MimeType { get; }

    /// <summary>
    /// Gets the size of the file as a string.
    /// </summary>
    public string? Size { get; }

    /// <summary>
    /// Gets the checksum values of the file.
    /// </summary>
    public Checksums? Checksums { get; }

    /// <summary>
    /// Gets the original checksum values of the file.
    /// </summary>
    public Checksums? OriginalChecksums { get; }

    #endregion

    #region Folder

    /// <summary>
    /// Gets the list of child resources (files or folders) within the folder.
    /// </summary>
    public List<Child>? Children { get; }

    #endregion

    /// <summary>
    /// Gets the URI of the file or folder.
    /// </summary>
    public Uri? Uri { get; }
}
