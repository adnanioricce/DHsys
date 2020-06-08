using System.IO;

namespace Infrastructure.Interfaces
{
    /// <summary>
    /// Handles I/O operations between application and file system
    /// </summary>
    public interface IFileSystemService
    {
        /// <summary>
        /// Opens file dialog on default path
        /// </summary>
        /// <param name="defaultPath">the default path from which to start dialog</param>
        /// <returns>a string path to the selected file in the dialog</returns>
        string OpenFileDialog(string defaultPath);
        /// <summary>
        /// Opens file dialog on default path filtered by given file extensions
        /// </summary>
        /// <param name="defaultPath">the default path from which to start dialog</param>
        /// <param name="fileExtensions">the extensions on which to filter the results on dialog</param>
        /// <returns>a string path to the selected file in the dialog</returns>
        string OpenFileDialog(string defaultPath, string fileExtensions);
        /// <summary>
        /// Opens a file in given path as a readonly <see cref="Stream"/> 
        /// </summary>
        /// <param name="path">the path to the file</param>
        /// <returns>a <see cref="Stream"/> object of the given file</returns>
        Stream OpenFile(string path);
        /// <summary>
        /// Opens a file in given path line by line as a array of strings
        /// </summary>
        /// <param name="path">the path to the file</param>
        /// <returns>a array of string splited by lines</returns>
        string[] OpenFileByLines(string path);

    }
}
