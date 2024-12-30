namespace ArtifactoryWebApi;

public class StorageInfo
{
    internal StorageInfo(StorageInfoModel model)
    {
        RepositoriesSummaryList = model.RepositoriesSummaryList.CastModel<RepositoriesSummary>();
        FileStoreSummary = model.FileStoreSummary.CastModel<FileStoreSummary>();
        BinariesSummary = model.BinariesSummary.CastModel<BinariesSummary>();

    }

    public IEnumerable<RepositoriesSummary>? RepositoriesSummaryList { get; }

    public FileStoreSummary? FileStoreSummary { get; }

    public BinariesSummary? BinariesSummary { get; }
}
