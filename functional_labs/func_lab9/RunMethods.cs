using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace func_lab9
{
    internal class RunMethods
    {
        public static void CurrentTovar(List<Tovar> tv)
        {
            int count = 0;
            Console.WriteLine("\n-----Current Tovar Type-----");
            tv.ForEach(x => { 
                Console.WriteLine($"tv{count + 1} ---> {x.CurrentTovarType}"); 
                count++; 
            });
        }

        public static void ValueTovar(List<Tovar> tv)
        {
            int count = 0; 
            Console.WriteLine("\n-----Tovar Value Count-----");
            tv.ForEach(x => { 
                Console.WriteLine($"tv{count + 1} value = {x.TovarData.Count}"); 
                count++; });
        }
         
        public static void Checking(Tovar tv)
        {
            if (tv.CurrentTovarType == TovarTypeEnum.Tovar3)
                Console.WriteLine("It is Mutable!");
            else Console.WriteLine("It is Immutable!");

            if (tv.TovarData.SequenceEqual(new[] { "a", "b", "c", "d", "e" }))
                Console.WriteLine("It is Mutable!");
            else Console.WriteLine("It is Immutable!");
        }
        
    }
}
