using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using func_lab5;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace func_lab5
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
            this.id_section = id_section;
            this.result = result;
            id_sportsman = idSportsman;
            this.data = data;
            this.competition = competition;
        }
    }
}