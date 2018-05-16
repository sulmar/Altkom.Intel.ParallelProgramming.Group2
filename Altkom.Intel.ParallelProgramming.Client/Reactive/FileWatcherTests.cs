using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Intel.ParallelProgramming.Client.Reactive
{
    class FileWatcherTests
    {
        public static void Test()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            var fileSystemWatcher = new FileSystemWatcher(path);
            fileSystemWatcher.IncludeSubdirectories = true;
            fileSystemWatcher.EnableRaisingEvents = true;

            var created = Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>
            (
                h => fileSystemWatcher.Created += h,
                h => fileSystemWatcher.Created -= h
            ).Select(x => x.EventArgs);

            var deleted = Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>
            (
                h => fileSystemWatcher.Deleted += h,
                h => fileSystemWatcher.Deleted -= h
            ).Select(x => x.EventArgs);

            created
                .Where(file => Path.GetExtension(file.Name).ToLower() == ".txt")
                .Take(2)
                .Subscribe(file => Console.WriteLine($"Created {file.Name}"));

            deleted.Subscribe(file =>
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"Deleted {file.Name}");
                Console.ResetColor();
            });


        }
    }
}
