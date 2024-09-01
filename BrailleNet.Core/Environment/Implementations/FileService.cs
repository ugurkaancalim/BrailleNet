using BrailleNet.Core.Environment.Interfaces;
using BrailleNet.Core.Extensions;
using BrailleNet.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrailleNet.Core.Environment.Implementations
{
    public class FileService : IFileService
    {
        private readonly string wwwroot;
        public FileService()
        {
            wwwroot = Path.GetFullPath("wwwroot");
        }
        public string StoreFile(byte[] formFile, string formFileName, out string newFileName,out string newFileUrl, FileFormat fileFormat)
        {
            newFileUrl = "files/generated-files/" + Guid.NewGuid().ToString("N");
            newFileName = Path.Combine(wwwroot, newFileUrl);
            newFileUrl += fileFormat.ToExtensionString();
            var formFilePath = Path.Combine(wwwroot, "files/original-files/" + Guid.NewGuid().ToString("N") + Path.GetExtension(formFileName));
            File.WriteAllBytes(formFilePath, formFile);
            return formFilePath;
        }
    }
}
