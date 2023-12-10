using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using func_lab7;
using LaYumba.Functional;
using NUnit.Framework;
using static LaYumba.Functional.F;
using String = LaYumba.Functional.String;

namespace func_lab7
{
    class Program
    {
        static void Main()
        {
            List<Sportsmen> sportsmens = new List<Sportsmen>()
            {
                new Sportsmen(2, "Омирбек А", "Таеквандо", 42,"0"),
                new Sportsmen(4, "Аскерова А", "Таеквандо", 37,"0"),
                new Sportsmen(6, "Бектаева Ж", "Бокс", 52,"0"),
                new Sportsmen(7, "Абдимбекова А", "Плавание", 41,"0"),
                new Sportsmen(9, "Болатбек Б", "Футбол", 58,"0"),
            };

            List<Sport_section> sections = new List<Sport_section>()
            {
                new Sport_section(11, "Плавание", "Беделхан Ы", "Юниор", "  "),
                new Sport_section(22, "Таеквандо", "Рахымжанов А",  "Юниор", "  "),
                new Sport_section(33, "Бокс", "Нурланов Р", "Юниор", "  "),
                new Sport_section(44, "Футбол", "Абдухашим Д", "Юниор", "  ")
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

            //Console.Write("\n Спортсмендердын резултаттары позитив па? ");
            //Console.WriteLine(Competition.TestCalc(competitions));

            //Console.Write("\n Average of results: ");
            //Console.WriteLine(Competition.CalcAverage(competitions));

            //Console.Write("\n Average of results with Using Match: ");
            //Competition.UseMatch(competitions);

            Sportsmen.Run(sportsmens);

            Sport_section.Run();

            Console.ReadKey();
        }
    }
}