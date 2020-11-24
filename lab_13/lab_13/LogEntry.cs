using System;
using System.IO;

namespace lab_13
{
    public class LogEntry
    {
        public DateTime Date { get; private set; }
        public string Action { get; private set; }
        public string ActionPath { get; private set; }

        public LogEntry(DateTime date, string action, string actionPath)
        {
            Date = date;
            Action = action;
            ActionPath = actionPath;
        }

        public override string ToString()
        {
            return $"[{Date}] {Action} {ActionPath}";
        }
    }
}