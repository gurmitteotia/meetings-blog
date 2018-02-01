using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace MeetingBlog.OOP
{
    public class CsvMeetingFile
    {
        private readonly string _filePath;
        public CsvMeetingFile(string filePath)
        {
            _filePath = filePath;
        }
      
        public IEnumerable<Meeting> Meetings()
        {
            var meetingLines = File.ReadAllLines(_filePath).Skip(1).Select(line => new MeetingLine(line));
            return meetingLines.Select(l => l.Meeting).ToArray();
        }

        //This class can also exists outside and edge unit test cases can be written directly against it.
        private class MeetingLine
        {
            private readonly string _line;
            public MeetingLine(string line)
            {
                _line = line;
            }
            public Meeting Meeting
            {
                get
                {
                    var meeting = _line.Split(',');
                    return new Meeting(meeting[0], meeting[1], ParseDate(meeting[2]), ParseDate(meeting[3]), ParseDate(meeting[4]));
                }
            }
            private DateTime ParseDate(string date)
            {
                if (DateTime.TryParse(date, out var parsedDate))
                    return parsedDate;
                throw new BadDateException($"Can not parse date {date} from line {_line}");
            }
        }
    }
}