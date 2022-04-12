using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner.ChainOfResponsibility
{
    public class MonitorData : IMonitorData
    {
        public int Cpu => Random.Shared.Next(101);

        public int Ram => Random.Shared.Next(101);
    }
}
