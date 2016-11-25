using System.Collections.Generic;

namespace MeetingBlog.POOP
{
    internal interface IFileReader
    {
        IEnumerable<string> ReadData(string filePath);
    }
}