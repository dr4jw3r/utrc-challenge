using System;
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
        /// <returns>A string array of lines in the file</returns>
        public static string[] ReadFile(string path)
        {
            try
            {
                return File.ReadAllLines(path);
            }
            catch(Exception e)
            {
                return null;
            }
        }

        #endregion
    }
}
