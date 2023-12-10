//using System;
//using System.Linq;
//using Akka.Actor;
//using Akka.Configuration;
//using Akka.DependencyInjection;
//using Akka.Event;
//using Microsoft.Extensions.DependencyInjection;
//using Akka.DI.Core;
//using Akka.DI.Extensions.DependencyInjection;
//using Microsoft.Extensions.DependencyInjection;

//namespace srs_reak_2
//{
//    public interface IEmailNotification
//    {
//        void Send(string message);
//    }

//    public class EmailNotification : IEmailNotification
//    {
//        public void Send(string message)
//        {
//            Console.WriteLine($"Sending email with message: {message}");
//        }
//    }

//    class NotificationActor : UntypedActor
//    {
//        private readonly IEmailNotification emailNotification;
//        private readonly IActorRef childActor;
//        public NotificationActor(IEmailNotification emailNotification)
//        {
//            this.emailNotification = emailNotification;
//            this.childActor = Context.ActorOf(Context.System.DI().Props<TextNotificationActor>());
//        }

//        protected override void OnReceive(object message)
//        {
//            Console.WriteLine($"Message received: {message}");
//            emailNotification.Send(message?.ToString());
//            childActor.Tell(message);
//        }

//        protected override SupervisorStrategy SupervisorStrategy()
//        {
//            return new OneForOneStrategy(
//                maxNrOfRetries: 10,
//                withinTimeRange: TimeSpan.FromMinutes(1),
//                localOnlyDecider: ex =>
//                {
//                    return ex switch
//                    {
//                        ArgumentException ae => Directive.Resume,
//                        NullReferenceException ne => Directive.Restart,
//                        _ => Directive.Stop
//                    };
//                }
//                );
//        }

//        protected override void PreStart() => Console.WriteLine("Actor started");

//        protected override void PostStop() => Console.WriteLine("Actor stopped");
//    }

//    class TextNotificationActor : UntypedActor
//    {
//        protected override void PreStart() =>
//            Console.WriteLine("TextNotification child started!");

//        protected override void PostStop() =>
//            Console.WriteLine("TextNotification child stopped!");

//        protected override void OnReceive(object message)
//        {
//            if (message.ToString() == "null")
//                throw new NullReferenceException();
//            if (message.ToString() == " ")
//                throw new ArgumentException();
//            if (string.IsNullOrEmpty(message.ToString()))
//                throw new Exception();

//            Console.WriteLine($"Sending text message {message}");
//        }
//    }

//    public class MyActor : ReceiveActor
//    {
//        public class Act
//        {
//            public static Act Instance = new Act();
//            private Act() { }
//        }
//        private ILoggingAdapter log = Context.GetLogger();

//        public MyActor()
//        {
//            Receive<Act>(swap1 =>
//            {
//                log.Info("Got a message");

//                BecomeStacked(() =>
//                {
//                    Receive<Act>(swap2 =>
//                    {
//                        log.Info("Message sent");
//                        UnbecomeStacked();
//                    });
//                });
//            });
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var serviceCollection = new ServiceCollection();
//            serviceCollection.AddScoped<IEmailNotification, EmailNotification>();
//            serviceCollection.AddScoped<NotificationActor>();
//            serviceCollection.AddScoped<TextNotificationActor>();
//            var serviceProvider = serviceCollection.BuildServiceProvider();

//            var actorSystem = ActorSystem.Create("actorSystem");
//            IActorRef actor = actorSystem.ActorOf(actorSystem.DI().Props<NotificationActor>());

//            var myActor = actorSystem.ActorOf<MyActor>("myactor");

//            Console.WriteLine("\nEnter message");
//            while (true)
//            {
//                var message = Console.ReadLine();
//                if (message == "stop") break;
//                actor.Tell(message);
//            }
//            actorSystem.Stop(actor);

//            Console.ReadLine();

//            Console.WriteLine("____________________________________");

//            myActor.Tell(MyActor.Act.Instance);
//            myActor.Tell(MyActor.Act.Instance);
//            myActor.Tell(MyActor.Act.Instance);
//            myActor.Tell(MyActor.Act.Instance);

//            Console.ReadLine();
//        }
//    }
//}


//using System;
//using System.Threading.Tasks;
//using Akka.Actor;
//using Akka.Configuration;
//using Akka.Routing;

//namespace Routing
//{
//    internal class Program
//    {
//        private static void Main(string[] args)
//        {
//            using (var system = ActorSystem.Create("MySystem"))
//            {
//                system.ActorOf<Worker>("Worker1");
//                system.ActorOf<Worker>("Worker2");
//                system.ActorOf<Worker>("Worker3");
//                system.ActorOf<Worker>("Worker4");

//                var config = ConfigurationFactory.ParseString(@"
//                                                                routees.paths = [
//                                                                    ""akka://MySystem/user/Worker1"" 
//                                                                    ""akka://MySystem/user/Worker2""
//                                                                    ""akka://MySystem/user/Worker3""
//                                                                    ""akka://MySystem/user/Worker4""
//                                                                ]");

//                var hashGroup = system.ActorOf(Props.Empty.WithRouter(new ConsistentHashingGroup(config)));

//                Console.WriteLine();

//                for (var i = 0; i < 5; i++)
//                {
//                    for (var j = 0; j < 7; j++)
//                    {
//                        var message = new HashableMessage
//                        {
//                            Name = Guid.NewGuid().ToString(),
//                            Id = j,
//                        };

//                        hashGroup.Tell(message);
//                    }
//                }

//                var roundRobinPool = system.ActorOf(new RoundRobinPool(5, null, null, null,
//                    usePoolDispatcher: false).Props(Props.Create<Worker>()));

//                for (var i = 0; i < 20; i++)
//                {
//                    roundRobinPool.Tell(i);
//                }
//                Console.ReadLine();
//            }
//        }
//    }

//    public class HashableMessage : IConsistentHashable
//    {
//        public string Name { get; set; }
//        public int Id { get; set; }

//        public object ConsistentHashKey
//        {
//            get { return Id; }
//        }

//        public override string ToString()
//        {
//            return string.Format("{0} {1}", Id, Name);
//        }
//    }

//    public class Worker : UntypedActor
//    {
//        protected override void OnReceive(object message)
//        {
//            Console.WriteLine("{0} received {1}", Self.Path.Name, message);
//        }
//    }
//}


using System;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Configuration;
using Akka.Routing;

/*
 * Create an actor and a message type that gets shared between Deployer and DeployTarget
 * in a common DLL
 */
/// <summary>
/// Actor that just replies the message that it received earlier
/// </summary>
public class EchoActor : ReceiveActor
{
    public EchoActor()
    {
        Receive<Hello>(hello =>
        {
            Console.WriteLine("[{0}]: {1}", Sender, hello.Message);
            Sender.Tell(hello);
        });
    }
}

public class Hello
{
    public Hello(string message)
    {
        Message = message;
    }

    public string Message { get; private set; }
}

class Program
{
    class SayHello { }

    class HelloActor : ReceiveActor
    {
        private IActorRef _remoteActor;
        private int _helloCounter;
        private ICancelable _helloTask;

        public HelloActor(IActorRef remoteActor)
        {
            _remoteActor = remoteActor;
            Receive<Hello>(hello =>
            {
                Console.WriteLine("Received {1} from {0}", Sender, hello.Message);
            });

            Receive<SayHello>(sayHello =>
            {
                _remoteActor.Tell(new Hello("hello" + _helloCounter++));
            });
        }

        protected override void PreStart()
        {
            _helloTask = Context.System.Scheduler.ScheduleTellRepeatedlyCancelable(TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(1), Context.Self, new SayHello(), ActorRefs.NoSender);
        }

        protected override void PostStop()
        {
            _helloTask.Cancel();
        }
    }

    static void Main(string[] args)
    {
        using (var system = ActorSystem.Create("Deployer", ConfigurationFactory.ParseString(@"
            akka {  
                actor{
                    provider = remote
                    deployment {
                        /remoteecho {
                            remote = ""akka.tcp://DeployTarget@localhost:8090""
                        }
                    }
                }
                remote {
                    dot-netty.tcp {
                        port = 0
                        hostname = localhost
                    }
                }
            }")))
        {
            var remoteAddress = Address.Parse("akka.tcp://DeployTarget@localhost:8090");
            //deploy remotely via config
            var remoteEcho1 = system.ActorOf(Props.Create(() => new EchoActor()), "remoteecho");

            //deploy remotely via code
            var remoteEcho2 =
                system.ActorOf(
                    Props.Create(() => new EchoActor())
                        .WithDeploy(Deploy.None.WithScope(new RemoteScope(remoteAddress))), "coderemoteecho");


            system.ActorOf(Props.Create(() => new HelloActor(remoteEcho1)));
            system.ActorOf(Props.Create(() => new HelloActor(remoteEcho2)));

            Console.ReadKey();
        }
    }
}