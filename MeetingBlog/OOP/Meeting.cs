using System;

namespace MeetingBlog.OOP
{
    /*
     * For the purpose of this tutorial following class is just a DTO, which does not have any behaviour. In real world it might a domain entity with behaviour.
    */
    public struct Meeting
    {
        public string Name { get; }
        public string Organiser { get; }
        public DateTime Date { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }

        public Meeting(string name, string organiser, DateTime date, DateTime startTime, DateTime endTime)
        {
            Name = name;
            Organiser = organiser;
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}