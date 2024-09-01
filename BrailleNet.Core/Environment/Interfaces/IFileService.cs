using BrailleNet.Core.Types;
using iText.Forms.Form.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrailleNet.Core.Environment.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// Uploads file and returns file path and generates a new filename for result.
        /// </summary>
        /// <param name="formFile">uploading file content in bytes.</param>
        /// <param name="formFileName">uploading files' name</param>
        /// <param name="newFileName">name of the new generating file. It's an out parameter</param>
        /// <param name="newFileFormat">extension format of new generating file.</param>
        /// <param name="newFileFormat">Url of generating file.</param>
        /// <param name="fileFormat">format of the generating file.</param>
        /// <returns>The path of the stored file.</returns>
        string StoreFile(byte[] formFile, string formFileName, out string newFileName, out string newFileUrl,FileFormat fileFormat);
    }

}
