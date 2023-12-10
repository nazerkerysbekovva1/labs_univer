using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Reactive.Disposables;

namespace reak_lab8
{
    struct Tovar
    {
        public int id;
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
        public void Info(Tovar t)
        {
            Console.WriteLine($" {t.id} <=> '{t.tovar_name}' <=> {t.vid} <=> {t.price} <=> postavshchik: {t.postavshik} <=> srok: {t.srok} <=> {t.kolichestvo}");
        }

        public static void DisplayHeader(string header)
        {
            Console.WriteLine();
            Console.WriteLine("---- {0} ----", header);
        }
    }
}
