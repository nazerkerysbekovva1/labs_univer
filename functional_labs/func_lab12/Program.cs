//using System;
//using System.Collections.ObjectModel;
//using System.ComponentModel;
//using System.Diagnostics;
//using System.Linq;
//using ObservableComputations;

//namespace ObservableComputationsExamples
//{
//    public class Tovar : INotifyPropertyChanged
//    {
//        public event PropertyChangedEventHandler PropertyChanged;

//        public int Id { get; set; }
//        public string tovar_name { get; set; }
//        public string vid { get; set; }


//        private decimal price;
//        public decimal Price
//        {
//            get => price;
//            set
//            {
//                price = value;
//                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
//            }
//        }

//        public Tovar(int tovarId, string name, string vid, int price)
//        {
//            Id = tovarId;
//            tovar_name = name;
//            this.vid = vid;
//            this.price = price;
//        }
//        public static void Info(Tovar t) 
//        {
//            Console.WriteLine($" {t.Id} <=> '{t.tovar_name}' <=> {t.vid} <=> {t.price}");
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            ObservableCollection<Tovar> tovars =
//                new ObservableCollection<Tovar>(new[]
//                {
//                    new Tovar (1, "Sisley","Female", 26),
//                    new Tovar (2, "Kenzo", "Female", 39),
//                    new Tovar (3, "Cerruti", "Male", 35),
//                    new Tovar (4, "Davidoff","Male", 27),
//                    new Tovar (5, "Bottega Veneta", "Female", 30),
//                    new Tovar (6, "Calvin Klein", "Female", 75),
//                    new Tovar (7, "Comme Des Gargons", "Unisex", 100),

//                });

//            foreach(var i in tovars)
//                Tovar.Info(i);

//            OcConsumer consumer = new OcConsumer();

//            Filtering<Tovar> expensiveTovars =
//                tovars
//                .Filtering(o => o.Price > 25)
//                .For(consumer);

//            Debug.Assert(expensiveTovars is ObservableCollection<Tovar>);

//            Console.WriteLine("check");
//            checkFiltering(tovars, expensiveTovars); 

            
//            tovars.Add(new Tovar(8, "Givenchy", "Unisex", 30));
//            tovars.Add(new Tovar(9, "Thierry Mugler", "Perfume sets", 35));
//            tovars[0].Price = 60;
//            tovars[3].Price = 65;

//            expensiveTovars.CollectionChanged += (sender, eventArgs) =>
//            {		
//                checkFiltering(tovars, expensiveTovars);
//            };

//            Console.WriteLine("Check filter");

//            expensiveTovars =
//               tovars
//               .Filtering(o => o.Price > 35)
//               .For(consumer);

//            checkFiltering(tovars, expensiveTovars); 

//            Console.ReadLine();

//            consumer.Dispose();
//        }

//        static void checkFiltering(ObservableCollection<Tovar> tovars, Filtering<Tovar> expensiveTovars)
//        {
//            foreach (var i in tovars)
//            {
//                Console.WriteLine(i.Id+ "  ->  "+ expensiveTovars.SequenceEqual(
//                    tovars.Where(o => o.Price > 25)));
//            }
//        }
//    }
//}


using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LaYumba.Functional;
using static LaYumba.Functional.F;
using static ObservableComputationsExamples.Instrumentation;

namespace ObservableComputationsExamples
{
    using static Enumerable;
    public static class Instrumentation
    {
        public static T Time<T>(string op, Func<T> f)
        {
            var sw = new Stopwatch();
            sw.Start();
            T t = f();
            sw.Stop();
            Console.WriteLine($"{op} took {sw.ElapsedMilliseconds}ms");
            return t;
        }
    }

    public class Tovar : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }
        public string tovar_name { get; set; }
        public string vid { get; set; }


        private decimal price;
        public decimal Price
        {
            get => price;
            set
            {
                price = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
            }
        }

        public Tovar(int tovarId, string name, string vid, int price)
        {
            Id = tovarId;
            tovar_name = name;
            this.vid = vid;
            this.price = price;
        }
        public static void Info(Tovar t)
        {
            Console.WriteLine($" {t.Id} <=> '{t.tovar_name}' <=> {t.vid} <=> {t.price}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ObservableCollection<Tovar> tovars =
                new ObservableCollection<Tovar>(new[]
                {
                    new Tovar (1, "Sisley","Female", 26),
                    new Tovar (2, "Kenzo", "Female", 39),
                    new Tovar (3, "Cerruti", "Male", 35),
                    new Tovar (4, "Davidoff","Male", 27),
                    new Tovar (5, "Bottega Veneta", "Female", 30),
                    new Tovar (6, "Calvin Klein", "Female", 75),
                    new Tovar (7, "Comme Des Gargons", "Unisex", 100),

                });

            //foreach (var i in tovars)
            //    Tovar.Info(i);
            Console.WriteLine();

            Range(1, 2).ForEach(_ => 
            {
                Time($"{tovars[0].Price} + {tovars[1].Price}", () =>
                   (from a in Return(300, $"{tovars[0].Price}")
                    from b in Return(500, $"{tovars[1].Price}")
                    select a + b).Result
                   );
                Console.WriteLine(tovars[0].Price + tovars[1].Price);

                Time($"{tovars[0].Id} + {tovars[1].Id}", () =>
                   Return(300, $"{tovars[0].tovar_name}, {tovars[1].tovar_name}").
                   Map<string, string, string>((l, r) => l + r).
                   Apply(Return(500, $"{tovars[0].Id}")).Result);
                Console.WriteLine(tovars[0].Id + tovars[1].Id);
            });

            Console.WriteLine("Traverses:\n");

            Time("Applicative Traverse", () => // ~500 ms
               Range(1, 5).TraverseA(async i =>
               {
                   await Task.Delay(i * 100);
                   return i;
               })
               .Map(xs => xs.Sum())
               .Result);

            Time("Monadic Traverse", () => // ~1500 ms
               Range(1, 5).TraverseM(async i =>
               {
                   await Task.Delay(i * 100);
                   return i;
               })
               .Map(xs => xs.Sum())
               .Result);

        }

        static async Task<string> Return(int delay, string val)
        {
            await Task.Delay(delay);
            return val;
        }
    }
}