using System;

namespace MeetingBlog.POOP
{
    internal class BadDateException : Exception
    {
        public BadDateException(string message) :base(message)
        {
        }
    }
}