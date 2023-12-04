using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_BarbutGame.Utils
{
    public class ParaIslemleri
    {
        public decimal ParaPuanGir(string islem)
        {
            Console.WriteLine($"{islem} istediğiniz Para/Puan tutarını girin.");
            try
            {
                decimal i = decimal.Parse(Console.ReadLine());
                return i;
            }
            catch (FormatException) { Console.WriteLine("doğru bir değer girmediniz. Lütfen para birimi giriniz."); return 0; }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}
