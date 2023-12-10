using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace reak_lab4
{
    public class ObservableRegistration : ObservableBase<string>
        {
            private readonly IQueryRegistration _req;

            public ObservableRegistration(IQueryRegistration req)
            {
                _req = req;
            }

            protected override IDisposable SubscribeCore(IObserver<string> observer)
            {
                Action<string> received = message =>
                {
                    observer.OnNext(message);
                };

                Action closed = () =>
                {
                    observer.OnCompleted();
                };

                Action<Exception> error = ex =>
                {
                    observer.OnError(ex);
                };

            _req.Received += received;
            _req.Closed += closed;
            _req.Error += error;

                return Disposable.Create(() =>
                {
                    _req.Received -= received;
                    _req.Closed -= closed;
                    _req.Error -= error;
                    _req.Disconnect();
                });
            }
        }
    }
