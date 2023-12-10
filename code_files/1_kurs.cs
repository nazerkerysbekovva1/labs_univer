//using System;

//namespace _1_kurs
//{
//    class Jalagy
//    {
//        private string name { get; set; }
//        private int sum_jalaky { get; set; }
//        private int ornalasy_jyly { get; set; }
//        private string koterme_paiyzy { get; set; }
//        private int salyk { get; set; }
//        private string esep_aiy { get; set; }
//        private int jumys_kuni { get; set; }
//        private int jumyska_kelgen_kuni { get; set; }
//        public Jalagy(string n, int o, string p, int s, string e, int k, int j)
//        {
//            name = n;
//            sum_jalaky = Jalaky();
//            ornalasy_jyly = o;
//            koterme_paiyzy = p;
//            salyk = s;
//            esep_aiy = e;
//            jumys_kuni = k;
//            jumyska_kelgen_kuni = j;
//        }
//        public int Jalaky()
//        {
//            if (jumys_kuni == jumyska_kelgen_kuni)
//            {
//                sum_jalaky = jumys_kuni * 1000;
//            }
//            else
//            {
//                sum_jalaky = jumyska_kelgen_kuni * 1000;
//            }
//            return sum_jalaky;
//        }
//        public int Jalpy_jalaky(int ai)
//        {
//            int jalaky = 0;
//            jalaky = (ai * Jalaky()) - salyk;
//            return jalaky;
//        }
//        public void Display1()
//        {
//            Console.WriteLine($"Kyzmetker aty-joni: {name} \nAi saiingy salyk molsheri: {salyk} \nJumyska ornalaskan jyly: {ornalasy_jyly} \nAilygy: {Jalaky()}");
//        }
//        public void Display2()
//        {
//            Console.WriteLine($"2 aida alatyn jalpy ailyk molsheri: " + Jalpy_jalaky(2));
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Jalagy j = new Jalagy("Koshkarbai Arman", 2012, "30%", 10000, "Dekabr", 25, 21);
//            Console.WriteLine();
//            j.Display1();
//            Console.WriteLine();
//            j.Display2();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace lab
//{
//    class Program
//    {
//        //nайти длину отрезка в метрах
//        static void LenghtMetr()
//        {
//            double length;
//            int u;

//            Console.Write("  Введите единицы измерения (1 — дециметр, 2 — километр, 3 — метр, 4 — миллиметр, 5 — сантиметр): ");
//            while (!int.TryParse(Console.ReadLine(), out u) || u < 1 || u > 5)
//            {
//                Console.Write("Ошибка ввода!\n Введите ещё раз единицы измерения (1 — дециметр, 2 — километр, 3 — метр, 4 — миллиметр, 5 — сантиметр): ");
//            }

//            Console.Write("  Введите длину в указанных единицах измерения: ");
//            while (!double.TryParse(Console.ReadLine(), out length))
//            {
//                Console.Write("Ошибка ввода!\n Введите ещё раз длину в указанных единицах измерения: ");
//            }

//            Console.WriteLine($"\n  Указанная длина составляет в метрах  {Length(u, length, Dlina.метр)}");
//            Console.ReadLine();
//        }
//        static void Length(int u, double length, Dlina dl)
//        {
//            // switch (u)
//            {
//                double result = dl switch
//                {
//                    Dlina.миллиметр => length * 0.1,
//                    Dlina.сантиметр => length * 1000.0,
//                    Dlina.дециметр => length,
//                    Dlina.метр => length * 0.001,
//                    Dlina.километр => length * 0.01
//                };
//                Console.WriteLine(result);
//            }
//        }
//        static void Main(string[] args)
//        {
//            Console.WriteLine("7 метров = {0} см.", Length(4, 7, Dlina.сантиметр));
//            Console.ReadLine();
//        }
//        enum Dlina
//        {
//            миллиметр,
//            сантиметр,
//            дециметр,
//            метр,
//            километр
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text;
//using System.Xml.Linq;
//using static System.Net.WebRequestMethods;

//namespace lab
//{
    // Proc24. Описать функцию Even(K) логического типа, возвращающую True, если целый параметр K является четным,
    // и False в противном случае.С ее помощью найти количество четных чисел в наборе из 10 целых чисел.


    //class Program
    //{
    //    static bool Even(int k)
    //    {
    //        if (k % 2 == 0)
    //            return true;
    //        else
    //            return false;
    //    }

    //    static void Main(string[] args)
    //    {
    //        int sum = 0;
    //        int quantity = 0;
    //        int[] array = new int[10] { 2, 5, 8, 4, 12, 32, 9, 20, 5, 6 };

    //        for (int i = 0; i < array.Length; i++)
    //        {
    //            if (Even(array[i]))
    //            {
    //                sum += array[i];
    //                quantity++;
    //            }
    //        }
    //        Console.WriteLine("Quantity of even number:" + quantity);
    //        Console.WriteLine("Sum of even number:" + sum);
    //    }
    //}



    // Proc12. Описать процедуру SortInc3(A, B, C), меняющую содержимое переменных A, B, C таким образом,
    // чтобы их значения оказались упорядоченными по возрастанию (A, B, C — вещественные параметры, являющиеся одновременно входными и выходными).
    // С помощью этой процедуры упорядочить по возрастанию два данных набора из трех чисел: (A1, B1, C1) и (A2, B2, C2).

    //class Program
    //{
    //    static void Swap(ref int x, ref int y)
    //    {
    //        x = x + y;
    //        y = x - y;
    //        x = x - y;
    //    }


    //    static void SortInc3(ref int A, ref int B, ref int C)
    //    {
    //        if (A > B) Swap(ref A, ref B);
    //        if (B > C) Swap(ref B, ref C);
    //        if (A > B) Swap(ref A, ref B);
    //    }


    //    static void Main(string[] args)
    //    {
    //        int i;

    //        for (i = 1; i <= 2; ++i)
    //        {
    //            int A, B, C;
    //            Console.Write("A:{0} = ", i);
    //            A = int.Parse(Console.ReadLine());
    //            Console.Write("B:{0} = ", i);
    //            B = int.Parse(Console.ReadLine());
    //            Console.Write("C:{0} = ", i);
    //            C = int.Parse(Console.ReadLine());

    //            SortInc3(ref A, ref B, ref C);
    //            Console.WriteLine("A:{0}; B:{1}; C:{2}", A, B, C);
    //            Console.WriteLine();
    //        }
    //    }
    //}

    //class ArifProgressia
    //{
    //    public int a1;  //прогрессияның алғашқы элементі 
    //    public int d;   //тұрақты қадамы
    //    public ArifProgressia(int a1, int d)
    //    {
    //        this.a1 = a1;
    //        this.d = d;
    //    }
    //    public int TandalganMushe(int n)
    //    {
    //        int an = a1 + (n - 1) * d;
    //        return an;
    //    }
    //    //public int TandalganKosyndy(int n)
    //    //{
    //    //    int sn = (TandalganMushe(n) + a1) * n / 2;
    //    //    return sn;
    //    //}
    //    public void Info()
    //    {
    //        Console.WriteLine("a1=" + a1 + "\td=" + d);
    //    }

    //    public static void Compare1(ArifProgressia ar1, ArifProgressia ar2, int n = 3)
    //    {
    //        if (ar1.TandalganMushe(n) < ar2.TandalganMushe(n))
    //            Console.WriteLine($"{ar1.TandalganMushe(n)} < {ar2.TandalganMushe(n)}");
    //        else
    //            Console.WriteLine($"{ar1.TandalganMushe(n)} < {ar2.TandalganMushe(n)}");
    //    }

    //    public static void Compare2(ArifProgressia ar1, ArifProgressia ar2, int n = 3)
    //    {
    //        if (ar1.a1 > ar2.a1)
    //            if (ar1.a1 > n)
    //                Console.WriteLine($"{ar1.a1} - {n} ten ulken");
    //        if (ar1.a1 < ar2.a1)
    //            if (ar2.a1 > n)
    //                Console.WriteLine($"{ar2.a1} - {n} ten ulken");
    //    }

    //    public static ArifProgressia operator +(ArifProgressia ar1, ArifProgressia ar2)
    //    {
    //        int value_a1 = ar1.a1 + ar2.a1;
    //        int value_d = (ar1.d + ar2.d) / 2;
    //        return new ArifProgressia(value_a1, value_d);
    //    }

    //    public static bool operator true(ArifProgressia ar)
    //    {
    //        if (ar.d > 0) return true;
    //        else return false;
    //    }
    //    public static bool operator false(ArifProgressia ar)
    //    {
    //        if (ar.d < 0) return true;
    //        else return false;
    //    }
    //    //public static ArifProgressia operator --(ArifProgressia ar)
    //    //{
    //    //    ArifProgressia natizhe = new ArifProgressia();
    //    //    natizhe.d = ar.d - 1;
    //    //    return natizhe;
    //    //}

    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        ArifProgressia ar1 = new ArifProgressia(2, 3);
    //        ArifProgressia ar2 = new ArifProgressia(3, 2);
    //        ArifProgressia ar3;
    //        ar1.Info();
    //        ar2.Info();
    //        Console.WriteLine("\nЕкы арифметикалык прогрессияны салыстыру:");
    //        ArifProgressia.Compare1(ar1, ar2);
    //        ArifProgressia.Compare2(ar1, ar2);
    //        Console.WriteLine("\nЖана арифметика прогрессия обьектысы:");
    //        ar3 = ar1 + ar2;
    //        ar3.Info();
    //        Console.WriteLine("\nАрифметикалык прогрессияны акикаттыка тексеру:");
    //        if (ar1)   
    //        {
    //                Console.WriteLine("d sany - on san");
    //        }
    //        else Console.WriteLine("d sany - teris san");

    //        Console.ReadKey();
    //    }
    //}

    //class Pair
    //{
    //    public int a;
    //    public int b;
    //    public Pair(int a, int b)
    //    {
    //        this.a = a;
    //        this.b = b;
    //    }

    //    public Pair Ozgerty(char operation)
    //    {
    //        Pair pair = new Pair(a, b);
    //        switch (operation)
    //        {
    //            case '+':
    //                pair.a += a;
    //                pair.b += b;
    //                break;
    //            case '*':
    //                pair.a *= a;
    //                pair.b *= b;
    //                break;
    //        }
    //        return pair;
    //    }

    //    public int Kobeity()
    //    {
    //        return a * b;
    //    }

    //    public void Info()
    //    {
    //        Console.WriteLine("a=" + a + "\tb=" + b);
    //    }
    //}
    //class TiktortBurysh : Pair
    //{
    //    public TiktortBurysh(int a, int b) : base(a, b) { }

    //    public int Perimetr(char op)
    //    {
    //        return Ozgerty(op).a + Ozgerty(op).b;
    //    }

    //    public int Audan()
    //    {
    //        return base.Kobeity();
    //    }
    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        TiktortBurysh t1 = new TiktortBurysh(4, 5);
    //        char operation = '+';
    //        Console.WriteLine("\nTiktortBurysh kabyrgalary:");
    //        t1.Info();
    //        Console.WriteLine("TiktortBurysh perimetri:" + t1.Perimetr(operation));
    //        Console.WriteLine("TiktortBurysh audany:" + t1.Audan());

    //        TiktortBurysh t2 = new TiktortBurysh(6, 8);
    //        char operation1 = '+';
    //        Console.WriteLine("\nTiktortBurysh kabyrgalary:");
    //        t2.Info();
    //        Console.WriteLine("TiktortBurysh perimetri:" + t2.Perimetr(operation1));
    //        Console.WriteLine("TiktortBurysh audany:" + t2.Audan());

    //        Console.ReadKey();
    //    }
    //}

    //Описать процедуру Swap(X, Y), меняющую содержимое перемен- 
    //ных X и Y(X и Y — вещественные параметры, являющиеся одновременно
    //входными и выходными). С ее помощью для данных переменных A, B, 
    //C, D последовательно поменять содержимое следующих пар: A и B, C
    //и D, B и C и вывести новые значения A, B, C, D.

    //class Program
    //{
    //    static void Swap(ref int x, ref int y)
    //    {
    //        x = x + y;
    //        y = x - y;
    //        x = x - y;
    //    }

    //    static void Main(string[] args)
    //    {
    //        int A, B, C, D;
    //        Console.Write("A: = ");
    //        A = int.Parse(Console.ReadLine());
    //        Console.Write("B: = ");
    //        B = int.Parse(Console.ReadLine());
    //        Console.Write("C: = ");
    //        C = int.Parse(Console.ReadLine());
    //        Console.Write("D: = ");
    //        D = int.Parse(Console.ReadLine());

    //        Swap(ref A, ref B);
    //        Console.WriteLine("A:{0}; B:{1}; C:{2}; D:{3}", A, B, C, D);   //A и B
    //        Swap(ref C, ref D);
    //        Console.WriteLine("A:{0}; B:{1}; C:{2}; D:{3}", A, B, C, D);   //C и D
    //        Swap(ref B, ref C);
    //        Console.WriteLine("A:{0}; B:{1}; C:{2}; D:{3}", A, B, C, D);   //B и C 
    //    }
    //}

    //11-нұсқа
    //Адам класын құрыңыз, өрістері: аты, жасы, салмағы.Өрістердің мәндерін қайта тағайындау әдістерін құрыңыз.
    //Туынды Студент класын анықтаңыз, өрістері: курсы.Студенттің курсын жоғарылату әдісін анықтаңыз.

    //class Adam
    //{
    //    public string name;
    //    public int age;
    //    public int wight;
    //    public Adam(string name, int age, int wight)
    //    {
    //        this.name = name;
    //        this.age = age;
    //        this.wight = wight;
    //    }
    //    public virtual void Shygaru()
    //    {
    //            Console.WriteLine("Name: {0}. \nOld: {1}. \nWeight: {2}.", name, age, wight);
    //    }
    //    public void SetName(string name)
    //    {
    //        this.name = name;
    //    }

    //    public void SetAge(int age)
    //    {
    //        this.age = age;
    //    }

    //    public void SetWight(int wight)
    //    {
    //        this.wight = wight;
    //    }
    //}

    //class Student : Adam
    //{
    //    public int course;
    //    public Student(string name, int age, int weight, int course): base(name, age, weight)
    //    {
    //        this.course = course;
    //    }
    //    public override void Shygaru()
    //    {
    //        Console.WriteLine("__________Student__");
    //            base.Shygaru(); Console.WriteLine("Course: {0}.", course);
    //    }
    //    public void Increase_course()
    //    {
    //                course++;
    //            Console.WriteLine("__Increased the student's course  \nCourse: " + course);
    //    }
    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Adam a = new Adam("Erkebulan Sagymtai", 23, 66);
    //        Student s = new Student("Meruert Kayiptai", 19, 60, 2);
    //        a.SetName("Erkebulan Atymtai");
    //        a.SetAge(22);
    //        a.SetWight(70);
    //        a.Shygaru();
    //        Console.WriteLine();
    //        s.Shygaru();
    //        s.Increase_course();

    //        Console.ReadLine();
    //        Console.ReadKey();
    //    }
    //}

    //11-нұсқа
    //Терезе класын сипаттаңыз.Өрістері: терезе тақырыбы, сол жақ жоғарғы төбесінің тік және көлденең координаталары,
    //терезе биіктігі мен ені.Келесі әдістерді жүзеге асырыңыз: 
    //1.терезе параметрлерін өзгерту әдісін асыра жүктеңіз: бүтін санға көбейту арқылы және нақты санға көбейту арқылы масштабтау. 
    //2.екі терезенің қосындысын анықтау (+) операторын асыра жүктеңіз.Операция нәтижесінде екі терезенің орналасу ауданын толық қамтитын жаңа терезе құрылу керек;
    //3.терезе параметрлерін өзгерту әдісін асыра жүктеңіз: бүтін санға көбейту арқылы және нақты санға көбейту арқылы масштабтау.

    //class Tereze
    //{
    //    public string tereze_taqyryby;
    //    public double X;
    //    public double Y;
    //    public double H;
    //    public double L;

    //    public Tereze(double X, double Y, double H, double L)
    //    {
    //        this.X = X;
    //        this.Y = Y;
    //        this.H = H;
    //        this.L = L;
    //    }

    //    public void Scaling1(Tereze a, double ozg)
    //    {
    //        a.X *= ozg;
    //        a.Y *= ozg;
    //        a.H *= ozg;
    //        a.L *= ozg;
    //    }

    //    public static Tereze operator +(Tereze t1, Tereze t2)
    //    {
    //        Tereze Op = new Tereze(0, 0, 0, 0);
    //        if ((t1.Y >= t2.Y && t2.Y < t1.Y + t1.H) && (t1.X <= t2.X && t2.X > t1.X + t1.L))
    //        {
    //            Op.H = t1.H + t1.H - (t1.Y - t2.Y);
    //            Op.L = t1.L + t2.L + (t2.X - t1.L);
    //            Op.X = Op.L;
    //            Op.Y = t1.Y;
    //        }
    //        else { Console.WriteLine("Еки терезе киылысады"); }
    //        return Op;
    //    }

    //    public double Area()
    //    {
    //        return H * L;
    //    }

    //    public void Scaling2(Tereze a, int ozg)
    //    {
    //        a.X *= ozg;
    //        a.Y *= ozg;
    //        a.H *= ozg;
    //        a.L *= ozg;
    //    }

    //    public void Shygaru()
    //    {
    //        Console.WriteLine("Tereze:" + "\nСол жак тобе координатасы: z = (" + X + "," + Y + ")" + "\nБиыктыгы:" + H + "\nУзындыгы:" + L);
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Tereze tereze1 = new Tereze(0, 80, 40, 50);
    //        Console.WriteLine(tereze1.tereze_taqyryby = "SL компаниясынын 40*50 стандартты олшемындегы терезе");
    //        tereze1.Shygaru();
    //        Console.WriteLine("Tereze audany: " + tereze1.Area());

    //        Console.WriteLine();
    //        Tereze tereze2 = new Tereze(70, 60, 60, 30);
    //        Console.WriteLine(tereze2.tereze_taqyryby = "QL компаниясынын 60*30 стандартты олшемындегы терезе");
    //        tereze2.Shygaru();
    //        Console.WriteLine("Tereze audany: " + tereze2.Area());

    //        Console.WriteLine();
    //        Tereze TEREZE = tereze1 + tereze2;
    //        Console.WriteLine("Еки терезени камтитын жана терезе ауданы:");
    //        TEREZE.Shygaru();

    //        Console.WriteLine();
    //        Console.WriteLine("Scaling бутин параметрмен:");
    //        tereze1.Scaling1(tereze1, 7.5);
    //        tereze1.Shygaru();

    //        Console.WriteLine();
    //        Console.WriteLine("Scaling накты параметрмен:");
    //        tereze1.Scaling2(tereze1, 10);
    //        tereze1.Shygaru();

    //        Console.WriteLine();
    //        Tereze TEREZE1 = tereze1 + tereze2;
    //        Console.WriteLine("Еки терезени камтитын жана терезе ауданы:");
    //        TEREZE1.Shygaru();
    //        Console.ReadKey();
    //    }
    //}


    //11-нұсқа
    //Терезе класын сипаттаңыз.Өрістері: терезе тақырыбы, сол жақ жоғарғы төбесінің тік және көлденең координаталары,
    //терезе биіктігі мен ені.Класс үшін статикалық өріс ойластырыңыз.
    //Абрамян оқулығынан берілген тапсрыманы орындаңыз.

    //class Tereze
    //{
    //    static string tereze_taqyryby;
    //    static int X;
    //    static int Y;
    //    static int H;
    //    static int L;

    //    public Tereze(string taqryp, int x, int y, int h, int l)
    //    {
    //        tereze_taqyryby = taqryp;
    //        X = x;
    //        Y = y;
    //        H = h;
    //        L = l;
    //    }

    //    public int Area()
    //    {
    //        return H * L;
    //    }


    //    public void Shygaru()
    //    {
    //        Console.WriteLine(tereze_taqyryby + "\nTereze:" + "\nСол жак тобе координатасы: z = (" + X + "," + Y + ")" + "\nБиыктыгы:" + H + "\nУзындыгы:" + L);
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Tereze tereze = new Tereze("SL компаниясынын 40*50 стандартты олшемындегы терезе", 0, 0, 40, 50);
    //        tereze.Shygaru(); Console.WriteLine("Tereze audany: " + tereze.Area());
    //        Console.ReadKey();
    //    }
    //}

    //11-нұсқа Терезе класын сипаттаңыз. Өрістері: терезе тақырыбы, сол жақ жоғарғы төбесінің тік және көлденең координаталары,
    //терезе биіктігі мен ені. Келесі әдістерді жүзеге асырыңыз:
    //1. класс үшін бос, параметрлі және көшіру конструкторларын құру;
    //2. терезе параметрлерін өзгерту әдісін асыра жүктеңіз: бүтін санға көбейту арқылы және нақты санға көбейту арқылы масштабтау.

    //class Tereze
    //{
    //    public string tereze_taqyryby;
    //    public int X;
    //    public int Y;
    //    public int H;
    //    public int L;

    //    public Tereze(string taqryp, int x, int y, int h, int l)
    //    {
    //        tereze_taqyryby = taqryp;
    //        X = x;
    //        Y = y;
    //        H = h;
    //        L = l;
    //    }

    //    public Tereze(Tereze a)
    //    {
    //        tereze_taqyryby = a.tereze_taqyryby;
    //        X = a.X;
    //        Y = a.Y;
    //        H = a.H;
    //        L = a.L;
    //    }

    //    public static int koordinata1(int x)
    //    {
    //        if (x <= 100) { x = x + 50; }
    //        else Console.WriteLine("Qate");
    //        return x;
    //    }
    //    public static int koordinata2(int y)
    //    {
    //        if (y <= 100) { y = y + 50; }
    //        else Console.WriteLine("Qate");
    //        return y;
    //    }
    //    public static int h_ozgertu(int h) { h = h - 5; return h; }
    //    public static int l_ozgertu(int l) { l = l + 10; return l; }


    //    public void Shygaru()
    //    {
    //        Console.WriteLine(tereze_taqyryby + "\nTereze:" + "\nСол жак тобе координатасы: z = (" + X + "," + Y + ")" + "\nБиыктыгы:" + H + "\nУзындыгы:" + L);
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Tereze tereze = new Tereze("SL компаниясынын 40*50 стандартты олшемындегы терезе", 0, 0, 40, 50);
    //        tereze.Shygaru();
    //        Console.WriteLine();
    //        Console.WriteLine("Олшеми озгертилген терезе олшемдеры" + "\nСол жак тобе координатасы: z = (" + Tereze.koordinata1(0) + "," + Tereze.koordinata2(0) + ")" + "\nБиыктыгы:" + Tereze.h_ozgertu(40) + "\nУзындыгы:" + Tereze.l_ozgertu(50));
    //        Console.ReadKey();

    //    }
    //}
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Tamerlan
{
    public class EventArgs : System.EventArgs
    {
        public readonly string kino;
        public EventArgs(string kino)
        {
            this.kino = kino;
        }
    }

    class prog
    {
        static void Main()
        {
            kinoteatr kino = new kinoteatr();
            kinoteatr[] kinoteatrs =
            {
                new kinoteatr("Chaplin","dolby",42,1300,"Сатпаева","1"),
                new kinoteatr("Esentai","IMAX",38,2200,"Аль-Фараби","2"),
                new kinoteatr("Atakent","stereo",42,1200,"Тимирязева","3"),
                new kinoteatr("Sary-Arka","dolby",42,1400,"Алтынсарина","4")
            };
            result_kinoteatr_day[] results =
            {
                new result_kinoteatr_day(new DateTime(2022,12,12),kinoteatrs[0],"Star wars",37),
                new result_kinoteatr_day(new DateTime(2022,12,12),kinoteatrs[1],"Star wars",29),
                new result_kinoteatr_day(new DateTime(2022,12,12),kinoteatrs[2],"Star wars",40),
                new result_kinoteatr_day(new DateTime(2022,12,12),kinoteatrs[3],"Star wars",33),
                new result_kinoteatr_day(new DateTime(2022,12,13),kinoteatrs[0],"Avatar",34),
                new result_kinoteatr_day(new DateTime(2022,12,13),kinoteatrs[1],"Avatar",22),
                new result_kinoteatr_day(new DateTime(2022,12,13),kinoteatrs[2],"Avatar",41),
                new result_kinoteatr_day(new DateTime(2022,12,13),kinoteatrs[3],"Avatar",34),
                new result_kinoteatr_day(new DateTime(2022,12,14),kinoteatrs[0],"Forrest Gump",37),
                new result_kinoteatr_day(new DateTime(2022,12,14),kinoteatrs[1],"Forrest Gump",29),
                new result_kinoteatr_day(new DateTime(2022,12,14),kinoteatrs[2],"Forrest Gump",40),
                new result_kinoteatr_day(new DateTime(2022,12,14),kinoteatrs[3],"Forrest Gump",33),
                new result_kinoteatr_day(new DateTime(2022,12,15),kinoteatrs[0],"The Terminal",36),
                new result_kinoteatr_day(new DateTime(2022,12,15),kinoteatrs[1],"The Terminal",26),
                new result_kinoteatr_day(new DateTime(2022,12,15),kinoteatrs[2],"The Terminal",42),
                new result_kinoteatr_day(new DateTime(2022,12,15),kinoteatrs[3],"The Terminal",37)
            };
            List<kinoteatr> kkk = kinoteatrs.ToList();

            kinoteatr.Habarlama(kkk);

            int[] data1 = new int[3];
            int[] data2 = new int[3];
            Console.WriteLine("1.Жыл,Ай,Кун:");
            for (int i = 0; i < data1.Length; i++) data1[i] = int.Parse(Console.ReadLine());
            Console.WriteLine("2.Жыл,Ай,Кун:");
            for (int i = 0; i < data2.Length; i++) data2[i] = int.Parse(Console.ReadLine());

            Console.WriteLine("----------------------------------------------------------------------------");
            kino.adis(new DateTime(data1[0], data1[1], data1[2]), new DateTime(data2[0], data2[1], data2[2]), results, kinoteatrs);

            Console.WriteLine("----------------------------------------------------------------------------");
            kinoteatr.adisEvent(new DateTime(data1[0], data1[1], data1[2]), new DateTime(data2[0], data2[1], data2[2]), results, kinoteatrs);

            Console.ReadKey();
        }
    }
    class kinoteatr
    {
        //private дегендер олар өрістер
        // get{} set{} ол қасиеттер
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string klass; // stereo , dolby ,IMAX
        public string Klass
        {
            get { return klass; }
            set { if (value == "stereo" || value == "dolby" || value == "IMAX") klass = value; }
        }
        private int kolichestva_mest;
        public int KolichestvaMest
        {
            get { return kolichestva_mest; }
            set { if (value > 0) kolichestva_mest = value; }
        }
        private int price_bilet;
        public int PriceBilet
        {
            get { return price_bilet; }
            set { if (value > 0) price_bilet = value; }
        }
        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string surname_director;
        public string SurnameDirector
        {
            get { return surname_director; }
            set { surname_director = value; }
        }
        public kinoteatr() { } // конструктор
        public kinoteatr(string name, string klass, int kolichestva_mest, int price_bilet, string address, string surname_director)//конструктор

        {
            this.name = name;
            this.klass = klass;
            this.kolichestva_mest = kolichestva_mest;
            this.price_bilet = price_bilet;
            this.address = address;
            this.surname_director = surname_director;
        }

        public event EventHandler<EventArgs> UserEvent;
        public void OnUserEvent(EventArgs k)
        {
            if (UserEvent != null)
                UserEvent(this, k);
        }
        public void DisplayMessage(object sender, EventArgs k)
        {
            Console.WriteLine($"___{k.kino} kinoteatyrynda. '{((kinoteatr)sender).Address}' addresinde bolatyn kinodan tusetin aksha summasy = {((kinoteatr)sender).KolichestvaMest * ((kinoteatr)sender).PriceBilet}");
            Console.ResetColor();
        }

        public static void Habarlama(List<kinoteatr> k)
        {
            for (int i = 0; i < k.Count; i++)
            {
                k[i].UserEvent += k[i].DisplayMessage;
            }
        }

        public void adis(DateTime date1, DateTime date2, result_kinoteatr_day[] results, kinoteatr[] kinoteatrs)  //тапсырма
        {
            double[] sum = new double[4];
            TimeSpan days = date2 - date1;
            int d = days.Days;
            for (int i = 0; i < results.Length; i++)
            {
                if (results[i].Date >= date1 && results[i].Date <= date2)
                {
                    if (results[i].NameKinoteatr == kinoteatrs[0].Name)
                    {
                        sum[0] += (results[i].KolichestvaZritelei * kinoteatrs[0].PriceBilet);
                    }
                    if (results[i].NameKinoteatr == kinoteatrs[1].Name)
                    {
                        sum[1] += (results[i].KolichestvaZritelei * kinoteatrs[1].PriceBilet);
                    }
                    if (results[i].NameKinoteatr == kinoteatrs[2].Name)
                    {
                        sum[2] += (results[i].KolichestvaZritelei * kinoteatrs[2].PriceBilet);
                    }
                    if (results[i].NameKinoteatr == kinoteatrs[3].Name)
                    {
                        sum[3] += (results[i].KolichestvaZritelei * kinoteatrs[3].PriceBilet);
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"{i + 1}.{kinoteatrs[i].Name} -\nСуммарная выручка: {sum[i]} \nСредняя выручка: {sum[i] / (d + 1)}");
            }
        }

        public static void adisEvent(DateTime date1, DateTime date2, result_kinoteatr_day[] results, kinoteatr[] kinoteatrs)
        {
            for (int i = 0; i < kinoteatrs.Length; i++)
            {
                if (results[i].Date >= date1 && results[i].Date <= date2)
                {
                    kinoteatrs[i].OnUserEvent(new EventArgs(kinoteatrs[i].Name));
                }
            }
        }
    }
    class result_kinoteatr_day
    {
        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        private string name_kinoteatr;
        public string NameKinoteatr
        {
            get { return name_kinoteatr; }
            set { name_kinoteatr = value; }
        }
        private string name_kino;
        public string NameKino
        {
            get { return name_kino; }
            set { name_kino = value; }
        }
        private int kolichestva_zritelei;
        public int KolichestvaZritelei
        {
            get { return kolichestva_zritelei; }
            set { if (value > 0) kolichestva_zritelei = value; }
        }
        public result_kinoteatr_day(DateTime date, kinoteatr k, string name_kino, int kolichestva_zritelei)//
        {
            this.date = date;
            name_kinoteatr = k.Name;
            this.name_kino = name_kino;
            this.kolichestva_zritelei = kolichestva_zritelei;
        }
    }
}
