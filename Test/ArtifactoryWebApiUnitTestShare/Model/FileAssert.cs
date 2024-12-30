namespace ArtifactoryWebApiUnitTest.Model;

public class FileAssert
{
    // not a uri only "/folder/file.xxx"
    public string? Uri { get; init; }

    public long? Size { get; init; }

    public DateTime? LastModified { get; init; }

    public bool Folder { get; init; }

    public string? Sha1 { get; init; }

    public string? Sha2 { get; init; }

    public MdTimestamps? MdTimestamps { get; init; }

    public override int GetHashCode()
    {
        return 0;
    }

    public override bool Equals(object? obj)
    {
        if (obj is ArtifactoryWebApi.File file)
        {
            Assert.IsNotNull(file);
            Assert.AreEqual(Uri, file.Uri, $"{nameof(Uri)} of {file.Uri}");
            Assert.AreEqual(Size, file.Size, $"{nameof(Size)} of {file.Uri}");
            Assert.AreEqual(LastModified?.Date, file.LastModified?.Date, $"{nameof(LastModified)} of {file.Uri}");
            Assert.AreEqual(Folder, file.Folder, $"{nameof(Folder)} of {file.Uri}");
            Assert.AreEqual(Sha1, file.Sha1, $"{nameof(Sha1)} of {file.Uri}");
            Assert.AreEqual(Sha2, file.Sha2, $"{nameof(Sha2)} of {file.Uri}");
            Assert.AreEqual(MdTimestamps?.Properties, file.MdTimestamps?.Properties, $"{nameof(MdTimestamps.Properties)} of {file.Uri}");
            return true;
                //Uri == file.Uri
                //&& Size == file.Size
                //&& LastModified?.Date == file.LastModified?.Date
                //&& Folder == file.Folder
                //&& Sha1 == file.Sha1
                //&& Sha2 == file.Sha2
                //&& MdTimestamps?.Properties == file.MdTimestamps?.Properties;
        }
        return base.Equals(obj);
    }
}
