using System;

namespace MeetingBlog.OOP
{
    public class Meeting
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

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Meeting)obj);
        }
        private bool Equals(Meeting other)
        {
            return string.Equals(_name, other._name) && string.Equals(_organiser, other._organiser) && _date.Equals(other._date) && _startTime.Equals(other._startTime) && _endTime.Equals(other._endTime);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _name.GetHashCode();
                hashCode = (hashCode * 397) ^ _organiser.GetHashCode();
                hashCode = (hashCode * 397) ^ _date.GetHashCode();
                hashCode = (hashCode * 397) ^ _startTime.GetHashCode();
                hashCode = (hashCode * 397) ^ _endTime.GetHashCode();
                return hashCode;
            }
        }
    }
}