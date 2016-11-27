using System.Collections.Generic;

namespace MeetingBlog.POOP
{
    //inteface to read data from any file
    internal interface IFileReader
    {
        IEnumerable<string> ReadData(string filePath);
    }
}