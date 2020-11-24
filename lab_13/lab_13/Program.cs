using System;
using System.IO;
using System.Linq;

namespace lab_13
{
    class Program
    {
        static void Main(string[] args)
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var dirPath = Path.Combine(desktopPath, "SESInspect");
            var filePath = Path.Combine(desktopPath, "SESInspect", "sesdirinfo.txt");
            var copyFilePath = Path.Combine(desktopPath, "SESInspect", "sesdirinfo_copy.txt");
            var dirPath2 = Path.Combine(desktopPath, "SESFiles");
            var dest = Path.Combine(dirPath, new DirectoryInfo(dirPath2).Name);
            var zip = Path.Combine(desktopPath, "Files.zip");
            var dir2 = Path.Combine(desktopPath, "unarchivedFiles");
            try
            {
                SESFileManager.CreateDirectory(dirPath);
                
                SESFileManager.CreateFile(filePath);
                
                SESFileManager.Copy(filePath, copyFilePath);

                SESFileManager.Delete(filePath);

                SESFileManager.CreateDirectory(dirPath2);

                SESFileManager.CopyRange(dirPath2, new DirectoryInfo("/home/eug1n1/Downloads/").GetFiles(), ".pdf");
                
                SESFileManager.ReplaceDir(dirPath2, dest);
                
                SESFileManager.CompressDir(dest, zip);
                
                SESFileManager.ExtractDir(zip, dir2);

                var logger = new SESLog();
                var logs = logger.ReadLog();

                foreach (var a in logs.Where(x => x.Date.Day == 15))
                {
                    Console.WriteLine(a.ToString());
                }

                foreach (var a in logs.Where(x => x.Action.Contains("Delete")))
                {
                    Console.WriteLine(a.ToString());
                }

                logger.ClearLog();

                logger.WriteLog(logs.Where(x => x.Action.Contains("Create")));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Directory.Delete(dirPath, true);
                File.Delete(zip);
                Directory.Delete(dir2, true);
            }
        }
    }
}