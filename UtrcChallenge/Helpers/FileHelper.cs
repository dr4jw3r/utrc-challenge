using System.IO;

namespace UtrcChallenge.Helpers
{
    public static class FileHelper
    {

        public static string[] ReadFile(string path)
        {
            return File.ReadAllLines(path);
        }

    }
}
