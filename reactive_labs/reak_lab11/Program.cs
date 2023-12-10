using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace reak_lab11
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

            Retry();
            OnErrorResumeNext(tovars[0]);
            CatchingSpecificExceptionType();
            BasicOnError();
            ExceptionInOnNext();

            Console.ReadKey();
        }

        //Оператор Retry переподписывает наблюдателя на наблюдаемую при возникновении ошибки. 
        private static void Retry()
        {
            Tovar.DisplayHeader("Retry operator");

            IObservable<Tovar> tv1 =
              Observable.Throw<Tovar>(new OutOfMemoryException());

            tv1
                .Log()
                .Retry(3)
                .SubscribeConsole("Retry");
        }

        private static void OnErrorResumeNext(Tovar tv)
        {
            Tovar.DisplayHeader("OnErrorResumeNext operator - соединит вторую наблюдаемую, когда первая завершит или выбросит");

            IObservable<string> tv1 =
              Observable.Throw<string>(new OutOfMemoryException());

            IObservable<string> tv2 =
              Observable.Return(tv.tovar_name);

            tv1
                .OnErrorResumeNext(tv2)
                .SubscribeConsole("OnErrorResumeNext(источник бросает)");

            tv2
                .OnErrorResumeNext(tv2)
                .SubscribeConsole("OnErrorResumeNext(источник завершен)");

        }

        //Оператор Catch объединяет наблюдаемые объекты в случае возникновения ошибки. 
        private static void CatchingSpecificExceptionType()
        {
            Tovar.DisplayHeader("Catch operator");

            IObservable<Tovar> tvRes =
              Observable.Throw<Tovar>(new OutOfMemoryException());

            tvRes
                .Catch((OutOfMemoryException ex) =>
                {
                    Console.WriteLine("обработка исключения OOM");
                    return Observable.Empty<Tovar>();
                })
                .SubscribeConsole("Catch (источник бросает)");

            //Catch не ограничивается одним типом исключения, он может быть общим для ВСЕХ исключений
            tvRes
                .Catch(Observable.Empty<Tovar>())
                .SubscribeConsole("Catch (обработка всех типов исключений)");

            //если исходный наблюдаемый объект завершился успешно, то оператор Catch не действует (в отличие от OnErrorResumeNext)
            Observable.Return(1)
                .Catch(Observable.Empty<int>())
                .SubscribeConsole("Catch (источник успешно завершен)");
        }

        private static void BasicOnError()
        {
            Tovar.DisplayHeader("Basic OnError");

            // Это самый простой способ работы с OnError.
            // Но это не идеально kak оператор 'Catch'
            IObservable<Tovar> tvRes =
                Observable.Throw<Tovar>(new OutOfMemoryException());

            tvRes
                .Subscribe(
                    _ => { },
                    e =>
                    {
                        if (e is OutOfMemoryException)
                        {
                            //последняя попытка освободить часть памяти
                            GCSettings.LargeObjectHeapCompactionMode =
                                GCLargeObjectHeapCompactionMode.CompactOnce;
                            GC.Collect();
                            GC.WaitForPendingFinalizers();

                            Console.WriteLine("GC Done");
                        }
                    });
        }

        private static void ExceptionInOnNext()
        {
            Tovar.DisplayHeader("Throwing exception in OnNext() - это остановит процесс, нажмите любую клавишу, чтобы продолжить");
            Console.ReadLine();

            Observable.Interval(TimeSpan.FromMilliseconds(50))
                .Subscribe(
                    x => { throw new Exception("Exception in OnNext"); },
                    e =>
                    {
                        /*мы не попадем сюда, так как исключение возникло в наблюдателе*/
                    });
        }
    }
}