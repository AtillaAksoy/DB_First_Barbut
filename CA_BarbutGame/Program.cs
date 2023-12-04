using CA_BarbutGame.Concrete;
using CA_BarbutGame.Utils;

namespace CA_BarbutGame
{
    internal class Program
    {
        public static void Main(string[] args) 
        {
            LogConcrete logConcrete = new LogConcrete();
            Menu menu = new Menu();
            Oyun oyun= new Oyun();
            LogKayıt logKayıt =new LogKayıt();
            PlayerConcrete playerconcrete = new PlayerConcrete();
            BankConcrete bankconcrete = new BankConcrete();
            ParaIslemleri paraIslemleri = new ParaIslemleri();
            Console.WriteLine("Barbut'a HOŞGELDİNİZ.");

            menu.MenuDon(menu.GirisMenu());
            while (true)
            {
                switch (menu.MenuSec())
                {
                    case 1:
                       string oyuncuad = menu.GirisName();
                        var oyuncu = playerconcrete.GetPlayerByName(oyuncuad);
                        if (playerconcrete.GirisIslem(oyuncuad, menu.GirisUserName(), menu.GirisPassword()) == true)
                        {
                            menu.MenuDon(menu.IslemMenu());
                            switch (menu.MenuSec())
                            {
                                case 1:
                                    while (true)
                                    {
                                        menu.MenuDon(menu.OyunMenu());
                                        switch (menu.MenuSec())
                                        {
                                            case 1:
                                                Console.WriteLine(oyun.OyunEkran(oyuncu));
                                                decimal oyuncuyatırdı = oyun.BakiyeYatır(oyuncu);
                                                if (oyuncuyatırdı > 1)
                                                {
                                                    //bu kıssımda methotlarla birlikte sadeleştirilebilir.
                                                    decimal pcyatırdı = oyun.PcBakiye(oyuncuyatırdı);
                                                    decimal toplamBakiye = oyun.ToplamBakiye(oyuncuyatırdı, pcyatırdı);
                                                    Console.WriteLine($"{oyuncu.Name} zar atmak için enter a basın");
                                                    Console.ReadLine();
                                                    int oyuncuzar = oyun.OyuncuZar();
                                                    Console.WriteLine($"{oyuncu.Name} attığı zar: {oyuncuzar}");
                                                    Console.WriteLine("bilgisayarın zar atması için enter a tıklayın");
                                                    Console.ReadLine();
                                                    int pczar = oyun.PCZar();
                                                    Console.WriteLine("bilgisayarın attığı zar: " + pczar);
                                                    Console.WriteLine("Sonuç:");
                                                    short zarpc = (short)pczar;
                                                    short zaroyuncu = (short)oyuncuzar;
                                                    switch (oyun.Sonuc(oyuncuzar, pczar))
                                                    {
                                                        case 1:
                                                            oyun.OyuncuKazandı(oyuncu, toplamBakiye);
                                                            logConcrete.SaveLog(logKayıt.LogSave(oyuncu, toplamBakiye, 0, zarpc, zaroyuncu, oyuncuyatırdı));
                                                            toplamBakiye = 0;
                                                            playerconcrete.UpdatePlayerPoint(oyuncu.Point, oyuncu);
                                                            break;
                                                        case 2:
                                                            oyun.OyuncuKaybetti(oyuncu, oyuncuyatırdı);
                                                            logConcrete.SaveLog(logKayıt.LogSave(oyuncu, 0, oyuncuyatırdı, zarpc, zaroyuncu, oyuncuyatırdı));
                                                            toplamBakiye = 0;
                                                            playerconcrete.UpdatePlayerPoint(oyuncu.Point, oyuncu);
                                                            break;
                                                        case 3:
                                                            oyun.DurumBerabere(oyuncu, oyuncuyatırdı);
                                                            logConcrete.SaveLog(logKayıt.LogSave(oyuncu, 0, oyuncuyatırdı, zarpc, zaroyuncu, oyuncuyatırdı));
                                                            toplamBakiye = 0;
                                                            playerconcrete.UpdatePlayerPoint(oyuncu.Point, oyuncu);
                                                            break;
                                                        default:
                                                            Console.WriteLine("bir hata oluştu");
                                                            break;
                                                    }
                                                }
                                                else { Console.WriteLine("lütfen 1 den büyük ve bakiyenizden küçük bir puan yatırın"); }
                                                break;
                                            case 2:
                                                logKayıt.LogDon(logConcrete.GetLogList());
                                                break;
                                            //geri case i oluştur.
                                            default:
                                                Console.WriteLine(menu.Uyarı());
                                                break;
                                        }
                                    }
                                    break;
                                case 2:
                                    while (true)
                                    {
                                        menu.MenuDon(menu.BakiyeMenu());
                                        switch (menu.MenuSec())
                                        {
                                            case 1:
                                                Console.WriteLine("oyun puanı:"+oyuncu.Point);
                                                Console.WriteLine("bankadaki parası:"+bankconcrete.GetMoney(oyuncu));
                                                break;
                                            case 2:
                                                //para çek (puanı bankaya at)
                                                bankconcrete.ParaCek(oyuncu,paraIslemleri.ParaPuanGir("Para Çek"));
                                                break;
                                            case 3:
                                                //para yatır (bankadan oyuna puan at)
                                                bankconcrete.ParaYatir(oyuncu, paraIslemleri.ParaPuanGir("Para Yatır"));
                                                break;
                                            //geri case i oluştur.
                                            default:
                                                Console.WriteLine(menu.Uyarı());
                                                break;
                                        }
                                    }
                                    break;
                                default:
                                    Console.WriteLine(menu.Uyarı());
                                    break;
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine(playerconcrete.CreatePlayer(menu.OyuncuKayıt())); 
                        break;
                    case 3:
                        foreach (var item in playerconcrete.GetAllPlayers())
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    default:
                        Console.WriteLine(menu.Uyarı());
                        break;
                }
            }

            
        }
    }
}