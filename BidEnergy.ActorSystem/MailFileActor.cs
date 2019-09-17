using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Util.Internal;
using BidEnergy.ActorSystem.Enum;
using CsvHelper;

namespace BidEnergy.ActorSystem
{

    public class MailFileActor:UntypedActor
    {
        private FileSystemWatcher _watcher;
        protected override void PreStart(){

              Console.WriteLine("Actor is going to start");
        }
        protected override void PostStop()
        {

        }
        protected override void OnReceive(object message)
        {
            var sourceSelection = ((FileSource) message);
            switch (sourceSelection)
            {
              case FileSource.Local:
                  ProcessFileChunks();
                  break;
              case FileSource.Aws:
                  break;
              default:
                  throw new ArgumentOutOfRangeException();
            }
        }
        private void ProcessFileChunks()
        {
            _watcher = new FileSystemWatcher
            {
                Path = "D:\\Watcher",
                NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                                        | NotifyFilters.FileName | NotifyFilters.DirectoryName,
                Filter = "*.*",
                EnableRaisingEvents = true

            };
            _watcher.Changed += OnChanged;
            //  var act= Context.ActorOf(Props.Create<ProcessActor>());
            //  act.Ask("ddd");
        }
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            Task.Delay(TimeSpan.FromMinutes(1));
            if (e.Name.Contains("csv"))
            {
                Task.Run(async () =>
                {
                    using (var reader = new StreamReader(e.FullPath))
                    using (var csv = new CsvReader(reader))
                    {
                        while (await csv.ReadAsync())
                        {

                        }
                    }
                });
            }
            Console.WriteLine("Hi I am activated");
        }
    }
}