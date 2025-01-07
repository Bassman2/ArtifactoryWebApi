namespace ArtifactoryWebApi;

[DebuggerDisplay("{Uri}")]
public class File 
{
    internal File(FileModel model) 
    {
        Uri = model.Uri;
        Size = model.Size;
        LastModified = model.LastModified;
        Folder = model.Folder;
        Sha1 = model.Sha1;
        Sha2 = model.Sha2;
        MdTimestamps = model.MdTimestamps.CastModel<MdTimestamps>();

        Name = model.Uri?.Substring(model.Uri.LastIndexOf('/') + 1);
    }

    public string? Name { get; }

    // not a uri only "/folder/file.xxx"
    public string? Uri { get; }

    public long? Size { get; }

    public DateTime? LastModified { get; }

    public bool Folder { get; }

    public string? Sha1 { get; }

    public string? Sha2 { get; }

    public MdTimestamps? MdTimestamps { get; }
}
