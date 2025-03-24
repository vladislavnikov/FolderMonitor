namespace FolderMonitor
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Enter folder path to monitor: ");
            string folderPath = Console.ReadLine();

            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("Folder does not exist.");
                return;
            }

            Console.Write("Enter MOVEit Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter MOVEit Password: ");
            string password = string.Empty;

            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            Console.WriteLine();

            var moveItClient = new MoveItClient();
            bool isAuthenticated = await moveItClient.AuthenticateAsync(username, password);

            if (!isAuthenticated)
            {
                return;
            }

            int? homeFolderId = await moveItClient.GetHomeFolderIdAsync();
            if (homeFolderId == null)
            {
                Console.WriteLine("Failed to retrieve Home Folder ID.");
                return;
            }

            var fileActions = new FileActions(moveItClient.HttpClient);
            var monitor = new FileMonitor(folderPath, fileActions, homeFolderId);

            Console.WriteLine($"Monitoring \"{folderPath}\" for new files...");
            Console.ReadLine();
        }
    }
}
