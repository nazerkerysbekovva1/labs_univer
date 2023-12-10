using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Double = LaYumba.Functional.Double;
using LaYumba.Functional;

namespace aw
{
    internal class AsyncLing
    {
        public static IList<int> SampleData()
        {
            const int arraySize = 50000000;
            var r = new Random();
            return Enumerable.Range(0, arraySize).Select(x => r.Next(140)).ToList();
        }

        public static void LinqQuery(IEnumerable<int> data)
        {
            Console.WriteLine(nameof(LinqQuery));
            var res = (from x in data.AsParallel()
                       where Math.Log(x) < 4
                       select x).Average();
            Console.WriteLine($"result from {nameof(LinqQuery)}: {res}");
            Console.WriteLine();
        }

        public static void ExtensionMethods(IEnumerable<int> data)
        {
            Console.WriteLine(nameof(ExtensionMethods));
            var res = data.AsParallel()
                .Where(x => Math.Log(x) < 4)
                .Select(x => x).Average();

            Console.WriteLine($"result from {nameof(ExtensionMethods)}: {res}");
            Console.WriteLine();
        }

        public static void UseCancellation(IEnumerable<int> data)
        {
            Console.WriteLine(nameof(UseCancellation));
            var cts = new CancellationTokenSource();

            Task.Run(() =>
            {
                try
                {
                    var res = (from x in data.AsParallel().WithCancellation(cts.Token)
                               where Math.Log(x) < 4
                               select x).Average();

                    Console.WriteLine($"query finished, sum: {res}");
                }
                catch (OperationCanceledException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });

            Console.WriteLine("query started");
            Console.Write("cancel? ");
            string input = Console.ReadLine();
            if (input.ToLower().Equals("yes"))
            {
                cts.Cancel();
            }

            Console.WriteLine();
        }

        static string Prompt(string msg) //Prompt message, Быстрый
        {
            Console.WriteLine(msg);
            return Console.ReadLine();
        }

        public static void Hypothenuse()
        {
            string s1 = Prompt("1 катет:")
                 , s2 = Prompt("2 катет:");

            var result = from a in Double.Parse(s1)
                         where a >= 0
                         let aa = a * a

                         from b in Double.Parse(s2)
                         where b >= 0
                         let bb = b * b

                         select Math.Sqrt(aa + bb);

            Console.WriteLine(result.Match(
               () => "Пожалуйста, введите два действительных положительных числа",
               (h) => $"Гипотенуза = {h}"));
        }
    }
}
