using System;

namespace MeetingBlog.OOP
{
    /*
     * For the purpose of this tutorial following class is just a DTO, which does not have any behaviour.
     * In real world it can be a domain entity with behaviour, and you might not have setter (and some getter) properties as they exists now.
    */
    public struct Meeting
    {
        public string Name { get; set; }
        public string Organiser { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}