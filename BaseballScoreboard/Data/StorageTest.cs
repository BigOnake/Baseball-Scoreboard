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
        private List<Team> teamList = new();

        public void AddPlayer(Player p)
        {
            playerList.Add(p);
        }

        public string[] GetAllTeams()
        {
            List<string> teams = new();

            foreach (Team t in teamList)
            {
                teams.Add(t.name);
            }

            return teams.ToArray();
        }

        public void setAllTeams(List<Team> t) { teamList = t; }
    }

    internal class Player
    {
        public int? id { get; set; }
        public string? fullName { get; set; }
        public string? primaryNumber { get; set; }
    }

    internal class Team
    {
        public int? id { get; set; }
        public string? name { get; set; }
    }
}