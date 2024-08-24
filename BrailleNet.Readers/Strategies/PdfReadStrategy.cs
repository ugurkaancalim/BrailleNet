using BrailleNet.Readers.Interfaces;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf;
using System.Reflection.PortableExecutable;

namespace BrailleNet.Readers.Strategies
{
    public class PdfReadStrategy : IReaderStrategy, IDisposable
    {
        private PdfDocument? pdfDoc;
        private int currentPage = 1;
        private StringReader? currentReader;
        private PdfReader? pdfReader;
        public void Dispose()
        { 
            // Dispose of managed resources
            currentReader?.Dispose();
            pdfDoc?.Close(); // Closes the document and disposes of the reader
            pdfReader?.Close();

            // Nullify references to enable garbage collection
            currentReader = null;
            pdfDoc = null;
            pdfReader = null;
        }

        public bool Load(string filePath)
        {
            try
            {
                pdfReader = new PdfReader(filePath);
                pdfDoc = new PdfDocument(pdfReader);
                currentPage = 1;
                currentReader = null;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string? ReadLine()
        {
            while (pdfDoc != null && currentPage <= pdfDoc.GetNumberOfPages())
            {
                // If we don't have a current reader or it's exhausted, move to the next page
                if (currentReader == null || currentReader.Peek() == -1)
                {
                    string text = ExtractTextFromPage(currentPage);
                    currentReader = new StringReader(text);
                    currentPage++;
                }

                // Read the next line from the current reader
                string? line = currentReader?.ReadLine();
                if (line != null)
                {
                    return line;
                }
            }
            return null; //End of PDF
        }

        private string ExtractTextFromPage(int pageNumber)
        {
            if (pdfDoc == null) return string.Empty;

            ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
            return PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(pageNumber), strategy);
        }
    }
}
