using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace reak_lab11
{
    public static class Tools
    {
        public static IDisposable SubscribeConsole<T>(this IObservable<T> observable, string name = "")
        {
            return observable.Subscribe(new QueryTovar<T>(name));
        }

        public static IDisposable SubscribeTheConsole<T>(this IObservable<T> observable, string name = "")
        {
            return observable.Subscribe(
                x => Console.WriteLine("{0} - OnNext({1})", name, x),
                ex =>
                {
                    Console.WriteLine("{0} - OnError:", name);
                    Console.WriteLine("\t {0}", ex);
                },
                () => Console.WriteLine("{0} - OnCompleted()", name));
        }

        public static IObservable<T> Log<T>(this IObservable<T> observable, string msg = "")
        {
            return observable.Do(
                x => Console.WriteLine("{0} - OnNext({1})", msg, x),
                ex =>
                {
                    Console.WriteLine("{0} - OnError:", msg);
                    Console.WriteLine("\t {0}", ex);
                },
                () => Console.WriteLine("{0} - OnCompleted()", msg));
        }

        public static IObservable<T> DoLast<T>(this IObservable<T> observable, Action lastAction, TimeSpan? delay = null)
        {
            Action delayedLastAction = async () =>
            {
                if (delay.HasValue)
                {
                    await Task.Delay(delay.Value);
                }
                lastAction();
            };
            return observable.Do(
                (_) => { },//empty OnNext
                _ => delayedLastAction(),
                delayedLastAction);
        }

        public static void RunExample<T>(this IObservable<T> observable, string exampleName = "")
        {
            var exampleResetEvent = new AutoResetEvent(false);

            observable
                 .DoLast(() => exampleResetEvent.Set(), TimeSpan.FromSeconds(3))
                 .SubscribeConsole(exampleName);

            exampleResetEvent.WaitOne();
        }
    }

    public static partial class ObservableEx
    {
        public static IObservable<T> FromValues<T>(params T[] values)
        {
            return values.ToObservable();
        }
    }
}
