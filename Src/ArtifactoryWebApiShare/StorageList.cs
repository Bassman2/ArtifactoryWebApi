namespace ArtifactoryWebApi;

public class StorageList
{
    internal StorageList(StorageListModel model)
    {
        Uri = model.Uri;
        Created = model.Created;
        Files = model.Files.CastModel<File>();
    }

    public Uri? Uri { get; }

    public DateTime? Created { get; }

    public IEnumerable<File>? Files { get; }

}
