using BrailleNet.Core.Extensions;
using BrailleNet.Core.Interfaces;
using BrailleNet.Core.Types;
using BrailleNet.Readers;
using System.Text;

namespace BrailleNet.Core.Implementations.Translators
{
    public class TextTransator : ITextTranslator
    {
        private readonly ITextConverter _textConverter;
        private readonly ILanguageImporter _languageImporter;
        public TextTransator(ITextConverter textConverter, ILanguageImporter languageImporter)
        {
            _textConverter = textConverter;
            _languageImporter = languageImporter;
            _textConverter.LoadLanguagePack(@"C:\Users\ugurc\source\repos\BrailleNet\BrailleNet.WebApp\wwwroot\language-packs\tr.bnet");//TODO get languagecode from user.
        }
        public bool Translate(string filePath, string newFilePath, FileFormat fileFormat)
        {
            var extension = Path.GetExtension(filePath);
            var readerStrategy = ReaderFactory.CreateStrategy(extension);
            readerStrategy.Load(filePath);
        
            // Create a StreamWriter instance
            using (StreamWriter writer = new StreamWriter(newFilePath + fileFormat.ToExtensionString()))
            {
                string? text;
                while ((text = readerStrategy.ReadLine()) != null)
                {
                    var convertedText = _textConverter.Convert(text);
                    writer.WriteLine(convertedText);
                }
            }
            return true;
        }

        public string Translate(string filePath)
        {
            var responseText = new StringBuilder();
            var extension = Path.GetExtension(filePath);
            var readerStrategy = ReaderFactory.CreateStrategy(extension);
            readerStrategy.Load(filePath);
            string? text;
            while ((text = readerStrategy.ReadLine()) != null)
            {
                var convertedText = _textConverter.Convert(text);
                responseText.AppendLine(convertedText);
            }
            return responseText.ToString();
        }
    }
}