using System;

namespace MeetingBlog.OOP
{
    /*
     * For the purpose of this tutorial following class is just a DTO, which does not have any behaviour. In real world it might a domain entity with behaviour.
    */
    public struct Meeting
    {
        private readonly string _name;
        private readonly string _organiser;
        private readonly DateTime _date;
        private readonly DateTime _startTime;
        private readonly DateTime _endTime;
        
        public Meeting(string name, string organiser, DateTime date, DateTime startTime, DateTime endTime)
        {
            _name = name;
            _organiser = organiser;
            _date = date;
            _startTime = startTime;
            _endTime = endTime;
        }
    }
}