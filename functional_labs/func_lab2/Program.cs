using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using func_lab2;
namespace func_lab2
{
/*


 */
    class Program
    {
        static void Main()
        {
            List<Sportsmen> sportsmens = new List<Sportsmen>()
            {
                new Sportsmen(1, "Нурадин Б", "Плавание", 50,"0"),
                new Sportsmen(2, "Омирбек А", "Таеквандо", 42,"0"),
                new Sportsmen(3, "Бекдаулет М", "Таеквандо", 35,"0"),
                new Sportsmen(4, "Аскерова А", "Таеквандо", 37,"0"),
                new Sportsmen(5, "Камараддин Р", "Бокс", 48,"0"),
                new Sportsmen(6, "Бектаева Ж", "Бокс", 52,"0"),
                new Sportsmen(7, "Абдимбекова А", "Плавание", 41,"0"),
                new Sportsmen(8, "Алирахимов Р", "Футбол", 60,"0"),
                new Sportsmen(9, "Болатбек Б", "Футбол", 58,"0"),
                new Sportsmen(10, "Самимолла У", "Футбол", 64,"0")
            };

            List<Sport_section> sections = new List<Sport_section>()
            {
                new Sport_section(11, "Плавание", "Беделхан Ы", "Юниор", "Жүзу бойынша жарыстар ұзындығы 25 немесе 50 метр болатын жабық немесе ашық бассейндерде өткізіледі, бастапқы тереңдігі 1,2 м. 3-деңгейдегі жарыстарды стандартты емес және жүзетін бассейндерде, ашық су қоймаларында өткізуге рұқсат етіледі."),
                new Sport_section(22, "Таеквандо", "Рахымжанов А",  "Юниор", "Жарысқа спарринг техникасы бойынша кемінде үш ай дайындалған спортшылар жіберіледі. Бір рет өлшенген және бірінші рет өлшенбеген қатысушы ресми салмақ өлшеу кезінде тағы бір салмақ өлшеуге құқылы."),
                new Sport_section(33, "Бокс", "Нурланов Р", "Юниор", "Бокс кеші раундтарға бөлінеді, олардың әрқайсысы кездесу деңгейіне байланысты (әуесқой немесе кәсіпқой) 3 -тен 5 минутқа дейін созылады. Боксшыларға раундтар арасында 1 минут демалуға уақыт беріледі."),
                new Sport_section(44, "Футбол", "Абдухашим Д", "Юниор", "Футбол эрежелері 13тен тарады, Үйғаша: Төреші, Туреші комекшілері, Ойын алыстығы, Ойын басталуы және қайта басталуы, Доп, Гол онықтау, Офсайд, Ойылышы бұзушылықтары")
            };

            List<Competition> competitions = new List<Competition>()
            {
                new Competition(44, 80, 10, new DateTime(2021, 9, 20), "Чемпионат1"),
                new Competition(44, 85, 8, new DateTime(2021, 9, 20), "Чемпионат1"),
                new Competition(22, 60, 2, new DateTime(2021, 9, 20), "Чемпионат1"),
                new Competition(22, 72, 4, new DateTime(2021, 9, 20), "Чемпионат1"),
                new Competition(11, 87, 1, new DateTime(2021, 9, 20), "Чемпионат1"),
                new Competition(33, 90, 6, new DateTime(2021, 9, 20), "Чемпионат1"),
                new Competition(11, 79, 7, new DateTime(2021, 9, 20), "Чемпионат1"),
                new Competition(33, 88, 5, new DateTime(2021, 9, 20), "Чемпионат1"),
                new Competition(22, 91, 3, new DateTime(2021, 9, 20), "Чемпионат1"),
                new Competition(44, 99, 9, new DateTime(2021, 9, 20), "Чемпионат1"),

                new Competition(44, 84, 10, new DateTime(2021, 10, 20), "Чемпионат2"),
                new Competition(44, 89, 8, new DateTime(2021, 10, 20), "Чемпионат2"),
                new Competition(22, 76, 2, new DateTime(2021, 10, 20), "Чемпионат2"),
                new Competition(22, 98, 4, new DateTime(2021, 10, 20), "Чемпионат2"),
                new Competition(11, 92, 1, new DateTime(2021, 10, 20), "Чемпионат2"),
                new Competition(33, 70, 6, new DateTime(2021, 10, 20), "Чемпионат2"),
                new Competition(11, 80, 7, new DateTime(2021, 10, 20), "Чемпионат2"),
                new Competition(33, 50, 5, new DateTime(2021, 10, 20), "Чемпионат2"),
                new Competition(22, 85, 3, new DateTime(2021, 10, 20), "Чемпионат2"),
                new Competition(44, 80, 9, new DateTime(2021, 10, 20), "Чемпионат2"),
            };

            Console.WriteLine("#####################################################");
            Console.WriteLine("ABOUT SPORTCOMLEX!!!");

            Console.WriteLine();
            var size = sportsmens
                .Where(j => j.sport_section == "Плавание")
                .Select(i => i).Count();
            var sectionList = Enumerable.Range(1, size)
                .Select(i => $"{sections.First().sport_section} -> {i}")
                .ToList();
            Tools.Format(sectionList)
                .ToList()
                .ForEach(Console.WriteLine);

            Console.Write("\nEnter sportsman name:");
            string name = Console.ReadLine();
            sportsmens
                .Where(y => name == y.sportsman_name)
                .ToList()
                .ForEach(x => Console.WriteLine(x.Shygaru(x)));

            Console.Write("\nEnter name of sport section:  ");
            string section = Console.ReadLine();
            sections.Where(y => section == y.sport_section)
                .ToList()
                .ForEach(x => Console.WriteLine(x.Shygaru(x)));


            Console.WriteLine("\n\n#####################################################");
            Console.WriteLine("ABOUT THE COMPETITION AND ITS RESULTS!!!");

            Console.Write("\nEnter time of competition (year, month, day):");
            int year = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());
            DateTime date = new DateTime(year, month, day);

            Console.WriteLine(date + "  kuni zharyska katyskan sportshylar tizimi:");
            bool ok = false;
            competitions.ForEach(c =>
            {
                if (c.data == date)
                {
                    sportsmens.ForEach(s =>
                    {
                        if (c.id_sportsman == s.id_sportsman)
                        {
                            Console.WriteLine("{0}. Result: {1}. Place: {2}", s.sportsman_name, c.result, Competition.Oryn(c.result));
                            ok = true;
                        }
                    });
                }
            });
            if (!ok)
                Console.WriteLine("No sportsmen.");

            Console.WriteLine("\n Orta ball:");
            Competition.OrtaBall(competitions, sportsmens);

            Console.WriteLine("\n Uroven masrestvo:");
            Competition.Skill_level(competitions, sportsmens);

            Console.WriteLine("\n Premium:");
            foreach (var s in sections)
            {
                Console.WriteLine("\n_Секция: " + s.sport_section + "\n_Coach: " + s.coach + "\n_Premium: " + Sport_section.Premium(competitions, sections));
            }

            Console.ReadKey();
        }
    }
}