using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace func_lab3
{
    internal static class Tools //MethodChaining
    {
        public static string AbbreviateName(this Sportsmen p)
         => Abbreviate(p.sportsman_name) + Abbreviate(p.sport_section);

        public static string Append(this string n)
           => $"@{n}_instagram.com";

        public static string Abbreviate(string s)
           => s.Substring(0, 2).ToUpper();
    }
}
