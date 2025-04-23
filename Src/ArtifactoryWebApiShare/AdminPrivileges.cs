namespace ArtifactoryWebApi;

/// <summary>
/// Represents the administrative privileges for managing members, resources, and indexing resources.
/// </summary>
public class AdminPrivileges
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AdminPrivileges"/> class.
    /// </summary>
    /// <param name="model">The model containing the administrative privilege settings.</param>
    internal AdminPrivileges(AdminPrivilegesModel model)
    {
        ManageMembers = model.ManageMembers;
        ManageResources = model.ManageResources;
        IndexResources = model.IndexResources;
    }

    /// <summary>
    /// Gets a value indicating whether the user has privileges to manage members.
    /// </summary>
    public bool? ManageMembers { get; }

    /// <summary>
    /// Gets a value indicating whether the user has privileges to manage resources.
    /// </summary>
    public bool? ManageResources { get; }

    /// <summary>
    /// Gets a value indicating whether the user has privileges to index resources.
    /// </summary>
    public bool? IndexResources { get; }
}
