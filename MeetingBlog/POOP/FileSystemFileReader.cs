using System.Collections.Generic;
using System.IO;

namespace MeetingBlog.POOP
{
    public class FileSystemFileReader : IFileReader
    {
        public IEnumerable<string> ReadData(string filePath)
        {
            return File.ReadLines(filePath);
        }
    }
}