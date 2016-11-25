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
                    return new Meeting
                    {
                        Name = meeting[0],
                        Organiser = meeting[1],
                        Date = ParseDate(meeting[2]),
                        StartTime = ParseDate(meeting[3]),
                        EndTime = ParseDate(meeting[4])
                    };
                }
            }
            private DateTime ParseDate(string date)
            {
                DateTime parsedDate;
                if(DateTime.TryParse(date, out parsedDate))
                    return parsedDate;

                throw new BadDateException($"Can not parse date {date} from line {_line}");
            }
        }
    }
}