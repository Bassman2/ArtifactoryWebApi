namespace ArtifactoryWebApi;

/// <summary>
/// Represents a list of files in a specific storage location within the Artifactory system.
/// </summary>
public class StorageList
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StorageList"/> class.
    /// </summary>
    /// <param name="model">The model containing the storage list data.</param>
    internal StorageList(StorageListModel model)
    {
        Uri = model.Uri;
        Created = model.Created;
        Files = model.Files.CastModel<File>();
    }

    /// <summary>
    /// Gets the URI of the storage location.
    /// </summary>
    public Uri? Uri { get; }

    /// <summary>
    /// Gets the creation timestamp of the storage list.
    /// </summary>
    public DateTime? Created { get; }

    /// <summary>
    /// Gets the list of files in the storage location.
    /// </summary>
    public List<File>? Files { get; }
}
