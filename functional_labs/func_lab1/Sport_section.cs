using System;
using System.Collections.Generic;
using System.Text;

namespace func_lab1
{
    class Sport_section
    {
        public int id_section { get; set; }
        public string sport_section { get; set; }
        public string coach { get; set; }
        public string category { get; set; }
        public string the_rules { get; set; }

        public Sport_section(int id_sport_section, string sport_section, string coach, string category, string the_rules)
        {
            this.id_section = id_sport_section;
            this.sport_section = sport_section;
            this.coach = coach;
            this.category = category;
            this.the_rules = the_rules;
        }

        public void Shygaru()
        {
            Console.WriteLine("- - - - - - - - - - - - - -");
            Console.WriteLine("_Sport section: " + id_section + " - " + sport_section + "\n_Coach_name: " + coach + "\n_Category of sport section: " + category + "\n_The rules: " + the_rules);
            Console.WriteLine("- - - - - - - - - - - - - -");
        }

        public static void SectionTop(string section, List<Sport_section> S)
        {
            bool ok = false;
            Console.WriteLine(section + " section turaly:");
            foreach (Sport_section s in S)
            {
                if (s.sport_section == section)
                {
                    s.Shygaru();
                    ok = true;
                }
                if (!ok)
                { Console.WriteLine("There is no sport section like that"); }
            }
        }

        public static void Premium(List<Competition> competition, List<Sport_section> sport_Sections, List<Sportsmen> sportsmens)
        {
            foreach (Sport_section s in sport_Sections)
            {
                int sum = 0;
                int premium = 0;
                foreach (Competition C in competition)
                {
                    if (C.id_section == s.id_section)
                    {
                        sum += C.result;
                        if (sum > 250)
                        {
                            premium = 15000;
                        }
                    }
                }
                Console.WriteLine("- - - - - - - - - - - - - -");
                Console.WriteLine("_Секция: " + s.sport_section + "\n_Coach: " + s.coach + "\n_Sum: " + sum + "\n_Premium: " + premium);
                Console.WriteLine("- - - - - - - - - - - - - -");
            }
        }
    }

}
