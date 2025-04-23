namespace ArtifactoryWebApi;

/// <summary>
/// Represents a child resource, which can be either a file or a folder.
/// </summary>
public class Child
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Child"/> class.
    /// </summary>
    /// <param name="model">The model containing the child resource's data.</param>
    internal Child(ChildModel model)
    {
        Uri = model.Uri;
        IsFolder = model.IsFolder;
    }

    /// <summary>
    /// Gets the URI of the child resource, which represents either a file or folder name (e.g., "/folder" or "/file.txt").
    /// </summary>
    public string? Uri { get; }

    /// <summary>
    /// Gets a value indicating whether the child resource is a folder.
    /// </summary>
    public bool IsFolder { get; }
}
