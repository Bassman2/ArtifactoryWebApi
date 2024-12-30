namespace ArtifactoryWebApi;

public class AdminPrivileges
{
    internal AdminPrivileges(AdminPrivilegesModel model)
    {
        ManageMembers = model.ManageMembers;
        ManageResources = model.ManageResources;
        IndexResources = model.IndexResources;
    }

    public bool? ManageMembers { get; }

    public bool? ManageResources { get; }

    public bool? IndexResources { get; }
}
