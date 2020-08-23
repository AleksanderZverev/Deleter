using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Deleter
{
    public static class Deleter
    {
        public static void FindAndDeleteAllFiles(DirectoryInfo dir, IReadOnlyList<string> fileNames)
        {
            Console.WriteLine("Enter in the \"" + dir.Name + "\" directory");
            var directories = dir.GetDirectories();
            foreach (var directoryInfo in directories)
            {
                if (fileNames.Contains(directoryInfo.Name))
                {
                    DeleteDirectory(directoryInfo);
                    Console.WriteLine("-" + directoryInfo.Name + " - deleted");
                }
                else
                    FindAndDeleteAllFiles(directoryInfo, fileNames);
            }
        }

        public static void DeleteDirectory(DirectoryInfo directory)
        {
            foreach (var fileInfo in directory.GetFiles())
            {
                fileInfo.Delete();
            }

            foreach (var directoryInfo in directory.GetDirectories())
            {
                DeleteDirectory(directoryInfo);
            }

            directory.Delete();
        }
    }
}