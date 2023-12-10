using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace func_lab11_2
{
    //Lazy Initialization – Инициализация по требованию. Это самый простой способ – реализовать проверку
    //поля на null и в случае необходимости заполнять его данными.
    public static class Lazy
    {
        public static Lazy<T> New<T>(Func<T> func)
        {
            return new Lazy<T>(func);
        }
    }
}
