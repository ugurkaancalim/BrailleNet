using BrailleNet.Readers.Interfaces;
using BrailleNet.Readers.Strategies;
namespace BrailleNet.Readers
{
    public static class ReaderFactory
    {

        public static IReaderStrategy CreateStrategy(string extension)
        {
            extension = extension.ToLower().Substring(1);
            if (extension == "pdf")
                return new PdfReadStrategy();
            else if (extension == "txt")
                return new TxtReadStrategy();
            else
                throw new Exception("Read strategy not found!");
        }
    }
}
