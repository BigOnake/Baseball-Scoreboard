using System.Reflection;
using System.Security.Policy;
using System.Text.Json;

namespace BaseballScoreboard.Data
{
    internal class ApiTest
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

        public List<Roster> GetRoster(int teamId)
        {
            List<Roster>? roster = new List<Roster>();
            path = BASE_URL + $"teams/{teamId}/roster/40Man?fields=roster&fields=person&fields=id&fields=fullName";

            string result = GetJson(path);
            roster = JsonSerializer.Deserialize<List<Roster>>(result);

            return roster;
        }

        static private string GetAccessToken()
        {
            string ACCESS_URL = "https://statsapi.mlb.com/api/v1/authentication/okta/token/refresh?refreshToken=";

            string[] FILE_INFO = readFile("BaseballScoreboard.Resources.config.txt").Split('\n');
            string REFRESH_TOKEN = FILE_INFO[0];

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