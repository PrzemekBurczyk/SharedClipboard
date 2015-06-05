using SharedClipboard.Manager;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClipboard.Utils
{
    public class FileUtils
    {
        public class FilesSizeLimitExceededException : Exception
        {
            public FilesSizeLimitExceededException(string message) : base(message) { }
        }

        private static long MAX_FILES_SIZE_BYTES = 5242880; //5MB

        private static long GetPathsSize(List<string> paths)
        {
            long totalSize = 0;
            foreach (string path in paths)
            {
                try
                {
                    FileInfo info = new FileInfo(path);
                    totalSize += info.Length;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Could not read file info from path: " + path + " error: " + e.Message);
                }
            }
            return totalSize;
        }

        private static ClipboardFile GetFileFromFilePath(string path)
        {
            try
            {
                ClipboardFile clipboardFile = new ClipboardFile();
                clipboardFile.Name = Path.GetFileName(path);
                clipboardFile.Data = Convert.ToBase64String(File.ReadAllBytes(path));
                return clipboardFile;
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not read file from path: " + path + " error: " + e.Message);
            }
            return null;
        }

        private static List<ClipboardFile> GetFilesFromFilePaths(List<string> paths)
        {
            List<ClipboardFile> files = new List<ClipboardFile>();
            foreach (string path in paths)
            {
                ClipboardFile clipboardFile = GetFileFromFilePath(path);
                if (clipboardFile != null)
                {
                    files.Add(clipboardFile);
                }
            }
            return files;
        }

        private static List<string> GetFilePaths(StringCollection paths)
        {
            List<string> filePaths = new List<string>();
            foreach (String path in paths)
            {
                FileAttributes fileAttributes = File.GetAttributes(path);
                if ((fileAttributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    filePaths.AddRange(Directory.GetFiles(path, "*", SearchOption.AllDirectories));
                }
                else
                {
                    filePaths.Add(path);
                }
            }
            return filePaths;
        }

        public static List<ClipboardFile> GetFilesFromPaths(StringCollection paths)
        {
            List<string> filePaths = GetFilePaths(paths);
            long size = GetPathsSize(filePaths);
            if (size <= MAX_FILES_SIZE_BYTES)
            {
                return GetFilesFromFilePaths(filePaths);
            }
            else
            {
                throw new FilesSizeLimitExceededException("Total files size exceeds limit of " + MAX_FILES_SIZE_BYTES + " bytes");
            }
        }
    }
}
