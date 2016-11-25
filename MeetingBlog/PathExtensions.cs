using System;
using System.IO;

namespace MeetingBlog
{
    public static class PathExtensions
    {
        public static string ToAbsolutePath(this string path)
        {
            string absolutePath = path;

            if (!Path.IsPathRooted(path))
            {
                var applicationDirectory = AppDomain.CurrentDomain.BaseDirectory;
                absolutePath = Path.Combine(applicationDirectory, path);
            }

            return absolutePath;
        }
    }
}