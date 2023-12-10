using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace reak_lab4
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
            return Disposable.Empty;
        }
    }
    public class UnknownException : Exception
    {
        internal UnknownException()
        { }
    }
}

