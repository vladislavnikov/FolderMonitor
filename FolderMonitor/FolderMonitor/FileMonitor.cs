namespace FolderMonitor
{
    public class FileMonitor
    {
        private readonly MoveItClient _moveItClient;

        public FileMonitor(string folderPath, string username, string password)
        {
            _moveItClient = new MoveItClient();
            AuthenticateAndSetHomeFolder(username, password).Wait();
        }

        private async Task AuthenticateAndSetHomeFolder(string username, string password)
        {
            if (await _moveItClient.AuthenticateAsync(username, password))
            {
                //GetFolder
            }
        }
    }
}
