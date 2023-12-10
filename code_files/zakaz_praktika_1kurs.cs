using System;
using System.IO;
using System.Text;

namespace zakaz_praktika_1kurs
{
    //   class Program
    //   {
    //       static void Main(string[] args)
    //       {
    //		Console.Write("m = ");
    //		int m = int.Parse(Console.ReadLine());
    //		Console.Write("n = ");
    //		int n = int.Parse(Console.ReadLine());
    //		int i, j;
    //		int i1, j1, i2, j2;
    //		double[] SA = new double[n];
    //		int[,] A = new int[m, n];
    //		Random r = new Random();
    //		Console.WriteLine(" elements: ");
    //		Console.WriteLine("\n");
    //		for (i = 0; i < m; i++)
    //		{
    //			for (j = 0; j < n; j++)
    //			{
    //				A[i, j] = r.Next(-10, 10);
    //				Console.Write("[" + i + "]" + A[i, j] + "\t");
    //			}
    //			Console.WriteLine("\n");
    //		}
    //		for (int k = 0; k < m; k++)
    //		{
    //			for (int l = 0; l < n; l++)
    //			{
    //				for (i = 0; i < m; i++)
    //				{
    //					for (j = 0; j < n; j++)
    //					{
    //						if (A[i,j]==A[k,l])
    //						{
    //							if (i != k || j != l)
    //							{
    //							i1= k;
    //							j1= l;
    //							i2= i;
    //							j2= j;
    //                                   Console.WriteLine("Одинаковые элементы A["+ i1+ ","+ j1+ "]="+ A[i1, j1]+ " и A["+ i2+ ","+ j2+ "]="+ A[i2, j2]);
    //							}
    //						}
    //					}
    //				}
    //			}
    //		}
    //		Console.WriteLine();
    //		Console.ReadKey();
    //	}

    //}



    class Tovar
    {
        private string name; //ористер
        private int price;
        private int count;

        public Tovar(string name, int price, int count) //конструктор
        {
            this.name = name;  
            this.price = price;
            this.count = count;
        }

        public string Name  //касиеттер
        {
            get { return name; }
            set { name = value; }
        }
        public int Price
        {
            get { return price; }
            set { if (value > 0) price = value; }
        }
        public int Count
        {
            get { return count; }
            set { if (value > 0) count = value; }
        }

        public int PriceSum()
        {
            return price * count;
        }

        public void Info()
        {
            Console.WriteLine("Товар аты = " + Name + "\n Багасы = " + Price + "\n Товар саны = " + count + "\n Товардын жалпы суммасы = " + PriceSum());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Tovar t1 = new Tovar("tovar1", 1200, 4);
            Tovar t2 = new Tovar("tovar2", 1450, 2);
            Tovar t3 = new Tovar("tovar3", 980, 3);
            t1.Info();
            t2.Info();
            t3.Info();

            int[] arraySum = new int[] { t1.PriceSum(), t1.PriceSum(), t1.PriceSum() };
            int max = int.MinValue;
            for (int i = 0; i < arraySum.Length; i++)
            {
                if (arraySum[i] > max)
                {
                    //найден больший элемент
                    max = arraySum[i];
                }
            }
            Console.WriteLine("\nЖалпы багасы улкен товар багасы: " + max);
            Console.ReadKey();
        }
    }
}
