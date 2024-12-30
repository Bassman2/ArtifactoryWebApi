namespace ArtifactoryWebApiUnitTest.Model;

public class ChildAssert
{
    // only file or folder name "/folder" or "/file.txt"
    public string? Uri { get; init; }

    public bool IsFolder { get; init;  }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override bool Equals(object? obj)
    {   
        if (obj is Child child)
        {
            return Uri == child.Uri && IsFolder == child.IsFolder;
        }
        return base.Equals(obj);
    }
}
