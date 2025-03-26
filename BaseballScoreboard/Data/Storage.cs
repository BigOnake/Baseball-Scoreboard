using System.ComponentModel;
using System.ComponentModel.Design;

namespace BaseballScoreboard.Data
{
    internal class Storage
    {
        private List<Player> playerList = new();
        private List<Team> teamList = new();

        private RosterList rosterList;
        private SortedList<string, int> teams;

        public Storage()
        {
            rosterList = new RosterList();
            teams = Controller.GetTeams();
        }

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

        public void SetAllTeams(List<Team> t) { teamList = t; }

        public void SetRosterList(RosterList rl)
        {
            rosterList = rl;
        }

        public int GetTeamId(string teamName)
        {
            if (teams.ContainsKey(teamName))
            { 
                return teams[teamName]; 
            }
            else
            {
                return -1; 
            }
        }
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

    internal class Position
    {
        public string? code { get; set; }
        public string? name { get; set; }
        public string? type { get; set; }
        public string? abbreviation { get; set; }
    }

    internal class Status
    {
        public string? code { get; set; }
        public string? description { get; set; }
    }

    internal class People()
    {
        public Person? person { get; set; }
        public string? jerseyNumber { get; set; }
        public Position? position { get; set; }
        public Status? status { get; set; }
        public int? parentTeamId { get; set; }
    }

    internal class RosterList
    {
        public List<People>? roster { get; set; }
    }

    internal class Game
    {
        public List<Dates>? dates { get; set; }
    }

    internal class Dates
    {
        public List<Games>? games { get; set; }
    }

    internal class Games
    {
        public int? gamePk { get; set; }
        public string? gameDate { get; set; }
    }

    internal class Umpires
    {
        public List<GameInfo>? officials { get; set; }
    }

    internal class GameInfo
    {
        public Official? official { get; set; }
        public string? officialType { get; set; }
    }

    internal class Official
    {
        public int? id { get; set; }
        public string? fullName { get; set; }
    }



    internal class FirstPitch
    {
        public List<Split>? splits { get; set; }
    }

    internal class Split
    {
        public Stats? stats { get; set; }
    }

    internal class Stats
    {
        public Hitting? hitting { get; set; }
    }

    internal class Hitting
    {
        public Standard? standard { get; set; }
        public Tracking? tracking { get; set; }
    }

    internal class Standard
    {
        public string? avg { get; set; }
        public string? ops { get; set; }
    }

    internal class Tracking
    {
        public HitProbability? hitProbability { get; set; }
    }

    internal class HitProbability
    {
        public double? averageValue { get; set; }
    }
    
}