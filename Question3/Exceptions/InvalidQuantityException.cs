using System;

namespace Question3.Exceptions
{
    public class InvalidQuantityException : Exception
    {
        public InvalidQuantityException(string message) : base(message) { }
    }
}
