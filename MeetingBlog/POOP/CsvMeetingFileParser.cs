using System;
using System.Collections.Generic;
using System.Linq;
using MeetingBlog.OOP;

namespace MeetingBlog.POOP
{
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

            return meetingLines.Skip(1).Select(ParseMeeting).ToArray();
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