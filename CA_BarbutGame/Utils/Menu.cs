using CA_BarbutGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_BarbutGame.Utils
{
    public class Menu
    {

        public int MenuSec()
        {
            Console.WriteLine("lütfen devam etmek istediğiniz menünün numarasını yazın.");
            try
            {
                int i =int.Parse(Console.ReadLine());
                return i;
            }
            catch (FormatException)
            {
                Console.WriteLine("lütfen sizden istenen şekilde bir seçim yapın. örneğin:2");
                return 0;
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); return 0; }
            return 0;
        }
        public string[] GirisMenu()
        {
            string[] menu = { "1-Sign In", "2-Log In.","3-Oyuncu tablosu" };
            return menu;
        }
       public string[] IslemMenu()
        {
            string[] menu = { "1-OYUN İŞLEMLERİ", "2-BAKİYE İŞLEMLERİ" };
            return menu;
        }
       public string[] OyunMenu()
        {
            string[] menu = { "1-Oyun Oyna", "2-Oyun Geçmişini gör." };
            return menu;
        }
       public string[] BakiyeMenu()
        {
            string[] menu = { "1-Bakiye görüntüle", "2-Para Çek.", "3-Para yatır." };
            return menu;
        }

       public void MenuDon(string[] menu)
        {
            foreach (string item in menu) { Console.WriteLine(item); }
        }

       public void OyuncuTablo(List<string> liste)
        {
            foreach (var item in liste)
            {
                Console.WriteLine(liste);
            }
        }

       public Player OyuncuKayıt()
        {
            Player player = new Player();
            try
            {
                Console.WriteLine("oyuncu ismi girin.");
                player.Name = Console.ReadLine();
                Console.WriteLine("oyuncu kullanıcı adı girin.");
                player.UserName = Console.ReadLine();
                Console.WriteLine("oyuncu şifre girin");
                player.Password = Console.ReadLine();
                player.Point = 500;
                player.BankId = 1;
                return player;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

       public string GirisName()
        {
            try
            {
                Console.WriteLine("İsminizi girin.");
                string name = Console.ReadLine();
                return name;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "bir hata oluştu";
        }
      public  string GirisUserName()
        {
            try
            {
                Console.WriteLine("Kullanıcı adınızı girin.");
                string username = Console.ReadLine();
                return username;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "bir hata oluştu";
        }
      public  string GirisPassword()
        {
            try
            {
                Console.WriteLine("şifrenizi girin.");
                string password = Console.ReadLine();
                return password;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "bir hata oluştu";
        }

        public string Uyarı()
        {
            return "Lütfen sizden istenilen aralıkta bir değer girin";
        }

        //Console.Beep(300,900);
        //    Console.Beep(1568, 200);
        //    Console.Beep(583, 100);
    }
}
