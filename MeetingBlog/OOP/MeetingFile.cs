using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Castle.Core.Internal;


namespace MeetingBlog.OOP
{
    public class MeetingFile
    {
        private readonly IEnumerable<Meeting> _meetings;
        private MeetingFile(IEnumerable<Meeting> meetings)
        {
            _meetings = meetings;
        }
        public static MeetingFile Csv(string path)
        {
            var meetingLines = File.ReadAllLines(path).Skip(1).Select(line => new MeetingLine(line));
            return new MeetingFile(meetingLines.Select(ml=>ml.Meeting).ToArray());
        }

        public void ScheduleIn(Calendar calendar)
        {
            _meetings.ForEach(calendar.Schedule);
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
                DateTime parsedDate;
                if(DateTime.TryParse(date, out parsedDate))
                    return parsedDate;

                throw new BadDateException(string.Format("Can not parse date {0} from line {1}",date,_line));
            }
        }
    }
}