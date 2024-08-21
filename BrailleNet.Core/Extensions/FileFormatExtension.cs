using BrailleNet.Core.Types;

namespace BrailleNet.Core.Extensions
{
    public static class FileFormatExtension
    {
        public static string ToExtensionString(this FileFormat fileFormat)
        {
            switch (fileFormat)
            {
                case FileFormat.Txt:
                    return ".txt";
                case FileFormat.Brf:
                    return ".brf";
                case FileFormat.Brl:
                    return ".brl";
                case FileFormat.Pef:
                    return ".pef";
                case FileFormat.Dxb:
                    return ".dxb";
                case FileFormat.Abt:
                    return ".abt";
                case FileFormat.Utb:
                    return ".utb";
                default:
                    return ".undefined";
            }
        }
    }
}
