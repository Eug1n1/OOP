using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Sockets;

namespace lab_13
{
    // ReSharper disable once InconsistentNaming
    public static class SESFileManager
    {
        private static SESLog logger;

        static SESFileManager()
        {
            logger = new SESLog();
        }
        
        public static IEnumerable<FileSystemInfo> GetFileSystemInfo(string driverName)
        {
            var allDrives = DriveInfo.GetDrives();
            List<FileSystemInfo> all = new List<FileSystemInfo>();
            var a = allDrives.Where(x => x.Name == driverName).Take(1);
            foreach (var e in a)
            {
                all.AddRange(new DirectoryInfo(e.RootDirectory.FullName).GetFiles("*.*", SearchOption.AllDirectories));
                all.AddRange(
                    new DirectoryInfo(e.RootDirectory.FullName).GetDirectories("*.*", SearchOption.AllDirectories));
                Console.WriteLine(
                    $"Files: {Directory.GetFiles(e.RootDirectory.FullName, "*.*", SearchOption.AllDirectories).Length}");
                Console.WriteLine(
                    $"Directories: {Directory.GetDirectories(e.RootDirectory.FullName, "", SearchOption.AllDirectories).Length}");
            }

            return all;
        }

        public static void CreateDirectory(string path)
        {
            if(new DirectoryInfo(path).Exists)
                throw new Exception($"{path} directory alrady exist");
                
            Directory.CreateDirectory(path);
            logger.WriteLog("Create directory", path);
        }

        public static void CreateFile(string path, string input = "")
        {
            using (var sw = new StreamWriter(path))
            {
                sw.Write(input);
            }
            logger.WriteLog("Create file", path);
        }

        public static void Copy(string filePath, string copyPath, bool overrideFile = false)
        {
            File.Copy(filePath, copyPath, overrideFile);
            logger.WriteLog("Copy file", copyPath);
        }

        public static void Delete(string filePath)
        {
            File.Delete(filePath);
            logger.WriteLog("Delete file", filePath);
        }

        public static void Replace(string sourcePath, string destinationPath, string destinationBackupFileName = "",
            bool ignoreErrors = false)
        {
            File.Replace(sourcePath, destinationPath, destinationBackupFileName, ignoreErrors);
            logger.WriteLog("Replace file", destinationPath);
        }

        public static void ReplaceDir(string sourcePath, string destinationPath)
        {
            Directory.Move(sourcePath, destinationPath);
            logger.WriteLog("Replace directory", destinationPath);
        }

        public static void CopyRange(string dirPath, FileInfo[] files, string extension, bool overrideFiles = false)
        {
            foreach (var file in files.Where(x => x.Extension == extension))
            {
                File.Copy(file.FullName, Path.Combine(dirPath, file.Name), overrideFiles);
            }
            
            logger.WriteLog("Copy files from path", dirPath);
        }

        public static void Rename(string filePath, string newFileName)
        {
            var newPath = filePath.Replace(Path.GetFileName(filePath), newFileName);

            File.Copy(filePath, newFileName);
            
            logger.WriteLog("Rename", filePath);
        }

        public static void CompressDir(string dirPath, string zipPath)
        {
            ZipFile.CreateFromDirectory(dirPath, zipPath);
            logger.WriteLog("Archive directory", dirPath);
        }

        public static void ExtractDir(string zipPath, string extractPath)
        {
            ZipFile.ExtractToDirectory(zipPath, extractPath);
            logger.WriteLog("Unarchive directory", zipPath);
        }
    }
}