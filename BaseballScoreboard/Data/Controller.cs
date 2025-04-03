using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;

namespace BaseballScoreboard.Data
{
    static internal class Controller
    {
        static private ApiClient apiClient = new ApiClient();
        static private Storage storage = new Storage();

        /*****************************************************/

        static public Teams GetTeams()
        {
            return storage.GetTeams();
        }

        static public void SetTeams()
        {
            storage.SetTeams(apiClient.GetTeams());
        }

        static public int GetTeamId(string teamName)
        {
            return storage.GetTeamId(teamName);
        }

        /**********************************************************/

        static public Roster GetRoster(string teamType)
        {
            return storage.GetRoster(teamType);
        }

        static public void SetRoster(int teamId, string teamType)
        {
           storage.SetRoster(apiClient.GetRoster(teamId), teamType);
        }

        /**********************************************************/

        static public int GetGamePk()
        {
            return storage.GetGamePk();
        }

        static public void SetGamePk(int teamId)
        {
            storage.SetGamePk(apiClient.GetGamePk(teamId));
        }

        /**********************************************************/

        static public Umpires GetUmpires()
        {
            return storage.GetUmpires();
        }

        static public void SetUmpires()
        {
            storage.SetUmpires(apiClient.GetUmpires(storage.GetGamePk()));
        }

        /**********************************************************/

        static public int GetPlayerId(string teamType, string playerName)
        {
            return storage.GetPlayerId(teamType, playerName);
        }

        static public async void AddSelectedPlayer(string teamType, string playerName)
        {
            PlayerStats info = new PlayerStats();
            int playerId = GetPlayerId(teamType, playerName);
            MessageBox.Show(playerId.ToString());

            info.name = playerName;
            info.fp = await GetFirstPitch(playerId);
            info.risp = await GetRISP(playerId);
            info.risp2o = await GetRISP2O(playerId);
            info.vsLeft = await GetVSLeft(playerId);
            info.vsRight = await GetVSRight(playerId);
            info.plus7 = await Get7Plus(playerId);
            info.hitterStats = await GetHitterStats(playerId);
            info.pitcherStats = await GetPitcherStats(playerId);
            info.pitchTypes = await GetPitchTypes(playerId);

            storage.AddSelectedPlayer(teamType, playerId, info);
        }

        static public void RemoveSelectedPlayer(string teamType, string playerName)
        {
            storage.RemoveSelectedPlayer(teamType, GetPlayerId(teamType, playerName));
        }

        static public async Task<SB> GetSB(int teamId)
        {
            return await apiClient.GetSB(teamId);
        }

        static public async void SetSB(string teamType, int teamId)
        {
            storage.SetSB(await GetSB(teamId), teamType);
        }

        /**********************************************************/

        static public Venues GetVenues(int gamePk)
        {
            return apiClient.GetVenues(gamePk);
        }

        static public void SetVenues(int gamePk)
        {
            storage.SetVenues(GetVenues(gamePk));
        }

        static public async Task<StadiumData> GetStadiumData(int venueId)
        {
            return await apiClient.GetStadiumData(venueId);
        }

        static public async void SetStadiumData()
        {
            storage.SetStadiumData(await GetStadiumData(storage.GetVenueId()));
        }

        /**********************************************************/

        static public Master GetMaster()
        {
            return storage.GetMaster();
        }

        /**********************************************************/



        /****************************************************************
        * 
        *                 START OF STAT CALLS
        * 
        ****************************************************************/

        static private async Task<FirstPitch> GetFirstPitch(int playerId)
        {
            return await apiClient.GetFirstPitch(playerId);
        }

        static private async Task<RISP> GetRISP(int playerId)
        {
            return await apiClient.GetRISP(playerId);
        }

        static private async Task<RISP> GetRISP2O(int playerId)
        {
            return await apiClient.GetRISP2O(playerId);
        }

        static private async Task<VSLeftRight> GetVSLeft(int playerId)
        {
            return await apiClient.GetVSLeft(playerId);
        }
        
        static private async Task<VSLeftRight> GetVSRight(int playerId)
        {
            return await apiClient.GetVSRight(playerId);
        }

        static private async Task<Plus7> Get7Plus(int playerId)
        {
            return await apiClient.Get7Plus(playerId);
        }

        static private async Task<HitterStats> GetHitterStats(int playerId)
        {
            return await apiClient.GetHitterStats(playerId);
        }

        static private async Task<PitcherStats> GetPitcherStats(int playerId)
        {
            return await apiClient.GetPitcherStats(playerId);
        }

        static private async Task<PitchTypes> GetPitchTypes(int playerId)
        {
            return await apiClient.GetPitchTypes(playerId);
        }
    }
}
