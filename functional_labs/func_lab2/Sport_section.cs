using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using func_lab2;

namespace func_lab2
{
    internal class Sport_section
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

        public string Shygaru(Sport_section x) => $"\n_Sport section: {x.id_section} - {x.sport_section} \n_Coach_name: {x.coach} \n_Category of sport section: {x.category}\n_The rules: {x.the_rules}\n";

        public static int Premium(List<Competition> competition, List<Sport_section> sport_Sections)
        {
            int sum = 0;
            int premium = 0;
            sport_Sections.ForEach(s =>
            {
                competition.ForEach(C =>
                {
                    if (C.id_section == s.id_section)
                    {
                        sum += C.result;
                        if (sum > 250)
                        {
                            premium = 15000;
                        }
                    }});
            });
            return premium;
        }
    }
}
