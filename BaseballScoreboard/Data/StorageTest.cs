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

        public List<Roster> rosterList = new();
        public SortedList<int, string> teams = new SortedList<int, string>();

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

    internal class Person
    {
        public int? id { get; set; }
        public string? fullName { get; set; }
    }

    internal class Roster
    {
        public List<Person>? roster { get; set; }
        public string? jerseyNumber { get; set; }
        public List<Person>? position { get; set; }
        public List<Person>? status { get; set; }
        public int? parentTeamId { get; set; }
    }
}