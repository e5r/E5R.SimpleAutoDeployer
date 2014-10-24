using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E5R.SimpleAutoDeployer
{
    public class Program
    {
        private static Program _app;
        private string _appName;
        private string[] _args;
        private FileSystemWatcher _watcher;

        public Program()
        {
            this._args = Environment.GetCommandLineArgs();
            this._appName = Path.GetFileName(this._args[0]);
            this._watcher = new FileSystemWatcher();
        }

        static void Main(string[] args)
        {
            _app = new Program();
            _app.RunWatcher();
            _app.InfiniteLoop();
        }

        private void InfiniteLoop()
        {
            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }

        private void RunWatcher()
        {
            if (_args.Length != 2)
            {
                PrintUsage();
                return;
            }

            _watcher.Path = Path.GetFullPath(_args[1]);

            _watcher.NotifyFilter = NotifyFilters.LastAccess
                | NotifyFilters.LastWrite
                | NotifyFilters.FileName
                | NotifyFilters.DirectoryName;

            _watcher.Filter = "";

            _watcher.Changed += new FileSystemEventHandler(FileChangedDetected);
            _watcher.Created += new FileSystemEventHandler(FileChangedDetected);
            _watcher.Deleted += new FileSystemEventHandler(FileChangedDetected);
            _watcher.Renamed += new RenamedEventHandler(FileRenamedDetected);

            _watcher.EnableRaisingEvents = true;
        }

        private void FileRenamedDetected(object sender, RenamedEventArgs e)
        {
            Console.WriteLine(String.Format("File: {0} renamed to {1}.", e.OldName, e.Name));
        }

        private void FileChangedDetected(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine(String.Format("File: {0} changed [{1}].", e.Name, e.ChangeType.ToString()));
        }

        private void PrintUsage()
        {
            Console.WriteLine(String.Format("Usage: {0} [directory]", _appName));
        }
    }
}
