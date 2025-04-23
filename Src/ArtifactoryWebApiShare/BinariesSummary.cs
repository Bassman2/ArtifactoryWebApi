namespace ArtifactoryWebApi;

/// <summary>
/// Represents a summary of binary and artifact statistics.
/// </summary>
public class BinariesSummary
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BinariesSummary"/> class.
    /// </summary>
    /// <param name="model">The model containing the binary and artifact statistics.</param>
    internal BinariesSummary(BinariesSummaryModel model)
    {
        BinariesCount = model.BinariesCount;
        BinariesSize = model.BinariesSize;
        ArtifactsSize = model.ArtifactsSize;
        Optimization = model.Optimization;
        ItemsCount = model.ItemsCount;
        ArtifactsCount = model.ArtifactsCount;
    }

    /// <summary>
    /// Gets the total number of binaries.
    /// </summary>
    public string? BinariesCount { get; }

    /// <summary>
    /// Gets the total size of binaries.
    /// </summary>
    public string? BinariesSize { get; }

    /// <summary>
    /// Gets the total size of artifacts.
    /// </summary>
    public string? ArtifactsSize { get; }

    /// <summary>
    /// Gets the optimization percentage of storage usage.
    /// </summary>
    public string? Optimization { get; }

    /// <summary>
    /// Gets the total number of items.
    /// </summary>
    public string? ItemsCount { get; }

    /// <summary>
    /// Gets the total number of artifacts.
    /// </summary>
    public string? ArtifactsCount { get; }
}
