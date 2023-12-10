using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reak_PERFUMERY
{
    internal static class Foreach //класс для методы расширения
    {
            //ForEach каита реализациясы
        public static void ForEach<Tovar>(this IEnumerable<Tovar> collection, Action<Tovar> action) //Товар обьектылерын тызымы, Товар клас типын кабылдаитын делегат Action
        {//значение каитармаитын функция
            foreach (var item in collection)
            {
                action(item);
            }
        }
        public static void ForEach<Tovar>(this IEnumerable<Tovar> collection, Action<Tovar> action, Func<Tovar, bool> predicate) //Товар клас типын кабылдаитын bool типты ман каитаратын делегат Func
        {//значение каитаратын функция
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    action(item);
                }
            }
        }
    }
}
