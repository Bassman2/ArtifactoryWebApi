namespace ArtifactoryWebApi.Model;

internal class ProjectModel
{
    [JsonPropertyName("display_name")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("admin_privileges")]
    public AdminPrivilegesModel? AdminPrivileges { get; set; }

    [JsonPropertyName("storage_quota_bytes")]
    public long? StorageQuotaBytes { get; set; }

    [JsonPropertyName("soft_limit")]
    public bool? SoftLimit { get; set; }

    [JsonPropertyName("storage_quota_email_notification")]
    public bool? StorageQuotaEmailNotification { get; set; }

    [JsonPropertyName("project_key")]
    public string? ProjectKey { get; set; }
}
