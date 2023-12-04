using CA_BarbutGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_BarbutGame.Repository
{
    public interface ILog
    {
        void SaveLog(Log log);
        List<Log> GetLogList();
    }
}
