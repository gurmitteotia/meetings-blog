using System.Collections.Generic;
using MeetingBlog.OOP;

namespace MeetingBlog.POOP
{
    public interface IMeetingFileParser
    {
        IEnumerable<Meeting> ParseMeetings(string filePath);
    }
}