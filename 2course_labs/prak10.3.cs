using System;   //7lab

namespace prak10._3
{
    //delegate void NNN(ref Student[] info);
    //class Student
    //{
    //    public string name;
    //    public string specialty;
    //    public int course;
    //    public double GPA_score;
    //    public Student(string name, string spec, int course, double gpa)
    //    {
    //        this.name = name;
    //        specialty = spec;
    //        this.course = course;
    //        GPA_score = gpa;
    //    }
    //    public virtual void Shygaru(ref Student[] info)
    //    {
    //        foreach (Student s in info) {
    //            Console.WriteLine("__________Student__");
    //            Console.WriteLine("Name: {0}. \nSpecialty: {1}. \nCourse: {2}. \nGPA_score: {3}. \nStipendia: {4}", s.name, s.specialty, s.course, s.GPA_score, s.Stipendia()); }
    //    }
    //    public virtual void Change_course(ref Student[] info)
    //    {
    //        foreach (Student s in info)
    //        {
    //            if (GPA_score > 2)
    //            {
    //                s.course++;
    //            }
    //            Console.WriteLine("__Changed the student's course  \nCourse: " + course);
    //        }
    //    }
    //    public virtual double Stipendia()
    //    {
    //        double stipendia=0;
    //        if (GPA_score > 3 && GPA_score <= 4)
    //        {
    //            return stipendia = 70000;
    //        }
    //        if (GPA_score > 2  && GPA_score <= 3)
    //        {
    //            return stipendia = 50000;
    //        }
    //        else if (GPA_score > 1 && GPA_score <= 2)
    //        {
    //            return stipendia = 30000;
    //        }
    //        else
    //        {
    //            return stipendia  = 10000;
    //        }
    //    }
    //}
    //class Paid_study: Student
    //{
    //    public int payment_for_study;
    //    public Paid_study(string name, string spec, int course, double gpa, int payment) : base(name, spec, course, gpa)
    //    {
    //        payment_for_study = payment;
    //    }
    //    //public override void Shygaru(ref Student[] info)
    //    //{
    //    //    base.Shygaru(ref info);
    //    //}
    //    public override void Change_course(ref Student[] info)
    //    {
    //        base.Change_course(ref info);
    //        string check_mark = "+";
    //        switch (check_mark)
    //        {
    //            case "+":
    //                Console.WriteLine("Payment_for_study: " + payment_for_study+" --- Paid!");
    //                break;
    //            case "-":
    //                Console.WriteLine("Payment_for_study: " + payment_for_study + " --- UnPaid!");
    //                break;
    //        }
    //    }
    //    public override double Stipendia()
    //    {
    //        double stipendia = 0;
    //        return stipendia;
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Student[] array ={ new Student("Nazerke Rysbek", "IT-specialist", 2, 3.77),
    //                           new Paid_study("Meruert Kayiptai", "Doctor", 2, 2.95, 1200000) };


    //        Console.ReadLine();
    //        Console.ReadKey();

    //        NNN n;
    //        NNN shygaru = array[0].Shygaru;
    //        NNN change = array[1].Change_course;
    //        n = shygaru;
    //        n += change;
    //        n(ref array);
    //    }
    //}

    //7lab 8nusqa
    //delegate void dell(ref Tiktortburysh[] info);
    //class Tiktortburysh
    //{
    //    public int a;
    //    public int b;
    //    public Tiktortburysh(int a, int b) { this.a = a; this.b = b; }
    //    public virtual double Perimetr()
    //    {
    //        return 2 * (a + b);
    //    }
    //    public virtual double Audan()
    //    {
    //        return a * b;
    //    }
    //    public virtual void Info(ref Tiktortburysh[] info)
    //    {
    //        Console.WriteLine($"a={a} \nb={b} \nP={Perimetr()} \nS={Audan()}");
    //    }
    //}
    //class DongTortburysh : Tiktortburysh
    //{
    //    public int r;
    //    public DongTortburysh(int a, int b, int r) : base(a, b) { this.r = r; }
    //    public override double Perimetr()
    //    {
    //        return 8 * r + 2 * Math.PI * r;
    //    }
    //    public override double Audan()
    //    {
    //        return 4 * r * r + Math.PI * r * r; ;
    //    }
    //    public override void Info(ref Tiktortburysh[] info)
    //    {
    //        Console.WriteLine($"\na={a} \nb={b} \nr={r} \nP={Perimetr()} \nS={Audan()}");
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Tiktortburysh[] burysh = { new Tiktortburysh(2, 3), new DongTortburysh(2, 3, 4) };

    //        for (int i = 0; i < burysh.Length; i++)
    //        {
    //            dell dl;
    //            dell info = burysh[i].Info;
    //            dl = info;
    //            dl(ref burysh);
    //        }
    //            Console.ReadKey();
    //    }
    //}
}
