using System;

namespace esep4
{
    class Esepshot
    {
        public int aqsha_kolemi;
        public int nomeri;
        public int syiaqy_molsheri;
        public Esepshot(int a, int b, int s)
        {
            aqsha_kolemi = a;
            nomeri = b;
            syiaqy_molsheri = s;
        }
        public void Shygaru()
        {
            //  Console.WriteLine("Esepshot iesinin tegi:" + Tegi);
            Console.WriteLine("Esepshot nomeri:" + nomeri);
            Console.WriteLine("Esepshottagy aqsha kolemi:" + aqsha_kolemi + "tenge.");
            Console.WriteLine("Syiaqy molsheri:" + syiaqy_molsheri + " %");
        }
    }
    static class Keneitu
    {
        public static int Jinalgan(this Esepshot e1)
        {
            int aq = 0; int sy = 0;
            aq = e1.aqsha_kolemi;
            sy = e1.syiaqy_molsheri;
            return ((aq * sy) / 100);
        }
    }
    class Program
    {
        static void Main()
        {
            Esepshot esepshot = new Esepshot(870000, 515, 10);
            esepshot.Shygaru();

            int summa_syiaqy = Keneitu.Jinalgan(esepshot);
            Console.WriteLine("Esepshotta 12 ai ishinde jinaqtalgan syiaqy molsheri:" + summa_syiaqy + " tenge.");

            Console.ReadKey();

        }
    }
}
