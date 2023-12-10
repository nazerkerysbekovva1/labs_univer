using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace func_lab4
{
    using static F;
    class Status
    {
        public string Type;
    }
    internal static class Tools //MethodChaining
    {
        public static string AbbreviateName(this Sportsmen p)
         => Abbreviate(p.sportsman_name) + Abbreviate(p.sport_section);

        public static string Append(this string n)
           => $"@{n}_instagram.com";

        public static string Abbreviate(string s)
           => s.Substring(0, 2).ToUpper();

        public static string SportsmanStatus(this Sportsmen p)
         => p.Status.Match(
            Some: r => $"{p.sportsman_name} is {r.Type}",
            None: () => $"{p.sportsman_name} is not sportsman");

        public static void Greet(string name, string sect)
           => Console.WriteLine(GreetingFor(name, sect));

        public static string GreetingFor(string name, string sect)
           => Some(name).Match(
              Some: n => $"{n} -> is {sect} coach!",
              None: () => "sorry, isnt coach");
    }
}
