using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaYumba.Functional;
using static LaYumba.Functional.F;
using Sportsman_name = System.String;
using Greeting = System.String;
using PersonalizedGreeting = System.String;
using System.Xml.Linq;

namespace func_lab10
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

        public Action<Sportsmen> Insta = sp =>
        {
            var insta = sp.AbbreviateName().Append();
            Console.WriteLine(insta);
        };

        internal static void Run(List<Sportsmen> sp)   //methods with delegates
        {
            string separator = "! ";

            Func<Greeting, Sportsman_name, PersonalizedGreeting> greet
               = (gr, name) => $"{gr}, {name}";

            Func<Greeting, Func<Sportsman_name, PersonalizedGreeting>> greetWith  //    Функции карри: оптимизированы для частичного применения
               = gr => name => $"{gr}{separator}{name}";

            var names = new List<Sportsman_name>();
            sp.ForEach(s =>
            {
                if (!names.Contains(s.sportsman_name))
                    names.Add(s.sportsman_name);
            });
            var s_names = names.ToArray();

            Console.WriteLine("\n Приветствие — с «нормальным» приложением с несколькими аргументами");
            s_names.Map(g => greet("Hello", g)).ForEach(Console.WriteLine);

            Console.WriteLine("\n Приветствие - официально - с частичным применением, вручную");
            var greetFormally = greetWith("Good evening");
            names.Map(greetFormally).ForEach(Console.WriteLine);

            Console.WriteLine("\n Приветствие - неформально - с частичным применением, общим");
            var greetInformally = greet.Apply("Hey");
            names.Map(greetInformally).ForEach(Console.WriteLine);

            Console.WriteLine("\n Приветствие - ностальгически - с частичным применением, карри");
            var greetNostalgically = greet.Curry()("Arrivederci");  //italian
            names.Map(greetNostalgically).ForEach(Console.WriteLine);
        }
    }
}

