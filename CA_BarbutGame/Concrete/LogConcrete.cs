using CA_BarbutGame.Models;
using CA_BarbutGame.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_BarbutGame.Concrete
{
    public class LogConcrete : ILog
    {
        BarbutDbContext context = new BarbutDbContext();

        public List<Log> GetLogList()
        {
            var result = context.Logs.ToList();
            return result;
        }

        public void SaveLog(Log log)
        {
            if (log!=null)
            {
                context.Logs.Add(log);
                int i = context.SaveChanges();
                if (i < 0)
                {
                    Console.WriteLine("log işleminde hata meydana geldi");
                }
            }
            else
            {
                Console.WriteLine("Log işlemi eksik.");
            }
           
        }
    }
}
