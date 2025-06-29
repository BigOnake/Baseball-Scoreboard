﻿using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace frmScoreCard.Data
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

        /*****************************************************/

        static public async Task<Coaches> GetCoaches(int teamId)
        {
            return await apiClient.GetCoaches(teamId);
        }

        static public async void SetCoaches(string teamType, int teamId)
        {
            storage.SetCoaches(await GetCoaches(teamId), teamType);
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

        static public void SetTeamName(string teamName, string teamType)
        {
            storage.SetTeamName(teamName, teamType);
        }

        static public async Task<LiveData> GetLiveData(int gamePk)
        {
            return await apiClient.GetLiveData(gamePk);
        }

        static public async Task SetLiveData(int gamePk)
        {
            storage.SetLiveData(await GetLiveData(gamePk));
        }

        static public LiveData FetchLiveData()
        {
            return storage.GetLiveData();
        }

        //static public async void AddBenchPlayers(string teamType, LiveData ld)
        //{
        //    storage.RemoveBenchPlayers(teamType);

        //    if (teamType == "home")
        //    {
        //        foreach (int playerId in ld.liveData.boxscore.teams.home.bench)
        //        {
        //            BenchStats bs = new BenchStats();

        //            bs.name = GetPlayerName(teamType, playerId);
        //            bs.position = GetPosition(teamType, playerId);
        //            bs.jerseyNumber = GetJerseyNumber(teamType, playerId);
        //            bs.hitterStats = await GetHitterStats(playerId);
        //            bs.sides = GetSide(playerId);

        //            storage.AddBenchPlayer(teamType, playerId, bs);
        //        }
        //    }
        //    else
        //    {
        //        foreach (int playerId in ld.liveData.boxscore.teams.away.bench)
        //        {
        //            BenchStats bs = new BenchStats();

        //            bs.name = GetPlayerName(teamType, playerId);
        //            bs.position = GetPosition(teamType, playerId);
        //            bs.jerseyNumber = GetJerseyNumber(teamType, playerId);
        //            bs.hitterStats = await GetHitterStats(playerId);
        //            bs.sides = GetSide(playerId);

        //            storage.AddBenchPlayer(teamType, playerId, bs);
        //        }
        //    }
        //}

        static public async void AddBenchPlayer(string teamType, string playerName)
        {
            BenchStats bs = new BenchStats();

            int playerId = GetPlayerId(teamType, playerName);

            bs.name = GetPlayerName(teamType, playerId);
            bs.position = GetPosition(teamType, playerId);
            bs.jerseyNumber = GetJerseyNumber(teamType, playerId);
            bs.hitterStats = await GetHitterStats(playerId);
            bs.sides = GetSide(playerId);

            storage.AddBenchPlayer(teamType, playerId, bs);
        }

        static public async void AddBullpenPlayer(string teamType, string playerName)
        {
            BullpenStats bp = new BullpenStats();

            int playerId = GetPlayerId(teamType, playerName);

            bp.name = GetPlayerName(teamType, playerId);
            bp.position = GetPosition(teamType, playerId);
            bp.jerseyNumber = GetJerseyNumber(teamType, playerId);
            bp.pitcherStats = await GetPitcherStats(playerId);
            bp.sides = GetSide(playerId);
            bp.bullpenPitches = await GetBullpenPitches(teamType, playerId);

            storage.AddBullpenPlayer(teamType, playerId, bp);
        }

        static public void RemoveSelectedBenchPlayer(string teamType, string playerName)
        {
            storage.RemoveBenchPlayer(teamType, GetPlayerId(teamType, playerName));
        }

        static public void RemoveSelectedBullpenPlayer(string teamType, string playerName)
        {
            storage.RemoveBullpenPlayer(teamType, GetPlayerId(teamType, playerName));
        }

        //static public async void AddBullpenPlayers(string teamType, LiveData ld)
        //{
        //    storage.RemoveBullpenPlayers(teamType);

        //    if (teamType == "home")
        //    {
        //        foreach (int playerId in ld.liveData.boxscore.teams.home.bullpen)
        //        {
        //            BullpenStats bp = new BullpenStats();

        //            bp.name = GetPlayerName(teamType, playerId);
        //            bp.position = GetPosition(teamType, playerId);
        //            bp.jerseyNumber = GetJerseyNumber(teamType, playerId);
        //            bp.pitcherStats = await GetPitcherStats(playerId);
        //            bp.sides = GetSide(playerId);
        //            bp.bullpenPitches = await GetBullpenPitches(teamType, playerId);

        //            storage.AddBullpenPlayer(teamType, playerId, bp);
        //        }
        //    }
        //    else
        //    {
        //        foreach (int playerId in ld.liveData.boxscore.teams.away.bullpen)
        //        {
        //            BullpenStats bp = new BullpenStats();

        //            bp.pitcherStats = await GetPitcherStats(playerId);
        //            bp.bullpenPitches = await GetBullpenPitches(teamType, playerId);
        //            bp.name = GetPlayerName(teamType, playerId);
        //            bp.position = GetPosition(teamType, playerId);
        //            bp.jerseyNumber = GetJerseyNumber(teamType, playerId);
        //            bp.pitcherStats = await GetPitcherStats(playerId);
        //            bp.sides = GetSide(playerId);
        //            bp.bullpenPitches = await GetBullpenPitches(teamType, playerId);

        //            storage.AddBullpenPlayer(teamType, playerId, bp);
        //        }
        //    }
        //}

        static public async Task<BullpenPitches> GetBullpenPitches(string teamType, int playerId)
        {
            return await apiClient.GetBullpenPitches(playerId);
        }

        static public string GetPlayerName(string teamType, int playerId)
        {
            return storage.GetPlayerName(teamType, playerId);
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

            info.name = playerName;
            info.position = GetPosition(teamType, playerId);
            info.jerseyNumber = GetJerseyNumber(teamType, playerId);
            info.sides = GetSide(playerId);
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

        static public string GetJerseyNumber(string teamType, int playerId)
        {
            return storage.GetJerseyNumber(teamType, playerId);
        }

        static public string GetPosition(string teamType, int playerId)
        {
            return storage.GetPosition(teamType, playerId);
        }

        static public Side GetSide(int playerId)
        {
            return apiClient.GetSide(playerId);
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
