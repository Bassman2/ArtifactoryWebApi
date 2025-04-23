namespace ArtifactoryWebApi;

/// <summary>
/// Represents a summary of the file store, including storage type and directory information.
/// </summary>
public class FileStoreSummary
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FileStoreSummary"/> class.
    /// </summary>
    /// <param name="model">The model containing the file store summary data.</param>
    internal FileStoreSummary(FileStoreSummaryModel model)
    {
        StorageType = model.StorageType;
        StorageDirectory = model.StorageDirectory;
    }

    /// <summary>
    /// Gets the type of storage used for the file store (e.g., "local", "cloud").
    /// </summary>
    public string? StorageType { get; }

    /// <summary>
    /// Gets the directory path where the file store is located.
    /// </summary>
    public string? StorageDirectory { get; }
}
