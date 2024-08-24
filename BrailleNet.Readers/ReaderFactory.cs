using BrailleNet.Readers.Interfaces;
using BrailleNet.Readers.Strategies;
namespace BrailleNet.Readers
{
    public static class ReaderFactory
    {
        static Dictionary<string, IReaderStrategy> readerStrategies = new Dictionary<string, IReaderStrategy>() {
            {"pdf", new PdfReadStrategy() },
            {"txt", new TxtReadStrategy() },
            {"doc", new WordReadStrategy() }
        };

        public static IReaderStrategy CreateStrategy(string extension)
        {
            extension = extension.ToLower().Substring(1);
            if (readerStrategies.TryGetValue(extension, out var requestedReaderStrategy))
                return requestedReaderStrategy;
            else
                throw new Exception("Read strategy not found!");
        }
    }
}
