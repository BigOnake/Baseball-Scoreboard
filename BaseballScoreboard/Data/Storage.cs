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

    /****************************************
    * 
    *          START OF STAT CLASSES
    * 
    ****************************************/

    internal class FirstPitch
    {
        public List<SplitFP>? splits { get; set; }
    }

    internal class SplitFP
    {
        public StatsFP? stats { get; set; }
    }

    internal class StatsFP
    {
        public HittingFP? hitting { get; set; }
    }

    internal class HittingFP
    {
        public StandardFP? standard { get; set; }
        public TrackingFP? tracking { get; set; }
    }

    internal class StandardFP
    {
        public string? avg { get; set; }
        public string? ops { get; set; }
    }

    internal class TrackingFP
    {
        public HitProbabilityFP? hitProbability { get; set; }
    }

    internal class HitProbabilityFP
    {
        public double? averageValue { get; set; }
    }

    /****************************************/
    internal class RISP
    {
        public List<SplitsRISP>? splits { get; set; }
    }

    internal class SplitsRISP
    {
        public StatsRISP? stats { get; set; }
    }

    internal class StatsRISP
    {
        public HittingRISP? hitting { get; set; }
    }

    internal class HittingRISP
    {
        public StandardRISP? standard { get; set; }
    }

    internal class StandardRISP
    {
        public int? homeRuns { get; set; }
        public int? hits { get; set; }
        public string? avg { get; set; }
        public int? atBats { get; set; }
    }

    /****************************************/

    internal class VSLeftRight
    {
        public List<SplitsVSLR>? splits { get; set; }
    }

    internal class SplitsVSLR
    {
        public StatsVSLR? stats { get; set; }
    }

    internal class StatsVSLR
    {
        public HittingVSLR? hitting { get; set; }
    }

    internal class HittingVSLR
    {
        public StandardVSLR standard { get; set; }
    }
    
    internal class StandardVSLR
    {
        public int? homeRuns { get; set; }
        public int? hits { get; set; }
        public string? avg { get; set; }
        public int? atBats { get; set; }
        public string? ops { get; set; }
    }

    /****************************************/
    internal class Plus7
    {
        public List<Splits7>? splits { get; set; }
    }

    internal class Splits7
    {
        public Stats7? stats { get; set; }
    }

    internal class Stats7
    {
        public Hitting7? hitting { get; set; }
    }

    internal class Hitting7
    {
        public Standard7? standard { get; set; }
    }

    internal class Standard7
    {
        public string? avg { get; set; }
        public string? ops { get; set; }
    }

    /****************************************/
    internal class HitterStat
    {
        public List<SplitsHitter>? splits { get; set; }
    }

    internal class SplitsHitter
    {
        public StatsHitter? stats { get; set; }
    }

    internal class StatsHitter
    {
        public HittingH? hitting { get; set; }
    }

    internal class HittingH
    {
        public StandardHitter? standard { get; set; }
    }

    internal class StandardHitter
    {
        public int? runs { get; set; }
        public int? doubles { get; set; }
        public int? triples { get; set; }
        public int? homeRuns { get; set; }
        public int? strikeOuts { get; set; }
        public int? intentionalWalks { get; set; }
        public string? avg { get; set; }
        public string? ops { get; set; }
        public int? caughtStealing { get; set; }
        public int? stolenBases { get; set; }
        public int? groundIntoDoublePlay { get; set; }
        public int? rbi { get; set; }
        public string? babip { get; set; }
    }

    /****************************************/
}