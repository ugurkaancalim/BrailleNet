
namespace BrailleNet.Core.Interfaces
{
    public interface ITextConverter
    {   
        /// <summary>
        /// this method loads a language pack
        /// </summary>
        /// <param name="packPath"></param>
        /// <exception cref="NotImplementedException"></exception>
        void LoadLanguagePack(string packPath);
        /// <summary>
        /// this method converts text to braille alphabet or braille alphabet to text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        string Convert(string text);
    }
}
