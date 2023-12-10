using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Reactive.Disposables;

namespace reak_lab7
{
    struct Tovar
    {
        public int id { get; set; }
        public string tovar_name;
        public string vid;
        public int price;
        public string postavshik;
        public DateTime srok;
        public int kolichestvo; 

        public Tovar(int tovarId, string name, string vid, int price, string optovaya_firma_postavshchik, DateTime srok_godnosti, int kolichestvo_postavlennykh_yedinits)
        {
            id = tovarId;
            tovar_name = name;
            this.vid = vid;
            this.price = price;
            postavshik = optovaya_firma_postavshchik;
            srok = srok_godnosti;
            kolichestvo = kolichestvo_postavlennykh_yedinits;
        }

        public static string Info(List<Tovar> tovars, int index)
        {
            Thread.Sleep(2000);

            if (index < tovars.Count())
                foreach(var t in tovars)
                    return  $"\n {t.id} <=> '{t.tovar_name}' <=> {t.vid} <=> {t.price} ";

            return tovars.Count().ToString();
        }

        public static IEnumerable<string> Generate(List<Tovar> tovars)
        {
            for (int i = 0; i < tovars.Count(); i++)
            {
                yield return Info(tovars, i);
            }
        }

        public static void DisplayHeader(string header)
        {
            Console.WriteLine();
            Console.WriteLine("---- {0} ----", header);
        }

        public static Tovar Current
        {
            get { return new Tovar(); }
        }

        public IObservable<string> ObserveMessages(Tovar tv)
        {
            return Observable.Never<string>().StartWith("Query1", "Query2", "Query3").Select(m => "TovarId --> " + tv.id + " - " + m);
            //«Never» используется, чтобы полученный наблюдаемый объект не был завершен, поэтому наблюдатели не будут отсоединены.
        }
    }
}
