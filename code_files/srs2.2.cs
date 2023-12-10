using System;
using System.Collections.Generic;
using System.Linq;

namespace srs2._2
{
    public class Program
    {
        public static void Main()
        {
            Makler m1 = new Makler("Иван", "Розыбакиева", 2018);
            Makler m2 = new Makler("Абылай", "Масанчи", 2018);
            Makler m3 = new Makler("Жандлс", "Аль Фараби", 2018);
            Makler m4 = new Makler("Айдос", "Жарокова", 2018);
            Makler m5 = new Makler("Акмарал", "Жандосова", 2018);
            Makler m6 = new Makler("Нурай", "Абая", 2018);
            Makler[] maklers = { m1, m2, m3, m4, m5, m6 };

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

            Console.Write("Тапсырма: ");
            int n = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {
                case 1:
                    Sdelka.Select1(sdelkas, tovars, DateTime.Parse("2019-01-2"), DateTime.Parse("2022-12-2"));
                    break;
                case 2:
                    Sdelka.Select2(tovars, sdelkas);
                    break;
                case 3:
                    Sdelka.Select3(sdelkas, tovars);
                    break;
                case 4:
                    Sdelka.Select4(sdelkas, maklers);
                    break;
                case 5:
                    Sdelka.Select5(tovars, maklers, sdelkas);
                    break;
            }
        }
        public class Makler
        {
            public string name;
            public string address;
            public int year;

            public Makler(string name, string address, int year)
            {
                this.name = name;
                this.address = address;
                this.year = year;
            }
        }

        public class Tovar
        {
            public string title_tovar;
            public string vid;
            public int price;
            public string firma_postavchik;
            public DateTime srok;
            public int count;

            public Tovar(string title_tovar, string vid, int price, string firma_postavchik, DateTime srok, int count)
            {
                this.title_tovar = title_tovar;
                this.vid = vid;
                this.price = price;
                this.firma_postavchik = firma_postavchik;
                this.srok = srok;
                this.count = count;
            }
        }

        public class Sdelka
        {
            public DateTime date_oper;
            public string title_tovar;
            public string vid;
            public int count_prod;
            public string name_makler;
            public string firma_pokupatel;

            public Sdelka(DateTime date_oper, string title_tovar, string vid, int count_prod, string name_makler, string firma_pokupatel)
            {
                this.date_oper = date_oper;
                this.title_tovar = title_tovar;
                this.vid = vid;
                this.count_prod = count_prod;
                this.name_makler = name_makler;
                this.firma_pokupatel = firma_pokupatel;
            }

            public static void Select1(Sdelka[] sdelkas, Tovar[] tovars, DateTime date1, DateTime date2)
            {
                tovars
                    .ToList()
                    .ForEach(x => Console.WriteLine($"Название товара: {x.title_tovar} " +
                    $"Колич. : {sdelkas.Where(y => y.title_tovar == x.title_tovar && y.date_oper.CompareTo(date1) == 1 && y.date_oper.CompareTo(date2) == -1).Select(y => y.count_prod).Sum()} " +
                    $"Цена: {sdelkas.Where(y => y.title_tovar == x.title_tovar && y.date_oper.CompareTo(date1) == 1 && y.date_oper.CompareTo(date2) == -1).Select(y => y.count_prod * x.price).Sum()}"));
            }
            public static void Select2(Tovar[] tovars, Sdelka[] sdelkas)
            {
                tovars
                    .ToList()
                    .ForEach(x => Console.WriteLine("Название товара: " + x.title_tovar + 
                    "  firma_pokup:  " + sdelkas.Where(y => y.title_tovar == x.title_tovar).Select(y => y.firma_pokupatel).First() + 
                    "Колич. =" + sdelkas.Where(y => y.title_tovar == x.title_tovar).Select(y => y.count_prod).Sum() + 
                    " Цена=" + sdelkas.Where(y => y.title_tovar == x.title_tovar).Select(y => y.count_prod * x.price).Sum())
                    );
            }
            public static void Select3(Sdelka[] sdelkas, Tovar[] tovars)
            {

                List<int> count_t = new List<int>();
                foreach (var tovar in tovars)
                {
                    var item = (from s in sdelkas
                                where s.vid == tovar.vid
                                select s).Count();
                    count_t.Add(item);
                }
                int max = count_t.Max();
                var item1 = (from t in tovars
                             where max == (from s in sdelkas
                                           where s.vid == t.vid
                                           select s).Count()
                             select t).First();
                Console.WriteLine($"Название товара: {item1.title_tovar} Цена: {item1.price} Фирма : {item1.firma_postavchik}");

            }
            public static void Select4(Sdelka[] sdelkas, Makler[] maklers)
            {

                List<int> count_m = new List<int>();
                foreach (var mak in maklers)
                {
                    var item = (from s in sdelkas
                                where s.name_makler == mak.name
                                select s).Count();
                    count_m.Add(item);
                }
                int max = count_m.Max();
                var item1 = (from m in maklers
                             where max == (from s in sdelkas
                                           where s.name_makler == m.name
                                           select s).Count()
                             select m).First();
                Console.WriteLine($"Имя: {item1.name}  year: {item1.year}  Адрес: {item1.address}");

            }
            public static void Select5(Tovar[] tovars, Makler[] maklers, Sdelka[] sdelkas)
            {


                maklers.ToList().ForEach(x => Console.WriteLine("Имя: " + x.name + 
                    "  Колич. : " + sdelkas.Where(y => y.name_makler == x.name).Select(y => y.count_prod).Sum() + 
                    " Цена: " +tovars.ToList().Select(t => sdelkas.Where(y => y.title_tovar == t.title_tovar && y.name_makler == x.name).Select(y => y.count_prod * t.price).Sum()).Sum()
                    ));
            }
        }
    }
}
