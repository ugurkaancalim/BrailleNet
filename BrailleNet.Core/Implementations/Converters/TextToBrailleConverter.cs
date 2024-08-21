using BrailleNet.Core.DataStructure;
using BrailleNet.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrailleNet.Core.Implementations.Converters
{
    public class TextToBrailleConverter : ITextConverter
    {
        private readonly ILanguageImporter _languageImporter;
        private List<CharacterStructure> characters;
        public TextToBrailleConverter(ILanguageImporter languageImporter)
        {
            _languageImporter = languageImporter;
        }
        /// <summary>
        /// this method converts plain text to braille text.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string Convert(string text)
        {
            text = text.ToLower();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != ' ')
                {
                    var braille = characters.SingleOrDefault(x => x.Character == text[i]);
                    sb.Append(braille != null ? braille.ToString() : "?");
                }
                else
                {
                    sb.Append(" ");
                }
            }

            return sb.ToString();
        }

        public void LoadLanguagePack(string packPath)
        {
            characters = _languageImporter.Import(packPath);
        }
    }
}
