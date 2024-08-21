using BrailleNet.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrailleNet.Core.Implementations.Converters
{
    public class BrailleToTextConverter : ITextConverter
    {
        /// <summary>
        /// This method converts braille text to plain text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string Convert(string text)
        {
            throw new NotImplementedException();
        }

        public void LoadLanguagePack(string packPath)
        {

            throw new NotImplementedException();
        }
    }
}
