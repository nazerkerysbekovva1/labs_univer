using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace reak_PERFUMERY
{
    class Sdelki
    {
        public int id;
        public DateTime data;
        public string tovar_n;
        public string vid;
        public int kolichestvo;
        public string name_makler;
        public string pokupatel;
        public Makler makler;
        public Tovar tovar;
        public Sdelki(int sdelkiId, DateTime data_sdelki, string name, string vid, int kolichestvo_prodannykh_yedinits, string makler_name, string optovaya_firma_pokupatel, Makler m, Tovar t)
        {
            id = sdelkiId;
            data = data_sdelki;
            tovar_n = name;
            this.vid = vid;
            kolichestvo = kolichestvo_prodannykh_yedinits;
            name_makler = makler_name;
            pokupatel = optovaya_firma_pokupatel;
            makler = m;
            tovar = t;
        }
        public void Info()
        {
            Console.WriteLine($" {id} <=> data_sdelki: {data} <=> {kolichestvo} <=> firma:{pokupatel} <=> Tovar:' {tovar.tovar_name}' <=> Makler: {makler.name}");
        }

        // 1. по каждому названию товара – сведения о проданном количестве и общей стоимости за указанный период;  +
        public static void Period(List<Sdelki> sd)
        {
            DateTime d1 = new DateTime(2022, 03, 14);
            DateTime d2 = new DateTime(2022, 06, 14);
            var period = sd.Where(k => (d1 < k.data && k.data < d2)).GroupBy(y => y.tovar.tovar_name).AsParallel()
                .Select(t => new
                {
                    id = t.Select(y => y.tovar.id).First(),
                    name = t.Select(y => y.tovar.tovar_name).First(),
                    kolichestvo = t.Select(y => y.kolichestvo).Sum(),
                    obsh_stoimost = t.Sum(y => y.kolichestvo * y.tovar.price)
                });
            foreach (var n in period)
            {
                Console.WriteLine();
                Console.WriteLine($" @Tovar Id = {n.id} \n @Nazvanie tovara = '{n.name}'  \n @Kolichestvo prodannykh yedinits = '{n.kolichestvo}' \n @Obshaia summa = '{n.obsh_stoimost}'");
            }
        }

        // 3. по виду товара, пользующемуся наибольшим спросом, – сведения о количестве и стоимости проданного товара по каждой фирме-покупателю
        public static void Vidd(List<Sdelki> sd, List<Tovar> tv)
        {
            List<int> list = new List<int>();
            foreach (var tov in tv)
            {
                var tovar = sd.Where(n => n.vid == tov.vid).Select(d => d).Count();
                list.Add(tovar);
            }
            int max = list.Max();
            var tovarr = tv.GroupBy(k => k.vid).Where(e => max == sd.Where(r => r.vid == e.Key).AsParallel().Select(d => d).Count()).First();
            {
                Console.WriteLine();
                Console.WriteLine($" @Vid tovara = '{tovarr.Key}' \n @Kolichestvo postavlennykh yedinits  = '{tovarr.Select(s => s.kolichestvo).Sum()}' \n @Optovaya firma pokupatel = '{tovarr.Select(s => s.postavshik).First()}'  \n @Price = '{tovarr.Select(h => h.price * h.kolichestvo).Sum()}'  ");
            }
        }

        // 5. по каждой фирме-поставщику – список маклеров с указанием све-дений о количестве и стоимости проданного ими товара по каждому маклеру.  
        public static void Firm_post(List<Sdelki> sd)
        {
            var period = sd.GroupBy(k => new { k.tovar.postavshik, k.makler.id }).AsParallel()
                .Select(t => new
                {
                    post = t.Select(w => w.tovar.postavshik).First(),
                    id = t.Select(w => w.makler.id).First(),
                    makler = t.Select(w => w.makler.name).First(),
                    tovar = t.Select(w => w.tovar.tovar_name).First(),
                    kolichestvo = t.Select(w => w.kolichestvo).Sum(),
                    obsh_stoimost = t.Select(w => w.kolichestvo * w.tovar.price).Sum()
                });
            foreach (var n in period)
            {
                Console.WriteLine();
                Console.WriteLine($" {n.post}   @Makler Id = '{n.id}' \n @Makler = '{n.makler}' \n @Nazvanie tovara = '{n.tovar}'  \n @Kolichestvo prodannykh yedinits = '{n.kolichestvo}' \n @Obshaia summa = '{n.obsh_stoimost}'");
            }
        }
    }
}
