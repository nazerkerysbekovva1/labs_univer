using System;
using System.Collections.Generic;
using System.Text;

namespace func_lab1
{
    class Competition
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

        public static void CompetetionSportsman(DateTime date, List<Competition> comp, List<Sportsmen> sportsmans)
        {
            Console.WriteLine(date + "  kuni zharyska katyskan sportshylar tizimi:");
            bool ok = false;
            foreach (var c in comp)
            {
                if (c.data == date)
                {
                    foreach (var s in sportsmans)
                    {
                        if (c.id_sportsman == s.id_sportsman)
                        {
                            Console.WriteLine("{0}. Result: {1}. Place: {2}", s.sportsman_name, c.result, Oryn(c.result));
                            ok = true;
                        }
                    }
                }
            }
            if (!ok)
                Console.WriteLine("No sportsmen.");
        }

        public static void Comp(DateTime date, string section, List<Competition> comp, List<Sport_section> sport_Sections, List<Sportsmen> sportsmens)
        {
            foreach (Sport_section sport_Section in sport_Sections)
            {
                Console.WriteLine("---- Секция: " + sport_Section.sport_section);
                foreach (Competition C in comp)
                {
                    foreach (Sportsmen sportsmen in sportsmens)
                    {
                        if (C.data == date)
                        {
                            if (C.result >= 90)
                            {
                                if (sportsmen.id_sportsman == C.id_sportsman)
                                {
                                    if (sportsmen.sport_section == section)
                                    {
                                        if (sport_Section.sport_section == section)
                                        {
                                            Console.WriteLine("- - - - - - - - - - - - - -");
                                            Console.WriteLine("ID: " + sportsmen.id_sportsman);
                                            Console.WriteLine("Name: " + sportsmen.sportsman_name);
                                            Console.WriteLine("Result: " + C.result);
                                            Console.WriteLine("Place: " + 1);
                                            Console.WriteLine("Section: " + sportsmen.sport_section);
                                            Console.WriteLine("- - - - - - - - - - - - - -");
                                        }
                                    }
                                }
                            }
                            else Console.WriteLine("There is no sportsman with a high score in this section");
                        }
                    }
                }
            }
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
            Console.WriteLine("- - - - - - - - - - - - - -");
            foreach (var s in sportsmans)
            {
                double orta = 0;
                int count = 0;
                foreach (var c in comp)
                {
                    if (c.id_sportsman == s.id_sportsman)
                    {
                        orta += c.result;
                        count++;
                    }
                }
                Console.WriteLine(s.sportsman_name + ": avg score for all shampionship = " + orta / count);
            }
            Console.WriteLine("- - - - - - - - - - - - - -");
        }

        public static void Skill_level(List<Competition> comp, List<Sportsmen> sportsmans)
        {
            Console.WriteLine("- - - - - - - - - - - - - -");
            foreach (var s in sportsmans)
            {
                double orta = 0;
                int count = 0;
                foreach (var c in comp)
                {
                    if (c.id_sportsman == s.id_sportsman)
                    {
                        orta += c.result;
                        count++;
                    }
                }
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
            }
            Console.WriteLine("- - - - - - - - - - - - - -");
        }
    }
}
