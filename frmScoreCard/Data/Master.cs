using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmScoreCard.Data
{
    /****************************************/

    public class Master
    {
        public Dictionary<int, PlayerStats>? homeTeamSelectedPlayers { get; set; }
        public SB? homeTeamSB { get; set; }
        public Coaches? homeTeamCoaches { get; set; }


        public Dictionary<int, PlayerStats>? guestTeamSelectedPlayers { get; set; }
        public SB? guestTeamSB { get; set; }
        public Coaches? guestTeamCoaches { get; set; }


        public Umpires? umps { get; set; }

        public Venues? venue { get; set; }
        public StadiumData? stadium { get; set; }
    }

    public class PlayerStats
    {
        public string? name { get; set; }
        public string? position { get; set; }
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

}