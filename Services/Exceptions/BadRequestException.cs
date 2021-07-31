using System;


namespace Snippet.BLL.Exceptions
{
    public class BadRequestException : Exception 
    {
        public BadRequestException(string message):base(message)
        {
           
        }
    }
}
