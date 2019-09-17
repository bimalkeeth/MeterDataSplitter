using System;
using Akka;
using Akka.Actor;
using BidEnergy.ActorSystem.Enum;

namespace BidEnergy.ActorSystem
{

    public class MailFileActor:UntypedActor
    {
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

                   var act= Context.ActorOf(Props.Create<ProcessActor>());
                   act.Ask("ddd");
                  break;

              case FileSource.Aws:
                  break;
              default:
                  throw new ArgumentOutOfRangeException();
            }
        }
    }
}