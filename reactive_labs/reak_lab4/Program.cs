using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using reak_lab4;

namespace reak_lab4
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
                new Tovar (4, "Davidoff","Male", 3450,"P2", new DateTime(2025,02,07), 6)
            };

            tovars.ForEach(x => Console.WriteLine(ListTovar(x)));
            Console.WriteLine();
            tovars.ForEach(x => EnforcingUnsubscribingObservers(x));
            Console.WriteLine();
            UsingObservableCreate();
            Console.WriteLine();
            tovars.ForEach(x => HandcraftedObservable(x));
            Console.ReadLine();
        }

        private static void UsingObservableCreate()
        {
            Console.WriteLine("\nUsing the Create operator");

            var numbers = ListTovar(new Tovar(5, "Bottega Veneta", "Female", 6685, "P3", new DateTime(2025, 02, 07), 10));

            numbers.SubscribeConsole();
        }


        public static IObservable<Tovar> ListTovar(Nullable<Tovar> tv)
        {
            return Observable.Create<Tovar>(observer =>
            {
                    if (!tv.HasValue)
                        observer.OnError(new UnknownException()); 
                    else
                        observer.OnNext(tv.Value); 

                observer.OnCompleted();
                return Disposable.Empty;
            });
        }

        private static void EnforcingUnsubscribingObservers(Tovar tv)
        {
            Console.WriteLine("\nПринудительная отмена подписки наблюдателей(OnCompleted / OnError)"); 
            IObservable<Tovar> TestObservable = new RegistryTovar();

            var Observer_1 = new QueryTovar<Tovar>("Query_1");
            var Observer_2 = new QueryTovar<Tovar>("Query_2");

            Console.WriteLine($"контракт не соблюдается в руководстве наблюдаемый");
            var subscription = TestObservable.Subscribe(Observer_2);

            Console.WriteLine();
            Console.WriteLine($"однако версия Observable.Create(...) обеспечивает");
            TestObservable =
                Observable.Create<Tovar>(o =>
                {
                    o.OnNext(tv);
                    o.OnError(new ApplicationException());
                    o.OnNext(tv);
                    o.OnCompleted();
                    o.OnNext(tv);
                    return Disposable.Empty;
                });
            subscription = TestObservable.Subscribe(Observer_1); 
            subscription = TestObservable.Subscribe(Observer_2);

        }

        private static void HandcraftedObservable(Tovar t)
        {
            Console.WriteLine("\nHandcrafted Observable");

            var tv = new RegistryTovar();
            var Observer = new QueryTovar<Tovar>("Query_last");
            var subscription = tv.Subscribe(new QueryTovar<Tovar>("Query___"));
            IObservable<Tovar> TestObservable =
                Observable.Create<Tovar>(o =>
                {
                    o.OnNext(t);
                    o.OnCompleted();
                    o.OnNext(t);
                    return Disposable.Empty;
                });
            subscription = TestObservable.Subscribe(Observer);
        }
    }

}