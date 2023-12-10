using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Disposables;

namespace reak_lab7
{
    public static class Tools
    {
        public static IDisposable SubscribeConsole<Tovar>(this IObservable<Tovar> observable,string name = "")
        {
            return observable.Subscribe(new QueryTovar<Tovar>(name));
        }
    }
}
