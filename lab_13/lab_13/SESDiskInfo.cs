using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lab_13
{
    // ReSharper disable once InconsistentNaming
    public static class SESDiskInfo
    {
        public static string GetDriversInfo()
        {
            IEnumerable<DriveInfo> allDrives;
            if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                allDrives = DriveInfo.GetDrives().Where(x => x.Name == "/" || x.Name == "/home");
            }
            else
            {
                allDrives = DriveInfo.GetDrives();
            }
            
            string FullInfo = "";
            
            foreach (var d in allDrives)
            {
                FullInfo += $"Drive {d.Name}\n";
                FullInfo += $"  Drive type: {d.DriveType}\n";
                if (d.IsReady == true)
                {
                    FullInfo += $"  Volume label: {d.VolumeLabel}\n";
                    FullInfo += $"  File system: {d.DriveFormat}\n";
                    FullInfo += $"  Available space to current user:{d.AvailableFreeSpace} bytes\n";
                    FullInfo += $"  Total available space: {d.TotalFreeSpace} bytes\n";
                    FullInfo += $"  Total size of drive: {d.TotalSize} bytes\n";
                }
            }

            return FullInfo;
        }
    }
}