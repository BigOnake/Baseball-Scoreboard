using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace frmScoreCard.Data
{
    internal class ApiClient
    {
        static string ACCESS_TOKEN;
        const string BASE_URL = "https://statsapi.mlb.com/api/v1/";
        static HttpClient client = new HttpClient();
        string? path;

        public ApiClient()
        {
            ACCESS_TOKEN = GetAccessToken();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ACCESS_TOKEN);
        }

        /**********************************************************/

        static private string GetRefreshToken()
        {
            string REQUEST_URL = "https://statsapi.mlb.com/api/v1/authentication/okta/token";

            string[] FILE_INFO = readFile("frmScoreCard.Resources.config.txt").Split('\n');

            HttpClient client = new HttpClient();
            string encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{FILE_INFO[0].Trim()}:{FILE_INFO[1].Trim()}"));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encoded);

            HttpResponseMessage response = client.PostAsync(REQUEST_URL, null).Result;
            if (response.IsSuccessStatusCode)
            {
                string[] tokens = response.Content.ReadAsStringAsync().Result.Split(',');

                string refreshToken = tokens[1];
                int startIndex = refreshToken.IndexOf(":") + 1;
                refreshToken = refreshToken.Substring(startIndex, refreshToken.Length - startIndex).Trim('\"');

                return refreshToken;
            }
            else
            {
                System.Windows.MessageBox.Show("ERROR - Could not fetch Refresh Token.");
                return "";
            }
        }

        static private string GetAccessToken()
        {
            string ACCESS_URL = "https://statsapi.mlb.com/api/v1/authentication/okta/token/refresh?refreshToken=";

            string REFRESH_TOKEN = GetRefreshToken();

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.PostAsync(ACCESS_URL + REFRESH_TOKEN, null).Result;

            if (response.IsSuccessStatusCode)
            {
                string[] tokens = response.Content.ReadAsStringAsync().Result.Split(',');

                string accessToken = tokens[0];
                int startIndex = accessToken.IndexOf(":") + 1;
                accessToken = accessToken.Substring(startIndex, accessToken.Length - startIndex).Trim('\"');

                return accessToken;
            }
            else
            {
                System.Windows.MessageBox.Show("ERROR - Could not fetch Access Token.");
                return "";
            }
        }

        internal static string readFile(string fileName)
        {
            using (Stream? stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fileName))
                if (stream != null)
                {
                    using (StreamReader? reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
                else { return ""; }
        }

        /**********************************************************/

        private string GetJson(string path)
        {
            string jsonStr = string.Empty;

            HttpResponseMessage response = client.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                jsonStr = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                jsonStr = "Unsuccessful response code";
            }

            return jsonStr;
        }

        private async Task<string> GetOAuthJsonRequest(string endpoint)
        {
            string result = String.Empty;

            HttpResponseMessage response = await client.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            else
            {
                result = "Failure - OAuth2.0 Get Request";
            }

            return result;
        }

        /**********************************************************/

        public Teams GetTeams()
        {
            path = BASE_URL + $"teams?sportId=1&leagueIds=103,104&activeStatus=Y&fields=teams,id,name";

            string result = GetJson(path);

            return JsonSerializer.Deserialize<Teams>(result);
        }

        public Roster GetRoster(int teamId)
        {
            path = BASE_URL + $"teams/{teamId}/roster/40Man";

            string result = GetJson(path);

            return JsonSerializer.Deserialize<Roster>(result);
        }

        public int GetGamePk(int teamId)
        {
            path = BASE_URL + $"schedule?teamId={teamId}&sportId=1&date={DateTime.Now.ToString("yyyy-MM-dd")}&" +
                $"fields=dates,games,gamePk,gameDate";
            string result = GetJson(path);

            int gameId = -1;
            try
            {
                Game? g = JsonSerializer.Deserialize<Game>(result);

                DateTime currentUtcTime = DateTimeOffset.UtcNow.UtcDateTime;
                TimeSpan smallestTs = TimeSpan.MaxValue;

                if (g?.dates?[0]?.games != null)
                {
                    foreach (Games gm in g.dates[0].games)
                    {
                        if (gm?.gameDate != null && gm?.gamePk != null)
                        {
                            DateTime currentGameTime = DateTime.ParseExact(gm.gameDate, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal);
                            TimeSpan currentDifference = currentGameTime - currentUtcTime;

                            if (Math.Abs((decimal)currentDifference.TotalSeconds) < Math.Abs((decimal)smallestTs.TotalSeconds))
                            {
                                smallestTs = currentDifference;
                                gameId = (int)gm.gamePk;
                            }
                        }
                    }
                }
            }
            catch
            {
                //MessageBox.Show("No games today.", "ERROR");
            }

            return gameId;
        }

        public Umpires GetUmpires(int gamePk)
        {
            // There must be valid games for the day
            path = BASE_URL + $"game/{gamePk}/boxscore?fields=officials,official,id,fullName,officialType";

            string result = GetJson(path);

            return JsonSerializer.Deserialize<Umpires>(result);
        }

        /**********************************************************/

        public async Task<SB> GetSB(int teamId)
        {
            path = BASE_URL + $"stats/search?gameTypes=R&group=hitting&groupBy=team&hydrate=person(currentTeam),team&" +
                $"includeNullMetrics=true&limit=50&seasons={DateTime.Now.Year.ToString()}&sportIds=1&statFields=standard,advanced,expected,tracking&" +
                $"teamIds={teamId}&fields=splits,stats,hitting,standard,caughtStealing,stolenBases,groundIntoDoublePlay";

            string result = await GetOAuthJsonRequest(path);

            return JsonSerializer.Deserialize<SB>(result);
        }

        /**********************************************************/

        public Venues GetVenues(int gamePk)
        {
            path = BASE_URL + $"schedule?gamePk={gamePk}&fields=dates,games,venue,id,name";

            string result = GetJson(path);

            return JsonSerializer.Deserialize<Venues>(result);
        }

        public async Task<StadiumData> GetStadiumData(int venueId)
        {
            path = BASE_URL + $"stats/search?gameTypes=R&group=pitching&groupBy=venue,pitchType,season&hydrate=person(currentTeam),team&" +
                $"includeNullMetrics=true&limit=50&seasons={DateTime.Now.Year.ToString()}&statFields=standard,advanced,expected,tracking&venueIds={venueId}&" +
                $"fields=splits,stats,pitching,standard,avg,ops,tracking,releaseSpeed,averageValue,pitchType,code";

            string result = await GetOAuthJsonRequest(path);

            return JsonSerializer.Deserialize<StadiumData>(result);
        }

        /****************************************
        * 
        *          START OF STAT CALLS
        * 
        ****************************************/

        public Side GetSide(int playerId)
        {
            path = BASE_URL + $"people?personIds={playerId}&fields=people,batSide,code,description,pitchHand,code,description";

            string result = GetJson(path);

            return JsonSerializer.Deserialize<Side>(result);
        }

        public async Task<FirstPitch> GetFirstPitch(int playerId)
        {
            path = BASE_URL + $"stats/search?batterIds={playerId}&" +
                $"gameTypes=S&group=hitting&groupBy=season,player&hydrate=person(currentTeam),team&" +
                $"includeNullMetrics=true&sitCodes=fip&seasons={DateTime.Now.Year.ToString()}&sportIds=1&" +
                $"statFields=standard,advanced,expected,tracking&" +
                $"fields=splits,stats,hitting,standard,ops,avg,tracking,hitProbability,averageValue";

            string result = await GetOAuthJsonRequest(path);

            return JsonSerializer.Deserialize<FirstPitch>(result);
        }

        public async Task<RISP> GetRISP(int playerId)
        {
            path = BASE_URL + $"stats/search?batterIds={playerId}&" +
                $"gameTypes=S&group=hitting&groupBy=season,player&hydrate=person(currentTeam),team&" +
                $"includeNullMetrics=true&limit=50&seasons={DateTime.Now.Year.ToString()}&sitCodes=risp&sportIds=&" +
                $"statFields=standard,advanced,expected,tracking&fields=splits,stats,hitting,standard,homeRuns,hits,avg,atBats";

            string result = await GetOAuthJsonRequest(path);

            return JsonSerializer.Deserialize<RISP>(result);
        }

        public async Task<RISP> GetRISP2O(int playerId)
        {
            path = BASE_URL + $"stats/search?batterIds={playerId}&" +
                $"gameTypes=S&group=hitting&groupBy=season,player&hydrate=person(currentTeam),team&" +
                $"includeNullMetrics=true&limit=50&seasons={DateTime.Now.Year.ToString()}&sitCodes=o2,risp&sportIds=1&" +
                $"statFields=standard,advanced,expected,tracking&fields=splits,stats,hitting,standard,homeRuns,hits,avg,atBats";

            string result = await GetOAuthJsonRequest(path);

            return JsonSerializer.Deserialize<RISP>(result);
        }

        public async Task<VSLeftRight> GetVSLeft(int playerId)
        {
            path = BASE_URL + $"stats/search?batterIds={playerId}&gameTypes=S&group=hitting&" +
                $"groupBy=season,player&hydrate=person(currentTeam),team&includeNullMetrics=true&" +
                $"limit=50&pitchHand=L&seasons={DateTime.Now.Year.ToString()}&sportIds=1&statFields=standard,advanced,expected,tracking&" +
                $"fields=splits,stats,hitting,standard,homeRuns,hits,avg,atBats,ops";

            string result = await GetOAuthJsonRequest(path);

            return JsonSerializer.Deserialize<VSLeftRight>(result);
        }

        public async Task<VSLeftRight> GetVSRight(int playerId)
        {
            path = BASE_URL + $"stats/search?batterIds={playerId}&gameTypes=S&group=hitting&" +
                $"groupBy=season,player&hydrate=person(currentTeam),team&includeNullMetrics=true&" +
                $"limit=50&pitchHand=R&seasons={DateTime.Now.Year.ToString()}&sportIds=1&statFields=standard,advanced,expected,tracking&" +
                $"fields=splits,stats,hitting,standard,homeRuns,hits,avg,atBats,ops";

            string result = await GetOAuthJsonRequest(path);

            return JsonSerializer.Deserialize<VSLeftRight>(result);
        }

        public async Task<Plus7> Get7Plus(int playerId)
        {
            path = BASE_URL + $"stats/search?batterIds={playerId}&gameTypes=S&group=hitting&" +
                $"groupBy=season,player&hydrate=person(currentTeam),team&includeNullMetrics=true&" +
                $"limit=50&seasons={DateTime.Now.Year.ToString()}&sitCodes=ig07&sportIds=1&" +
                $"statFields=standard,advanced,expected,tracking&fields=splits,stats,hitting,standard,avg,ops";

            string result = await GetOAuthJsonRequest(path);

            return JsonSerializer.Deserialize<Plus7>(result);
        }

        public async Task<HitterStats> GetHitterStats(int playerId)
        {
            path = BASE_URL + $"stats/search?batterIds={playerId}&gameTypes=S&group=hitting&groupBy=season,player&" +
                $"hydrate=person(currentTeam),team&includeNullMetrics=true&limit=50&seasons={DateTime.Now.Year.ToString()}&sportIds=1&" +
                $"statFields=standard,advanced,expected,tracking&" +
                $"fields=splits,stats,hitting,standard,runs,triples,homeRuns,strikeOuts,baseOnBalls,avg,ops,doubles,caughtStealing,stolenBases,groundIntoDoublePlay,rbi,babip";

            string result = await GetOAuthJsonRequest(path);

            return JsonSerializer.Deserialize<HitterStats>(result);
        }

        public async Task<PitcherStats> GetPitcherStats(int playerId)
        {
            path = BASE_URL + $"stats/search?pitcherIds={playerId}&gameTypes=S&group=pitching&groupBy=season,team,player&" +
                $"hydrate=person(currentTeam),team&includeNullMetrics=true&limit=50&seasons={DateTime.Now.Year.ToString()}&sportIds=1&" +
                $"statFields=standard,advanced,expected,tracking&fields=splits,stats,pitching,standard,gamesStarted,groundOuts," +
                $"homeRuns,strikeOuts,intentionalWalks,hits,avg,groundIntoDoublePlay,era,inningsPitched,wins,losses,saves,saveOpportunities,blownSaves,earnedRuns,whip,gamesPlayed,baseOnBalls,inningsPitched,holds";

            string result = await GetOAuthJsonRequest(path);

            return JsonSerializer.Deserialize<PitcherStats>(result);
        }

        public async Task<PitchTypes> GetPitchTypes(int playerId)
        {
            path = BASE_URL + $"stats/search?pitcherIds={playerId}&gameTypes=S&group=pitching&" +
                $"groupBy=pitchType,player&hydrate=person(currentTeam),team&includeNullMetrics=true&" +
                $"limit=50&seasons={DateTime.Now.Year.ToString()}&sportIds=1&statFields=standard,advanced,expected,tracking&" +
                $"fields=splits,stats,pitching,standard,hits,atBats,tracking,exitVelocity,averageValue,pitchType,code";

            string result = await GetOAuthJsonRequest(path);

            return JsonSerializer.Deserialize<PitchTypes>(result);
        }

        public async Task<BullpenPitches> GetBullpenPitches(int playerId)
        {
            path = BASE_URL + $"stats/search?pitcherIds={playerId}&gameTypes=S&group=pitching&groupBy=pitchType,player&" +
                $"hydrate=person(currentTeam),team&includeNullMetrics=true&limit=50&seasons={DateTime.Now.Year.ToString()}&sportIds=1&" +
                $"statFields=standard,advanced,expected,tracking&" +
                $"fields=splits,stats,pitching,standard,hits,atBats,tracking,releaseSpeed,averageValue,pitchType,code";

            string result = await GetOAuthJsonRequest(path);

            return JsonSerializer.Deserialize<BullpenPitches>(result);
        }

        /**********************************************************/

        public async Task<Coaches> GetCoaches(int teamId)
        {
            path = BASE_URL + $"teams/{teamId}/coaches";

            string result = await GetOAuthJsonRequest(path);

            return JsonSerializer.Deserialize<Coaches>(result);
        }

        /**********************************************************/

        public async Task<LiveData> GetLiveData(int gamePk)
        {
            path = $"https://statsapi.mlb.com/api/v1.1/game/{gamePk}/feed/live?&fields=liveData,boxscore,teams";

            string result = await GetOAuthJsonRequest(path);

            return JsonSerializer.Deserialize<LiveData>(result);
        }
    }
}   