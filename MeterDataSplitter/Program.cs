using System;
using Akka.Actor;
using BidEnergy.ActorSystem;
using BidEnergy.ActorSystem.Enum;

namespace MeterDataSplitter
{
    class Program
    {

        static void Main(string[] args)
        {

            var actorSys = ActorSystem.Create("meter-file-system");
            var fileActor = actorSys.ActorOf(Props.Create<MailFileActor>());
            fileActor.Tell(FileSource.Local);

            Console.ReadKey();
            Console.CancelKeyPress += (s, a) =>
            {
                a.Cancel = true;
                actorSys.Stop(fileActor);
            };

            Console.WriteLine("Actor system stopped");
        }
    }
}