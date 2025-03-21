namespace FolderMonitor
{
    public class FileMonitor
    {
        private readonly FileSystemWatcher _watcher;
        private readonly MoveItClient _moveItClient;
        private int? _homeFolderId;

        public FileMonitor(string folderPath, string username, string password)
        {
            _watcher = new FileSystemWatcher(folderPath) { EnableRaisingEvents = true, Filter = "*.*", NotifyFilter = NotifyFilters.FileName };
           
            _moveItClient = new MoveItClient();
            AuthenticateAndSetHomeFolder(username, password).Wait();
        }

        private async Task AuthenticateAndSetHomeFolder(string username, string password)
        {
            if (await _moveItClient.AuthenticateAsync(username, password))
            {
                _homeFolderId = await _moveItClient.GetHomeFolderIdAsync();
            }
        }

    }
}
