using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using reak_lab5;

namespace reak_lab5
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

            RegistryTovar registr = new RegistryTovar();
            QueryTovar<Tovar> q1 = new QueryTovar<Tovar>("zapros 1"); 
            q1.Subscribe(registr); 
            QueryTovar<Tovar> q2 = new QueryTovar<Tovar>("zapros 2");
            q2.Subscribe(registr); 
            registr.ListTovar(new Tovar(1, "Sisley", "Female", 7645, "P1", new DateTime(2025, 02, 07), 7));
            registr.ListTovar(new Tovar(2, "Kenzo", "Female", 2575, "P1", new DateTime(2025, 02, 07), 9));
            q1.Unsubscribe();  
            registr.ListTovar(new Tovar(3, "Cerruti", "Male", 4315, "P2", new DateTime(2025, 02, 07), 12));
            registr.ListTovar(new Tovar(5, "Bottega Veneta", "Female", 6685, "P3", new DateTime(2025, 02, 07), 10));
            registr.End();

            
            GeneratingEnumerableAsynchronously(tovars).Wait();
            foreach (var t in tovars)
            {
            GeneratingWithObservable(tovars, t);
                GeneratingAsynchronously(tovars, t);
            }
            Console.WriteLine("Done");
            Console.ReadLine();

        }

        private static void GeneratingWithObservable(List<Tovar> tv, Tovar t)
        {
            Console.WriteLine("\nGenerating primes into observable ");

            var generator = new Tovar();

            var subscription = generator
                .GeneratePrimes_Sync(tv, t)
                .Timestamp()
                .SubscribeConsole("Generate observable");

            Console.WriteLine("Generation is done");
        }

        private async static Task GeneratingEnumerableAsynchronously(List<Tovar> tv)
        {
            Console.WriteLine("\nGenerating enumerable asynchronously");

            var generator = new Tovar();

            Console.WriteLine("\nit will takes a 10 seconds before anything will be printed");
            foreach (var prime in await generator.GenerateAsync(tv))
            {
                Console.Write(prime);
            }
        }

        private static void GeneratingAsynchronously(List<Tovar> tv, Tovar t)
        {
            Console.WriteLine("\nUsing observable");

            var generator = new Tovar();
            var primesObservable = generator.GeneratePrimes_ManualAsync(tv, t);
            //primesObservable = generator.GeneratePrimes_AsyncCreate(5);
            var subscription =
                primesObservable
                .SubscribeConsole("Info observable");

            Console.WriteLine("Proving we're not blocked. you can continue typing. type X to dispose and exit");
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "X")
                {
                    subscription.Dispose();
                    return;
                }

                Console.WriteLine("\t {0}", input);
            }
        }
    }
}
/*Output:
 * 
 zapros 1
: The name tovara is Sisley
zapros 2
: The name tovara is Sisley
zapros 1
: The name tovara is Kenzo
zapros 2
: The name tovara is Kenzo
zapros 2
: The name tovara is Cerruti
zapros 2
: The name tovara is Bottega Veneta
Request query ended by name on zapros 2.

Generating enumerable asynchronously

it will takes a 10 seconds before anything will be printed

 1 <=> 'Sisley' <=> Female <=> 7645
 1 <=> 'Sisley' <=> Female <=> 7645
 1 <=> 'Sisley' <=> Female <=> 7645
 1 <=> 'Sisley' <=> Female <=> 7645
 1 <=> 'Sisley' <=> Female <=> 7645
 1 <=> 'Sisley' <=> Female <=> 7645
 1 <=> 'Sisley' <=> Female <=> 7645
 1 <=> 'Sisley' <=> Female <=> 7645
 1 <=> 'Sisley' <=> Female <=> 7645
 1 <=> 'Sisley' <=> Female <=> 7645
Generating primes into observable
Generate observable
: The name tovara is Sisley@06.10.2022 12:59:17 +00:00
Generate observable
: The name tovara is Kenzo@06.10.2022 12:59:19 +00:00
Generate observable
: The name tovara is Cerruti@06.10.2022 12:59:21 +00:00
Generate observable
: The name tovara is Davidoff@06.10.2022 12:59:23 +00:00
Generate observable
: The name tovara is Bottega Veneta@06.10.2022 12:59:25 +00:00
Generate observable
: The name tovara is Calvin Klein@06.10.2022 12:59:27 +00:00
Generate observable
: The name tovara is Comme Des Gargons@06.10.2022 12:59:29 +00:00
Generate observable
: The name tovara is Givenchy@06.10.2022 12:59:31 +00:00
Generate observable
: The name tovara is Thierry Mugler@06.10.2022 12:59:33 +00:00
Generate observable
: The name tovara is Lancome@06.10.2022 12:59:35 +00:00
Request query ended by name on Generate observable.
Generation is done

Using observable
Proving we're not blocked. you can continue typing. type X to dispose and exit
Info observable
: The name tovara is Sisley
Info observable
: The name tovara is Kenzo
Info observable
: The name tovara is Cerruti
Info observable
: The name tovara is Davidoff
Info observable
: The name tovara is Bottega Veneta
Info observable
: The name tovara is Calvin Klein
Info observable
: The name tovara is Comme Des Gargons
Info observable
: The name tovara is Givenchy
Info observable
: The name tovara is Thierry Mugler
Info observable
: The name tovara is Lancome
Request query ended by name on Info observable.


*/