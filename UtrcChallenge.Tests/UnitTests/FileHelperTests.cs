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
            string testDirectory = TestContext.CurrentContext.TestDirectory;
            string filePath = $"{testDirectory}/test.txt";

            string[] fileLines = { "LINE_1", "LINE_2", "LINE_3", "LINE_4" };
            File.WriteAllLines(filePath, fileLines);
            string[] fileContents = FileHelper.ReadFile(filePath);
            File.Delete(filePath);

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
