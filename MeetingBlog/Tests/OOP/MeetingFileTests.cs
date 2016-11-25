﻿
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
            Assert.That(scheduledMeetings.Count, Is.EqualTo(2));

            Assert.That(scheduledMeetings[0].Name, Is.EqualTo("OOP Intro"));
            Assert.That(scheduledMeetings[0].Organiser, Is.EqualTo("SpiderMan"));
            Assert.That(scheduledMeetings[0].Date, Is.EqualTo(DateTime.Parse("24-11-2016")));
            Assert.That(scheduledMeetings[0].StartTime, Is.EqualTo(DateTime.Parse("10:00:00")));
            Assert.That(scheduledMeetings[0].EndTime, Is.EqualTo(DateTime.Parse("11:00:00")));

            Assert.That(scheduledMeetings[1].Name, Is.EqualTo("Function Programming Intro"));
            Assert.That(scheduledMeetings[1].Organiser, Is.EqualTo("SuperMan"));
            Assert.That(scheduledMeetings[1].Date, Is.EqualTo(DateTime.Parse("25-11-2016")));
            Assert.That(scheduledMeetings[1].StartTime, Is.EqualTo(DateTime.Parse("09:00:00")));
            Assert.That(scheduledMeetings[1].EndTime, Is.EqualTo(DateTime.Parse("10:00:00")));
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
}