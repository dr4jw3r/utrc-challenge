using System.IO;

namespace UtrcChallenge.Helpers
{
    public static class FileHelper
    {
        #region Public Methods

        public static string[] ReadFile(string path)
        {
            return File.ReadAllLines(path);
        }

        #endregion
    }
}
