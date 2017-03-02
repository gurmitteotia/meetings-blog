using System.Collections.Generic;
using System.IO;
using Castle.Core.Internal;

namespace MeetingBlog.OOP.Appraoch2
{
    public class MeetingFile
    {
        private readonly IEnumerable<Meeting> _meetings;
        private MeetingFile(IEnumerable<Meeting> meetings)
        {
            _meetings = meetings;
        }
        public static MeetingFile Parse(string path, FileFormat fileFormat)
        {
            using (var fileReader = new StreamReader(File.OpenRead(path)))
                return new MeetingFile(fileFormat.ParseFrom(fileReader));
        }
        public void ScheduleIn(Calendar calendar)
        {
            _meetings.ForEach(calendar.Schedule);
        }
    }
}