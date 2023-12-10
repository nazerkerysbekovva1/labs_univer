using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;

namespace reak_lab_2
{//обьекттын арекетын бакылайтын наблюдатель. реализациясын ыске асырады
    internal class RegistryTovar : IObservable<Tovar>
    {
        private List<IObserver<Tovar>> observers;
        public RegistryTovar()
        {
            observers = new List<IObserver<Tovar>>();
        }

        public IDisposable Subscribe(IObserver<Tovar> observer)  //наблюдателдер Товар обьектысын наблюдаемый обьектке тыркеу ушын Subscribe адысын колданамыз
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }
        private class Unsubscriber : IDisposable //бул наблюдателдерге хабарландыруларды алуды токтату ушын IDisposable интерфеисынен Unsubscriber обьектысын каитарады
        {
            private List<IObserver<Tovar>> _observers;
            private IObserver<Tovar> _observer;
            public Unsubscriber(List<IObserver<Tovar>> observers, IObserver<Tovar> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }
            public void Dispose()//тазарту
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
                    observer.OnError(new UnknownException()); //егер Товар нулга тен болса, OnError ар наблюдателды UnknownException обьектысыне береды.
                else
                    observer.OnNext(tv.Value); //егер Товар нулга тен болмаса, ар наблюдателге OnNext шакырып отырады.
            }
        }
        public void End()//если запрос туралы деректер болмаса бул метод ар наблюдателге OnCompleted адысын шакырады, одан сон наблюдателдердын тызымын тазартады7
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

