using CA_BarbutGame.Models;
using CA_BarbutGame.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CA_BarbutGame.Concrete
{
    public class PlayerConcrete : IPlayer
    {
        BarbutDbContext context = new BarbutDbContext();
        public string CreatePlayer(Player player)
        {//aynı issimden birden fazla oluşabiliyor.
            if (player!=null)
            {
                //Bank bank = new Bank();
                //bank.IdNavigation = player;
                //bank.Money = 0;
                //context.Banks.Add(bank);

                context.Players.Add(player);
                
                int i = context.SaveChanges();

                if (i > 0)
                {
                    return $"{player.Name} Eklendi \nUserName: {player.UserName}\nPassword: {player.Password}";
                   
                }
                else { return "kayıt yapılamadı."; }
            }
            else { return "kullanıcı bilgileri eksik girildi"; }
        }

        public List<string> GetAllPlayers()
        {
            List<string> namesList = context.Players.Select(player => player.Name).ToList();
            return namesList;
        }

        public Player GetPlayerByName(string name)
        {
            var result = context.Players.Where(x => x.Name == name).FirstOrDefault();
            return result;
        }

        public bool GirisIslem(string name, string UserName, string Password)
        {
            var result = GetPlayerByName(name);
            if (result != null)
            {
                if (result.UserName == UserName && result.Password == Password)
                {
                    Console.WriteLine("Hoşgeldin" + " " + result.Name);
                    return true;
                }
                else { Console.WriteLine("kullanıcı bilgileri yanlış."); return false; }
            }
            else
            {
                Console.WriteLine("Kullanıcı bulunamadı.");
                return false;
            }

        }

        public void UpdatePlayerPoint(decimal guncelPuan, Player oyuncu)
        {
            oyuncu.Point = guncelPuan;
            int i = context.SaveChanges();
            if (i < 0)
            {
                Console.WriteLine("güncelleme yapılamadı.");
            }
        }
    }
}
