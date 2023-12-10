using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using func_lab4;
using LaYumba.Functional;
using static LaYumba.Functional.F;
using String = LaYumba.Functional.String;

namespace func_lab4
{
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

            Console.WriteLine("\n Create Instagram account for sportsmen:");
            sportsmens.ForEach(x => x.Insta(x));

            //Представляет коллекцию ключей, каждый из сопоставляется с одним или несколькими значениями.
            Console.WriteLine("\n Sportsmen of each sports section:");
            Lookup<char, string> lookup = (Lookup<char, string>)sportsmens.ToLookup(p => p.sport_section[0],
                                                    p => p.sport_section + " " + p.sportsman_name);

            // Iterate through each IGrouping in the Lookup and output the contents.
            foreach (IGrouping<char, string> packageGroup in lookup)
            {
                // Print the key value of the IGrouping.
                Console.WriteLine(packageGroup.Key);
                // Iterate through each value in the IGrouping and print its value.
                foreach (string str in packageGroup)
                    Console.WriteLine("    {0}", str);
            }

            Console.WriteLine("\n Status sportsman:");
            sportsmens.ForEach(x => { x.Status = new Status { Type = "sportsman" }; });
            sportsmens.ForEach(x => Console.WriteLine(x.SportsmanStatus));

            Console.WriteLine("\n ToUpper Names:");
            var names = sportsmens.Select(x => x.sportsman_name).ToList();
            IEnumerable<string> name = names.AsEnumerable();
            name
               .Map(String.ToUpper)
               .ForEach(Console.WriteLine);

            Console.WriteLine("\n Coaches of SportComplex:");
            sections.ForEach(v => Tools.Greet(v.coach, v.sport_section));

            Console.WriteLine();
            var optionalAges = Competition.Map(p => p.id_section).ToArray().ForEach(n => Console.Write(n + " "));
            

            Console.WriteLine();
            var statedAges = Competition.Bind(p => p.id_section).ToArray();
            statedAges.ForEach(n => Console.Write(n + " "));
           

            Console.WriteLine();
            var averageAge = statedAges.Average().ToString();
            Console.WriteLine(averageAge);
            

            Console.ReadKey();

        }
        static IEnumerable<Competition> Competition => new[]
      {
             new Competition { id_section = Some(44) },
             new Competition { }, 
             new Competition { id_section = Some(22) },
          };
    }
}