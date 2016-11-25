
using System.Linq;
using MeetingBlog.POOP;
using NUnit.Framework;

namespace MeetingBlog.Tests.POOP
{
    [TestFixture]
    public class FileSystemFileReaderTests
    {
        [Test]
        public void Can_read_data_from_file()
        {
            var fileReader = new FileSystemFileReader();

            var data = fileReader.ReadData(@"Tests\POOP\testfile.txt".ToAbsolutePath()).ToArray();

            Assert.That(data,Is.EqualTo(new [] {"blah"}));
        }
    }
}