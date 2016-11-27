using System.Collections.Generic;

namespace MeetingBlog.POOP
{
    //interface to read meetings from file
    internal interface IMeetingFileParser
    {
        IEnumerable<Meeting> ParseMeetings(string filePath);
    }
}