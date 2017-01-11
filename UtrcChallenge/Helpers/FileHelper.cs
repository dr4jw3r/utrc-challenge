using System.IO;

namespace UtrcChallenge.Helpers
{
    public static class FileHelper
    {
        #region Public Methods

        /// <summary>
        /// Reads all lines from the file at the specified path
        /// </summary>
        /// <param name="path">Path of the file to be read</param>
        /// <returns></returns>
        public static string[] ReadFile(string path)
        {
            return File.ReadAllLines(path);
        }

        #endregion
    }
}
