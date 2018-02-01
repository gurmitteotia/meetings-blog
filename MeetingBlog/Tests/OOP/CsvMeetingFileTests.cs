
using System;
using System.IO;
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

            var meetings = meetingFile.Meetings();

            Assert.That(meetings, Is.EqualTo(new[]
            {
                new Meeting("OOP Intro", "SpiderMan", DateTime.Parse("24-11-2016"), DateTime.Parse("10:00:00"), DateTime.Parse("11:00:00")),
                new Meeting("Function Programming Intro", "SuperMan", DateTime.Parse("25-11-2016"), DateTime.Parse("09:00:00"), DateTime.Parse("10:00:00"))
            }));
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