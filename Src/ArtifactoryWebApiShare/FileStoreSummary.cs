namespace ArtifactoryWebApi;

public class FileStoreSummary
{
    internal FileStoreSummary(FileStoreSummaryModel model)
    {
        StorageType = model.StorageType;
        StorageDirectory = model.StorageDirectory;
    }

    public string? StorageType { get; }

    public string? StorageDirectory { get; }
}
