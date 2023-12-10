using System;
using System.Collections.Generic;
using System.Text;

namespace func_lab1
{
    class Sportsmen
    {
        public int id_sportsman { get; set; }
        public string sportsman_name { get; set; }
        public string sport_section { get; set; }
        public int the_weight { get; set; }
        public string skill_level { get; set; }

        public Sportsmen(int id_sportsman, string sportsman_name, string sport_section, int the_weight, string skill_level)
        {
            this.id_sportsman = id_sportsman;
            this.sportsman_name = sportsman_name;
            this.sport_section = sport_section;
            this.the_weight = the_weight;
            this.skill_level = skill_level;
        }

        public void Shygaru()
        {
            Console.WriteLine("- - - - - - - - - - - - - -");
            Console.WriteLine("_Sportshy: " + id_sportsman + " - " + sportsman_name + "\n_Sport section: " + sport_section + "\n_Weight:" + the_weight + "\n_Skill level:" + skill_level);
            Console.WriteLine("- - - - - - - - - - - - - -");
        }

        public static void AboutSportsmen(string name, List<Sportsmen> sportsmans)
        {
            bool ok = false;
            foreach (Sportsmen s in sportsmans)
            {
                if (s.sportsman_name == name)
                {
                    s.Shygaru();
                    ok = true;
                }
            }
            if (!ok)
                Console.WriteLine("There is no Sportsman like that");
        }
    }
}
