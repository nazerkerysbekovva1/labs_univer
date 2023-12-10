using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using func_lab5;
using LaYumba.Functional;
using NUnit.Framework;
using static LaYumba.Functional.F;
using String = LaYumba.Functional.String;

namespace func_lab5
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

                new Competition(44, 84, 10, new DateTime(2021, 10, 20), "Чемпионат2"),
                new Competition(44, 89, 8, new DateTime(2021, 10, 20), "Чемпионат2"),
                new Competition(22, 76, 2, new DateTime(2021, 10, 20), "Чемпионат2"),
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
            // => [Some(33), None, Some(37)]

            Console.WriteLine();
            var statedAges = Competition.Bind(p => p.id_section).ToArray();
            statedAges.ForEach(n => Console.Write(n + " "));
            // => [33, 37]

            Console.WriteLine();
            var averageAge = statedAges.Average().ToString();
            Console.WriteLine(averageAge);
            // => 35


            Console.WriteLine("\n Create Email account for sport section:");
            var opt = Some(new Sport_section(11, "Плавание", "Беделхан Ы", "Юниор", " "));
            var a = opt.Map(Sport_section.emailFor);
            var b = opt.Map(Tools.AbbreviateName)
                      .Map(Tools.Appendd);
            Assert.AreEqual(a, b); //Проверяет, равны ли указанные строки, и выдает исключение, если они не равны.
            Console.WriteLine(b);

            Console.WriteLine("\n Average Result Of Stronger Sportsman:");
            Console.WriteLine( Tools.AverageResultOfStrongerSportsman(comp));
            Console.ReadKey();

        }
        static IEnumerable<Competition> Competition => new[]
      {
             new Competition { id_section = Some(44) },
             new Competition { }, // this person did not disclose her age
             new Competition { id_section = Some(22) },
       };

        private static List<Competition> comp
           => Range(1, 8).Map(i => new Competition { result = 87 * i}).ToList();
    }
}