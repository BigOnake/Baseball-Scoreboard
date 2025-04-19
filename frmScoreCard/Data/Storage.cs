using System.ComponentModel;
using System.ComponentModel.Design;
using System.DirectoryServices;
using System.Reflection.Metadata.Ecma335;
using System.Security.Policy;
using System.Text.Json;
using System.Windows;

namespace frmScoreCard.Data
{
    public class Storage
    {
        public Teams teams;
        public int gamePk;

        public Roster homeTeamRoster;
        public Roster guestTeamRoster;

        public Master data;
        

        public Storage()
        {
            teams = new Teams();
            gamePk = -1;

            homeTeamRoster = new Roster();
            guestTeamRoster = new Roster();

            data = new Master();
        }

        /****************************************/

        public Teams GetTeams()
        {
            return teams;
        }

        public void SetTeams(Teams t)
        {
            teams = t;
        }

        public string GetPosition(string teamType, int playerId)
        {
            if (teamType == "home")
            {
                foreach (PlayerInfo pi in homeTeamRoster.roster)
                {
                    if (pi.person.id == playerId)
                        return pi.position.abbreviation;
                }
            }
            else
            {
                foreach (PlayerInfo pi in guestTeamRoster.roster)
                {
                    if (pi.person.id == playerId)
                        return pi.position.abbreviation;
                }
            }

            return "";
        }

        /****************************************/

        public int GetTeamId(string teamName)
        {
            int teamId = -1;

            if (teams?.teams != null)
            {
                foreach (Team t in teams.teams)
                {
                    if (t?.id != null && t.name == teamName)
                    {
                        teamId = (int)t.id;
                        break;
                    }
                }
            }

            return teamId;
        }

        /****************************************/

        public Roster GetRoster(string teamType)
        {
            if (teamType == "home")
                return homeTeamRoster;
            else
                return guestTeamRoster;
        }

        public void SetRoster(Roster r, string teamType)
        {
            if (teamType == "home")
                homeTeamRoster = r;
            else
                guestTeamRoster = r;
        }

        /****************************************/

        public int GetGamePk()
        {
            return gamePk;
        }
        
        public void SetGamePk(int gameId)
        {
            gamePk = gameId;
        }

        /****************************************/

        public void SetTeamName(string teamName, string teamType)
        {
            if (teamType == "home")
                data.homeTeamName = teamName;
            else
                data.guestTeamName = teamName;
        }

        /****************************************/

        public Umpires GetUmpires()
        {
            return data.umps;
        }

        public void SetUmpires(Umpires u)
        {
            data.umps = u;
        }

        /****************************************/

        public int GetPlayerId(string teamType, string playerName)
        {
            int id = -1;

            if (teamType == "home")
            {
                foreach (PlayerInfo p in homeTeamRoster.roster)
                {
                    if (p.person.fullName == playerName)
                    {
                        id = (int)p.person.id;
                        break;
                    }
                }
            }
            else
            {
                foreach (PlayerInfo p in guestTeamRoster.roster)
                {
                    if (p.person.fullName == playerName)
                    {
                        return (int)p.person.id;
                        break;
                    }
                }
            }

            return id;
        }

        public string GetJerseyNumber(string teamType, int playerId)
        {
            string jerseyNum = "";

            if (teamType == "home")
            {
                foreach (PlayerInfo p in homeTeamRoster.roster)
                {
                    if (p.person.id == playerId)
                    {
                        jerseyNum = p.jerseyNumber;
                        break;
                    }
                }
            }
            else
            {
                foreach (PlayerInfo p in guestTeamRoster.roster)
                {
                    if (p.person.id == playerId)
                    {
                        jerseyNum = p.jerseyNumber;
                        break;
                    }
                }
            }

            return jerseyNum;
        }

        public string GetPlayerName(string teamType, int playerId)
        {
            string name = "";

            if (teamType == "home")
            {
                foreach (PlayerInfo p in homeTeamRoster.roster)
                {
                    if (playerId == p.person.id)
                    {
                        name = p.person.fullName;
                        break;
                    }
                }
            }
            else
            {
                foreach (PlayerInfo p in guestTeamRoster.roster)
                {
                    if (playerId == p.person.id)
                    {
                        name = p.person.fullName;
                        break;
                    }
                }
            }

            return name;
        }

        /****************************************/

        public void AddSelectedPlayer(string teamType, int playerId, PlayerStats p)
        {
            if (teamType == "home")
                data.homeTeamSelectedPlayers[playerId] = p;
            else
                data.guestTeamSelectedPlayers[playerId] = p;
        }

        public void RemoveSelectedPlayer(string teamType, int playerId)
        {
            if (teamType == "home")
                data.homeTeamSelectedPlayers.Remove(playerId);
            else
                data.homeTeamSelectedPlayers.Remove(playerId);
        }

        /****************************************/

        public void SetSB(SB s, string teamType)
        {
            if (teamType == "home")
                data.homeTeamSB = s;
            else
                data.guestTeamSB = s;
        }

        /****************************************/

        public Venues GetVenues()
        {
            return data.venue;
        }

        public void SetVenues(Venues v)
        {
            data.venue = v;
        }

        public int GetVenueId()
        {
            return (int)data.venue.dates[0].games[0].venue.id;
        }

        /****************************************/

        public StadiumData GetStadiumData()
        {
            return data.stadium;
        }

        public void SetStadiumData(StadiumData s)
        {
            data.stadium = s;
        }

        /****************************************/

        public Coaches GetCoaches(string teamType)
        {
            if (teamType == "home")
                return data.homeTeamCoaches;
            else
                return data.guestTeamCoaches;
        }

        public void SetCoaches(Coaches c, string teamType)
        {
            if (teamType == "home")
                data.homeTeamCoaches = c;
            else
                data.guestTeamCoaches = c;
        }

        /****************************************/

        public void SetLiveData(LiveData l)
        {
            data.live = l;
        }

        public LiveData GetLiveData()
        {
            return data.live;
        }

        public void AddBenchPlayer(string teamType, int playerId, BenchStats bs)
        {
            if (teamType == "home")
            {
                if (!data.homeTeamBench.ContainsValue(bs))
                    data.homeTeamBench[playerId] = bs;
            }
            else
            {
                if (!data.guestTeamBench.ContainsValue(bs))
                    data.guestTeamBench[playerId] = bs;
            }
        }

        public void RemoveBenchPlayers(string teamType)
        {
            if (teamType == "home")
                data.homeTeamBench.Clear();
            else
                data.guestTeamBench.Clear();
        }

        public void RemoveBullpenPlayers(string teamType)
        {
            if (teamType == "home")
                data.homeTeamBullpen.Clear();
            else
                data.guestTeamBullpen.Clear();
        }

        public void AddBullpenPlayer(string teamType, int playerId, BullpenStats bp)
        {
            if (teamType == "home")
            {
                if (!data.homeTeamBullpen.ContainsValue(bp))
                    data.homeTeamBullpen[playerId] = bp;
            }
            else
            {
                if (!data.guestTeamBullpen.ContainsValue(bp))
                    data.guestTeamBullpen[playerId] = bp;
            }
        }

        /****************************************/

        public Master GetMaster()
        {
            return data;
        }
    }

    /****************************************/

    public class Master
    {
        public string? homeTeamName { get; set; }
        public Dictionary<int, PlayerStats>? homeTeamSelectedPlayers { get; set; }
        public SB? homeTeamSB { get; set; }
        public Coaches? homeTeamCoaches { get; set; }
        public Dictionary<int, BenchStats>? homeTeamBench { get; set; }
        public Dictionary<int, BullpenStats>? homeTeamBullpen { get; set; }

        public LiveData? live { get; set; }


        public string? guestTeamName { get; set; }
        public Dictionary<int, PlayerStats>? guestTeamSelectedPlayers { get; set; }
        public SB? guestTeamSB { get; set; }
        public Coaches? guestTeamCoaches { get; set; }
        public Dictionary<int, BenchStats>? guestTeamBench { get; set; }
        public Dictionary<int, BullpenStats>? guestTeamBullpen { get; set; }



        public Umpires? umps { get; set; }
        public Venues? venue { get; set; }
        public StadiumData? stadium { get; set; }

        public Master()
        {
            homeTeamSelectedPlayers = new Dictionary<int, PlayerStats>();
            homeTeamSB = new SB();
            homeTeamCoaches = new Coaches();
            homeTeamBench = new Dictionary<int, BenchStats>();
            homeTeamBullpen = new Dictionary<int, BullpenStats>();

            live = new LiveData();

            guestTeamSelectedPlayers = new Dictionary<int, PlayerStats>();
            guestTeamSB = new SB();
            homeTeamCoaches = new Coaches();
            guestTeamBench = new Dictionary<int, BenchStats>();
            guestTeamBullpen = new Dictionary<int, BullpenStats>();

            umps = new Umpires();
            venue = new Venues();
            stadium = new StadiumData();
        }
    }

    public class PlayerStats
    {
        public string? name { get; set; }
        public string? position { get; set; }
        public string? jerseyNumber { get; set; }
        public Side? sides { get; set; }
        public FirstPitch? fp { get; set; }
        public RISP? risp { get; set; }
        public RISP? risp2o { get; set; }
        public VSLeftRight? vsLeft { get; set; }
        public VSLeftRight? vsRight { get; set; }
        public Plus7? plus7 { get; set; }
        public HitterStats? hitterStats { get; set; }
        public PitcherStats? pitcherStats { get; set; }
        public PitchTypes? pitchTypes { get; set; }
    }

    public class BenchStats
    {
        public string? name { get; set; }
        public string? position { get; set; }
        public string? jerseyNumber { get; set; }
        public HitterStats? hitterStats { get; set; }
    }

    public class BullpenStats
    {
        public string? name { get; set; }
        public string? position { get; set; }
        public string? jerseyNumber { get; set; }
        public PitcherStats? pitcherStats { get; set; }
    }

    /****************************************/

    public class Teams
    {
        public List<Team>? teams { get; set; }
    }

    public class Team
    {
        public int? id { get; set; }

        public string? name { get; set; }

        public override string ToString()
        {
            if (name != null)
                return name;
            else
                return "";
        }
    }

    /****************************************/

    public class Roster
    {
        public List<PlayerInfo>? roster { get; set; }
    }

    public class PlayerInfo
    {
        public Person? person { get; set; }
        public string? jerseyNumber { get; set; }
        public Position? position { get; set;}
        public Status? status { get; set; }
        public int? parentTeamId { get; set; }

        public override string ToString()
        {
            if (person?.fullName != null && position?.abbreviation != null)
                return $"{person.fullName} - {position.abbreviation}";
            else
                return "";
        }
    }

    public class Person
    {
        public int? id { get; set; }
        public string? fullName { get; set; }
        public string? link { get; set; }
    }

    public class Position
    {
        public string? code { get; set; }
        public string? name { get; set; }
        public string? type { get; set; }
        public string? abbreviation { get; set; }
    }

    public class Status
    {
        public string? code { get; set; }
        public string? description { get; set; }
    }

    /****************************************/

    public class Game
        {
            public List<Dates>? dates { get; set; }
        }

    public class Dates
    {
        public List<Games>? games { get; set; }
    }

    public class Games
    {
        public int? gamePk { get; set; }
        public string? gameDate { get; set; }
    }

    /****************************************/

    public class Umpires
    {
        public List<Umpire>? officials { get; set; }
    }

    public class Umpire
    {
        public Official? official { get; set; }
        public string? officialType { get; set; }

        public override string ToString()
        {
            if (official != null && officialType != null)
                return $"{officialType[0]}{officialType[officialType.IndexOf(' ') + 1]} - {official.fullName}";
            else
                return "";
        }
    }

    public class Official
    {
        public int? id { get; set; }
        public string? fullName { get; set; }
    }

    /****************************************/

    public class SB
    {
        public List<SplitsSB>? splits { get; set; }
    }

    public class SplitsSB
    {
        public StatsSB? stats { get; set; }
    }

    public class StatsSB
    {
        public HittingSB? hitting { get; set; }
    }

    public class HittingSB
    {
        public StandardSB? standard { get; set; }
    }

    public class StandardSB
    {
        public int? caughtStealing { get; set; }
        public int? stolenBases { get; set; }
        public int? groundIntoDoublePlay { get; set; }
    }

    /****************************************/

    public class Venues
    {
        public List<DatesVenue>? dates { get; set; }
    }

    public class DatesVenue
    {
        public List<GamesVenue>? games { get; set; }
    }

    public class GamesVenue
    {
        public Venue? venue { get; set; }
    }

    public class Venue
    {
        public int? id { get; set; }
        public string? name { get; set; }
    }

    /****************************************/

    public class StadiumData
    {
        public List<SplitsStadium>? splits { get; set; }
    }

    public class SplitsStadium
    {
        public StatsStadium? stats { get; set; }
        public PitchTypeStadium? pitchType { get; set; }
    }

    public class StatsStadium
    {
        public PitchingStadium? pitching { get; set; }
    }

    public class PitchingStadium
    {
        public StandardStadium? standard { get; set; }
        public TrackingStadium? tracking { get; set; }
    }

    public class StandardStadium
    {
        public string? avg { get; set; }
        public string? ops { get; set; }
    }

    public class TrackingStadium
    {
        public ReleaseSpeedStadium? releaseSpeed { get; set; }
    }

    public class ReleaseSpeedStadium
    {
        public double? averageValue { get; set; }
    }

    public class PitchTypeStadium
    {
        public string? code { get; set; }
    }

    /****************************************/

    public class Coaches
    {
        public string? copyright { get; set; }
        public List<CoachRoster>? roster { get; set; }
    }

    public class CoachRoster
    {
        public CoachPerson? person { get; set; }
        public string? jerseyNumber { get; set; }
        public string? job { get; set; }
        public string? jobId { get; set; }
        public string? title { get; set; }
    }

    public class CoachPerson
    {
        public int? id { get; set; }
        public string? fullName { get; set; }
        public string? link { get; set; }
    }

    /****************************************
    * 
    *          START OF STAT CLASSES
    * 
    ****************************************/

    public class Side
    {
        public List<People>? people { get; set; }
    }

    public class People
    {
        public BatSide? batSide { get; set; }
        public PitchHandSide? pitchHand { get; set; }
    }

    public class BatSide
    {
        public string? description { get; set; }
    }

    public class PitchHandSide
    {
        public string? description { get; set; }
    }

    /****************************************/

    public class FirstPitch
    {
        public List<SplitFirstPitch>? splits { get; set; }
    }

    public class SplitFirstPitch
    {
        public StatsFirstPitch? stats { get; set; }
    }

    public class StatsFirstPitch
    {
        public HittingFirstPitch? hitting { get; set; }
    }

    public class HittingFirstPitch
    {
        public StandardFirstPitch? standard { get; set; }
        public TrackingFirstPitch? tracking { get; set; }
    }

    public class StandardFirstPitch
    {
        public string? avg { get; set; }
        public string? ops { get; set; }
    }

    public class TrackingFirstPitch
    {
        public HitProbabilityFirstPitch? hitProbability { get; set; }
    }

    public class HitProbabilityFirstPitch
    {
        public double? averageValue { get; set; }
    }

    /****************************************/
    public class RISP
    {
        public List<SplitsRISP>? splits { get; set; }
    }

    public class SplitsRISP
    {
        public StatsRISP? stats { get; set; }
    }

    public class StatsRISP
    {
        public HittingRISP? hitting { get; set; }
    }

    public class HittingRISP
    {
        public StandardRISP? standard { get; set; }
    }

    public class StandardRISP
    {
        public int? homeRuns { get; set; }
        public int? hits { get; set; }
        public string? avg { get; set; }
        public int? atBats { get; set; }
    }

    /****************************************/

    public class VSLeftRight
    {
        public List<SplitsVSLeftRight>? splits { get; set; }
    }

    public class SplitsVSLeftRight
    {
        public StatsVSLeftRight? stats { get; set; }
    }

    public class StatsVSLeftRight
    {
        public HittingVSLeftRight? hitting { get; set; }
    }

    public class HittingVSLeftRight
    {
        public StandardVSLeftRight? standard { get; set; }
    }

    public class StandardVSLeftRight
    {
        public int? homeRuns { get; set; }
        public int? hits { get; set; }
        public string? avg { get; set; }
        public int? atBats { get; set; }
        public string? ops { get; set; }
    }

    /****************************************/

    public class Plus7
    {
        public List<SplitsPlus7>? splits { get; set; }
    }

    public class SplitsPlus7
    {
        public StatsPlus7? stats { get; set; }
    }

    public class StatsPlus7
    {
        public HittingPlus7? hitting { get; set; }
    }

    public class HittingPlus7
    {
        public StandardPlus7? standard { get; set; }
    }

    public class StandardPlus7
    {
        public string? avg { get; set; }
        public string? ops { get; set; }
    }

    /****************************************/

    public class HitterStats
    {
        public List<SplitsHitterStats>? splits { get; set; }
    }

    public class SplitsHitterStats
    {
        public StatsHitterStats? stats { get; set; }
    }

    public class StatsHitterStats
    {
        public HittingHitterStats? hitting { get; set; }
    }

    public class HittingHitterStats
    {
        public StandardHitterStats? standard { get; set; }
    }

    public class StandardHitterStats
    {
        public int? runs { get; set; }
        public int? doubles { get; set; }
        public int? triples { get; set; }
        public int? homeRuns { get; set; }
        public int? strikeOuts { get; set; }
        public int? baseOnBalls { get; set; }
        public string? avg { get; set; }
        public string? ops { get; set; }
        public int? caughtStealing { get; set; }
        public int? stolenBases { get; set; }
        public int? groundIntoDoublePlay { get; set; }
        public int? rbi { get; set; }
        public string? babip { get; set; }
    }

    /****************************************/

    public class PitcherStats
    {
        public List<SplitsPitcherStats>? splits { get; set; }
    }

    public class SplitsPitcherStats
    {
        public StatsPitcherStats? stats { get; set; }
    }

    public class StatsPitcherStats
    {
        public PitchingPitcherStats? pitching { get; set; }
    }

    public class PitchingPitcherStats
    {
        public StandardPitcherStats? standard { get; set; }
    }

    public class StandardPitcherStats
    {
        public int? gamesPlayed { get; set; }
        public int? gamesStarted { get; set; }
        public int? groundOuts { get; set; }
        public int? homeRuns { get; set; }
        public int? strikeOuts { get; set; }
        public int? baseOnBalls { get; set; }
        public int? intentionalWalks { get; set; }
        public int? hits { get; set; }
        public string? avg { get; set; }
        public int? groundIntoDoublePlay { get; set; }
        public string? era { get; set; }
        public string? inningsPitched { get; set; }
        public int? wins { get; set; }
        public int? losses { get; set; }
        public int? saves { get; set; }
        public int? saveOpportunities { get; set; }
        public int? holds { get; set; }
        public int? blownSaves { get; set; }
        public int? earnedRuns { get; set; }
        public string? whip { get; set; }
    }

    /****************************************/

    public class PitchTypes
    {
        public List<SplitsPitchTypes>? splits { get; set; }
    }

    public class SplitsPitchTypes
    {
        public StatsPitchTypes? stats { get; set; }

        public PitchTypePitchTypes? pitchType { get; set; }
    }

    public class StatsPitchTypes
    {
        public PitchingPitchTypes? pitching { get; set; }
    }

    public class PitchingPitchTypes
    {
        public StandardPitchTypes? standard { get; set; }
        public TrackingPitchTypes? tracking { get; set; }
    }

    public class StandardPitchTypes
    {
        public int? hits { get; set; }
        public int? atBats { get; set; }
    }

    public class TrackingPitchTypes
    {
        public ExitVelocityPitchTypes? exitVelocity { get; set; }
    }

    public class ExitVelocityPitchTypes
    {
        public double? averageValue { get; set; }
    }

    public class PitchTypePitchTypes
    {
        public string? code { get; set; }
    }

    /****************************************
    * 
    *       START OF LIVE DATA CLASSES
    * 
    ****************************************/

    public class LiveData
    {
        public Live? liveData { get; set; }
    }

    public class Live
    {
        public Boxscore? boxscore { get; set; }
    }

    public class Boxscore
    {
        public TeamsLiveData? teams { get; set; }
    }

    public class TeamsLiveData
    {
        public AwayLiveData? away { get; set; }
        public HomeLiveData? home { get; set; }

    }

    public class AwayLiveData
    {
        public List<int>? bench { get; set; }
        public List<int>? bullpen { get; set; }
    }

    public class HomeLiveData
    {
        public List<int>? bench { get; set; }
        public List<int>? bullpen { get; set; }
    }
}