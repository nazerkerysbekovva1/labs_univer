using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Disposables;
using System.Collections.ObjectModel;

namespace reak_lab4
{
    public static class Tools
    {
        public static IObservable<string> ToObservable(this IQueryRegistration registr)
        {
            return new ObservableRegistration(registr);
        }

        public static IDisposable SubscribeConsole<Tovar>(this IObservable<Tovar> observable, string name = "")
        {
            return observable.Subscribe(new QueryTovar<Tovar>(name));
        }
    }
}