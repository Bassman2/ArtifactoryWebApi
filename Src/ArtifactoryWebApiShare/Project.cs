namespace ArtifactoryWebApi;

public class Project
{
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
    public string? DisplayName { get; }

    public string? Description { get; }

    public AdminPrivileges? AdminPrivileges { get; }

    public long? StorageQuotaBytes { get; }

    public bool? SoftLimit { get; }

    public bool? StorageQuotaEmailNotification { get; }

    public string? ProjectKey { get; }
}
