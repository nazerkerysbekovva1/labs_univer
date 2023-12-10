using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;


namespace reak_lab4
{
    public class QueryTovar<Tovar> : IObserver<Tovar>  
    {
        private IDisposable unsubscriber;  
        private readonly string nameQuery; 
        public QueryTovar(string nameQuery)
        {
            this.nameQuery = nameQuery;
        }
        public string NameQuery
        { 
            get { return this.nameQuery; } 
        }

        public virtual void OnCompleted()  
        {
            Console.WriteLine("Request query ended by name on {0}.", this.NameQuery);            
        }

        public virtual void OnError(Exception e) 
        {
            Console.WriteLine("{0}: Request cannot be determined.", this.NameQuery, e);
        }

        public virtual void OnNext(Tovar value) 
        {
            Console.WriteLine("{1}: The name tovara is {0} ", value, this.NameQuery + "\n"); 
        }
        public virtual void Unsubscribe() 
        {
            if (unsubscriber != null)
                unsubscriber.Dispose();
        }
    }
}
