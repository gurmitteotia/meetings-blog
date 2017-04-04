
using System;
using System.Collections.Generic;
using MeetingBlog.OOP;
using NUnit.Framework;

namespace MeetingBlog.Tests.OOP
{
    [TestFixture]
    public class MeetingFileTests
    {
        [Test]
        public void Can_schedule_meetings_in_calendar_from_csv_file()
        {
            var calendar = new TestCalendar();
            //Other potential approach is to generate csv file in tests
            var meetingFile = MeetingFile.Csv(@"Tests\OOP\ValidMeetings.csv".ToAbsolutePath());

            meetingFile.ScheduleIn(calendar);

            AssertThatMeetingsAreScheduledIn(calendar);
        }

        [Test]
        public void Throws_exception_on_invalid_format_file()
        {
            Assert.Throws<BadDateException>(() => MeetingFile.Csv(@"Tests\OOP\InvalidDateMeeting.csv".ToAbsolutePath()));
            Assert.Throws<BadDateException>(() => MeetingFile.Csv(@"Tests\OOP\InvalidStartTimeMeeting.csv".ToAbsolutePath()));
            Assert.Throws<BadDateException>(() => MeetingFile.Csv(@"Tests\OOP\InvalidEndTimeMeeting.csv".ToAbsolutePath()));
        }

        private static void AssertThatMeetingsAreScheduledIn(TestCalendar calendar)
        {
            var scheduledMeetings = calendar.ScheduledMeetings;
            
            Assert.That(scheduledMeetings, Is.EqualTo(new []
            {
                new Meeting("OOP Intro", "SpiderMan", DateTime.Parse("24-11-2016"), DateTime.Parse("10:00:00"), DateTime.Parse("11:00:00")),
                new Meeting("Function Programming Intro", "SuperMan", DateTime.Parse("25-11-2016"), DateTime.Parse("09:00:00"), DateTime.Parse("10:00:00"))
            }));
        }
        private class TestCalendar : Calendar
        {
            public List<Meeting> ScheduledMeetings { get; private set; }

            public TestCalendar()
            {
                ScheduledMeetings = new List<Meeting>();
            }  
            public void Schedule(Meeting meeting)
            {
                ScheduledMeetings.Add(meeting);    
            }
        } 
    }
}