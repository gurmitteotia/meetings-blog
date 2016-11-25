using System;

namespace MeetingBlog.OOP
{
    public class BadDateException : Exception
    {
        public BadDateException(string message) :base(message)
        {
        }
    }
}