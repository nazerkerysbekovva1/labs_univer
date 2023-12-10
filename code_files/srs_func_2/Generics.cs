using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace srs_func_2
{
    public class TemplateTest<T>
    {
        T[] arr = new T[10];
        int index = 0;

        public bool Add(T value)
        {
            if (index >= 10)
            {
                return false;
            }

            arr[index++] = value;
            return true;
        }

        public T get(int index)
        {
            if (index < this.index && index >= 0)
            {
                return arr[index];
            }
            else
            {
                return default(T);
            }
        }

        public int Count()
        {
            return index;
        }
    }
}
