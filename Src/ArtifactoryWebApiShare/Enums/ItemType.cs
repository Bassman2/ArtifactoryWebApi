namespace ArtifactoryWebApi.Service;

/// <summary>
/// Represents the type of an item, which can be a file, a folder, or both.
/// </summary>
[Flags]
internal enum ItemType
{
    /// <summary>
    /// Represents a file item.
    /// </summary>
    File = 1,

    /// <summary>
    /// Represents a folder item.
    /// </summary>
    Folder = 2,

    /// <summary>
    /// Represents both file and folder items.
    /// </summary>
    Both = 3
}
