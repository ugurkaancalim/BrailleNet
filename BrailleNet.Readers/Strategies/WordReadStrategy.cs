using BrailleNet.Readers.Interfaces;
using DocumentFormat.OpenXml.Packaging;


namespace BrailleNet.Readers.Strategies
{
    public class WordReadStrategy : IReaderStrategy, IDisposable
    {
        private WordprocessingDocument? wordDoc;
        private IEnumerator<string>? lineEnumerator;

        public bool Load(string filePath)
        {
            try
            {
                wordDoc = WordprocessingDocument.Open(filePath, false);
                string text = ExtractText();
                lineEnumerator = (IEnumerator<string>?)text.Split('\n').GetEnumerator();
                return true;
            }
            catch (Exception)
            {
                Dispose(); // Ensure cleanup on failure
                return false;
            }
        }

        public string? ReadLine()
        {
            return lineEnumerator?.MoveNext() == true ? lineEnumerator.Current : null;
        }

        private string ExtractText()
        {
            if (wordDoc == null) return string.Empty;
            var body = wordDoc.MainDocumentPart?.Document.Body;
            return body?.InnerText ?? string.Empty;
        }

        public void Dispose()
        {
            // Dispose of managed resources
            wordDoc?.Dispose();
            wordDoc = null;
            lineEnumerator = null;
        }
    }
}
