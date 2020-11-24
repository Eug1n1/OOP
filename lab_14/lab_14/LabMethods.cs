using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using lab_13;
using Newtonsoft.Json;

namespace lab_14
{
    public static class LabMethods
    {
        public static void BinarySerializer(string path, LogEntry log)
        {
            var formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, log);
            }
        }

        public static LogEntry BinaryDeserializer(string path)
        {
            var formatter = new BinaryFormatter();

            var fs = new FileStream(path, FileMode.OpenOrCreate);
            var log = (LogEntry) formatter.Deserialize(fs);
            fs.Dispose();

            return log;
        }

        public static void JsonSerializer(string path, LogEntry log)
        {
            string output = JsonConvert.SerializeObject(log);

            using (var sw = new StreamWriter(path))
            {
                sw.Write(output);
            }
        }

        public static LogEntry JsonDeserializer(string path)
        {
            var sr = new StreamReader(path);
            var output = sr.ReadToEnd();
            sr.Dispose();

            return JsonConvert.DeserializeObject<LogEntry>(output);
        }

        public static void XmlSerializer(string path, LogEntry log)
        {
            var formatter = new XmlSerializer(typeof(LogEntry));
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, log);
            }
        }

        public static LogEntry XmlDeserializer(string path)
        {
            var formatter = new XmlSerializer(typeof(LogEntry));

            var fs = new FileStream(path, FileMode.OpenOrCreate);
            var log = (LogEntry) formatter.Deserialize(fs);
            fs.Dispose();

            return log;
        }
    }
}