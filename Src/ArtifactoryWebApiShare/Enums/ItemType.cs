namespace ArtifactoryWebApi.Service;

[Flags]
internal enum ItemType
{
    File = 1,
    Folder = 2,
    Both = 3
}
