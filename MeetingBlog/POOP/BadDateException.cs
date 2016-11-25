using System;

namespace MeetingBlog.POOP
{
    public class BadDateException : Exception
    {
        public BadDateException(string message) :base(message)
        {
        }
    }
}