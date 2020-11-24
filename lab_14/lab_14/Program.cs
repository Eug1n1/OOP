using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using lab_13;
using Newtonsoft.Json;

namespace lab_14
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = new LogEntry("gjbsdkjb", "name");
            var path = "/home/eug1n1/log.dat";
            LabMethods.BinarySerializer(path, log);
            
            path = "/home/eug1n1/log.json";
            LabMethods.JsonSerializer(path, log);
            
            path = "/home/eug1n1/log.xml";
            LabMethods.XmlSerializer(path, log);
        }
    }
}