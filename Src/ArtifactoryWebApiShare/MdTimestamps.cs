namespace ArtifactoryWebApi;

/// <summary>
/// Represents metadata timestamps associated with a file or folder.
/// </summary>
public class MdTimestamps
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MdTimestamps"/> class.
    /// </summary>
    /// <param name="model">The model containing the metadata timestamps.</param>
    internal MdTimestamps(MdTimestampsModel model)
    {
        Properties = model.Properties;
    }

    /// <summary>
    /// Gets the timestamp of the metadata properties.
    /// </summary>
    public DateTime? Properties { get; }
}
