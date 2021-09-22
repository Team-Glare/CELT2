using System.IO;

namespace CELTAPI.Utilities
{
    public interface IStreamReader
    {
        StreamReader GetReader(Stream inputStream);
    }
}