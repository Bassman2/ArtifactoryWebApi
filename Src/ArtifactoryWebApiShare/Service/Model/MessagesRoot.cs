namespace ArtifactoryWebApi.Service.Model;

internal class MessagesRoot
{
    [JsonPropertyName("messages")]
    public List<MessageModel>? Messages { get; set; }
}
