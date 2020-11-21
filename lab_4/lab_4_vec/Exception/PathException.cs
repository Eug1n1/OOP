using System;

namespace lab_5
{
    public class PathException : Exception
    {
        public override string Message { get; } = "Path must include file name";

        public PathException(string message) : base(message)
        {
        }

        public PathException()
        {
        }
    }
}