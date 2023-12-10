using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reak_lab4
{
    public class QueryRegistration : IQueryRegistration
    {
        public event Action<string> Received = delegate { };
        public event Action Closed = delegate { };
        public event Action<Exception> Error = delegate { };

        public void NotifyRecieved(string tv)
        {
            Received(tv);
        }
        public void NotifyClosed()
        {
            Closed();
        }
        public void NotifyError()
        {
            Error(new OutOfMemoryException());
        }

        public void Disconnect()
        {
            Console.WriteLine("Disconnect");
        }
    }
}
