using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace func_lab10
{
    public class NazEventArgs : System.EventArgs
    {
        public readonly string section;
        public NazEventArgs(string sect)
        {
            section = sect;
        }
    }

    public class Program
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
                new Sport_section(11, "Плавание", "Беделхан Ы", "Юниор", " "),
                new Sport_section(22, "Таеквандо", "Рахымжанов А",  "Юниор", " "),
                new Sport_section(33, "Бокс", "Нурланов Р", "Юниор", " "),
                new Sport_section(44, "Футбол", "Абдухашим Д", "Юниор", " ")
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

            //Console.Write("\n Спортсмендердын резултаттары позитив па? ");
            //Console.WriteLine(Competition.TestCalc(competitions));

            //Console.Write("\n Average of results: ");
            //Console.WriteLine(Competition.CalcAverage(competitions));

            //Console.Write("\n Average of results with Using Match: ");
           // Competition.UseMatch(competitions);

            //Sportsmen.Run(sportsmens);

            Sport_section.Run();

            Competition.Massiv(competitions);
            Sport_section.Massiv(sections);

            Console.WriteLine("\nEnter time of competition (year, month, day):");
            int year = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());
            DateTime date = new DateTime(year, month, day);

            Competition.CompetetionSportsman(date, competitions, sportsmens);

            Console.Write("\nEnter name of sport section:  ");
            string section = Console.ReadLine();
            for (int i = 0; i < sections.Count; i++)
            {
                sections[i].Collect(section, sections);
            }
            Console.ReadKey();
        }
    }
}
