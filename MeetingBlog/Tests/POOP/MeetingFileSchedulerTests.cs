using System;
using System.Collections.Generic;
using MeetingBlog.POOP;
using Moq;
using NUnit.Framework;

namespace MeetingBlog.Tests.POOP
{
    [TestFixture]
    public class MeetingFileSchedulerTests
    {
        private MeetingFileScheduler _meetingFileScheduler;
        private Mock<IMeetingFileParser> _meetingFileParser;
        private TestCalendar _calendar;
        private const string _file = "meetingFile";

        [SetUp]
        public void Setup()
        {
            _meetingFileParser = new Mock<IMeetingFileParser>();
            _calendar = new TestCalendar();
            _meetingFileScheduler = new MeetingFileScheduler(_meetingFileParser.Object, _calendar);
        }

        [Test]
        public void Scheduled_parsed_meeting_from_file_in_calender()
        {
            var parsedMeeting = new[]
            {
                new Meeting()
                {
                    Name = "oop",
                    Organiser = "someone",
                    Date = DateTime.Parse("29-10-2016"),
                    StartTime = DateTime.Parse("03:04:06"),
                    EndTime = DateTime.Parse("04:05:06")
                }
            };

            _meetingFileParser.Setup(p => p.ParseMeetings(_file)).Returns(parsedMeeting);

            _meetingFileScheduler.ScheduleFrom(_file);

            Assert.That(_calendar.ScheduledMeetings,Is.EquivalentTo(parsedMeeting));
        }

        private class TestCalendar : Calendar
        {
            public List<Meeting> ScheduledMeetings { get; set; } = new List<Meeting>();
            public void Schedule(Meeting meeting)
            {
                ScheduledMeetings.Add(meeting);
            }
        }
    }

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