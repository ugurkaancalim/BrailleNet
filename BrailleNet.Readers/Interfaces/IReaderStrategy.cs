
namespace BrailleNet.Readers.Interfaces
{
    public interface IReaderStrategy
    {
        bool Load(string filePath);
        string? ReadLine();
    }
}
