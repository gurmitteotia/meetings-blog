using System;
using System.Collections.Generic;
using System.Linq;
using MeetingBlog.POOP;
using Moq;
using NUnit.Framework;

namespace MeetingBlog.Tests.POOP
{
    [TestFixture]
    public class CsvMeetingFileParserTests
    {
        private CsvMeetingFileParser _csvMeetingFileParser;
        private Mock<IFileReader> _fileReader;
        private const string _fileName = "meetingfile.csv";

        [SetUp]
        public void Setup()
        {
            _fileReader = new Mock<IFileReader>();
            _csvMeetingFileParser = new CsvMeetingFileParser(_fileReader.Object);
        }

        [Test]
        public void Can_parse_multiple_meetings_from_file()
        {
            _fileReader.Setup(f => f.ReadData(_fileName))
                .Returns(new[] { "Name, Organiser, Date, Start Time, End time",
                                 "OOP Intro,SpiderMan, 24-11-2016, 10:00:00, 11:00:00",
                                "Function Programming Intro,SuperMan, 25-11-2016, 09:00:00, 10:00:00" });

            var meetings = _csvMeetingFileParser.ParseMeetings(_fileName);

            AssertThatMeetingsAreParsedCorrectly(meetings.ToList());
        }

        [Test]
        public void Throws_exception_when_meeting_date_can_not_be_parsed()
        {
            _fileReader.Setup(f => f.ReadData(_fileName))
                .Returns(new[] { "Name, Organiser, Date, Start Time, End time",
                                 "OOP Intro,SpiderMan, Blah blah, 10:00:00, 11:00:00"
                                });

             Assert.Throws<BadDateException>(()=> _csvMeetingFileParser.ParseMeetings(_fileName));
        }

        private static void AssertThatMeetingsAreParsedCorrectly(IList<Meeting> scheduledMeetings)
        {
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
    }
}