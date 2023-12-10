using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace srs_func_2
{
    internal class LingQuery
    {
        public static void Select1(Tovar[] tovars, Sdelka[] sdelkas)
        {
            tovars
                .ToList()
                .ForEach(x => Console.WriteLine("Название товара: "+x.title_tovar + "  " +
                "firma_pokup:  "+sdelkas.Where(y => y.title_tovar == x.title_tovar).Select(y => y.firma_pokupatel).First() + 
                "Колич. =" + sdelkas.Where(y => y.title_tovar == x.title_tovar).Select(y => y.count_prod).Sum() + 
                " Цена=" + sdelkas.Where(y => y.title_tovar == x.title_tovar).Select(y => y.count_prod * x.price).Sum())
                );
        }
        public static void Select2(Sdelka[] sdelkas, Tovar[] tovars)
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
    }
    }
