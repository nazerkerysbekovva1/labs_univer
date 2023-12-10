using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using reak_lab7;
using System.Reactive.Subjects;

namespace reak_lab7
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

            SubjectExample();
            Console.WriteLine();
            ReplaySubjectExample();
            Console.WriteLine();
            AsyncSubjectExample();
            Console.WriteLine();
            TaskToObservableWithAsyncSubject();

            Console.WriteLine("\n\n");
            Multicast();
            Reconnecting(tovars[0]);
        }

        private static void SubjectExample()
        {

            Tovar.DisplayHeader("Subject - опубликовать уведомление, которое он наблюдает");

            Subject<Tovar> sbj = new Subject<Tovar>();

            sbj.SubscribeConsole("First");
            sbj.SubscribeConsole("Second");

            sbj.OnNext(new Tovar(5, "Bottega Veneta", "Female", 6685, "P3", new DateTime(2025, 02, 07), 10));
            sbj.OnNext(new Tovar(1, "Sisley", "Female", 7645, "P1", new DateTime(2025, 02, 07), 7));
            sbj.OnCompleted();
        }

        private static void ReplaySubjectExample()
        {
            Tovar.DisplayHeader("ReplaySubject - опубликовать все уведомления для текущих и будущих наблюдателей");

            ReplaySubject<Tovar> sbj = new ReplaySubject<Tovar>(bufferSize: 3, window: TimeSpan.FromSeconds(1));

            sbj.OnNext(new Tovar(4, "Davidoff", "Male", 3450, "P2", new DateTime(2025, 02, 07), 6));
            sbj.OnNext(new Tovar(5, "Bottega Veneta", "Female", 6685, "P3", new DateTime(2025, 02, 07), 10));
            sbj.OnNext(new Tovar(6, "Calvin Klein", "Female", 2285, "P4", new DateTime(2025, 02, 07), 8));
            sbj.OnNext(new Tovar(7, "Comme Des Gargons", "Unisex", 6700, "P5", new DateTime(2025, 02, 07), 7));
            var subscription = sbj.SubscribeConsole("Replay"); //only tovar 5,6,7 will be observed
            subscription.Dispose();

            Console.WriteLine("Sleeping for 1 sec");
            Thread.Sleep(1000);
            sbj.OnNext(new Tovar(1, "Sisley", "Female", 7645, "P1", new DateTime(2025, 02, 07), 7));

            sbj.SubscribeConsole("Replay2"); //only tovar1 will be observed - the only value in the last second
        }

        private static void AsyncSubjectExample()
        {
            Tovar.DisplayHeader("AsyncSubject - выдаст только последнее наблюдаемое значение");

            AsyncSubject<Tovar> sbj = new AsyncSubject<Tovar>();

            sbj.OnNext(new Tovar(8, "Givenchy", "Unisex", 5630, "P5", new DateTime(2025, 02, 07), 11));
            sbj.OnNext(new Tovar(9, "Thierry Mugler", "Perfume sets", 4635, "P4", new DateTime(2025, 02, 07), 8));
            sbj.OnCompleted();

            sbj.SubscribeConsole();
        }

        private static void TaskToObservableWithAsyncSubject()
        {
            Tovar.DisplayHeader("AsyncSubject - оператор Task.ToObservable() использует AsyncSubject");
            var tcs = new TaskCompletionSource<bool>();
            var task = tcs.Task;

            AsyncSubject<bool> sbj = new AsyncSubject<bool>();
            task.ContinueWith(t =>
            {
                switch (t.Status)
                {
                    case TaskStatus.RanToCompletion:
                        sbj.OnNext(t.Result);
                        sbj.OnCompleted();
                        break;
                    case TaskStatus.Faulted:
                        sbj.OnError(t.Exception.InnerException);
                        break;
                    case TaskStatus.Canceled:
                        sbj.OnError(new TaskCanceledException(t));
                        break;
                }
            }, TaskContinuationOptions.ExecuteSynchronously);
            tcs.SetResult(true);   // выполнение задачи до того, как наблюдатель подписался
            sbj.SubscribeConsole();
        }

        private static void Multicast()
        {
            var coldObservable = Observable.Interval(TimeSpan.FromSeconds(1)).Take(3);

            var observable =
                coldObservable.Multicast(
                    subjectSelector: () => new Subject<long>(),
                    selector: src => src.Zip(src, (a, b) => a + b));

            observable.SubscribeConsole();

        }

        private static void Reconnecting(Tovar tv)
        {
            Tovar.DisplayHeader("Повторное подключение подключаемой наблюдаемой");

            var connectableObservable =
                Observable.Defer(() => Tovar.Current.ObserveMessages(tv))
                    .Publish();

            connectableObservable.SubscribeConsole("Queries Screen");
            connectableObservable.SubscribeConsole("Queries Statistics");

            var subscription = connectableObservable.Connect();

            //После уведомления приложения об отключении сервера
            Console.WriteLine(" \n--Удаление текущего соединения и повторное подключение--");
            subscription.Dispose();
            subscription = connectableObservable.Connect();

            //ожидание завершения наблюдаемого
            Thread.Sleep(5000);
        }
    }
}
/*Output:
 * 
 * 
 ---- Subject - опубликовать уведомление, которое он наблюдает ----
First
: The name tovara is Bottega Veneta
Second
: The name tovara is Bottega Veneta
First
: The name tovara is Sisley
Second
: The name tovara is Sisley
Request query ended by name on First.
Request query ended by name on Second.


---- ReplaySubject - опубликовать все уведомления для текущих и будущих наблюдателей ----
Replay
: The name tovara is Bottega Veneta
Replay
: The name tovara is Calvin Klein
Replay
: The name tovara is Comme Des Gargons
Sleeping for 1 sec
Replay2
: The name tovara is Sisley


---- AsyncSubject - выдаст только последнее наблюдаемое значение ----

: The name tovara is Thierry Mugler
Request query ended by name on .


---- AsyncSubject - оператор Task.ToObservable() использует AsyncSubject ----

: The name tovara is True
Request query ended by name on .




---- Повторное подключение подключаемой наблюдаемой ----
Queries Screen
: The name tovara is TovarId --> 1 - Query1
Queries Statistics
: The name tovara is TovarId --> 1 - Query1
Queries Screen
: The name tovara is TovarId --> 1 - Query2
Queries Statistics
: The name tovara is TovarId --> 1 - Query2
Queries Screen
: The name tovara is TovarId --> 1 - Query3
Queries Statistics
: The name tovara is TovarId --> 1 - Query3

--Удаление текущего соединения и повторное подключение--
Queries Screen
: The name tovara is TovarId --> 1 - Query1
Queries Statistics
: The name tovara is TovarId --> 1 - Query1
Queries Screen
: The name tovara is TovarId --> 1 - Query2
Queries Statistics
: The name tovara is TovarId --> 1 - Query2
Queries Screen
: The name tovara is TovarId --> 1 - Query3
Queries Statistics
: The name tovara is TovarId --> 1 - Query3

: The name tovara is 0

: The name tovara is 2

: The name tovara is 4
Request query ended by name on .
*/