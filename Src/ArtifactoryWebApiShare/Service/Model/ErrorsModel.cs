namespace ArtifactoryWebApi.Service.Model;

internal class ErrorsModel
{
    [JsonPropertyName("errors")]
    public List<ErrorModel>? Errors { get; set; }

    public override string ToString()
    {
        return Errors?.Select(e => $"{e.Status} {e.Message}").Aggregate("", (a,b) => $"{a}, {b}") ?? string.Empty;
    }
}
