using System;
using System.Collections.Generic;
using System.Text;
using func_lab2;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace func_SPORTCOMLEX
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

        public Action<Sport_section> Shygaru = x =>
        Console.WriteLine($"\n_Sport section: {x.id_section} - {x.sport_section} \n_Coach_name: {x.coach} \n_Category of sport section: {x.category}\n_The rules: {x.the_rules}\n");

        public static Func<Sport_section, string> emailFor = p =>
       Tools.Appendd(p.AbbreviateName());
    }

}
