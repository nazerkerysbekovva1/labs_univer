using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaYumba.Functional;
using static LaYumba.Functional.F;
using System.Xml.Linq;

namespace func_lab8
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

        static Func<int, int, int> multiply = (i, j) => i * j;
        static Func<int, int> @double = i => i * 2;

        internal static void MapUnaryFunction(Sportsmen[] sp) // Унарная функция Map
        {
            Option<int> double3 = Some(sp[3].the_weight).Map(@double);
            Console.WriteLine($"\n {sp[3].sportsman_name}, спортшы салмагынын еселенген манi = {double3}");

            Console.WriteLine($"\n Cпортшылардын идентификатор мандерынын еселенген манi:");
            IEnumerable<int> doubles = Range(sp[0].id_sportsman, sp[3].id_sportsman).Map(@double);
            doubles.ForEach(b => Console.WriteLine(b));
        }

        internal static void BinaryFunctionByLowering(List<Competition> comp) // Применение бинарную функцию путем понижения
        {
            Console.WriteLine("\n Спортшы идентификаторлары мен результаттары кобеитындысы");
            comp.ForEach(x =>
            {
                Option<int> id = Some(x.id_sportsman);
                Option<int> res = Some(x.result);

                var result = id.Match(
                   () => None,
                   valA => res.Match(
                      () => None,
                      valB => Some(multiply(valA, valB))
                   )
                );
                Console.WriteLine($"{x.id_sportsman} * {x.result} = {result}");
            });
        }
    }
}