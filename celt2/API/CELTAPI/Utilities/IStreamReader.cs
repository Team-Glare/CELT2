using System.IO;

namespace CELTAPI.Utilities
{
    /// <summary>
    /// Interface for stream reader.
    /// </summary>
    public interface IStreamReader
    {
        StreamReader GetReader(Stream inputStream);
    }
}
