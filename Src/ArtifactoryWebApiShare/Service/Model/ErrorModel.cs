namespace ArtifactoryWebApi.Service.Model;

internal class ErrorModel
{
    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }
}
