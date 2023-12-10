using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;

namespace reak_lab5
{
    internal class RegistryTovar : IObservable<Tovar>
    {
        private List<IObserver<Tovar>> observers;
        public RegistryTovar()
        {
            observers = new List<IObserver<Tovar>>();
        }

        public IDisposable Subscribe(IObserver<Tovar> observer)  
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }
        private class Unsubscriber : IDisposable 
        {
            private List<IObserver<Tovar>> _observers;
            private IObserver<Tovar> _observer;
            public Unsubscriber(List<IObserver<Tovar>> observers, IObserver<Tovar> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }
            public void Dispose()
            { 
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
        public void ListTovar(Nullable<Tovar> tv) 
        {                                         
            foreach (var observer in observers)
            {
                if (!tv.HasValue)
                    observer.OnError(new UnknownException()); 
                else
                    observer.OnNext(tv.Value);
            }
        }
        public void End()
        {
            foreach (var observer in observers.ToArray())
                if (observers.Contains(observer))
                    observer.OnCompleted();
            observers.Clear();
        }
    }
    public class UnknownException : Exception
    {
        internal UnknownException()
        { }
    }
}

