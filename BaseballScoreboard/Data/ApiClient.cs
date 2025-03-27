using System.Drawing.Imaging;
using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BaseballScoreboard.Data
{
    internal class ApiClient
    {
        static string ACCESS_TOKEN = GetAccessToken();
        const string BASE_URL = "https://statsapi.mlb.com/api/v1/";
        static HttpClient client = new HttpClient();
        string? path;

        public string GetPlayerInfo(int personId)
        {
            // Returns an object containing list "people"
            string queryDetailed = "?fields=people%2C+fullName%2C+id%2C+primaryNumber";
            path = BASE_URL + $"people/{personId}{queryDetailed}";

            return GetJson(path);
        }

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

        public string GetOAuthJsonRequest(string endpoint)
        {
            string result = String.Empty;

            ACCESS_TOKEN = GetAccessToken();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ACCESS_TOKEN);
            HttpResponseMessage response = client.GetAsync(endpoint).Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                result = "Failure - OAuth2.0 Get Request";
            }

            return result;
        }

        public RosterList GetRoster(int teamId)
        {
            RosterList players = new RosterList();
            path = BASE_URL + $"teams/{teamId}/roster/40Man";

            string result = GetJson(path);
            players = JsonSerializer.Deserialize<RosterList>(result);

            return players;
        }

        // Date Format: YYYY-MM-DD
        public int GetGamePk(string date, int teamId)
        {
            Game? g = new Game();
            path = BASE_URL + $"schedule?teamId={teamId}&sportId=1&date={date}&fields=dates%2C+games%2C+gamePk%2C+gameDate";
            string result = GetJson(path);
            g = JsonSerializer.Deserialize<Game>(result);

            DateTime currentUtcTime = DateTimeOffset.UtcNow.UtcDateTime;
            TimeSpan smallestTs = TimeSpan.MaxValue;
            int gameId = -1;

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

            return gameId;
        }

        public Umpires GetUmpires(int gamePk)
        {
            Umpires ump = new Umpires();
            path = BASE_URL + $"game/{gamePk}/boxscore?fields=officials%2Cofficial%2Cid%2CfullName%2CofficialType";

            string result = GetJson(path);
            ump = JsonSerializer.Deserialize<Umpires>(result);

            return ump;
        }


        /****************************************************************
         * 
         *                 START OF STAT CALLS
         * 
         ****************************************************************/

        public FirstPitch GetFirstPitch(int playerId)
        {
            string endpoint = BASE_URL + $"stats/search?batterIds={playerId}&" +
                $"gameTypes=S&group=hitting&groupBy=season,player&hydrate=person(currentTeam),team&" +
                $"includeNullMetrics=true&sitCodes=fip&seasons={DateTime.Now.Year.ToString()}&sportIds=1&" +
                $"statFields=standard,advanced,expected,tracking&" +
                $"fields=splits,stats,hitting,standard,ops,avg,tracking,hitProbability,averageValue";

            string result = GetOAuthJsonRequest(endpoint);

            FirstPitch stat = new FirstPitch();
            stat = JsonSerializer.Deserialize<FirstPitch>(result);

            return stat;
        }

        public RISP GetRISP(int playerId)
        {
            string endpoint = BASE_URL + $"stats/search?batterIds={playerId}&" +
                $"gameTypes=S&group=hitting&groupBy=season,player&hydrate=person(currentTeam),team&" +
                $"includeNullMetrics=true&limit=50&seasons={DateTime.Now.Year.ToString()}&sitCodes=risp&sportIds=&" +
                $"statFields=standard,advanced,expected,tracking&fields=splits,stats,hitting,standard,homeRuns,hits,avg,atBats";

            string result = GetOAuthJsonRequest(endpoint);

            RISP stat = new RISP();
            stat = JsonSerializer.Deserialize<RISP>(result);

            return stat;
        }

        public RISP GetRISP2O(int playerId)
        {
            string endpoint = BASE_URL + $"stats/search?batterIds={playerId}&" +
                $"gameTypes=S&group=hitting&groupBy=season,player&hydrate=person(currentTeam),team&" +
                $"includeNullMetrics=true&limit=50&seasons={DateTime.Now.Year.ToString()}&sitCodes=o2,risp&sportIds=1&" +
                $"statFields=standard,advanced,expected,tracking&fields=splits,stats,hitting,standard,homeRuns,hits,avg,atBats";

            string result = GetOAuthJsonRequest(endpoint);

            RISP stat = new RISP();
            stat = JsonSerializer.Deserialize<RISP>(result);

            return stat;
        }

        public VSLeftRight GetVSLeft(int playerId)
        {
            string endpoint = BASE_URL + $"stats/search?batterIds={playerId}&gameTypes=S&group=hitting&" +
                $"groupBy=season,player&hydrate=person(currentTeam),team&includeNullMetrics=true&" +
                $"limit=50&pitchHand=L&seasons={DateTime.Now.Year.ToString()}&sportIds=1&statFields=standard,advanced,expected,tracking&" +
                $"fields=splits,stats,hitting,standard,homeRuns,hits,avg,atBats,ops";

            string result = GetOAuthJsonRequest(endpoint);

            VSLeftRight stat = new VSLeftRight();
            stat = JsonSerializer.Deserialize<VSLeftRight>(result);

            return stat;
        }

        public VSLeftRight GetVSRight(int playerId)
        {
            string endpoint = BASE_URL + $"stats/search?batterIds={playerId}&gameTypes=S&group=hitting&" +
                $"groupBy=season,player&hydrate=person(currentTeam),team&includeNullMetrics=true&" +
                $"limit=50&pitchHand=R&seasons={DateTime.Now.Year.ToString()}&sportIds=1&statFields=standard,advanced,expected,tracking&" +
                $"fields=splits,stats,hitting,standard,homeRuns,hits,avg,atBats,ops";

            string result = GetOAuthJsonRequest(endpoint);

            VSLeftRight stat = new VSLeftRight();
            stat = JsonSerializer.Deserialize<VSLeftRight>(result);

            return stat;
        }

        public Plus7 Get7Plus(int playerId)
        {
            string endpoint = BASE_URL + $"stats/search?batterIds={playerId}&gameTypes=S&group=hitting&" +
                $"groupBy=season,player&hydrate=person(currentTeam),team&includeNullMetrics=true&" +
                $"limit=50&seasons={DateTime.Now.Year.ToString()}&sitCodes=ig07&sportIds=1&" +
                $"statFields=standard,advanced,expected,tracking&fields=splits,stats,hitting,standard,avg,ops";

            string result = GetOAuthJsonRequest(endpoint);

            Plus7 stat = new Plus7();
            stat = JsonSerializer.Deserialize<Plus7>(result);

            return stat;
        }

        public HitterStat GetHitterStats(int playerId)
        {
            string endpoint = BASE_URL + $"stats/search?batterIds=663457&gameTypes=S&group=hitting&groupBy=season,player&" +
                $"hydrate=person(currentTeam),team&includeNullMetrics=true&limit=50&seasons=2025&sportIds=1&" +
                $"statFields=standard,advanced,expected,tracking&" +
                $"fields=splits,stats,hitting,standard,runs,triples,homeRuns,strikeOuts,intentionalWalks,avg,ops,doubles,caughtStealing,stolenBases,groundIntoDoublePlay,rbi,babip";

            string result = GetOAuthJsonRequest(endpoint);

            HitterStat stat = new HitterStat();
            stat = JsonSerializer.Deserialize<HitterStat>(result);

            return stat;
        }

        /****************************************************************/

        static private string GetRefreshToken()
        {
            string REQUEST_URL = "https://statsapi.mlb.com/api/v1/authentication/okta/token";

            string[] FILE_INFO = readFile("BaseballScoreboard.Resources.config.txt").Split('\n');

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
                MessageBox.Show("ERROR - Could not fetch Refresh Token.");
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
                MessageBox.Show("ERROR - Could not fetch Access Token.");
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

        /****************************************************************/
    }
}

/* Rudimentary as of now
 * Teams should be stored locally, and accessed via storage class

public string GetAllTeams()
{
    // Returns an object containing list "teams"
    // Elemnts of "teams" have attributes id, name
    string queryDetailed = "teams?leagueIds=103&leagueIds=104&fields=teams&fields=name&fields=id";
    path = BASE_URL + $"{queryDetailed}";

    return GetJson(path);
}
*/        