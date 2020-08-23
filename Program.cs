using System;
using System.Collections.Generic;
using System.IO;

namespace Deleter
{
    class Program
    {
        private static readonly List<string> fileNames = new List<string>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите имя файла, который хотите удалить.");
                var answer = Console.ReadLine();
                if (answer == null) break;
                fileNames.Add(answer);

                Console.WriteLine("Еще? (y/n)");
                var againAns = Console.ReadLine();
                if (againAns == null || againAns.ToLower() != "y")
                    break;
            }

            Console.WriteLine("Введенные имена файлов: " + string.Join(", ", fileNames) + ".");
            Console.WriteLine("Приступить к удалению?(y/n)");
            var ans = Console.ReadLine();
            if (ans == null || ans.ToLower() != "y")
                return;

            Console.WriteLine("Приступаю к удалению!");
            Console.WriteLine(new string('-', 20));

            var path = Directory.GetCurrentDirectory();
            var dir = new DirectoryInfo(path);
            Deleter.FindAndDeleteAllFiles(dir, fileNames);

            Console.WriteLine();
            Console.WriteLine("Готово!");
            Console.WriteLine("Нажмите любую клавишу, чтобы закрыть программу...");
            Console.ReadLine();
        }
    }
}
