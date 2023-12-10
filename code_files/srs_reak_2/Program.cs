using System;
using System.Linq;
using Akka.Actor;
using Akka.Configuration;
using Akka.DependencyInjection;
using Akka.Event;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Akka.DI.Core;
using Akka.DI.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace srs_reak_2
{
    public interface IEmailNotification  //интерфейс уводемлениены почтага жіберетін қызмет атқарады
    {
        void Send(string message);  //параметр ретінде string типті хабарлама
    }

    public class EmailNotification : IEmailNotification  //интерфейсты жузеге асыратын класс 
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending email with message: {message}");  //сообщениенын почтага жіберілгенін хабарлаитын метод
        }
    }

    class NotificationActor : UntypedActor  //уводемлениены жіберетін актер, мында Актер UntypedActor класын кеңейту және
                                            //OnReceive әдісін енгізу арқылы жүзеге асырылады. 
    {
        private readonly IEmailNotification emailNotification;
        private readonly IActorRef childActor;  //IActorRef интерфеисы актер создавать етуге көмектесетін интерфеис

        public NotificationActor(IEmailNotification emailNotification)
        {
            this.emailNotification = emailNotification;
            this.childActor = Context.ActorOf(Context.System.DI().Props<TextNotificationActor>());  //актер контекстін пайдалану - дочерный актерді жасайды.
                                                                                                    //Дочерный актер ретінде TextNotificationActor алдым
                                                                                                    //ActorOf ты - шақыру IActorRef экземплярын қайтарады.
        }

        protected override void OnReceive(object message)  //Бұл әдіс хабарламаны параметр ретінде қабылдайды.
        {
            Console.WriteLine($"Message received: {message}");  //сообщениенын келгенын хабарлау
            emailNotification.Send(message?.ToString());    //почта уводемлениесыне жіберу
            childActor.Tell(message);    //сообщениені дочерный актер хабарлауы
        }

        protected override SupervisorStrategy SupervisorStrategy()  //бұл метод исключениелерді тез оқшаулауға және қалпына келтіруге
                                                                    //мүмкіндік беретін встроенный метод.
        {
            return new OneForOneStrategy(   // 1 минут ішінде 10 қатеден артық болса, токтайды
                maxNrOfRetries: 10,
                withinTimeRange: TimeSpan.FromMinutes(1),
                localOnlyDecider: ex =>
                {
                    return ex switch
                    {
                        ArgumentException ae => Directive.Resume,
                        NullReferenceException ne => Directive.Restart,
                        _ => Directive.Stop
                    };
                }
                );
        }

        protected override void PreStart() => Console.WriteLine("Actor started"); //актер іске қосылғанда

        protected override void PostStop() => Console.WriteLine("Actor stopped"); //актердің жұмысы тоқтағанда
    }

    class TextNotificationActor : UntypedActor    //уводемлениедегі сообщениены анықтап, жіберетін дочерный актер
    {
        protected override void PreStart() =>
            Console.WriteLine("TextNotification child started!");

        protected override void PostStop() =>
            Console.WriteLine("TextNotification child stopped!");

        protected override void OnReceive(object message)
        {
            if (message.ToString() == "null")    //егер консольга "null" деп жазсак, NullReferenceException туындайды
                throw new NullReferenceException();
            if (message.ToString() == " ")      //егер консольга " " деп жазсак, ArgumentException туындайды
                throw new ArgumentException();
            if (string.IsNullOrEmpty(message.ToString()))    //егер консольга жазбай хабарлама жіберсек, Exception туындайды
                throw new Exception();

            Console.WriteLine($"Sending text message {message}");
        }
    }

    public class MyActor : ReceiveActor  //ReceiveActor класын наследовать ету арқылы, внутренный Receive() методы жузеге асырылады
    {
        public class Act
        {
            public static Act Instance = new Act();
            private Act() { }
        }
        private ILoggingAdapter log = Context.GetLogger();  //GetLogger() көрсетілген регистрді(логгерды) алады.

        public MyActor()
        {
            Receive<Act>(swap1 =>    // Receive<T>(Action<T> handler) ішкі субьектісін констуктор аркылы шақырылады
                                     // өңделетін әрбір хабарламаның типі үшін шақырылады
                                     // өңделген әрбір хабарламаны Stack те сақтаиды
            {
                log.Info("Got a message"); 

                BecomeStacked(() =>  // BecomeStacked() методы арқылы хабарламаларды стекке жинайды
                {
                    Receive<Act>(swap2 =>
                    {
                        log.Info("Message sent");
                        UnbecomeStacked();   //стектегі алдыңғы хабарламаға оралуға мәжбүолеу үшін UnbecomeStacked() методы шақырылады
                    });
                });
            });
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();  //сервистарды қосу үшін ServiceCollection обьектісін жасаймыз
            //Метод AddScoped берілген класстардағы запростар үшін бір обьект экземплярын жасайды
            serviceCollection.AddScoped<IEmailNotification, EmailNotification>(); 
            serviceCollection.AddScoped<NotificationActor>();
            serviceCollection.AddScoped<TextNotificationActor>();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var actorSystem = ActorSystem.Create("actorSystem");  //ActorSystem пайдалану - актер жүйесін қамтамасыз ететін, басқаратын жоғары деңгейлі актерлерді жасайды
            actorSystem.UseServiceProvider(serviceProvider);   //сервистерды актерлар системасына тыркейміз

            //Props - бұл актерлерді құру опцияларын көрсетуге арналған конфигурация класы
            IActorRef actor = actorSystem.ActorOf(actorSystem.DI().Props<NotificationActor>());  // 1 actor  

            var myActor = actorSystem.ActorOf<MyActor>("myactor");    // 2 actor

            Console.WriteLine("\nEnter message");
            while (true)
            {
                var message = Console.ReadLine();
                if (message == "stop") break;   // "stop" жазганда хабарламалар енгізу циклы тоқтайды
                actor.Tell(message);
            }
            actorSystem.Stop(actor);  // хабарлама жіберуді тоқтату

            Console.ReadLine();

            Console.WriteLine("____________________________________");

            myActor.Tell(MyActor.Act.Instance);  // 2 actor хабарлаитын хабарламалар ды шакыру, стекке жиналғанын бақылаймыз
            myActor.Tell(MyActor.Act.Instance);
            myActor.Tell(MyActor.Act.Instance);
            myActor.Tell(MyActor.Act.Instance);

            Console.ReadLine();
        }
    }
}