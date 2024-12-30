namespace ArtifactoryWebApi;

public class BinariesSummary
{
    internal BinariesSummary(BinariesSummaryModel model)
    {
        BinariesCount = model.BinariesCount;
        BinariesSize = model.BinariesSize;
        ArtifactsSize = model.ArtifactsSize;
        Optimization = model.Optimization;
        ItemsCount = model.ItemsCount;
        ArtifactsCount = model.ArtifactsCount;
    }

    public string? BinariesCount { get; }

    public string? BinariesSize { get; }

    public string? ArtifactsSize { get; }

    public string? Optimization { get; }

    public string? ItemsCount { get; }

    public string? ArtifactsCount { get; }
}
