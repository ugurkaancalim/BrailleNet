using BrailleNet.Core.DataStructure;
using BrailleNet.Core.Interfaces;

namespace BrailleNet.Core.Implementations.Importers
{
    public class LanguageImporter : ILanguageImporter
    {
        /// <summary>
        /// This method takes a path of language file and returns characterset of language
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<CharacterStructure> Import(string path)
        {
            var text = File.ReadAllText(path);
            var characters = text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            var result = new List<CharacterStructure>();
            foreach (var character in characters)
            {
                var data = character.Split('$');
                result.Add(new CharacterStructure()
                {
                    Character = data[0].ToLower()[0],
                    BrailleCharacter = data[1][0]
                });
            }
            return result;
        }
    }
}
