using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;

namespace reak_lab10
{
    internal class QueryTovar<Tovar> : IObserver<Tovar>  //QueryTovar деген наблюдател курдым, максаты бызге товардын кандаи не каи запроспен аякталатынын бакылау 
    {
        private IDisposable unsubscriber;  //освобождения неуправляемых ресурсов
        private readonly string nameQuery;  //запрос аты
        public QueryTovar(string nameQuery)
        {
            this.nameQuery = nameQuery;
        }
        public string NameQuery
        {
            get { return this.nameQuery; }
        }

        public virtual void Subscribe(IObservable<Tovar> q)  //Подписка
        {
            if (q != null)
                unsubscriber = q.Subscribe(this);
        }

        public virtual void OnCompleted()  //процесс аякталу
        {
            Console.WriteLine("Request query ended by name on {0}.", this.NameQuery);
            this.Unsubscribe();
        }

        public virtual void OnError(Exception e)  //егер кате шыкса катены корсетып беру
        {
            Console.WriteLine("{0}: Request cannot be determined.", this.NameQuery);
        }

        public virtual void OnNext(Tovar value) //итерация, негызгы шыгарушы
        {
            Console.WriteLine("{1}: {0} ", value, this.NameQuery);
            //Console.WriteLine("{1}: The name tovara is {0} ", value, this.NameQuery); //обьектты каи наблюдател алганын корсету
            //value.Info(value);   //обьекты туралы информация шыгару
        }

        public virtual void Unsubscribe() //босату
        {
            if (unsubscriber != null)
                unsubscriber.Dispose();
        }
    }
}
