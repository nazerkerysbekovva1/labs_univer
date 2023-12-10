using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static reak_lab_3.Program;

namespace reak_lab_3
{
    internal class Tovar
    {
        public int id;
        public string tovar_name;
        public string vid;
        public int price;
        public string postavshik;
        public DateTime srok;
        public int kolichestvo;
        public Tovar(int tovarId, string name, string vid, int price, string optovaya_firma_postavshchik, DateTime srok_godnosti, int kolichestvo_postavlennykh_yedinits)
        {
            id = tovarId;
            tovar_name = name;
            this.vid = vid;
            this.price = price;
            postavshik = optovaya_firma_postavshchik;
            srok = srok_godnosti;
            kolichestvo = kolichestvo_postavlennykh_yedinits;
        }
        public void Info()  //информация товарлар
        {
            Console.WriteLine($" {id} <=> '{tovar_name}' <=> {vid} <=> {price} <=> postavshchik: {postavshik} <=> srok: {srok} <=> {kolichestvo}");
        }
        public static bool CompareLength(string first, string second) //мандердын узындыгын салыстыратын bool типты функция
        {
            return first.Length == second.Length;
        }
        public bool CompareContent(string first, string second)  //мандердын уксастыгын салыстыратын bool типты функция
        {
            return first == second;
        }
        public static bool AreSimilar(string[] leftItems, string[] rightItems, ComparisonTest tester) ////мандердын уксастыгын тексеретын bool типты функция
        {
            if (leftItems.Length != rightItems.Length) 
                return false;
            for (int i = 0; i < leftItems.Length; i++)
            {
                if (tester(leftItems[i], rightItems[i]) == false) //делегат tester экземпляры аркылы тексеру
                {
                    return false;
                }
            }
            return true;
        }
    }
}
