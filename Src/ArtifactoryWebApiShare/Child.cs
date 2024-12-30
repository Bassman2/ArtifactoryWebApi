namespace ArtifactoryWebApi;

public class Child
{
    internal Child(ChildModel model)
    {
        Uri = model.Uri;
        IsFolder = model.IsFolder;
    }

    // only file or folder name "/folder" or "/file.txt"
    public string? Uri { get; }

    public bool IsFolder { get; }
}
