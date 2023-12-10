using System;
using System.Collections.Generic;

namespace prak11
{
    //delegate void del(double time);
    //class PostalOffice
    //{
    //    public event del UserEvent;

    //    public void OnUserEvent() 
    //    {
    //        if (UserEvent != null)
    //            UserEvent(AVGtime);
    //    }

    //    public int bolimshe;
    //    public int sanat;
    //    public double AVGtime;
    //    public double pr; //probability

    //    public PostalOffice(int bolim)
    //    {
    //        bolimshe = bolim;
    //    }
    //    public void Info()
    //    {
    //        Console.WriteLine();
    //        Console.WriteLine("___газеттер болимге уакытында жеткызылды");
    //    }
    //    public virtual void Zhetkizu() { }

    //    public void DisplayMessage(double time) //окига ондеуши
    //    {
    //        Console.WriteLine();
    //        Console.ForegroundColor = ConsoleColor.Red;
    //        Console.WriteLine($"___газеттер yакытынан кеш жеткызылды!  Жеткызудын орташа уакыты {time} сагатты курайды!");
    //        Console.ResetColor();
    //    }
    //}
    //class FirstCategory : PostalOffice
    //{
    //    public FirstCategory(int bolim) : base(bolim) {sanat = 1; AVGtime = 1; }
    //    public override void Zhetkizu()
    //    {
    //        Random rnd = new Random();
    //        int procent = rnd.Next(0, 100);
    //        double ver = (double)procent / 100;
    //        if (ver <= 0.95)
    //        {
    //            Info();
    //            pr = ver;
    //            Console.WriteLine("{0} санатты №{1} болимшедегы газеттер, жеткызу ыктималдылыгы - {2,2:f3}", sanat, bolimshe, pr);
    //        }
    //        else
    //        {
    //            OnUserEvent();
    //            pr = ver;
    //            Console.WriteLine("{0} санатты №{1} болимшедегы газеттер, жеткызу ыктималдылыгы - {2,2:f3}", sanat, bolimshe, pr);
    //        }
    //    }
    //}
    //class SecondCategory : PostalOffice
    //{
    //    public SecondCategory(int bolim) : base(bolim) {sanat = 2; AVGtime = 1.5; }
    //    public override void Zhetkizu()
    //    {
    //        Random rnd = new Random();
    //        int procent = rnd.Next(0, 100);
    //        double ver = (double)procent / 100;
    //        if (ver <= 0.8)
    //        {
    //            Info();
    //            pr = ver;
    //            Console.WriteLine("{0} санатты №{1} болимшедегы газеттер, жеткызу ыктималдылыгы - {2,2:f3}", sanat, bolimshe, pr);
    //        }
    //        else
    //        {
    //            OnUserEvent();
    //            pr = ver;
    //            Console.WriteLine("{0} санатты №{1} болимшедегы газеттер, жеткызу ыктималдылыгы - {2,2:f3}", sanat, bolimshe, pr);
    //        }
    //    }
    //}
    //class ThirdCategory : PostalOffice
    //{
    //    public ThirdCategory(int bolim) : base(bolim) { sanat = 3; AVGtime = 2; }
    //    public override void Zhetkizu()
    //    {
    //        Random rnd = new Random();
    //        int procent = rnd.Next(0, 100);
    //        double ver = (double)procent / 100;
    //        if (ver <= 0.7)
    //        {
    //            Info();
    //            pr = ver;
    //            Console.WriteLine("{0} санатты №{1} болимшедегы газеттер, жеткызу ыктималдылыгы - {2,2:f3}", sanat, bolimshe, pr);
    //        }
    //        else
    //        {
    //            OnUserEvent();
    //            pr = ver;
    //            Console.WriteLine("{0} санатты №{1} болимшедегы газеттер, жеткызу ыктималдылыгы - {2,2:f3}", sanat, bolimshe, pr);
    //        }
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        PostalOffice[] baspa = { new FirstCategory(11),
    //                                 new FirstCategory(22),
    //                                 new SecondCategory(33),
    //                                 new SecondCategory(44),
    //                                 new ThirdCategory(55),
    //                                 new ThirdCategory(66)};

    //        for (int i = 0; i < baspa.Length-1; i++)
    //        {
    //            baspa[i].UserEvent += baspa[i+1].DisplayMessage;
    //            baspa[i].Zhetkizu();
    //        }
    //        Console.ReadKey();
    //    }
    //}

    //8nusqa

    //class Auditor
    //{
    //    public bool Biliktilik { get; set; } 
    //    public bool Sapar { get; set; } = false; 
    //    public Auditor(bool biliktilik) { Biliktilik = biliktilik; }
    //}

    //class Programmalaushy
    //{
    //    public bool Biliktilik { get; set; } 
    //    public bool Sapar { get; set; } = false; 
    //    public Programmalaushy(bool biliktilik) { Biliktilik = biliktilik; } 
    //}

    //class Kompania
    //{
    //    public delegate void del(string message);
    //    public event del UserEvent; // Определение события

    //    public List<Programmalaushy> Programmer;
    //    public List<Auditor> Auditor;
    //    public Kompania(List<Programmalaushy> programmer, List<Auditor> auditor) 
    //    {
    //        Programmer = programmer;
    //        Auditor = auditor;
    //    }

    //    public void OnUserEvent_1()
    //    {
    //         if (UserEvent != null)
    //            UserEvent("Іссапарға жіберілген қызметкерлер тобында біліктілігі жоғары программист жоқ!");
    //    }
    //    public void OnUserEvent_2()
    //    {
    //        if (UserEvent != null)
    //            UserEvent("Іссапарға жіберілген қызметкерлер тобында біліктілігі жоғары аудитор жоқ!");
    //    }

    //    // Функция отправки случайных работников в командировку 
    //    public void Issapar(int countofProgrammers, int countofAuditors)
    //    {
    //        int ZhogaryBilikti_1 = 0; // Счетчик, в котором будет записываться кол-во отправленных
    //        // в командировку программистов с высокой квалификацией
    //        Random rnd = new Random();

    //        while (countofProgrammers > 0)
    //        {
    //            int index = rnd.Next(Programmer.Count); // Случайный номер программиcта в списке

    //            // Если случайно выбранный программист уже не в командировке
    //            if (!Programmer[index].Sapar) Programmer[index].Sapar = true;
    //            else continue;

    //            if (Programmer[index].Biliktilik) ZhogaryBilikti_1++;
    //            countofProgrammers--;

    //            Console.WriteLine("\n"+countofProgrammers+"  "+ZhogaryBilikti_1);
    //        }
    //        if (ZhogaryBilikti_1 == 0)
    //            OnUserEvent_1();
    //        else Console.WriteLine("Іссапарға жіберілген қызметкерлер тобында біліктілігі жоғары программист саны - " + ZhogaryBilikti_1);

    //        // Аналогичная логика для аудиторов
    //        int ZhogaryBilikti_2 = 0;
    //        while (countofAuditors > 0)
    //        {
    //            int index = rnd.Next(Auditor.Count); // Случайный номер программиcта в списке

    //            // Если случайно выбранный программист уже не в командировке
    //            if (!Auditor[index].Sapar) Auditor[index].Sapar = true;
    //            else continue;

    //            if (Auditor[index].Biliktilik) ZhogaryBilikti_2++;
    //            countofAuditors--;

    //            Console.WriteLine("\n"+countofAuditors + "  " + ZhogaryBilikti_2);
    //        }

    //        if (ZhogaryBilikti_2 == 0)
    //            OnUserEvent_2();
    //        else Console.WriteLine("Іссапарға жіберілген қызметкерлер тобында біліктілігі жоғары аудитор саны - " + ZhogaryBilikti_2);
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        List<Programmalaushy> Programmers = new List<Programmalaushy>(); // Создаем список программистов
    //        // Создаем 3 программиста обычной и 2 высокой квалификации
    //        for (int i = 0; i < 5; i++) Programmers.Add(new Programmalaushy(false));
    //        for (int i = 0; i < 2; i++) Programmers.Add(new Programmalaushy(true));

    //        List<Auditor> Auditors = new List<Auditor>(); // Создаем список аудиторов
    //        // Создаем 5 аудиторов обычной и 3 высокой квалификации
    //        for (int i = 0; i < 8; i++) Auditors.Add(new Auditor(false));
    //        for (int i = 0; i < 3; i++) Auditors.Add(new Auditor(true));

    //        Kompania firm = new Kompania(Programmers, Auditors); // Создаем фирму, в которой будут работать программисты и аудиторы
    //        firm.UserEvent += DisplayMessage;   // Добавляем обработчик для события Notify
    //        firm.Issapar(2, 3); // Отправляем группу из 2-х программистов и 3-х аудиторов в коммандировку
    //    }

    //    // Функция, в которой описывается логика того, что происходит в случае отсутствия 
    //    // сотрудника высокой квалификации хотя бы одной из должностей
    //    private static void DisplayMessage(string message)
    //    {
    //        Console.WriteLine(message);
    //    }
    //}

    class Auditor
    {
        public bool Biliktilik { get; set; }
        public bool Sapar { get; set; } = false;
        public Auditor(bool biliktilik) { Biliktilik = biliktilik; }
    }

    class Programmalaushy
    {
        public bool Biliktilik { get; set; }
        public bool Sapar { get; set; } = false;
        public Programmalaushy(bool biliktilik) { Biliktilik = biliktilik; }
    }

    class Kompania
    {
        public delegate void del(string message);
        public event del UserEvent; 

        public List<Programmalaushy> Programmer;
        public List<Auditor> Auditor;
        public Kompania(List<Programmalaushy> programmer, List<Auditor> auditor)
        {
            Programmer = programmer;
            Auditor = auditor;
        }

        public void OnUserEvent_1()
        {
            if (UserEvent != null)
                UserEvent("Іссапарға жіберілген қызметкерлер тобында біліктілігі жоғары программист жоқ!");
        }
        public void OnUserEvent_2()
        {
            if (UserEvent != null)
                UserEvent("Іссапарға жіберілген қызметкерлер тобында біліктілігі жоғары аудитор жоқ!");
        }

        
        public void Issapar(int countofProgrammers, int countofAuditors)
        {
            int ZhogaryBilikti_1 = 0;
            Random rnd = new Random();

            while (countofProgrammers > 0)
            {
                int index = rnd.Next(Programmer.Count); 
                if (!Programmer[index].Sapar) Programmer[index].Sapar = true;
                else continue;

                if (Programmer[index].Biliktilik) ZhogaryBilikti_1++;
                countofProgrammers--;

                Console.WriteLine("\ncountofProgrammers: " + countofProgrammers + "\nZhogaryBilikti_1: " + ZhogaryBilikti_1);
            }
            if (ZhogaryBilikti_1 == 0)
                OnUserEvent_1();
            else Console.WriteLine("Іссапарға жіберілген қызметкерлер тобында біліктілігі жоғары программист саны - " + ZhogaryBilikti_1);

            
            int ZhogaryBilikti_2 = 0;
            while (countofAuditors > 0)
            {
                int index = rnd.Next(Auditor.Count); 
                if (!Auditor[index].Sapar) Auditor[index].Sapar = true;
                else continue;

                if (Auditor[index].Biliktilik) ZhogaryBilikti_2++;
                countofAuditors--;

                Console.WriteLine("\ncountofAuditors: " + countofAuditors + "\nZhogaryBilikti_2: " + ZhogaryBilikti_2);
            }
            if (ZhogaryBilikti_2 == 0)
                OnUserEvent_2();
            else Console.WriteLine("Іссапарға жіберілген қызметкерлер тобында біліктілігі жоғары аудитор саны - " + ZhogaryBilikti_2);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Programmalaushy> Programmers = new List<Programmalaushy>(); 
            for (int i = 0; i < 5; i++) Programmers.Add(new Programmalaushy(false));
            for (int i = 0; i < 2; i++) Programmers.Add(new Programmalaushy(true));

            List<Auditor> Auditors = new List<Auditor>();
            for (int i = 0; i < 8; i++) Auditors.Add(new Auditor(false));
            for (int i = 0; i < 3; i++) Auditors.Add(new Auditor(true));

            Kompania firm = new Kompania(Programmers, Auditors); 
            firm.UserEvent += DisplayMessage;   
            firm.Issapar(2, 3);
        }

        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
