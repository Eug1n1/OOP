using System.IO;
using System.Reflection.PortableExecutable;

namespace lab_13
{
    public class MyDriverInfo
    {
        public string Name { get; private set; }
        public string DriverFormate { get; private set; }
        public long TotalSize { get; private set; }
        public long AvailableFreeSpace { get; private set; }

        public MyDriverInfo(DriveInfo info)
        {
            Name = info.Name;
            DriverFormate = info.DriveFormat;
            TotalSize = info.TotalSize;
            AvailableFreeSpace = info.AvailableFreeSpace;
        }

        public override string ToString()
        {
            return $"[{DriverFormate}]  {Name}\t[{AvailableFreeSpace}/{TotalSize}]";
        }
    }
}