using System;
using System.IO;

namespace lab_13
{
    [Serializable]
    public class LogEntry
    {
        public DateTime Date { get; set; }
        public string Action { get; set; }

        [NonSerialized] public string uselessField = "182731923";

        public LogEntry()
        {
        }

        public LogEntry(string action, string name)
        {
            Date = DateTime.Now;
            Action = action;
            uselessField = name;
        }

        public LogEntry(DateTime date, string action)
        {
            Date = date;
            Action = action;
        }

        public override string ToString()
        {
            return $"[{Date}] {Action}";
        }
    }
}