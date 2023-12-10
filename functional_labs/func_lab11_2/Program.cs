using func_lab11_2;
using System.Linq;
using LaYumba.Functional;

namespace func_lab11_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Sportsmen> sportsmens = new List<Sportsmen>()
            {
                new Sportsmen(1, "Нурадин Б", "Плавание", 50,"0"),
                new Sportsmen(2, "Омирбек А", "Таеквандо", 42,"0"),
                new Sportsmen(3, "Бекдаулет М", "Таеквандо", 35,"0"),
                new Sportsmen(4, "Аскерова А", "Таеквандо", 37,"0"),
                new Sportsmen(5, "Камараддин Р", "Бокс", 48,"0"),
                new Sportsmen(6, "Бектаева Ж", "Бокс", 52,"0"),
                new Sportsmen(7, "Абдимбекова А", "Плавание", 41,"0"),
                new Sportsmen(8, "Алирахимов Р", "Футбол", 60,"0"),
                new Sportsmen(9, "Болатбек Б", "Футбол", 58,"0"),
                new Sportsmen(10, "Самимолла У", "Футбол", 64,"0")
            };

            Console.WriteLine("\n-------------------------------------------------------");
            Lazy<int> lazy = new Lazy<int>(() =>
            {
                Console.WriteLine("_calculating...");
                return 42;
            });
            Console.WriteLine("starting...");
            Console.WriteLine("result = {0}", lazy.Value);
            Console.WriteLine("result (again) = {0}", lazy.Value);


            Console.WriteLine("\n-------------------------------------------------------");
            int integer = 100;
            foreach (var i in sportsmens)
            {
                var lazy2 = Lazy.New(() =>
                {
                    Console.WriteLine("_calculating...");
                    return new { Mul = i.id_sportsman * integer };
                });
                Console.WriteLine("{0} New ID for DataBase = {1}", i.sportsman_name, lazy2.Value.Mul);
            }

            Console.WriteLine("\n_calculating integer and the weights...");
            foreach (var i in sportsmens)
            {
                var lazy2 = Lazy.New(() =>
                {
                    return new { Mul = i.the_weight * integer, Sum = i.the_weight + integer };
                });
                Console.WriteLine("Mul = {0}, Sum = {1}",
                  lazy2.Value.Mul, lazy2.Value.Sum);
            }

            Console.WriteLine("\n-------------------------------------------------------"); ;
            var id_count = sportsmens.Select(h => h.id_sportsman).Count();
            var weight_sum = sportsmens.Select(h => h.the_weight).Sum();

            var calc1 = Lazy.New(() =>
            {
                Console.WriteLine("_Calculating #1");
                return id_count;
            });
            var calc2 = Lazy.New(() =>
            {
                Console.WriteLine("_Calculating #2");
                return weight_sum;
            });
            UseRandomArgument(calc1, calc2);
            UseRandomArgument(calc1, calc2);

            Console.WriteLine("\n-------------------------------------------------------");
            var lazyGrandmaBlue = lazyGrandma.Map(turnBlue);
            Console.WriteLine(lazyGrandmaBlue());
        }

        static Random rnd = new Random();
        static void UseRandomArgument(Lazy<int> a0, Lazy<int> a1)
        {
            int res;
            if (rnd.Next(2) == 0)
                res = a0.Value;
            else
                res = a1.Value;
            Console.WriteLine("result = {0}", res);
        }

        static Func<string> lazyGrandma = () =>
         {
             Console.WriteLine("getting grandma...");
             return "grandma";
         };
        static Func<string, string> turnBlue = s =>
        {
            Console.WriteLine("turning blue...");
            return $"blue {s}";
        };
    }
}