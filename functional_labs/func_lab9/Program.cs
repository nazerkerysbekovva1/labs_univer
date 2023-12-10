using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace func_lab9
{
    class Program
    {
        static void Main()
        {
            var tv1 = new Tovar(TovarTypeEnum.Tovar1);
            var tv2 = tv1.ChangeTovar(TovarTypeEnum.Tovar3);
            var tv3 = tv2.ChangeTovar(new[] { "Sisley", "Kenzo", "Thidefiy" });
            var tv4 = tv3.ChangeTovar(TovarTypeEnum.Tovar1, new[] { "Armani", "Lo Drese" });
            var tv5 = tv4.ChangeTovar(TovarTypeEnum.Tovar3);

            List<Tovar> tv = new List<Tovar> { tv1, tv2, tv3, tv4, tv5 }; 

            Debug.Assert(
                tv5.CurrentTovarType == TovarTypeEnum.Tovar3);
            Debug.Assert(
                tv5.TovarData.SequenceEqual(new[] { "Sisley", "Kenzo", "Thidefiy", "Armani", "Lo Drese" }));

            
            RunMethods.CurrentTovar(tv);

            RunMethods.ValueTovar(tv);

            Console.WriteLine("\n-----Mutability check-----");
            RunMethods.Checking(tv5);

            Console.ReadKey();
        }
    }
}


