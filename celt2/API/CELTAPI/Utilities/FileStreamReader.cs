using System.IO;

namespace CELTAPI.Utilities
{
    public class FileStreamReader : IStreamReader
    {
        public StreamReader GetReader(Stream inputStream)
        {
            return new StreamReader(inputStream);
        }
    }
}