using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace func_lab2
{
    public static class Tools
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
    }
}
