using CA_BarbutGame.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_BarbutGame.Utils
{
    public class Oyun
    {

        
        public string OyunEkran (Player oyuncu)
        {
            return $"Oyuncu: {oyuncu.Name}\nOyuncu puan: {oyuncu.Point}";
        }
        Random rnd = new Random();
        public int OyuncuZar()
        {
            int i = rnd.Next(1, 7);
            return i;
        }
        public int PCZar()
        {
            int i = rnd.Next(1, 7);
            return i;
        }
        //sqlMoney ???
        public Decimal BakiyeYatır(Player oyuncu)
        {
            Console.WriteLine("ortaya bir bakiye yatırın.\n!Yatıracağınız bakiye güncel bakiyenizden büyük ve 1 den küçük olamaz.");
            try
            {
                decimal i = Decimal.Parse(Console.ReadLine());
                if (i > 1) 
                {
                    if (i<=oyuncu.Point)
                    {
                        oyuncu.Point -= i;
                        Console.WriteLine(oyuncu.Name+" yatırdığı bakiye : "+i );
                        return i;
                    }
                    else { Console.WriteLine("bakiyenizden fazla tutar yatırmaya çalıştınız."); return 0; }
                }//burada şart blokları ile karar yapılarını farklı bir methotda yapıp konsol uyarılarını geriye string dönseydim eğer
                //veyahut karar yapılarını konsolda yazsaydım daha uyumlu bir program olurdu ve her platformda çalışabilirdi.
                else { return 0; Console.WriteLine("yatıracağınız bakiye 1 den küçük olamaz."); }
            }
            catch(FormatException) { Console.WriteLine("tutarı yanlış yazdınız."); return 0; }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            
        }
        public decimal PcBakiye(decimal bakiye)
        {
            
            decimal i = bakiye;
            Console.WriteLine("pc yatırdığı bakiye: " +i);
            return i;
        }
        public decimal ToplamBakiye(decimal oyuncubakiye,decimal pcbakiye)
        {
            decimal toplamBakiye = oyuncubakiye + pcbakiye;
            Console.WriteLine("toplam bakiye: " + toplamBakiye);
            return toplamBakiye;
        }
        public int Sonuc(int oyuncuzar,int pczar)
        {
            if (oyuncuzar>pczar)
            {
                return 1;
            }
            else if (oyuncuzar < pczar)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }

        //geriye string dönerek uygulama uyumlu hale getirilebilirdi.
        public void OyuncuKazandı(Player oyuncu,decimal toplambakiye)
        {
            Console.WriteLine($"Tebrikler {oyuncu.Name} kazandı.\nBilgisayar kaybetti.\n{oyuncu.Name} kazancı: {toplambakiye}");
            oyuncu.Point += toplambakiye;
        }
        public void OyuncuKaybetti(Player oyuncu, decimal oyuncuyatırdı)
        {
            Console.WriteLine($"Üzgünüz. {oyuncu.Name} kaybetti.\nBilgisayar Kazandı.\n{oyuncu.Name} kaybı: {oyuncuyatırdı}");
           
        }
        public void DurumBerabere(Player oyuncu, decimal oyuncuyatırdı)
        {
            Console.WriteLine($"Berabere. puanlar geri dağıtıldı.");
            oyuncu.Point += oyuncuyatırdı;
        }
    }
}
