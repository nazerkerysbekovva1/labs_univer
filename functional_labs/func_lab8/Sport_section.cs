using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaYumba.Functional;
using static LaYumba.Functional.F;
using NUnit.Framework;
using func_lab8;
using Double = LaYumba.Functional.Double;
using String = LaYumba.Functional.String;

namespace func_lab8
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

        public static string Process(string input) // преобразование string -> double
         => input.Split(',')        // IEnumerable<string>
            .Map(String.Trim)       // IEnumerable<string>
            .Traverse(Double.Parse) // Option<IEnumerable<double>>
            .Map(Enumerable.Sum)    // Option<double>
            .Match(
               () => "Некоторые из ваших входных данных не удалось проанализировать",
               sum => $"Сумма of results {sum}");
    }
}
