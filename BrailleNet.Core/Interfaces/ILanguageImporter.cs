using BrailleNet.Core.DataStructure;

namespace BrailleNet.Core.Interfaces
{
    public interface ILanguageImporter
    {
        List<CharacterStructure> Import(string path);
    }
}
