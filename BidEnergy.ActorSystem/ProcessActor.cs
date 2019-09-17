using Akka.Actor;

namespace BidEnergy.ActorSystem
{
    public class ProcessActor:ReceiveActor
    {
        public ProcessActor()
        {

            Receive<string>(msg => Sender.Tell(msg));
        }
    }
}