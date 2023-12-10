using func_SPORTCOMLEX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace func_lab2
{
    internal static class Tools
    {
        public static string Name(this string s)
         => s.ToUpper().Substring(0);

        static IEnumerable<int> Naturals(int startingWith = 0)
        {
            while (true) yield return startingWith++;
        }

        public static IEnumerable<string> Format(this IEnumerable<string> list) => list
              .Select(Tools.Name)
              .Zip(Naturals(startingWith: 1), (s, i) => $"{i} sportsman. {s}");

        public static string AbbreviateName(this Sportsmen p)
         => Abbreviate(p.sportsman_name) + Abbreviate(p.sport_section);

        public static string Append(this string n)
           => $"@{n}_instagram.com";

        public static string Abbreviate(string s)
           => s.Substring(0, 2).ToUpper();

        public static void Greet(string name, string sect)
           => Console.WriteLine(GreetingFor(name, sect));

        public static string GreetingFor(string name, string sect)
           => Some(name).Match(
              Some: n => $"{n} -> is {sect} coach!",
              None: () => "sorry, isnt coach");

        public static double AverageResult(this IEnumerable<Competition> comp)
         => comp
            .Average(p => p.result);

        public static IEnumerable<Competition> StrongerSportsman(this List<Competition> comp)
           => comp
              .OrderByDescending(p => p.result)
              .Take(comp.Count / 4);

        public static double AverageResultOfStrongerSportsman(this List<Competition> comp)
         => comp
            .StrongerSportsman()
            .AverageResult();

        public static string AbbreviateName(this Sport_section p)
         => Abbreviate(p.coach) + Abbreviate(p.sport_section);

        public static string Appendd(this string n)
           => $"{n}_@gmail.com";
    }
}
