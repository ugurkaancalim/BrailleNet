﻿using BrailleNet.Core.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrailleNet.Core.Interfaces
{
    public interface ILanguageImporter
    {
        List<CharacterStructure> Import(string path);
    }
}
