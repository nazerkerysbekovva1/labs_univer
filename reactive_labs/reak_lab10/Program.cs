using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace reak_lab10
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var tovars = new List<Tovar>
            {
                new Tovar (1, "Sisley","Female", 7645,"P1", new DateTime(2025,02,07), 7),
                new Tovar (2, "Kenzo", "Female", 2575, "P1", new DateTime(2025,02,07), 9),
                new Tovar (3, "Cerruti", "Male", 4315, "P2",  new DateTime(2025,02,07), 12),
                new Tovar (4, "Davidoff","Male", 3450,"P2", new DateTime(2025,02,07), 6),
                new Tovar (5, "Bottega Veneta", "Female", 6685, "P3", new DateTime(2025,02,07), 10),
                new Tovar (6, "Calvin Klein", "Female", 2285, "P4", new DateTime(2025,02,07), 8),
                new Tovar (7, "Comme Des Gargons", "Unisex", 6700, "P5", new DateTime(2025,02,07), 7),
                new Tovar (8, "Givenchy", "Unisex", 5630,"P5", new DateTime(2025,02,07), 11),
                new Tovar (9, "Thierry Mugler","Perfume sets", 4635,"P4", new DateTime(2025,02,07), 8),
                new Tovar (10, "Lancome","Perfume sets", 3800, "P1", new DateTime(2025,02,07), 9)
            };
            // var tovars2 = tovars.ToArray();

            BasicScheduling();
            BasicSchedulingEveryTwoSeconds();
            ObservableIntervalOnCurrentThread();
            ThreadPoolSchedulerExample();
            CurrentThreadSchedulerExample();
            ImmediateSchedulerExample();
            EventLoopSchedulerExample();

            Console.ReadKey();
        }

        private static void BasicScheduling()
        {
            Tovar.DisplayHeader("Basic Scheduling - Планирование запуска действия через две секунды");

            IScheduler scheduler = NewThreadScheduler.Default;

            IDisposable scheduling =
                scheduler.Schedule(
                    Unit.Default,
                    TimeSpan.FromSeconds(2),
                    (scdlr, _) =>
                    {
                        Console.WriteLine("Tovar, Now: {0}", scdlr.Now);
                        return Disposable.Empty;
                    });

            Console.WriteLine("спать в течение 3 секунд, поэтому планирование будет иметь место");
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

        private static void BasicSchedulingEveryTwoSeconds()
        {
            Tovar.DisplayHeader("Basic Scheduling - Планирование действия для рекурсивного запуска каждые две секунды");

            IScheduler scheduler = NewThreadScheduler.Default;
            Func<IScheduler, int, IDisposable> action = null;
            action = (scdlr, callNumber) =>
            {
                Console.WriteLine("Tovar {0}, Now: {1}, Thread: {2}", callNumber, scdlr.Now,
                    Thread.CurrentThread.ManagedThreadId);
                return scdlr.Schedule(callNumber + 1, TimeSpan.FromSeconds(2), action);
            };
            var scheduling =
                scheduler.Schedule(
                    0,
                    TimeSpan.FromSeconds(2),
                    action);

            Console.WriteLine("спать в течение 5 секунд, а затем утилизировать");

            Thread.Sleep(TimeSpan.FromSeconds(5));
            scheduling.Dispose();

            Console.WriteLine("планирование расположено, Now: {0}", scheduler.Now);
        }

        private static void ObservableIntervalOnCurrentThread()
        {
            Tovar.DisplayHeader("Parametrizing concurrency - передача CurrentThreadScheduler оператору Interval, чтобы выбросы были в вызывающем потоке");

            Console.WriteLine("Before - Thread: {0}", Thread.CurrentThread.ManagedThreadId);
            Observable.Interval(TimeSpan.FromSeconds(1), CurrentThreadScheduler.Instance)
                .Timestamp()
                .Take(3)
                .Do(x => Console.WriteLine("Inside - {0} - Thread: {1}", x, Thread.CurrentThread.ManagedThreadId))
                .RunExample();
        }   

        private static void ThreadPoolSchedulerExample()
        {
            Tovar.DisplayHeader("ThreadPoolScheduler - Использует ThreadPool для каждого планирования");

            var threadPoolScheduler = ThreadPoolScheduler.Instance;

            var countdownEvent = new CountdownEvent(2);

            threadPoolScheduler.Schedule(Unit.Default,
                (s, _) =>
                {
                    Console.WriteLine("Action1 - Thread:{0}", Thread.CurrentThread.ManagedThreadId);
                    countdownEvent.Signal();
                });
            threadPoolScheduler.Schedule(Unit.Default,
                (s, _) =>
                {
                    Console.WriteLine("Action2 - Thread:{0}", Thread.CurrentThread.ManagedThreadId);
                    countdownEvent.Signal();
                });
            countdownEvent.Wait();
        }

        private static void CurrentThreadSchedulerExample()
        {
            Tovar.DisplayHeader("CurrentThreadScheduler - Использует текущий поток (вызывающий поток) для каждого планирования");

            var currentThreadScheduler = CurrentThreadScheduler.Instance;

            var countdownEvent = new CountdownEvent(2);

            Console.WriteLine("Calling thread: {0}", Thread.CurrentThread.ManagedThreadId);

            currentThreadScheduler.Schedule(Unit.Default,
                (s, _) =>
                {
                    Console.WriteLine("Action1 - Thread:{0}", Thread.CurrentThread.ManagedThreadId);
                    countdownEvent.Signal();
                });
            currentThreadScheduler.Schedule(Unit.Default,
                (s, _) =>
                {
                    Console.WriteLine("Action2 - Thread:{0}", Thread.CurrentThread.ManagedThreadId);
                    countdownEvent.Signal();
                });
            countdownEvent.Wait();
        }

        private static void ImmediateSchedulerExample()
        {
            Tovar.DisplayHeader("ImmediateScheduler - Использует текущий поток (вызывающий поток) для каждого планирования, но немедленно запускает запланированное действие.");

            var immediateScheduler = ImmediateScheduler.Instance;

            var countdownEvent = new CountdownEvent(2);

            Console.WriteLine("Calling thread: {0}", Thread.CurrentThread.ManagedThreadId);

            immediateScheduler.Schedule(Unit.Default,
                (s, _) =>
                {
                    Console.WriteLine("Action1 - Thread:{0}", Thread.CurrentThread.ManagedThreadId);
                    countdownEvent.Signal();
                });
            immediateScheduler.Schedule(Unit.Default,
                (s, _) =>
                {
                    Console.WriteLine("Action2 - Thread:{0}", Thread.CurrentThread.ManagedThreadId);
                    countdownEvent.Signal();
                });
            countdownEvent.Wait();
        }

        private static void EventLoopSchedulerExample()
        {
            Tovar.DisplayHeader("EventLoopScheduler - Создает назначенный поток, который будет выполнять все запланированные действия.");

            var eventLoopScheduler = new EventLoopScheduler();

            var countdownEvent = new CountdownEvent(2);

            Console.WriteLine("Calling thread: {0}", Thread.CurrentThread.ManagedThreadId);

            eventLoopScheduler.Schedule(Unit.Default,
                (s, _) =>
                {
                    Console.WriteLine("Action1 - Thread:{0}", Thread.CurrentThread.ManagedThreadId);
                    countdownEvent.Signal();
                });
            eventLoopScheduler.Schedule(Unit.Default,
                (s, _) =>
                {
                    Console.WriteLine("Action2 - Thread:{0}", Thread.CurrentThread.ManagedThreadId);
                    countdownEvent.Signal();
                });
            countdownEvent.Wait();
        }
    }
}