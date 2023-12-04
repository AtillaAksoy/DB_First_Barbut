using CA_BarbutGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_BarbutGame.Utils
{
    public class LogKayıt
    {
        public void LogDon(List<Log> list)
        {
            BarbutDbContext context = new BarbutDbContext();
            foreach (var item in list)
            {
                //clası abstract yapıp bu sorguyu override edebilirmiydik?
                string name = context.Players.Where(x => x.Id == item.PlayerId).Select(x => x.Name).FirstOrDefault();
                Console.WriteLine($"{item.DateTime} oyuncunun adı:{name} oyuncunun attığı zar:{item.PlayerDice} bilgisayarın attığı zar:{item.PcDice}" +
                    $"oyuncunun yatırdığı bakiye: {item.PlayerCurrentBalance}");
                if (item.Winner==name)
                {
                    Console.WriteLine($"Durum:{name}Kazandı :) kazancı:{item.PlayerEarnings}");
                }
                else if (item.Loser == name)
                {
                    Console.WriteLine($"Durum:{name}Kaybetti :( kaybı:{item.PlayerLoss}");
                }
                else if (item.Winner== "durum berabere") 
                {
                    Console.WriteLine("Durum Berabere");
                    Console.WriteLine("Kazanç yada kayıp yok yatırılan geri alındı.");
                }
            }
        }

        public Log LogSave(Player oyuncu,decimal kazanç,decimal kayıp,short pczar,short oyuncuzar,decimal oyuncuyatırdıbakiye)
        {
            string kazanan = "";
            string kaybeden = "";
            if (oyuncuzar>pczar)
            {
                kazanan=oyuncu.Name;
                kaybeden = "bilgisayar.";
            }
            else if (oyuncuzar < pczar)
            {
                kazanan = "bilgisayar";
                kaybeden = oyuncu.Name;
            }
            else
            {
                kaybeden = "durum berabere";
                kazanan = "durum berabere";
            }
            Log log = new Log();
            log.DateTime = DateTime.Now;
            //log.Player = oyuncu;
            log.Winner = kazanan;
            log.Loser = kaybeden;
            log.PlayerCurrentBalance = oyuncuyatırdıbakiye;
            log.PlayerLoss = kayıp;
            log.PlayerEarnings = kazanç;
            log.PlayerDice = oyuncuzar;
            log.PcDice = pczar;
            log.PlayerId= oyuncu.Id;
            return log;
        }
        
    }
}
