namespace ArtifactoryWebApi;

/// <summary>
/// Represents a project in the Artifactory system, including its metadata and administrative settings.
/// </summary>
public class Project
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Project"/> class.
    /// </summary>
    /// <param name="model">The model containing the project's data.</param>
    internal Project(ProjectModel model)
    {
        DisplayName = model.DisplayName;
        Description = model.Description;
        AdminPrivileges = model.AdminPrivileges.CastModel<AdminPrivileges>();
        StorageQuotaBytes = model.StorageQuotaBytes;
        SoftLimit = model.SoftLimit;
        StorageQuotaEmailNotification = model.StorageQuotaEmailNotification;
        ProjectKey = model.ProjectKey;
    }

    /// <summary>
    /// Gets the display name of the project.
    /// </summary>
    public string? DisplayName { get; }

    /// <summary>
    /// Gets the description of the project.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets the administrative privileges associated with the project.
    /// </summary>
    public AdminPrivileges? AdminPrivileges { get; }

    /// <summary>
    /// Gets the storage quota allocated to the project, in bytes.
    /// </summary>
    public long? StorageQuotaBytes { get; }

    /// <summary>
    /// Gets a value indicating whether the project has a soft limit for storage usage.
    /// </summary>
    public bool? SoftLimit { get; }

    /// <summary>
    /// Gets a value indicating whether email notifications are enabled for storage quota limits.
    /// </summary>
    public bool? StorageQuotaEmailNotification { get; }

    /// <summary>
    /// Gets the unique key of the project.
    /// </summary>
    public string? ProjectKey { get; }
}
