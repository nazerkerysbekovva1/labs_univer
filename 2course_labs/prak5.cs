using System;

namespace prak5
{
    class Tereze
    {
        public string tereze_taqyryby;
        public double X;
        public double Y;
        public double H;
        public double L;

        public Tereze(double X, double Y, double H, double L)
        {
            this.X = X;
            this.Y = Y;
            this.H = H;
            this.L = L;
        }

        public void Scaling1(Tereze a, double ozg)
        {
            a.X *= ozg;
            a.Y *= ozg;
            a.H *= ozg;
            a.L *= ozg;
        }

        public static Tereze operator +(Tereze t1, Tereze t2)
        {
            Tereze Op = new Tereze(0,0,0,0);
            if ((t1.Y >= t2.Y && t2.Y < t1.Y + t1.H) && (t1.X <= t2.X && t2.X > t1.X + t1.L))
            {
                Op.H = t1.H + t1.H - (t1.Y - t2.Y);
                Op.L = t1.L + t2.L + (t2.X - t1.L);
                Op.X = Op.L;
                Op.Y = t1.Y;    
            }
            else { Console.WriteLine("Еки терезе киылысады"); }
            return Op;
        }

        public double Area()
        {
            return H * L;
        }

        public void Scaling2(Tereze a, int ozg)
        {
            a.X *= ozg;
            a.Y *= ozg;
            a.H *= ozg;
            a.L *= ozg;
        }

        public void Shygaru()
        {
            Console.WriteLine("Tereze:" + "\nСол жак тобе координатасы: z = (" + X + "," + Y + ")" + "\nБиыктыгы:" + H + "\nУзындыгы:" + L);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Tereze tereze1 = new Tereze(0, 80, 40, 50);
            Console.WriteLine(tereze1.tereze_taqyryby = "SL компаниясынын 40*50 стандартты олшемындегы терезе");
            tereze1.Shygaru();
            Console.WriteLine("Tereze audany: " + tereze1.Area());

            Console.WriteLine();
            Tereze tereze2 = new Tereze(70, 60, 60, 30);
            Console.WriteLine(tereze2.tereze_taqyryby = "QL компаниясынын 60*30 стандартты олшемындегы терезе");
            tereze2.Shygaru();
            Console.WriteLine("Tereze audany: " + tereze2.Area());

            Console.WriteLine();
            Tereze TEREZE= tereze1 + tereze2;
            Console.WriteLine("Еки терезени камтитын жана терезе ауданы:"); 
            TEREZE.Shygaru();

            Console.WriteLine();
            Console.WriteLine("Scaling бутин параметрмен:");
            tereze1.Scaling1(tereze1, 7.5);
            tereze1.Shygaru();

            Console.WriteLine();
            Console.WriteLine("Scaling накты параметрмен:");
            tereze1.Scaling2(tereze1, 10);
            tereze1.Shygaru();

            Console.WriteLine();
            Tereze TEREZE1 = tereze1 + tereze2;
            Console.WriteLine("Еки терезени камтитын жана терезе ауданы:");
            TEREZE1.Shygaru();
            Console.ReadKey();
        }
    }
}
