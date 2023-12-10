using srs_func_2;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace aw
{
    class Program
    {
        static void Main(string[] args)
        {
            Tovar t1 = new Tovar("Tovar1", "v1", 1230, "fp1", DateTime.Parse("2021-01-2"), 34);
            Tovar t2 = new Tovar("Tovar2", "v2", 1230, "fp2", DateTime.Parse("2021-01-2"), 43);
            Tovar t3 = new Tovar("Tovar3", "v3", 1230, "fp3", DateTime.Parse("2021-01-2"), 13);
            Tovar t4 = new Tovar("Tovar4", "v4", 1230, "fp4", DateTime.Parse("2021-01-2"), 13);
            Tovar t5 = new Tovar("Tovar5", "v5", 1230, "fp5", DateTime.Parse("2021-01-2"), 32);
            Tovar[] tovars = { t1, t2, t3, t4, t5 };

            Sdelka s1 = new Sdelka(DateTime.Parse("2021-01-2"), "Tovar1", "v1", 12, "Иван", "f1");
            Sdelka s2 = new Sdelka(DateTime.Parse("2021-01-2"), "Tovar2", "v2", 12, "Абылай", "f2");
            Sdelka s3 = new Sdelka(DateTime.Parse("2021-01-2"), "Tovar3", "v3", 12, "Жандлс", "f3");
            Sdelka s4 = new Sdelka(DateTime.Parse("2021-01-2"), "Tovar4", "v4", 12, "Айдос", "f4");
            Sdelka s5 = new Sdelka(DateTime.Parse("2021-01-2"), "Tovar5", "v5", 13, "Акмарал", "f5");
            Sdelka s6 = new Sdelka(DateTime.Parse("2021-01-2"), "Tovar4", "v4", 12, "Абылай", "f6");
            Sdelka s7 = new Sdelka(DateTime.Parse("2021-01-2"), "Tovar3", "v3", 12, "Жандлс", "f7");
            Sdelka s8 = new Sdelka(DateTime.Parse("2021-01-2"), "Tovar5", "v5", 12, "Абылай", "f1");
            Sdelka s9 = new Sdelka(DateTime.Parse("2021-01-2"), "Tovar2", "v2", 12, "Нурай", "f8");
            Sdelka s10 = new Sdelka(DateTime.Parse("2021-01-2"), "Tovar1", "v1", 12, "Айдос", "f9");
            Sdelka[] sdelkas = { s1, s2, s3, s5, s6, s7, s8, s9, s10 };


            Console.WriteLine("________________________________________________");
            Run_Ling(tovars, sdelkas);

            Console.WriteLine("________________________________________________");
            Run_Event();

            //var arrayInt = new TemplateTest<int>();

            //var arrayString = new TemplateTest<string>();
        }

        static void Run_Ling(Tovar[] tovars, Sdelka[] sdelkas)
        {
            IList<int> data = AsyncLing.SampleData();
            AsyncLing.LinqQuery(data);
            AsyncLing.ExtensionMethods(data);
            AsyncLing.UseCancellation(data);

            Console.WriteLine("------");
            Console.WriteLine("1-query");
            LingQuery.Select1(tovars, sdelkas);
            Console.WriteLine("2-query");
            LingQuery.Select2(sdelkas, tovars);

            Console.WriteLine("------");
            AsyncLing.Hypothenuse();
        }


        static void Run_Event()
        {
            var tv1 = new Order() { tv = "book", pr = 234, count = 4 };
            var tv2 = new Order() { tv = "copybook", pr = 50, count = 12 };
            var tv3 = new Order() { tv = "notebook", pr = 300, count = 7 };

            List<Order> tv = new List<Order>() { tv1, tv2, tv3 };

            var c1 = new Consumer("Consumer1");
            tv1.NewTovarInfo += c1.NewTovarIsHere;

            var c2 = new Consumer("Consumer2");
            tv1.NewTovarInfo += c2.NewTovarIsHere;

            tv2.NewTovarInfo += c2.NewTovarIsHere;

            tv3.NewTovarInfo += c2.NewTovarIsHere;

            tv3.NewTovarInfo += c1.NewTovarIsHere;

            tv1.NewTovar();
            tv2.NewTovar();
            tv3.NewTovar();

            //tv1.NewTovarInfo -= c2.NewTovarIsHere;
            //tv1.NewTovarInfo -= c1.NewTovarIsHere;
            tv1.Pricee();
            tv1.SumAll();

            Console.WriteLine("------");
            Order.Massiv(tv);
        }
    }
}


