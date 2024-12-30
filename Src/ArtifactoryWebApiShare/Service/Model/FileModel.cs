namespace ArtifactoryWebApi.Service.Model
{
    [DebuggerDisplay("{Uri}, IsFolder: {Folder}")]
    internal class FileModel
    {
        // not a uri only "/folder/file.xxx"
        [JsonPropertyName("uri")]
        public string? Uri { get; set; }

        [JsonPropertyName("size")]
        public long? Size { get; set; }

        [JsonPropertyName("lastModified")]
        public DateTime? LastModified { get; set; }

        [JsonPropertyName("folder")]
        public bool Folder { get; set; }

        [JsonPropertyName("sha1")]
        public string? Sha1 { get; set; }

        [JsonPropertyName("sha2")]
        public string? Sha2 { get; set; }

        [JsonPropertyName("mdTimestamps")]
        public MdTimestampsModel? MdTimestamps { get; set; }
    }
}
