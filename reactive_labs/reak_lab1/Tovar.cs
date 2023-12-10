using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace reak_lab1
{
    class Tovar
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
        public void Info()
        {
            Console.WriteLine($" {id} <=> '{tovar_name}' <=> {vid} <=> {price} <=> postavshchik: {postavshik} <=> srok: {srok} <=> {kolichestvo}");
        }

        // 2. по каждому названию товара – перечень фирм-покупателей с указанием сведений о количестве единиц и стоимости купленного ими товара по каждой фирме-покупателю;
        public static void Firm_pok(List<Sdelki> sd)
        {
            var pok = sd.GroupBy(k => new { k.pokupatel, k.tovar.tovar_name }).AsParallel()
              .Select(t => new
              {
                  name = t.Select(w => w.tovar.tovar_name).First(),
                  firma = t.Select(w => w.pokupatel).First(),
                  kolichestvo = t.Select(w => w.kolichestvo).Sum(),
                  price = t.Select(w => w.tovar.price * w.kolichestvo).Sum()
              });
            foreach (var n in pok)
            {
                Console.WriteLine();
                Console.WriteLine($" @Nazmvanie tovara = '{n.name}'   \n @Optovaya firma pokupatel  = '{n.firma}' \n @Kolichestvo prodannykh yedinits = '{n.kolichestvo}' \n @Price = '{n.price}'  ");
            }
        }
    }
}
