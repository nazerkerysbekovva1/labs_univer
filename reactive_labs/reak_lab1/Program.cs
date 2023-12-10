using System;
using System.Collections.Generic;
using System.Linq;

/* Project: «Парфюмерный базар». Постоянно работающий парфюмерный базар характеризуется участием в ней оптовых фирм-поставщиков и оптовых фирм-покупателей,
 * при этом все сделки заклю-чаются через специальных маклеров, имеющих доступ ко всем товарам. 
Управление базаром должно иметь сведения: 
о маклерах: фамилия маклера, адрес, год рождения; 
о товаре: название товара, вид, цена единицы товара, оптовая фирма-поставщик, срок годности, количество поставленных единиц; 
о заключенных сделках: дата сделки, название товара, вид, количество проданных единиц, фамилия маклера, оптовая фирма-покупатель.
*/

namespace reak_lab1
{
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
