using System.Collections.Generic;
using System.IO;

namespace MeetingBlog.POOP
{
    internal class FileSystemFileReader : IFileReader
    {
        public IEnumerable<string> ReadData(string filePath)
        {
            return File.ReadLines(filePath);
        }
    }
}