using System;

namespace MeetingBlog.POOP
{
    internal class Meeting
    {
        public string Name { get; set; }
        public string Organiser { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}