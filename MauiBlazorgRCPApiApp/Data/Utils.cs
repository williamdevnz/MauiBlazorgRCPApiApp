using System.IO;
using System.Text.RegularExpressions;

namespace MauiBlazorgRCPApiApp.Data
{
    public static class Utils
    {
        public static void RegError(string err)
        {
            string logDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyAppLogs");
            Directory.CreateDirectory(logDirectory);  // Asegura que el directorio exista.

            string logFile = Path.Combine(logDirectory, "applog.txt");

            File.AppendAllText(logFile, $"[{DateTime.Now}] Error: {err}\n");
            //Deja el error en la carpeta Documents del PC en el archivo applog.txt
        }
    }
}
