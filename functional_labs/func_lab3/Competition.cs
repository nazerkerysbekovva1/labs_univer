using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using func_lab3;

namespace func_lab3
{
    internal class Competition
    {
        public int id_section { get; set; }
        public int result { get; set; }
        public int id_sportsman { get; set; }
        public DateTime data { get; set; }
        public string competition { get; set; }

        public Competition(int id_sport_section, int result, int idSportsman, DateTime data, string competition)
        {
            this.id_section = id_section;
            this.result = result;
            id_sportsman = idSportsman;
            this.data = data;
            this.competition = competition;
        }

        public static Func<int, string> Oryn = result =>
        {
            if (result >= 90)
                return "___1 place";
            else if (result >= 80 && result < 90)
                return "___2 place";
            else if (result > 70 && result < 80)
                return "___3 place";
            else
                return "___Lost place";
        };

        public static Func<List<Competition>, Sportsmen, (string, int)> ObshaiaSummaBall = (comp, sportsmans) =>
        {
            string s_name;
            int orta = 0;
            int sum = 0;
            var o = comp.Where(m => m.id_sportsman == sportsmans.id_sportsman).Select(o => orta += o.result).ToList();
            for (int i = 0; i < o.Count(); i++)
            {
                sum += o[i];
            }
            s_name = sportsmans.sportsman_name;
            return (s_name, sum);
        };

        public static Func<List<Competition>, Sportsmen, string> Skill_level = (comp, sportsmans) =>
        {
            int count = 3;
            int ball = Competition.ObshaiaSummaBall(comp, sportsmans).Item2 / count;
            if (ball >= 86)
            {
                sportsmans.skill_level = " --> 1st level";
            }
            else if (ball >= 76)
            {
                sportsmans.skill_level = " --> 2nd level";
            }
            else if (ball >= 66)
            {
                sportsmans.skill_level = " --> 3rd level";
            }
            else
            { sportsmans.skill_level = " --> 0"; }
            return sportsmans.skill_level;
        };

        public Option<int> GetIndexOfSubstring(string s, string substring)
        {
            var index = s.IndexOf(substring);
            if (index == -1)
                return new None<int>();

            return new Some<int>(index);
        }
        public static string SubstringBefore(string s, string substring)
        {
            var operations = new Competition(44, 84, 10, new DateTime(2021, 10, 20), "Чемпионат2");
            var index = operations.GetIndexOfSubstring(s, substring);

            if (index.IsSome)
                return s.Substring(0, index.Value) + "some";

            return s + "none";
        }
    }
}