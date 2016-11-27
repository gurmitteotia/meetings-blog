namespace MeetingBlog.POOP
{
    internal class MeetingFileScheduler
    {
        private readonly IMeetingFileParser _meetingFileParser;
        private readonly Calendar _calendar;

        public MeetingFileScheduler(IMeetingFileParser meetingFileParser, Calendar calendar)
        {
            _meetingFileParser = meetingFileParser;
            _calendar = calendar;
        }

        public void ScheduleFrom(string meetingfile)
        {
            var meetings = _meetingFileParser.ParseMeetings(meetingfile);
            foreach (var meeting in meetings)
            {
                _calendar.Schedule(meeting);
            }
        }
    }
}