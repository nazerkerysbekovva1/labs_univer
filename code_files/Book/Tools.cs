using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    static class Tools
    {
        public static IEnumerable<Books> Sort1(this List<Box1> books)
           => books
              .OrderByDescending(p => p.year);
        public static IEnumerable<Books> Sort1(this List<Box2> books)
           => books
              .OrderByDescending(p => p.year);
        public static IEnumerable<Books> Sort1(this List<Box3> books)
           => books
              .OrderByDescending(p => p.year);
    }
}
