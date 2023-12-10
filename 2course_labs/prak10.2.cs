using System;

namespace prak10._2
{
    class Tereze
    {
        public delegate void NNN(string shygaru);
        public NNN ter;
        public void AA(NNN _ter)
        {
            ter = _ter;
        }

        public static string tereze_taqyryby = "SL компаниясынын стандартты олшемындегы терезе";
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
        public int Kob()
        {
            return H * L;
        }
        public void Shygaru()
        {
            ter(tereze_taqyryby + "\nTereze:" + "\nСол жак тобе координатасы: z = (" + X + "," + Y + ")" + "\nБиыктыгы: " + H + "\nУзындыгы: " + L + "\nАуданы: " + Kob());
        }
    }

    static class Terezeler
    {
        public static int ZhanaTereze(this Tereze t1, Tereze t2)
        {
            int a = 0, b = 0;
            if ((t1.Y >= t2.Y && t2.Y < t1.Y + t1.H) && (t1.X <= t2.X && t2.X > t1.X + t1.L))
            {
                a = t1.H + t1.H - (t1.Y - t2.Y);
                b = t1.L + t2.L + (t2.X - t1.L);
            }
            else { Console.WriteLine("Еки терезе киылысады"); }
            return a * b;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Tereze[] tereze = { new Tereze(0, 80, 40, 50), 
                                 new Tereze(70, 60, 60, 30)};
            foreach (Tereze t in tereze)
            { 
                t.AA(new Tereze.NNN(Shygaruu));
                t.Shygaru();
            }
            Console.WriteLine();
            Console.WriteLine("Еки терезени камтитын жана терезе ауданы: " + Terezeler.ZhanaTereze(tereze[0], tereze[1]));
            Console.ReadKey();
        }
        private static void Shygaruu(string shygaru)
        {
            Console.WriteLine(shygaru);
        }
    }
}
