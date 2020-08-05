using Infrastructure.Interfaces;
using Microsoft.Win32;
using System.IO;

namespace Desktop.Services
{
    public class IOService : IFileSystemService
    {
        private readonly string _defaultPath = "C:\\";
        public IOService(string defaultPath)
        {
            if (Directory.Exists(_defaultPath))
            {
                _defaultPath = defaultPath;
            }
        }        
        public virtual Stream OpenFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new System.Exception(string.Format("the file on path {0} don't exists", path));
            }            
            var stream = File.OpenRead(path);            
            return stream;
        }
        public virtual string[] OpenFileByLines(string path)
        {
            if (!File.Exists(path))
            {
                throw new System.Exception(string.Format("the file on path {0} don't exists", path));
            }
            return File.ReadAllLines(path);             
        }
        public virtual string OpenFileDialog(string defaultPath, string fileExtensions)
        {
            var fileDialog = new OpenFileDialog
            {
                InitialDirectory = string.IsNullOrEmpty(defaultPath) ? _defaultPath : defaultPath,
                Filter = string.IsNullOrEmpty(fileExtensions) ? "*.*" : fileExtensions,
                CheckPathExists = true
            };
            fileDialog.ShowDialog();
            return fileDialog.FileName;
        }        
        public virtual string OpenFileDialog(string defaultPath)
        {
            return OpenFileDialog(defaultPath,"");
        }
    }
}
