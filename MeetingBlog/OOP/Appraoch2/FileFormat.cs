using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MeetingBlog.OOP.Appraoch2
{
    public class FileFormat
    {
        private readonly Func<StreamReader, IEnumerable<Meeting>> _meetingParser;
        private FileFormat(Func<StreamReader, IEnumerable<Meeting>> meetingParser)
        {
            _meetingParser = meetingParser;
        }
        public static readonly FileFormat Csv = new FileFormat(ParseFromCsvFormat);
        public static readonly FileFormat Xml = new FileFormat(ParseFromXmlFormat);

        public IEnumerable<Meeting> ParseFrom(StreamReader fileReader)
        {
            return _meetingParser(fileReader);
        }
        private static IEnumerable<Meeting> ParseFromCsvFormat(StreamReader dataReader)
        {
            var meetingLines = dataReader.ReadAllLines().Skip(1).Select(line => new MeetingLine(line));
            return meetingLines.Select(ml => ml.Meeting).ToArray();
        }

        private static IEnumerable<Meeting> ParseFromXmlFormat(StreamReader dataReader)
        {
            //TODO: implement xml parsing
            throw new NotImplementedException();
        }
        private class MeetingLine
        {
            private readonly string _line;
            public MeetingLine(string line)
            {
                _line = line;
            }
            public Meeting Meeting
            {
                get
                {
                    var meeting = _line.Split(',');
                    return new Meeting(meeting[0], meeting[1], ParseDate(meeting[2]), ParseDate(meeting[3]), ParseDate(meeting[4]));
                }
            }
            private DateTime ParseDate(string date)
            {
                DateTime parsedDate;
                if (DateTime.TryParse(date, out parsedDate))
                    return parsedDate;

                throw new BadDateException(string.Format("Can not parse date {0} from line {1}", date, _line));
            }
        }
    }
}