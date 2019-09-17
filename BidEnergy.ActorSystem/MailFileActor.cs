using System;
using Akka.Actor;
using BidEnergy.ActorSystem.Enum;

namespace BidEnergy.ActorSystem
{

    public class MailFileActor:UntypedActor
    {
        protected override void PreStart(){

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


                  break;

              case FileSource.Aws:
                  break;
              default:
                  throw new ArgumentOutOfRangeException();
            }
        }
    }
}