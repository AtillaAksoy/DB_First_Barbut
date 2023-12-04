using CA_BarbutGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_BarbutGame.Repository
{
    public interface IPlayer
    {
        string CreatePlayer(Player player);

        List<string> GetAllPlayers();

        Player GetPlayerByName(string name);

        bool GirisIslem(string name, string UserName, string Password);
        void UpdatePlayerPoint(decimal guncelPuan,Player oyuncu);
    }
}
