using System.IO;

namespace lab_13
{
    public class SESDirInfo
    {
        public static string GetDirInfo(string filePath)
        {
            var dirInfo = new DirectoryInfo(filePath);
            var fullInfo = "";
            fullInfo += $"Name: {dirInfo.Name}\n";
            fullInfo += $"  File full path: {dirInfo.FullName}\n";
            fullInfo += $"  Number of files: {dirInfo.GetFiles().Length}\n";
            fullInfo += $"  number of directories: {dirInfo.GetDirectories().Length}\n";
            fullInfo += $"  Parent: {dirInfo.Parent}\n";
            
            return fullInfo;
        }
    }
}