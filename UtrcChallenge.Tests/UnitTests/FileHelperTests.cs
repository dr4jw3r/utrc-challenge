using NUnit.Framework;
using System.IO;
using UtrcChallenge.Helpers;

namespace UtrcChallenge.Tests.UnitTests
{
    [TestFixture]
    public class FileHelperTests
    {
        [Test]
        public void CorrectlyReadsFileContents()
        {
            const string FileName = "test.txt";

            string[] fileLines = { "LINE_1", "LINE_2", "LINE_3", "LINE_4" };
            File.WriteAllLines(FileName, fileLines);
            string[] fileContents = FileHelper.ReadFile(FileName);
            File.Delete(FileName);

            Assert.AreEqual(4, fileContents.Length);
        }

        [Test]
        public void ReturnsNullIfFileAtPathDoesNotExist()
        {
            string[] fileContents = FileHelper.ReadFile("file_that_does_not_exist.txt");
            Assert.IsNull(fileContents);
        }
    }
}
