namespace ArtifactoryWebApi;

public class MdTimestamps
{
    internal MdTimestamps(MdTimestampsModel model)
    {
        Properties = model.Properties;
    }

    public DateTime? Properties { get; }

}
