using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using reak_lab9;
using System.Reactive.Subjects;
using System.Xml.Linq;
using System.Reactive.Threading.Tasks;
using System.Reflection;

namespace reak_lab9
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

            ZippingTwoObservables(tovars);
            MergingObservableOfObservables(tovars);
            CombineLatestExample();
            ConcatExample();

            Thread.Sleep(100);
            Tovar.DisplayHeader("The Buffer operator - можно использовать для замедления высокоскоростного потока, взяв его по частям");
                BufferingHiRateChatMessages(tovars[2]);

            Console.ReadKey();
        }

        private static void ZippingTwoObservables(List<Tovar> tv)
        {
            Tovar.DisplayHeader("The Zip operator - объединяет значения с одинаковым индексом из двух наблюдаемых");

            for (int i = 0; i < tv.Count; i++)
            {
                if (i % 2 != 0)
                {
                    //екы товардын сан мандеры - идентификатор, цена, количество.
                    IObservable<int> tv1 = ObservableEx.FromValues(tv[i - 1].id, tv[i - 1].price, tv[i - 1].kolichestvo);
                    IObservable<int> tv2 = ObservableEx.FromValues(tv[i].id, tv[i].price, tv[i].kolichestvo);

                    tv1
                        .Zip(tv2, (t1, t2) => (t1 + t2) / 2)
                        .SubscribeConsole("Avg: " + tv[i - 1].tovar_name + " <-> " + tv[i].tovar_name);
                }
            }
        }

        private static void MergingObservableOfObservables(List<Tovar> tv)
        {
            //подписывается на все наблюдаемые объекты и рассылает их уведомления по мере их поступления.
            Tovar.DisplayHeader("The Merge operator - позволяет также объединять наблюдаемые, испускаемые другими наблюдаемыми");

            tv.ForEach(x =>
            {
                //товардын аты, вид, поставщик
                IObservable<string> texts = ObservableEx.FromValues(x.tovar_name, x.vid, x.postavshik);
                texts
                    .Select(txt => Observable.Return(txt + "-Result"))
                    .Merge()
                    .SubscribeConsole("Merging from observable -> id tovar " + x.id);
            });
        }

        private static void CombineLatestExample() //ОбъединитьПоследние
        {
            Tovar.DisplayHeader("The CombineLatest operator - объединяет последние сгенерированные значения из каждой наблюдаемой с помощью функции выбора.");

            Subject<string> tovarName = new Subject<string>();
            Subject<int> kol = new Subject<int>();
            kol.CombineLatest(tovarName,
             (s, h) => String.Format("Name:{0} Kolichestvo:{1}", h, s))
             .SubscribeConsole("Counts");

            tovarName.OnNext("Givenchy");
            tovarName.OnNext("Lancome");
            tovarName.OnNext("Kenzo");
            kol.OnNext(30);
            kol.OnNext(31);
            tovarName.OnNext("Sisley");
            tovarName.OnNext("Davidoff");
        }

        private static void ConcatExample()
        {
            Tovar.DisplayHeader("The Concat operator - объединяет вторую наблюдаемую последовательность к первой наблюдаемой последовательности после успешного завершения первой.");

            Task<string[]> Lux = Task.Delay(10).ContinueWith(_ => new[] { "Calvin Klein", "Thierry Mugler", "Comme Des Gargons" });
            Task<string[]> Ordiniary = Task.FromResult(new[] { "Sisley", "Kenzo", "Cerruti" });
            Observable.Concat(Lux.ToObservable(),
             Ordiniary.ToObservable())
             .SelectMany(tovars => tovars)
             .SubscribeConsole("Concat Tovars");
        }

        private static void BufferingHiRateChatMessages(Tovar tv)
        {
           // Оператор Buffer разбивает наблюдаемую последовательность на ограниченные наборы и создает наблюдаемый из этих наборов.
            var coldMessages = Observable.Interval(TimeSpan.FromMilliseconds(20))
                .Take(3)
                .Select(x => "Tovar is " + x + " " + tv.tovar_name);

            IObservable<string> messages =
                coldMessages.Concat(
                     coldMessages.DelaySubscription(TimeSpan.FromMilliseconds(100)))
                    .Publish()
                    .RefCount();

            messages.Buffer(messages.Throttle(TimeSpan.FromMilliseconds(100)))
                    .SelectMany((b, i) => b.Select(m => string.Format("Buffer {0} - {1}", i, m)))
                    .RunExample("Query");

        }

        //private static void GroupJoin()
        //{
        //    Tovar.DisplayHeader("The GroupJoin operator - correlates elements from two observables based on overlapping duration windows and put them in a correlation group");

        //    Subject<Tovar> TVSubject = new Subject<Tovar>();
        //    IObservable<Tovar> Tov = TVSubject.AsObservable();

        //    var maleEntering = Tov.Where(x => x.vid == "Male");
        //    var femaleEntering = Tov.Where(x => x.vid == "Female");

        //    var maleExiting = Tov.Where(x => x.vid == "Male");
        //    var femaleExiting = Tov.Where(x => x.vid == "Female");

        //    var malesAcquaintances =
        //        maleEntering
        //            .GroupJoin(femaleEntering,
        //                male => maleExiting.Where(exit => exit.tovar_name == male.tovar_name),
        //                female => femaleExiting.Where(exit => exit.tovar_name == female.tovar_name),
        //                (m, females) => new { Male = m.tovar_name, Females = females });

        //    var amountPerUser =
        //        from acquinteces in malesAcquaintances
        //        from cnt in acquinteces.Females.Scan(0, (acc, curr) => acc + 1)
        //        select new { acquinteces.Male, cnt };

        //    amountPerUser.SubscribeConsole("Amount of meetings per User");

        //    //
        //    // Using Query Syntax GroupJoin clause
        //    //


        //    //amountPerUser2.SubscribeConsole("Amount of meetings per User (query syntax)");

        //    //This is the sequence you see in Figure 9.8
        //    TVSubject.OnNext(new Tovar(1, "Sisley", "Female", 7645, "P1", new DateTime(2025, 02, 07), 7));
        //    TVSubject.OnNext(new Tovar(2, "Kenzo", "Female", 2575, "P1", new DateTime(2025, 02, 07), 9));
        //    TVSubject.OnNext(new Tovar(3, "Cerruti", "Male", 4315, "P2", new DateTime(2025, 02, 07), 12));
        //    TVSubject.OnNext(new Tovar(4, "Davidoff", "Male", 3450, "P2", new DateTime(2025, 02, 07), 6));
        //    TVSubject.OnNext(new Tovar(5, "Bottega Veneta", "Female", 6685, "P3", new DateTime(2025, 02, 07), 10));
        //    TVSubject.OnNext(new Tovar(6, "Calvin Klein", "Female", 2285, "P4", new DateTime(2025, 02, 07), 8));
        //    TVSubject.OnNext(new Tovar(7, "Comme Des Gargons", "Unisex", 6700, "P5", new DateTime(2025, 02, 07), 7));
        //    TVSubject.OnNext(new Tovar(8, "Givenchy", "Unisex", 5630, "P5", new DateTime(2025, 02, 07), 11));
        //    TVSubject.OnNext(new Tovar(9, "Thierry Mugler", "Perfume sets", 4635, "P4", new DateTime(2025, 02, 07), 8));
        //    TVSubject.OnNext(new Tovar(10, "Lancome", "Perfume sets", 3800, "P1", new DateTime(2025, 02, 07), 9));
        //}
    }
}