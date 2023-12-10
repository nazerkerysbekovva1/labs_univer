using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using func_lab2;

namespace func_lab2
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

        public static void OrtaBall(List<Competition> comp, List<Sportsmen> sportsmans)
        {
            double ball = 0;
            sportsmans.ForEach(s =>
            {
                double orta = 0;
                int count = 0;
                comp.ForEach(c =>
                {
                    if (c.id_sportsman == s.id_sportsman)
                    {
                        orta += c.result;
                        count++;
                        ball += orta / count;
                    }
                });
                Console.WriteLine(s.sportsman_name + ": avg score for all shampionship = " + ball);
            });
        }

        public static void Skill_level(List<Competition> comp, List<Sportsmen> sportsmans)
        {
            sportsmans.ForEach(s =>
            {
                double orta = 0;
                int count = 0;
                comp.ForEach(c =>
                {
                    if (c.id_sportsman == s.id_sportsman)
                    {
                        orta += c.result;
                        count++;
                    }
                });
                if ((orta / count) >= 86)
                {
                    s.skill_level = "1st level";
                }
                else if ((orta / count) >= 76)
                {
                    s.skill_level = "2nd level";
                }
                else if ((orta / count) >= 66)
                {
                    s.skill_level = "3rd level";
                }
                else
                { s.skill_level = "0"; }
                Console.WriteLine(s.sportsman_name + ": level of skill gained from result of championships = " + s.skill_level);
            });
            Console.WriteLine("- - - - - - - - - - - - - -");
        }
    }
}
