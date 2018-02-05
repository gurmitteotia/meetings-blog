
using System;
using System.IO;
using System.Linq;
using MeetingBlog.OOP;

using NUnit.Framework;

namespace MeetingBlog.Tests.OOP
{
    [TestFixture]
    public class CsvMeetingFileTests
    {
        private string _filePath;

        [SetUp]
        public void Setup()
        {
            _filePath = Path.Combine(Environment.CurrentDirectory, Guid.NewGuid().ToString());
            WriteFileHeader();
        }

        [TearDown]
        public void Teardown()
        {
            File.Delete(_filePath);
        }

        [Test]
        public void Parse_meetings()
        {
            AppendFileLine("OOP Intro,SpiderMan, 24-11-2016, 10:00:00, 11:00:00");
            AppendFileLine("Function Programming Intro,SuperMan, 25-11-2016, 09:00:00, 10:00:00");
            var meetingFile = new CsvMeetingFile(_filePath);

            var meetings = meetingFile.Meetings().ToArray();

            Assert.That(meetings.Count(), Is.EqualTo(2));
            var meeting1 = new Meeting()
            {
                Name = "OOP Intro",Organiser = "SpiderMan",Date = DateTime.Parse("24-11-2016"),
                StartTime = DateTime.Parse("10:00:00"),EndTime = DateTime.Parse("11:00:00")
            };
            var meeting2 = new Meeting()
            {
                Name = "OOP Intro",Organiser = "SpiderMan",Date = DateTime.Parse("24-11-2016"),
                StartTime = DateTime.Parse("10:00:00"),EndTime = DateTime.Parse("11:00:00")
            };
            AssertMeetingsContains(meetings, meeting1);
            AssertMeetingsContains(meetings, meeting2);

        }

        private void AssertMeetingsContains(Meeting[] meetings, Meeting expected)
        {
            var actual = meetings.First(m => m.Name == expected.Name);
            Assert.That(actual.Organiser, Is.EqualTo(expected.Organiser));
            Assert.That(actual.Date, Is.EqualTo(expected.Date));
            Assert.That(actual.StartTime, Is.EqualTo(expected.StartTime));
            Assert.That(actual.EndTime, Is.EqualTo(expected.EndTime));
        }

        [Test]
        public void Throws_exception_on_invalid_date()
        {
            AppendFileLine("OOP Intro,SpiderMan,invalid date, 10:00:00, 11:00:00");
            Assert.Throws<BadDateException>(() => new CsvMeetingFile(_filePath).Meetings());
        }

        [Test]
        public void Throws_exception_on_invalid_start_time()
        {
            AppendFileLine("OOP Intro,SpiderMan,28-10-2016, invalid start date , 11:00:00");
            Assert.Throws<BadDateException>(() => new CsvMeetingFile(_filePath).Meetings());
        }
        [Test]
        public void Throws_exception_on_invalid_end_time()
        {
            AppendFileLine("OOP Intro,SpiderMan,30-10-2016, 10:00:00, invalid end time");
            Assert.Throws<BadDateException>(() => new CsvMeetingFile(_filePath).Meetings());
        }

        private void WriteFileHeader()
        {
            File.AppendAllLines(_filePath, new[]{"Name, Organiser, Date, Start Time, End time"});
        }
        private void AppendFileLine(string line)
        {
            File.AppendAllLines(_filePath, new []{line});
        }
    }
}