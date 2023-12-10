using LaYumba.Functional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace func_lab10
{
    public delegate void datecomp(int id_sp, int res);

    class Competition
    {
        public int id_section { get; set; }
        public int result { get; set; }
        public int id_sportsman { get; set; }
        public DateTime data { get; set; }
        public string competition { get; set; }

        public event datecomp UserEvent1;
        public void OnUserEvent1()
        {
            if (UserEvent1 != null)
                UserEvent1(id_sportsman, result);
        }
        public void DisplayMessage1(int id_sp, int res)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"id - {this.id_sportsman}-ге тен спортшы - '{this.result}' результатпен жолдама алды!");
            Console.ResetColor();
        }

        public static void Massiv(List<Competition> cm)
        {
            for (int i = 0; i < cm.Count; i++)
            {
                cm[i].UserEvent1 += cm[i].DisplayMessage1;
            }
        }

        public Competition(int id_section, int result, int id_sportsman, DateTime data, string competition)
        {
            this.id_section = id_section;
            this.result = result;
            this.id_sportsman = id_sportsman;
            this.data = data;
            this.competition = competition;
        }

        public static void CompetetionSportsman(DateTime date, List<Competition> comp, List<Sportsmen> sportsmans)
        {
            Console.WriteLine("---- " + date + "  kuni zharyska katyskan sportshylar tizimi:");
            bool ok = false;
            foreach (var c in comp)
            {
                if (c.data == date)
                {
                    foreach (var s in sportsmans)
                    {
                        if (c.id_sportsman == s.id_sportsman)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Id: {0}. {1}. Result: {2}. Place: {3}", s.id_sportsman, s.sportsman_name, c.result, Oryn(c.result));
                            ok = true;
                        }
                    }
                    if (Oryn(c.result) == "___1 place")
                    {
                        Console.WriteLine("Got a ticket to the championship!");
                        c.OnUserEvent1();
                    }
                    else
                    {
                        Console.WriteLine("Didnt get a ticket to the championship!");
                    }
                }
            }
            if (!ok)
                Console.WriteLine("No sportsmen.");
        }

        public static Either<string, double> CalcAverage(List<Competition> x)
        {
            double countRes = x.Select(x => x.result).Count();
            double sumRes = x.Select(x => x.result).Sum();

            if (countRes == 0)
                return "count of result cannot be 0";

            if (sumRes != 0 && Math.Sign(countRes) != Math.Sign(sumRes))
                return "countRes and sumRes cannot be negative";

            return sumRes / countRes;
        }

        public static void UseMatch(List<Competition> x)
        {
            var message = CalcAverage(x).Match(
               Right: z => $"Result = {z}",
               Left: err => $"Invalid input = {err}");
            Console.WriteLine(message);
        }

        public static bool TestCalc(List<Competition> x) => Competition.CalcAverage(x).Match(_ => false, _ => true);

        public static string Oryn(int result)
        {
            if (result >= 90)
                return "___1 place";
            else if (result >= 80 && result < 90)
                return "___2 place";
            else if (result >= 70 && result < 80)
                return "___3 place";
            else
                return "___Lost place";
        }

    }
}
