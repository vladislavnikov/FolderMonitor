namespace FolderMonitor
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter folder to monitor: ");
            string folderPath = Console.ReadLine();

            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("Folder does not exist.");
                return;
            }

            Console.Write("Enter MOVEit Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter MOVEit Password: ");
            string password = Console.ReadLine();

            FileMonitor monitor = new FileMonitor(folderPath, username, password);

            Console.WriteLine($"Monitoring {folderPath} for new files...");
            Console.ReadLine();
        }
    }
}
