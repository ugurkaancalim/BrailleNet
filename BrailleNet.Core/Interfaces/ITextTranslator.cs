using BrailleNet.Core.Types;

namespace BrailleNet.Core.Interfaces
{
    public interface ITextTranslator
    {
        /// <summary>
        /// this method translates a text to braille or a braille to text and saves to a file
        /// </summary>
        /// <param name="filePath">Path of text file</param>
        /// <param name="newFilePath">Path of new file</param>
        /// <param name="fileFormat">Format of new file</param>
        /// <returns></returns>
        bool Translate(string filePath, string newFilePath, FileFormat fileFormat);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath">Path of text file</param>
        /// <returns></returns>
        string Translate(string filePath);
    }
}
