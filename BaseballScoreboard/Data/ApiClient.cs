using System.Drawing.Imaging;
using System.Globalization;
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
                MessageBox.Show("Error getting refresh token.");
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
                MessageBox.Show("Error getting access token.");
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