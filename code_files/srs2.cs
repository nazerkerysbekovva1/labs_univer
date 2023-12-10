using System;
using System.Collections.Generic;
using System.Linq;

namespace srs2
{
    class Makler
    {
        public int id;
        public string name;
        public string address;
        public int year_of_birth;
        public Makler(int maklerId, string name_Makler, string address_Makler, int year_of_birth)
        {
            id = maklerId;
            name = name_Makler;
            address = address_Makler;
            this.year_of_birth = year_of_birth;
        }

        public void Info()
        {
            Console.WriteLine($" {id} <=> {name} <=> {address} <=> year_of_birth: {year_of_birth}");
        }

        // 4. по маклеру, совершившему максимальное количество сделок, – сведения о нем и фирмах-поставщиках; +
        public static void Sdelok(List<Sdelki> sd, List<Makler> mk)
        {
            List<int> list = new List<int>();
            foreach (var mak in mk)
            {
                var makler = sd.Where(n => n.name_makler == mak.name).Select(d => d).Count();
                list.Add(makler);
            }
            int max = list.Max();
            var maklerr = mk.Where(e => max == sd.Where(r => r.name_makler == e.name).AsParallel().Select(d => d).Count()).First();
            Console.WriteLine();
            Console.WriteLine($" @Makler Id = {maklerr.id} \n @Name Maklera = '{maklerr.name}'  \n @Address Maklera = '{maklerr.address}' \n @Year of birth = '{maklerr.year_of_birth}' \n @Optovaya firma postavshchik = '{maklerr}'");
        }
    }

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
            //  Select(t => new
            //{
            //    vid = t.Select(w => w.tovar.vid).First(),
            //    kolichestvo1 = t.Select(w => w.tovar.kolichestvo).Sum(),
            //    kolichestvo2 = t.Select(w => w.kolichestvo).Sum(),
            //    price = t.Select(w => w.tovar.price * w.kolichestvo).Sum(),
            //    pokupatel = t.Select(w => w.pokupatel).First()
            //});
            //var vid1 = vidd.GroupBy(o => o.pokupatel);
            // foreach (var n in vid1)
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

    class Program
    {
        static void Main(string[] args)
        {
            var maklers = new List<Makler>
            {
                new Makler(1, "Pirmetov Maksat", "Almaty", 1989),
                new Makler(2, "Abduhashim Darhan", "Astana", 1995),
                new Makler(3, "Kushanov Arslan", "Shymkent", 2000) };

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

            var sdelki = new List<Sdelki>
            {
                new Sdelki (1, new DateTime(2022,06,12), "Sisley", "Female", 3,"Pirmetov Maksat", "LV_1", maklers[0], tovars[0]),
                new Sdelki (2, new DateTime(2021,10,23), "Kenzo", "Female", 3, "Pirmetov Maksat", "LV_1", maklers[0], tovars[1]),
                new Sdelki (3, new DateTime(2021,11,23), "Cerruti", "Male", 3, "Kushanov Arslan", "Dolce&Gabana_2", maklers[2], tovars[2]),
                new Sdelki (3, new DateTime(2021,11,23), "Cerruti", "Male", 3, "Kushanov Arslan", "Dolce&Gabana_2", maklers[2], tovars[2]),//
                new Sdelki (4, new DateTime(2022,05,23), "Davidoff","Male", 3, "Pirmetov Maksat", "Dolce&Gabana_2", maklers[0], tovars[3]),
                new Sdelki (5, new DateTime(2022,11,23), "Bottega Veneta", "Female", 3, "Abduhashim Darhan", "Dior_3", maklers[1], tovars[4]),
                new Sdelki (6, new DateTime(2022,01,23),  "Calvin Klein", "Female", 3, "Kushanov Arslan", "Gucci_4", maklers[2], tovars[5]),
                new Sdelki (7, new DateTime(2022,03,23), "Comme Des Gargons", "Unisex", 3, "Kushanov Arslan", "Armani_5", maklers[2], tovars[6]),
                new Sdelki (8, new DateTime(2022,02,23), "Givenchy", "Unisex", 3, "Kushanov Arslan", "Armani_5",  maklers[1], tovars[7]),
                new Sdelki (9, new DateTime(2022,04,23), "Thierry Mugler","Perfume sets", 3, "Abduhashim Darhan", "Gucci_4", maklers[1], tovars[8]),
                new Sdelki (10, new DateTime(2022,01,23), "Lancome","Perfume sets",  3, "Kushanov Arslan", "LV_1", maklers[2], tovars[9]),
                new Sdelki (11, new DateTime(2022,06,13), "Sisley", "Female", 3,"Pirmetov Maksat", "LV_1", maklers[0], tovars[0]),
            };
            //Console.WriteLine("____________________database__________________");
            //Console.WriteLine("\n_______MAKLERS_______");
            //foreach (var s in maklers)
            //    s.Info();
            //Console.WriteLine("\n_______TOVARS_______");
            //foreach (var s in tovars)
            //    s.Info();
            //Console.WriteLine("\n_______SDELKI_______");
            //foreach (var s in sdelki)
            //    s.Info();
            //Console.WriteLine("\n______________________________________________");




            Console.WriteLine("\n\n-----1st query-----");
            Sdelki.Period(sdelki);

            Console.WriteLine("\n\n-----2nd query-----");
            Tovar.Firm_pok(sdelki);

            Console.WriteLine("\n\n-----3rd query-----");
            Sdelki.Vidd(sdelki, tovars);

            Console.WriteLine("\n\n-----4th query-----");
            Makler.Sdelok(sdelki, maklers);

            Console.WriteLine("\n\n-----5th query-----");
            Sdelki.Firm_post(sdelki);
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace srs2
//{
//    class Makler
//    {
//        public int id;
//        public string name;
//        public string address;
//        public int year_of_birth;
//        public Makler(int maklerId, string name_Makler, string address_Makler, int year_of_birth)
//        {
//            id = maklerId;
//            name = name_Makler;
//            address = address_Makler;
//            this.year_of_birth = year_of_birth;
//        }

//        public void Info()
//        {
//            Console.WriteLine($" {id} <=> {name} <=> {address} <=> year_of_birth: {year_of_birth}");
//        }

//        // 4. по маклеру, совершившему максимальное количество сделок, – сведения о нем и фирмах-поставщиках; +
//        public static void Sdelok(List<Sdelki> sd, List<Makler> mk)
//        {
//            List<int> list = new List<int>();
//            foreach (var mak in mk)
//            {
//                var makler = sd.Where(n => n.name_makler == mak.name).Select(d => d).Count();
//                list.Add(makler);
//            }
//            int max = list.Max();
//            var maklerr = mk.Where(e => max == sd.Where(r => r.name_makler == e.name).Select(d => d).Count()).First();
//            Console.WriteLine();
//            Console.WriteLine($" @Makler Id = {maklerr.id} \n @Name Maklera = '{maklerr.name}'  \n @Address Maklera = '{maklerr.address}' \n @Year of birth = '{maklerr.year_of_birth}' \n @Optovaya firma postavshchik = '{maklerr}'");
//        }
//    }

//    class Tovar
//    {
//        public int id;
//        public string tovar_name;
//        public string vid;
//        public int price;
//        public string postavshik;
//        public DateTime srok;
//        public int kolichestvo;
//        public Tovar(int tovarId, string name, string vid, int price, string optovaya_firma_postavshchik, DateTime srok_godnosti, int kolichestvo_postavlennykh_yedinits)
//        {
//            id = tovarId;
//            tovar_name = name;
//            this.vid = vid;
//            this.price = price;
//            postavshik = optovaya_firma_postavshchik;
//            srok = srok_godnosti;
//            kolichestvo = kolichestvo_postavlennykh_yedinits;
//        }
//        public void Info()
//        {
//            Console.WriteLine($" {id} <=> '{tovar_name}' <=> {vid} <=> {price} <=> postavshchik: {postavshik} <=> srok: {srok} <=> {kolichestvo}");
//        }

//        // 2. по каждому названию товара – перечень фирм-покупателей с указанием сведений о количестве единиц и стоимости купленного ими товара по каждой фирме-покупателю;
//        public static void Firm_pok(List<Sdelki> sd)
//        {
//            var pok = sd.GroupBy(k => new { k.pokupatel, k.tovar.tovar_name })
//              .Select(t => new
//              {
//                  name = t.Select(w => w.tovar.tovar_name).First(),
//                  firma = t.Select(w => w.pokupatel).First(),
//                  kolichestvo = t.Select(w => w.kolichestvo).Sum(),
//                  price = t.Select(w => w.tovar.price * w.kolichestvo).Sum()
//              });
//            foreach (var n in pok)
//            {
//                Console.WriteLine();
//                Console.WriteLine($" @Nazmvanie tovara = '{n.name}'   \n @Optovaya firma pokupatel  = '{n.firma}' \n @Kolichestvo prodannykh yedinits = '{n.kolichestvo}' \n @Price = '{n.price}'  ");
//            }
//        }
//    }

//    class Sdelki
//    {
//        public int id;
//        public DateTime data;
//        public string tovar_n;
//        public string vid;
//        public int kolichestvo;
//        public string name_makler;
//        public string pokupatel;
//        public Makler makler;
//        public Tovar tovar;
//        public Sdelki(int sdelkiId, DateTime data_sdelki, string name, string vid, int kolichestvo_prodannykh_yedinits, string makler_name, string optovaya_firma_pokupatel, Makler m, Tovar t)
//        {
//            id = sdelkiId;
//            data = data_sdelki;
//            tovar_n = name;
//            this.vid = vid;
//            kolichestvo = kolichestvo_prodannykh_yedinits;
//            name_makler = makler_name;
//            pokupatel = optovaya_firma_pokupatel;
//            makler = m;
//            tovar = t;
//        }
//        public void Info()
//        {
//            Console.WriteLine($" {id} <=> data_sdelki: {data} <=> {kolichestvo} <=> firma:{pokupatel} <=> Tovar:' {tovar.tovar_name}' <=> Makler: {makler.name}");
//        }

//        // 1. по каждому названию товара – сведения о проданном количестве и общей стоимости за указанный период;  +
//        public static void Period(List<Sdelki> sd)
//        {
//            DateTime d1 = new DateTime(2022, 03, 14);
//            DateTime d2 = new DateTime(2022, 06, 14);
//            var period = sd.Where(k => (d1 < k.data && k.data < d2)).GroupBy(y => y.tovar.tovar_name)
//                .Select(t => new
//                {
//                    id = t.Select(y => y.tovar.id).First(),
//                    name = t.Select(y => y.tovar.tovar_name).First(),
//                    kolichestvo = t.Select(y => y.kolichestvo).Sum(),
//                    obsh_stoimost = t.Sum(y => y.kolichestvo * y.tovar.price)
//                });
//            foreach (var n in period)
//            {
//                Console.WriteLine();
//                Console.WriteLine($" @Tovar Id = {n.id} \n @Nazvanie tovara = '{n.name}'  \n @Kolichestvo prodannykh yedinits = '{n.kolichestvo}' \n @Obshaia summa = '{n.obsh_stoimost}'");
//            }
//        }

//        // 3. по виду товара, пользующемуся наибольшим спросом, – сведения о количестве и стоимости проданного товара по каждой фирме-покупателю
//        public static void Vidd(List<Sdelki> sd, List<Tovar> tv)
//        {
//            List<int> list = new List<int>();
//            foreach (var tov in tv)
//            {
//                var tovar = sd.Where(n => n.vid == tov.vid).Select(d => d).Count();
//                list.Add(tovar);
//            }
//            int max = list.Max();
//            var tovarr = tv.GroupBy(k => k.vid).Where(e => max == sd.Where(r => r.vid == e.Key).Select(d => d).Count()).First();
//            //  Select(t => new
//            //{
//            //    vid = t.Select(w => w.tovar.vid).First(),
//            //    kolichestvo1 = t.Select(w => w.tovar.kolichestvo).Sum(),
//            //    kolichestvo2 = t.Select(w => w.kolichestvo).Sum(),
//            //    price = t.Select(w => w.tovar.price * w.kolichestvo).Sum(),
//            //    pokupatel = t.Select(w => w.pokupatel).First()
//            //});
//            //var vid1 = vidd.GroupBy(o => o.pokupatel);
//            // foreach (var n in vid1)
//            {
//                Console.WriteLine();
//                Console.WriteLine($" @Vid tovara = '{tovarr.Key}' \n @Kolichestvo postavlennykh yedinits  = '{tovarr.Select(s => s.kolichestvo).Sum()}' \n @Optovaya firma pokupatel = '{tovarr.Select(s => s.postavshik).First()}'  \n @Price = '{tovarr.Select(h => h.price * h.kolichestvo).Sum()}'  ");
//            }
//        }

//        // 5. по каждой фирме-поставщику – список маклеров с указанием све-дений о количестве и стоимости проданного ими товара по каждому маклеру.  
//        public static void Firm_post(List<Sdelki> sd)
//        {
//            var period = sd.GroupBy(k => new { k.tovar.postavshik, k.makler.id })
//                .Select(t => new
//                {
//                    post = t.Select(w => w.tovar.postavshik).First(),
//                    id = t.Select(w => w.makler.id).First(),
//                    makler = t.Select(w => w.makler.name).First(),
//                    tovar = t.Select(w => w.tovar.tovar_name).First(),
//                    kolichestvo = t.Select(w => w.kolichestvo).Sum(),
//                    obsh_stoimost = t.Select(w => w.kolichestvo * w.tovar.price).Sum()
//                });
//            foreach (var n in period)
//            {
//                Console.WriteLine();
//                Console.WriteLine($" {n.post}   @Makler Id = '{n.id}' \n @Makler = '{n.makler}' \n @Nazvanie tovara = '{n.tovar}'  \n @Kolichestvo prodannykh yedinits = '{n.kolichestvo}' \n @Obshaia summa = '{n.obsh_stoimost}'");
//            }
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var maklers = new List<Makler>
//            {
//                new Makler(1, "Pirmetov Maksat", "Almaty", 1989),
//                new Makler(2, "Abduhashim Darhan", "Astana", 1995),
//                new Makler(3, "Kushanov Arslan", "Shymkent", 2000) };

//            var tovars = new List<Tovar>
//            {
//                new Tovar (1, "Sisley","Female", 7645,"P1", new DateTime(2025,02,07), 7),
//                new Tovar (2, "Kenzo", "Female", 2575, "P1", new DateTime(2025,02,07), 9),
//                new Tovar (3, "Cerruti", "Male", 4315, "P2",  new DateTime(2025,02,07), 12),
//                new Tovar (4, "Davidoff","Male", 3450,"P2", new DateTime(2025,02,07), 6),
//                new Tovar (5, "Bottega Veneta", "Female", 6685, "P3", new DateTime(2025,02,07), 10),
//                new Tovar (6, "Calvin Klein", "Female", 2285, "P4", new DateTime(2025,02,07), 8),
//                new Tovar (7, "Comme Des Gargons", "Unisex", 6700, "P5", new DateTime(2025,02,07), 7),
//                new Tovar (8, "Givenchy", "Unisex", 5630,"P5", new DateTime(2025,02,07), 11),
//                new Tovar (9, "Thierry Mugler","Perfume sets", 4635,"P4", new DateTime(2025,02,07), 8),
//                new Tovar (10, "Lancome","Perfume sets", 3800, "P1", new DateTime(2025,02,07), 9)
//            };

//            var sdelki = new List<Sdelki>
//            {
//                new Sdelki (1, new DateTime(2022,06,12), "Sisley", "Female", 3,"Pirmetov Maksat", "LV_1", maklers[0], tovars[0]),
//                new Sdelki (2, new DateTime(2021,10,23), "Kenzo", "Female", 3, "Pirmetov Maksat", "LV_1", maklers[0], tovars[1]),
//                new Sdelki (3, new DateTime(2021,11,23), "Cerruti", "Male", 3, "Kushanov Arslan", "Dolce&Gabana_2", maklers[2], tovars[2]),
//                new Sdelki (3, new DateTime(2021,11,23), "Cerruti", "Male", 3, "Kushanov Arslan", "Dolce&Gabana_2", maklers[2], tovars[2]),//
//                new Sdelki (4, new DateTime(2022,05,23), "Davidoff","Male", 3, "Pirmetov Maksat", "Dolce&Gabana_2", maklers[0], tovars[3]),
//                new Sdelki (5, new DateTime(2022,11,23), "Bottega Veneta", "Female", 3, "Abduhashim Darhan", "Dior_3", maklers[1], tovars[4]),
//                new Sdelki (6, new DateTime(2022,01,23),  "Calvin Klein", "Female", 3, "Kushanov Arslan", "Gucci_4", maklers[2], tovars[5]),
//                new Sdelki (7, new DateTime(2022,03,23), "Comme Des Gargons", "Unisex", 3, "Kushanov Arslan", "Armani_5", maklers[2], tovars[6]),
//                new Sdelki (8, new DateTime(2022,02,23), "Givenchy", "Unisex", 3, "Kushanov Arslan", "Armani_5",  maklers[1], tovars[7]),
//                new Sdelki (9, new DateTime(2022,04,23), "Thierry Mugler","Perfume sets", 3, "Abduhashim Darhan", "Gucci_4", maklers[1], tovars[8]),
//                new Sdelki (10, new DateTime(2022,01,23), "Lancome","Perfume sets",  3, "Kushanov Arslan", "LV_1", maklers[2], tovars[9]),
//                new Sdelki (11, new DateTime(2022,06,13), "Sisley", "Female", 3,"Pirmetov Maksat", "LV_1", maklers[0], tovars[0]),
//            };
//            //Console.WriteLine("____________________database__________________");
//            //Console.WriteLine("\n_______MAKLERS_______");
//            //foreach (var s in maklers)
//            //    s.Info();
//            //Console.WriteLine("\n_______TOVARS_______");
//            //foreach (var s in tovars)
//            //    s.Info();
//            //Console.WriteLine("\n_______SDELKI_______");
//            //foreach (var s in sdelki)
//            //    s.Info();
//            //Console.WriteLine("\n______________________________________________");




//            Console.WriteLine("\n\n-----1st query-----");
//            Sdelki.Period(sdelki);

//            Console.WriteLine("\n\n-----2nd query-----");
//            Tovar.Firm_pok(sdelki);

//            Console.WriteLine("\n\n-----3rd query-----");
//            Sdelki.Vidd(sdelki, tovars);

//            Console.WriteLine("\n\n-----4th query-----");
//            Makler.Sdelok(sdelki, maklers);

//            Console.WriteLine("\n\n-----5th query-----");
//            Sdelki.Firm_post(sdelki);
//        }
//    }
//}