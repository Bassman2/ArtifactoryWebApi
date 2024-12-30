namespace ArtifactoryWebApi;

public class Checksums
{
    internal Checksums(ChecksumsModel model)
    {
        Md5 = model.Md5;
        Sha1 = model.Sha1;
        Sha256 = model.Sha256;
    }

    public string? Md5 { get; }

    public string? Sha1 { get; }

    public string? Sha256 { get; }
}
