using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaYumba.Functional;
using static LaYumba.Functional.F;
using NUnit.Framework;

namespace func_lab8
{
    internal static class Tools //MethodChaining
    {
        public static string AbbreviateName(this Sportsmen p)
         => Abbreviate(p.sportsman_name) + Abbreviate(p.sport_section);

        public static string AbbreviateName(this Sport_section p)
         => Abbreviate(p.coach) + Abbreviate(p.sport_section);

        public static string Append(this string n)
           => $"@{n}_instagram.com";

        public static string Appendd(this string n)
           => $"{n}_@gmail.com";

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
    }
}
