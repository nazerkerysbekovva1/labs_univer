using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace func_lab3
{
    internal class Sportsmen
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

        public Action<Sportsmen> Shygaru = s => 
        Console.WriteLine("\n_Sportshy: " + s.id_sportsman + " - " + s.sportsman_name + "\n_Sport section: " + s.sport_section + "\n_Weight:" + s.the_weight + "\n_Skill level:" + s.skill_level);

        public Action<Sportsmen> Insta = sp =>
        {
            var insta = sp.AbbreviateName().Append();
            Console.WriteLine(insta);
        };
    }
}