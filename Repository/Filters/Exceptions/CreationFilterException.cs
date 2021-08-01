using System;

namespace Snippet.Data.Filters.Exceptions
{
    public class CreationFilterException : Exception
    {
        public CreationFilterException(string msg) : base(msg) { }
    }
}
