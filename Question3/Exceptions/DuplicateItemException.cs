using System;

namespace Question3.Exceptions
{
    public class DuplicateItemException : Exception
    {
        public DuplicateItemException(string message) : base(message) { }
    }
}
