namespace ArtifactoryWebApi.Model;

internal class AdminPrivilegesModel
{
    [JsonPropertyName("manage_members")]
    public bool? ManageMembers { get; set; }

    [JsonPropertyName("manage_resources")]
    public bool? ManageResources { get; set; }

    [JsonPropertyName("index_resources")]
    public bool? IndexResources { get; set; }
}
