using System;

namespace MeetingBlog.OOP
{
    public class Meeting
    {
        public Meeting(string name, string organiser, DateTime date, DateTime startTime, DateTime endTime)
        {
            Name = name;
            Organiser = organiser;
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
        }

        public string Name { get; private set; }

        public string Organiser { get; private set; }

        public DateTime Date { get; private set; }

        public DateTime StartTime { get; private set; }

        public DateTime EndTime { get; private set; }
    }
}