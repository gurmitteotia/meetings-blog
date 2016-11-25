using System;
using System.Collections.Generic;
using System.Linq;
using MeetingBlog.OOP;
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
                .Returns(new[] {"OOP Intro,SpiderMan, 24-11-2016, 10:00:00, 11:00:00"});

            var meetings = _csvMeetingFileParser.ParseMeetings(_fileName);
        }
    }

    internal interface IFileReader
    {
        IEnumerable<string> ReadData(string filePath);
    }

    internal class CsvMeetingFileParser
    {
        private readonly IFileReader _fileReader;

        public CsvMeetingFileParser(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }
        public IEnumerable<Meeting> ParseMeetings(string meetingfileCsv)
        {
            var meetingLines = _fileReader.ReadData(meetingfileCsv);

            return meetingLines.Select(ParseMeeting).ToArray();
        }

        private static Meeting ParseMeeting(string line)
        {
            var meeting = line.Split(',');
            return new Meeting
            {
                Name = meeting[0],
                Organiser = meeting[1],
                Date = ParseDate(meeting[2]),
                StartTime = ParseDate(meeting[3]),
                EndTime = ParseDate(meeting[4])
            };
        }
        private static DateTime ParseDate(string date)
        {
            DateTime parsedDate;
            if (DateTime.TryParse(date, out parsedDate))
                return parsedDate;

            throw new BadDateException($"Can not parse date {date}.");
        }
    }
}