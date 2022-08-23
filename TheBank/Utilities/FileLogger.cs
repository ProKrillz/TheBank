namespace TheBank.Utilities
{
    public static class FileLogger
    {
        static string fileName;

        static void WriteToLog(string logMessage)
        {
            string path = @"C:\Logs";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
