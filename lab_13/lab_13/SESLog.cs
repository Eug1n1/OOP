using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace lab_13
{
    // ReSharper disable once InconsistentNaming
    public class SESLog
    {
        private string _path =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "logfile.txt");

        public string LogfilePath
        {
            get => _path;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"LogfilePath", "Path mustn't be null");
                }

                if (Path.EndsInDirectorySeparator("value"))
                {
                    throw new ArgumentException("The file name must be presented in the path");
                }

                _path = value;
            }
        }

        public SESLog()
        {
        }

        public SESLog(string path)
        {
            LogfilePath = path;
        }

        public void WriteLog(string action, string path)
        {
            string output = JsonConvert.SerializeObject(new LogEntry(DateTime.Now, action, path));

            var sw = new StreamWriter(LogfilePath, true);
            sw.Write(output + "\n");
            sw.Dispose();
        }

        public void WriteLog(IEnumerable<LogEntry> logs)
        {
            var sw = new StreamWriter(LogfilePath, true);
            var output = "";
            foreach (var log in logs)
            {
                output = JsonConvert.SerializeObject(log);
                sw.Write(output + "\n");
            }

            sw.Dispose();
        }

        public List<LogEntry> ReadLog()
        {
            var logList = new List<LogEntry>();
            var sr = new StreamReader(LogfilePath);
            while (!sr.EndOfStream)
            {
                logList.Add(
                    JsonConvert.DeserializeObject<LogEntry>(sr.ReadLine() ?? throw new InvalidOperationException()));
            }

            sr.Dispose();

            return logList;
        }

        public IEnumerable<LogEntry> DateSearch(DateTime date)
        {
            var logList = ReadLog();

            return logList.Where(x => x.Date == date);
        }

        public IEnumerable<LogEntry> ActionSearch(string action)
        {
            var logList = ReadLog();

            return logList.Where(x => x.Action == action);
        }

        public IEnumerable<LogEntry> PathSearch(string path)
        {
            var logList = ReadLog();

            return logList.Where(x => x.ActionPath == path);
        }

        public void ClearLog()
        {
            var sw = new StreamWriter(_path);
            sw.Write("");
            sw.Dispose();
        }
    }
}