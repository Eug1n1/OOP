using System;

namespace lab_5
{
    public class HarborNullException : NullReferenceException
    {
        public string Message { get; set; } = "Harbor should be defined";

        public HarborNullException()
        {
            
        }
        public HarborNullException(string message) : base (message)
        {
            Message = message;
        }
    }
}