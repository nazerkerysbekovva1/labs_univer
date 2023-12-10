using System;

namespace prak4
{
    class Tereze
    {
        public string tereze_taqyryby;
        public int X;
        public int Y;
        public int H;
        public int L;

        public Tereze(int X, int Y, int H, int L)
        {
            this.X = X;
            this.Y = Y;
            this.H = H;
            this.L = L;
        }
        
        public Tereze(Tereze a)
        {
            tereze_taqyryby = a.tereze_taqyryby;
            X = a.X;
            Y = a.Y;
            H = a.H;
            L = a.L;
        }

        public static int ZhanaTereze(Tereze t1, Tereze t2)
        {
            int a = 0, b = 0;
            if((t1.Y >= t2.Y && t2.Y < t1.Y + t1.H) && (t1.X <= t2.X && t2.X > t1.X + t1.L))
            {
                a = t1.H + t1.H - (t1.Y - t2.Y); 
                b = t1.L + t2.L + (t2.X - t1.L);
            }
            else { Console.WriteLine("Еки терезе киылысады"); }
            return a * b;
        }

        public int Area()
        {
            return H * L;
        }

        public void Shygaru()
        {
            Console.WriteLine(tereze_taqyryby + "\nTereze:" + "\nСол жак тобе координатасы: z = (" + X + "," + Y + ")" + "\nБиыктыгы:" + H + "\nУзындыгы:" + L);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Tereze tereze1 = new Tereze(0, 80, 40, 50);
            tereze1.tereze_taqyryby = "SL компаниясынын 40*50 стандартты олшемындегы терезе";
            tereze1.Shygaru();
            Console.WriteLine("Tereze audany: " + tereze1.Area());

            Console.WriteLine();
            Console.WriteLine("Tereze koshirmesi:");
            Tereze ter = new Tereze(tereze1);
            ter.Shygaru();
            Console.WriteLine("Tereze audany: " + ter.Area());

            Console.WriteLine();
            Tereze tereze2 = new Tereze(70, 60, 60, 30);
            tereze2.tereze_taqyryby = "QL компаниясынын 60*30 стандартты олшемындегы терезе";
            tereze2.Shygaru();
            Console.WriteLine("Tereze audany: " + tereze2.Area());

            Console.WriteLine();
            Console.WriteLine("Еки терезени камтитын жана терезе ауданы:"+ Tereze.ZhanaTereze(tereze1, tereze2));
            Console.ReadKey();
        }
    }
}
