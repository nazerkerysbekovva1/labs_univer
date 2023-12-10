using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using func_lab8;
using LaYumba.Functional;
using NUnit.Framework;
using static LaYumba.Functional.F;
using String = LaYumba.Functional.String;
using Double = LaYumba.Functional.Double;

namespace func_lab8
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
                new Competition(22, 72, 4, new DateTime(2021, 9, 20), "Чемпионат1"),
                new Competition(11, 87, 1, new DateTime(2021, 9, 20), "Чемпионат1"),
                new Competition(33, 90, 6, new DateTime(2021, 9, 20), "Чемпионат1"),
                new Competition(11, 79, 7, new DateTime(2021, 9, 20), "Чемпионат1"),
                new Competition(33, 88, 5, new DateTime(2021, 9, 20), "Чемпионат1"),
                new Competition(22, 91, 3, new DateTime(2021, 9, 20), "Чемпионат1"),
                new Competition(44, 99, 9, new DateTime(2021, 9, 20), "Чемпионат1"),
            };

            Sportsmen.MapUnaryFunction(sportsmens.ToArray());

            Sportsmen.BinaryFunctionByLowering(competitions);

            string input = Prompt("\n Введите results:");
            var result = Sport_section.Process(input);
            Console.WriteLine(result);

            Console.WriteLine("\n Resultat ball:");
            Competition.ResBall(competitions, sportsmens);

            Console.WriteLine("\n Hypothenuse example");
            Hypothenuse();

            Console.ReadKey();
        }

        static string Prompt(string msg) //Prompt message, Быстрый
        {
            Console.WriteLine(msg);
            return Console.ReadLine();
        }

        static void Hypothenuse()
        {
            string s1 = Prompt("1 катет:")
                 , s2 = Prompt("2 катет:");

            var result = from a in Double.Parse(s1)
                         where a >= 0
                         let aa = a * a

                         from b in Double.Parse(s2)
                         where b >= 0
                         let bb = b * b

                         select Math.Sqrt(aa + bb);

            Console.WriteLine(result.Match(
               () => "Пожалуйста, введите два действительных положительных числа",
               (h) => $"Гипотенуза = {h}"));
        }
    }
}