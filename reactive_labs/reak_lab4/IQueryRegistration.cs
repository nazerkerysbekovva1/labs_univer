using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reak_lab4
{
    public interface IQueryRegistration
    {
        event Action<string> Received;
        event Action Closed;
        event Action<Exception> Error;
        void Disconnect();

    }
}
