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

        public void AddPlayer(Player p)
        {
            playerList.Add(p);
        }

        public string[] GetAllTeams()
        {
            string[] teams = {"Arizona Diamondbacks", "Atlanta Braves",
                                "Baltimore Orioles", "Boston Red Sox",
                                "Chicago Cubs", "Chicago White Sox",
                                "Cincinnati Reds","Cleveland Guardians",
                                "Colorado Rockies", "Detroit Tigers",
                                "Houston Astros", "Kansas City Royals",
                                "Los Angeles Angels", "Los Angeles Dodgers",
                                "Miami Marlins", "Milwaukee Brewers",
                                "Minnesota Twins", "New York Mets",
                                "New York Yankees", "Oakland Athletics",
                                "Philadelphia Phillies", "Pittsburgh Pirates",
                                "San Diego Padres", "San Francisco Giants",
                                "Seattle Mariners", "St. Louis Cardinals",
                                "Tampa Bay Rays", "Texas Rangers",
                                "Toronto Blue Jays", "Washington Nationals"};
            return teams;
        }
    }

    internal class Player
    {
        public int? id { get; set; }
        public string? fullName { get; set; }
        public string? primaryNumber { get; set; }
    }
}
