using System;

namespace lab_5
{
    public class CaptainAgeException : ArgumentException
    {
        public override string Message { get; } = "Incorrect captain age value!";

        public CaptainAgeException(string message) : base(message)
        {
            
        }

        public CaptainAgeException()
        {
            
        }
    }
}