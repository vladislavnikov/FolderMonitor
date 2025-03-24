using System.Net.Http;

namespace FolderMonitor
{
    /// <summary>
    /// Monitors a specified folder for new files and automatically uploads them using FileActions.
    /// </summary>
    public class FileMonitor
    {
        private readonly string _folderPath;
        private readonly FileActions _fileActions;
        private readonly int? _homeFolderId;

        public FileMonitor(string folderPath, FileActions fileActions, int? homeFolderId)
        {
            _folderPath = folderPath;
            _fileActions = fileActions;
            _homeFolderId = homeFolderId;

            var watcher = new FileSystemWatcher(_folderPath)
            {
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size,
                Filter = "*.*",
                EnableRaisingEvents = true
            };

            watcher.Created += async (sender, e) => await OnNewFileDetected(e.FullPath);
        }

        /// <summary>
        /// Handles the event when a new file is detected in the monitored folder.
        /// </summary>
        /// <param name="filePath">The full path of the newly created file.</param>
        private async Task OnNewFileDetected(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            Console.WriteLine($"New file detected: {fileName}");

            await _fileActions.UploadFileAsync(filePath, _homeFolderId, fileName);
        }
    }
}
