using BaseballScoreboard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BaseballScoreboard.Data
{
    internal class StorageTest
    {
        private List<Player> playerList = new();

        void addPlayer(Player p)
        {
            playerList.Add(p);
        }
    }

    internal class Player
    {
        public int? id { get; set; }
        public string? fullName { get; set; }
        public string? primaryNumber { get; set; }
    }
}
