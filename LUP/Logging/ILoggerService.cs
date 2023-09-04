using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Logging
{
    public interface ILoggerService
    {
        void Message(LogMessage message);
    }
}
