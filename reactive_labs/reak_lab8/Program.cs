using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using reak_lab8;
using System.Reactive.Subjects;
using System.Xml.Linq;

namespace reak_lab8
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
            var tovars2 = tovars.ToArray();

            Distinct(tovars2);
            Selecting();
            SelectMany();
            MaxAndMin(tovars2);

            Console.ReadKey();
        }

        private static void Distinct(Tovar[] tv) 
        {
            Tovar.DisplayHeader("The Distinct operator - фильтрует значения, которые уже были выданы наблюдаемым объектом.");

            var subject = new Subject<string>();
            subject.Log()
                .Distinct()
                .SubscribeConsole("Distinct");

            subject.OnNext(tv[0].tovar_name);
            subject.OnNext(tv[1].tovar_name);
            subject.OnNext(tv[2].tovar_name);
            subject.OnNext(tv[3].tovar_name);
            subject.OnNext(tv[4].tovar_name);
            subject.OnCompleted();
        }

        private static void Selecting()
        {
            Tovar.DisplayHeader("The Select operator - принимая только некоторые свойства в Tovar");

            Observable.Interval(TimeSpan.FromMilliseconds(500)).Take(3)
                .Select(i => new Tovar(10, "Lancome", "Perfume sets", 3800, "P1", new DateTime(2025, 02, 07), 9))
                .Select(m => new { Id = m.id, Name = m.tovar_name, LocalTime = m.srok.ToLocalTime() })
                .Log()
                .Wait();
        }

        private static void SelectMany()
        {
            Tovar.DisplayHeader("The SelectMany operator - добавляется автоматически новый Tovar");
            var theTovars = new[]
            {
                new Tovar {
                    id = 7,
                    tovar_name = "Comme Des Gargons",
                    vid = "Unisex",
                    price = 6700,
                    postavshik = "P5",
                    srok = new DateTime(2025,02,07),
                    kolichestvo = 7},
               new Tovar {
                    id = 4,
                    tovar_name = "Davidoff",
                    vid = "Male",
                    price = 3450,
                    postavshik = "P2",
                    srok = new DateTime(2025,02,07),
                    kolichestvo = 6},
            };

            IObservable<Tovar> tt = theTovars.ToObservable();
            tt.ForEach(x => Console.WriteLine("-> new Tovar - {0},  count of tovara - {1},  obshaia summa - {2}", x.tovar_name, x.kolichestvo, (x.price * x.kolichestvo)));
        }

        private static void MaxAndMin(Tovar[] tv)
        {
            Tovar.DisplayHeader("The Max and Min operators");;

            Subject<Tovar> price = new Subject<Tovar>();
            price.Max(g => g.price)
                .SubscribeTheConsole("Max");
            price.Min(g => g.price)
                .SubscribeTheConsole("Min");

            price.OnNext(tv[0]);
            price.OnNext(tv[1]);
            price.OnNext(tv[2]);
            price.OnNext(tv[3]);
            price.OnNext(tv[4]);
            price.OnCompleted();
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