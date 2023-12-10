using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using func_lab7;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace func_lab7
{
    internal class Competition
    {
        public Option<int> id_section { get; set; }

        public int result { get; set; }
        public int id_sportsman { get; set; }
        public DateTime data { get; set; }
        public string competition { get; set; }

        public Competition() { }

        public Competition(int id_sport_section, int result, int idSportsman, DateTime data, string competition)
        {
            this.id_section = id_section;
            this.result = result;
            id_sportsman = idSportsman;
            this.data = data;
            this.competition = competition;
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

    }
}