using System.IO;

namespace CELTAPI.Utilities
{
    /// <summary>
    /// File stream reader which implements IStreamReader
    /// </summary>
    public class FileStreamReader : IStreamReader
    {
        /// <summary>
        /// Method for getting a StreamReader.
        /// </summary>
        /// <param name="inputStream">Stream input.</param>
        /// <returns>An instance of StreamReader with the inputted Stream.</returns>
        public StreamReader GetReader(Stream inputStream)
        {
            return new StreamReader(inputStream);
        }
    }
}
