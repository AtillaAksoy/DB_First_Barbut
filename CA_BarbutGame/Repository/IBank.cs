using CA_BarbutGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_BarbutGame.Repository
{
    public interface IBank
    {
        decimal GetMoney(Player oyuncu);
        void ParaCek(Player oyuncu,decimal para);
        void ParaYatir(Player oyuncu,decimal para);

    }
}
