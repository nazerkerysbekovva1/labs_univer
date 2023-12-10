using System;
class Tereze
{
    public string tereze_taqyryby;
    public int x;
    public int y;
    public int h;
    public int l;

    public static int h_kabirga = 15, b_kabirga = 60;
    public string[,] kabirga = new string[h_kabirga, b_kabirga];

    public Tereze(string taqryp, int x, int y, int h, int l)
    {
        tereze_taqyryby = taqryp;
        this.x = x;
        this.y = y;
        this.h = h;
        this.l = l;
    }

    public int koordinata1(int ozg)
    {
        if (x <= 100) { x += ozg; }
        else Console.WriteLine("Qate");
        return x;
    }
    public int koordinata2(int ozg)
    {
        if (y <= 100) { y += ozg; }
        else Console.WriteLine("Qate");
        return y;
    }
    public int h_ozgertu(int ozg) { h += ozg; return h; }
    public int l_ozgertu(int ozg) { l += ozg; return l; }


    public void Shygaru()
    {
        Console.WriteLine(tereze_taqyryby + "\nTereze:" + "\nСол жак тобе координатасы: z = (" + x + "," + y + ")" + "\nБиыктыгы:" + h + "\nУзындыгы:" + l);
    }
    public static int Audan(Tereze t1, Tereze t2)
    {
        int a = 0, b = 0;

        if ((t1.y <= t2.y && t2.y < t1.y + t1.l) && (t1.x <= t2.x && t2.x < t1.x + t1.h))//еки терезе киылыса ма соны тексерип аламыз
        {
            a = t1.x + t1.l - t2.x;
            b = t1.y + t1.h - t2.y;
        }

        return a * b;
    }
    public void Print()
    {
        for (int i = 0; i < h_kabirga; i++)
        {
            for (int j = 0; j < b_kabirga; j++)
            {
                kabirga[i, j] = "*";
            }
        }

        for (int i = x; i < x + l; i++)
        {
            for (int j = y; j < y + h; j++)
            {
                kabirga[i, j] = " ";
            }
        }



        for (int i = 0; i < h_kabirga; i++)
        {
            for (int j = 0; j < b_kabirga; j++)
            {
                Console.Write(kabirga[i, j]);
            }
            Console.WriteLine();
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Tereze tereze1 = new Tereze("SL компаниясынын 40*50 стандартты олшемындегы терезе", 2, 6, 10, 5);

        tereze1.Shygaru();
        tereze1.Print();
        tereze1.l_ozgertu(3);
        tereze1.koordinata2(10);
        Console.WriteLine("\n_____________________");
        Console.WriteLine("___________________");
        Console.WriteLine("___________________\n");
        Console.WriteLine("\nОлшеми озгертилген терезе олшемдеры:");
        tereze1.Shygaru();
        tereze1.Print();

        Tereze tereze2 = new Tereze("KM компаниясынын 30*40 стандартты олшемындегы терезе", 4, 9, 7, 9);

        tereze2.Shygaru();
        tereze2.Print();

        Console.WriteLine("Еки терезе киылысса, киылысу ауданы:", Tereze.Audan(tereze1, tereze2));
        Console.ReadKey();

    }
}

