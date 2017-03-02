using System.Collections.Generic;
using System.IO;

namespace MeetingBlog.OOP.Appraoch2
{
    internal static class StreamReaderExtension
    {
        public static IEnumerable<string> ReadAllLines(this StreamReader reader)
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
}