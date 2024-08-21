using BrailleNet.Core.DataStructure;
using BrailleNet.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrailleNet.Core.Implementations
{
    public class LanguageImporter : ILanguageImporter
    {
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
                    Character = data[0],
                    BrailleCharacter = data[1]
                });
            }
            return result;
        }
    }
}
