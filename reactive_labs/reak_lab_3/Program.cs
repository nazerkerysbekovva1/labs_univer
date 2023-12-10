using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using reak_lab_3;

/* Цель:
•	Сочетание C# с функциональными методами
•	Использование делегатов и лямбда-выражений
•	Запрос коллекций с помощью LINQ
*/
namespace reak_lab_3
{
    class Program
    {
        public delegate bool ComparisonTest(string first, string second); //bool типты делегат, bool типты функцияларды шакыру ушын
        public delegate void ActionDelegate(); //void типты делегат

        static void Main(string[] args)
        {
            List<Tovar> tv = new List<Tovar>()
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
                new Tovar (10, "Lancome","Perfume sets", 3800, "P1", new DateTime(2025,02,07), 9)};
            Console.WriteLine("   ---------");
            priceList(tv);
            Console.WriteLine("   ---------");
            Method_Action_and_Func(tv);
            Console.WriteLine("   ---------");
            Similar(tv);
            Console.WriteLine("   ---------");
            Firm_pok(tv);
        }
        private static void Method_Action_and_Func(List<Tovar> tv)
        {
            //Action аркылы товарлар туралы инфо шыгару
            Foreach.ForEach(tv, n => n.Info());
            Console.WriteLine("   ---------");
            //Func аркылы аиди жуп товарлардын аиди мен атын шыгару
            Foreach.ForEach(tv, n => Console.WriteLine($"id-{n.id} tovar is - {n.tovar_name}"), n => (n.id % 2 == 0));
        }

        private static void Similar(List<Tovar> tv) //Товарлардын аттары мен вид тарынын уксастыгын аныктаитын метод
        {
            List<string> tovar, vid;
            vid = new List<string>(); tovar = new List<string>(); //жанадан 2 тызым курып аламыз
            foreach (var t in tv)
            {
                tovar.Add(t.tovar_name);  //tv обьектылер тызымынен тек аттары мен вид турлерын тызымге жинактаимыз
                vid.Add(t.vid);
            }
            string[] tovar_name = tovar.ToArray(); // массивке турлендыремыз
            string[] vidd = vid.ToArray();
            Console.WriteLine("Are tovar_names and vids similar? {0}", Tovar.AreSimilar(tovar_name, vidd, Tovar.CompareLength));
            //AreSimilar функциясынын шакырылуы, бул жерде делегат обьектысы ретынде CompareLength функциясы
        }

        private static void priceList(List<Tovar> tv)//курделы аукымды аинымалыларды колдану ушын жасалган метод
        {
            var actions = new List<ActionDelegate>(); //ActionDelegate делегатынын жана экземплярынын тызымын жарияламыз
            foreach (var i in tv)
            { //цикл аркылы делегатка косып отырамыз: товар аты мен ценасын
                actions.Add(delegate () { Console.WriteLine("{0}--> {1}", i.tovar_name, i.price); });
            }
            foreach (var act in actions) act(); //консолга шыгарамыз
        }
        public static void Firm_pok(List<Tovar> tv)// сатылган товардын количесво-сы 9дан коп товарлардын аты мен ценасын шыгару
        {
            var pok = tv.Where(k => k.kolichestvo >= 9)
              .Select(t => new
              {
                  name = t.tovar_name,
                  kolichestvo = t.kolichestvo,
                  price = t.price * t.kolichestvo
              });
            foreach (var n in pok)
            {
                Console.WriteLine();
                Console.WriteLine($" @Nazmvanie tovara = '{n.name}'  \n @Kolichestvo prodannykh yedinits = '{n.kolichestvo}' \n @Price = '{n.price}'  ");
            }
        }
    }
}

/* Output:
     ---------
Sisley--> 7645
Kenzo--> 2575
Cerruti--> 4315
Davidoff--> 3450
Bottega Veneta--> 6685
Calvin Klein--> 2285
Comme Des Gargons--> 6700
Givenchy--> 5630
Thierry Mugler--> 4635
Lancome--> 3800
   ---------
 1 <=> 'Sisley' <=> Female <=> 7645 <=> postavshchik: P1 <=> srok: 07.02.2025 0:00:00 <=> 7
 2 <=> 'Kenzo' <=> Female <=> 2575 <=> postavshchik: P1 <=> srok: 07.02.2025 0:00:00 <=> 9
 3 <=> 'Cerruti' <=> Male <=> 4315 <=> postavshchik: P2 <=> srok: 07.02.2025 0:00:00 <=> 12
 4 <=> 'Davidoff' <=> Male <=> 3450 <=> postavshchik: P2 <=> srok: 07.02.2025 0:00:00 <=> 6
 5 <=> 'Bottega Veneta' <=> Female <=> 6685 <=> postavshchik: P3 <=> srok: 07.02.2025 0:00:00 <=> 10
 6 <=> 'Calvin Klein' <=> Female <=> 2285 <=> postavshchik: P4 <=> srok: 07.02.2025 0:00:00 <=> 8
 7 <=> 'Comme Des Gargons' <=> Unisex <=> 6700 <=> postavshchik: P5 <=> srok: 07.02.2025 0:00:00 <=> 7
 8 <=> 'Givenchy' <=> Unisex <=> 5630 <=> postavshchik: P5 <=> srok: 07.02.2025 0:00:00 <=> 11
 9 <=> 'Thierry Mugler' <=> Perfume sets <=> 4635 <=> postavshchik: P4 <=> srok: 07.02.2025 0:00:00 <=> 8
 10 <=> 'Lancome' <=> Perfume sets <=> 3800 <=> postavshchik: P1 <=> srok: 07.02.2025 0:00:00 <=> 9
   ---------
id-2 tovar is - Kenzo
id-4 tovar is - Davidoff
id-6 tovar is - Calvin Klein
id-8 tovar is - Givenchy
id-10 tovar is - Lancome
   ---------
Are tovar_names and vids similar? False
   ---------

 @Nazmvanie tovara = 'Kenzo'
 @Kolichestvo prodannykh yedinits = '9'
 @Price = '23175'

 @Nazmvanie tovara = 'Cerruti'
 @Kolichestvo prodannykh yedinits = '12'
 @Price = '51780'

 @Nazmvanie tovara = 'Bottega Veneta'
 @Kolichestvo prodannykh yedinits = '10'
 @Price = '66850'

 @Nazmvanie tovara = 'Givenchy'
 @Kolichestvo prodannykh yedinits = '11'
 @Price = '61930'

 @Nazmvanie tovara = 'Lancome'
 @Kolichestvo prodannykh yedinits = '9'
 @Price = '34200'

*/  