using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using func_lab8;
using LaYumba.Functional;

namespace func_lab8
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
            id_section = id_sport_section;
            this.result = result;
            id_sportsman = idSportsman;
            this.data = data;
            this.competition = competition;
        }

        public static void ResBall(List<Competition> comp, List<Sportsmen> sportsmans)  //res ball off sportsmen LING
        {
            var result = 
            from s in sportsmans
            from c in comp
            where s.id_sportsman == c.id_sportsman
            select (c.competition, s.sport_section, s.sportsman_name, c.result);

            result.ForEach(g => Console.WriteLine($"{g.Item1}: {g.Item2} --> {g.Item3} = {g.Item4}"));
        }
    }
}