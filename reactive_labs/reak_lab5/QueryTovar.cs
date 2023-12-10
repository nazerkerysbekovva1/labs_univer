﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;

namespace reak_lab5
{
    internal class QueryTovar<Tovar> : IObserver<Tovar>  
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

        public virtual void Subscribe(IObservable<Tovar> q)  
        {
            if (q != null)
                unsubscriber = q.Subscribe(this); 
        }

        public virtual void OnCompleted()  
        {
            Console.WriteLine("Request query ended by name on {0}.", this.NameQuery);            
            this.Unsubscribe();
        }

        public virtual void OnError(Exception e) 
        {
            Console.WriteLine("{0}: Request cannot be determined.", this.NameQuery);
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
