using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrailleNet.Readers.Interfaces
{
    public interface IReaderStrategy
    {
        bool Load(string filePath);
        string? Readline();
    }
}
