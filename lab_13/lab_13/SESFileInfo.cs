using System.IO;

namespace lab_13
{
    public static class SESFileInfo
    {
        public static string GetFileInfo(string filePath)
        {
            var fileInfo = new FileInfo(filePath);

            string FullInfo = "";
            FullInfo += $"Name: {fileInfo.Name}\n";
            FullInfo += $"  File full path: {fileInfo.FullName}\n";
            FullInfo += $"  Size: {fileInfo.Length} bytes\n";
            FullInfo += $"  Extension: {fileInfo.Extension}\n";
            FullInfo += $"  Creation time: {fileInfo.CreationTime} bytes\n";
            FullInfo += $"  Last write Time: {fileInfo.LastWriteTime} bytes\n";
            
            return FullInfo;
        }
    }
}