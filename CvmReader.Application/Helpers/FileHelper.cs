using System.IO.Compression;

namespace CvmReader.Application.Helpers
{
    public static class FileHelper
    {
        public static async Task SaveFileAsync(string filePath, byte[] content)
        {
            string? directory = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory!);

            await File.WriteAllBytesAsync(filePath, content);
        }

        public static string[]? SearchFilePathByName(string filePath, string fileName)
        {
            string[] paths = Directory.GetFiles(filePath);
            string[] filteredPaths = Array.FindAll(paths, file =>
                Path.GetFileName(file).Contains(fileName, StringComparison.OrdinalIgnoreCase));

            if (filteredPaths.Length == 0) return null;

            return filteredPaths;
        }

        public static void ExtractZipFiles(byte[] file, string path)
        {
            var zip = new MemoryStream(file);
            var zipRead = new ZipArchive(zip, ZipArchiveMode.Read);

            foreach (ZipArchiveEntry entry in zipRead.Entries)
            {
                string fileExtension = Path.GetExtension(entry.Name);
                string fileName = Path.GetFileNameWithoutExtension(entry.Name);
                fileName = $"{fileName}_{DateTime.Now:yyyy-MM-dd}";

                entry.ExtractToFile(Path.Combine(path, $"{fileName}{fileExtension}"), overwrite: true);
            }
        }

        public static void DeleteOldFiles(string filePath)
        {
            if (!Directory.Exists(filePath)) return;

            string[] paths = Directory.GetFiles(filePath);
            string[] filteredPaths = Array.FindAll(paths, file =>
               !Path.GetFileName(file).Contains(DateTime.Now.ToString("yyyy-MM-dd"), StringComparison.OrdinalIgnoreCase));

            foreach (string file in filteredPaths) File.Delete(file);
        }
    }
}
