using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labka14_1_
{
    class obsluzhivanie
    {
        public string adres;
        public int abonent;
        public DateTime firstdata;
        public DateTime interval1;
        public DateTime interval2;
        public string sostoyanie;
        public obsluzhivanie(string adres, int abonent, DateTime firstdata, DateTime interval1, DateTime interval2, string sostoyanie)
        {
            this.adres = adres;
            this.abonent = abonent;
            this.firstdata = firstdata;
            this.interval1 = interval1;
            this.interval2 = interval2;
            this.sostoyanie = sostoyanie;
        }
        public void Info()
        {
            Console.WriteLine($"Адрес:" + adres + "\n количество абонентов:" + abonent + "\n дата последнего обслуживания:" + firstdata + "\n интервал обслуживания в днях:" + interval1 + "   " + interval2 + "\n состояние системы:" + sostoyanie);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            obsluzhivanie[] o =
            {
                new obsluzhivanie("Zhansugyrova", 3, new DateTime(2021, 5, 10), new DateTime(2021,4,01),new DateTime(2021,7,1), "удолетворительно"),
                new obsluzhivanie("Abylaihana",3,new DateTime(2021,4,21), new DateTime(2021,4,01),new DateTime(2021,7,1),"хорошо"),
                new obsluzhivanie("Konaeva",3,new DateTime(2021,7,19), new DateTime(2021,4,01),new DateTime(2021,7,1),"отлично")
            };
            foreach (var A in o)
            {
                A.Info();
            }
            var S = o.Select(b => new { b.adres, latestdata = b.firstdata.AddDays(14) });
            Console.WriteLine("\n\n1st zapros");
            Console.WriteLine("-----------------------------");
            foreach (var days in S)
            {
                Console.WriteLine($"{days.adres},{days.latestdata}");
            }
            var S1 = o.Where(a => (a.interval1 <= a.firstdata && a.firstdata <= a.interval2)).Select(a=>new {a.adres, a.firstdata } );

            Console.WriteLine("\n\n2nd zapros");
            Console.WriteLine("-----------------------------");
            foreach (var d in S1)
            {
                Console.WriteLine($"{d.adres},{d.firstdata}");
            }
            Console.ReadKey();
        }
    }
}