using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
namespace emtixan
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcurrentDictionary<int, string> san = new ConcurrentDictionary<int, string>();
            san.TryAdd(1, "bir");
            san.TryAdd(2, "eki");
            san.TryUpdate(1, "algashky", "bir");
            san.AddOrUpdate(3, "ush", (sanau, matin) => matin = matin + " lasgastyrushy");
            Console.WriteLine(san[2]);
          
        }
    }
}
