using CA_BarbutGame.Models;
using CA_BarbutGame.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_BarbutGame.Concrete
{
    public class BankConcrete : IBank
    {
        BarbutDbContext context = new BarbutDbContext();
        public decimal GetMoney(Player oyuncu)
        {
            decimal money = context.Banks.Where(x=>x.Id==oyuncu.Id).Select(x=>x.Money).FirstOrDefault();
            return money;

        }

        public void ParaCek(Player oyuncu, decimal para)
        {
            if (para<=oyuncu.Point&&para>0)
            {//result null dönüyor banka hesabı oluşturmuyor.
                var result = context.Banks.FirstOrDefault(x => x.Id == oyuncu.Id);
                result.Money += para;
                //oyuncu.Bank.Money += para;
                oyuncu.Point -= para;
                int i = context.SaveChanges();
                if (i<0) { Console.WriteLine("güncelleme işlemi yapılırken bir hata meydana geldi."); }
            }
            else { Console.WriteLine("çekeceğiniz para miktari puan bakiyenizden küçük ve 0 dan büyük olmalı."); }
        }

        public void ParaYatir(Player oyuncu, decimal para)
        {
            var result = context.Banks.Where(x => x.Id == oyuncu.Id).FirstOrDefault();
            if (para<=result.Money&&para>0)
            {
                oyuncu.Point += para;
                result.Money -= para;
                int i = context.SaveChanges();
                if (i < 0) { Console.WriteLine("güncelleme işlemi yapılırken bir hata meydana geldi."); }
            }
            else { Console.WriteLine("yatıracağınız para miktari para bakiyenizden küçük ve 0 dan büyük olmalı."); }
        }
    }
}
