using System.Text.Json;

namespace BaseballScoreboard.Data
{
    internal class ApiTest
    {
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
    }
}

        // Rudimentary as of now
        // Teams should be stored locally, and accessed via storage class
        /*
        public string GetAllTeams()
        {
            // Returns an object containing list "teams"
            // Elemnts of "teams" have attributes id, name
            string queryDetailed = "teams?leagueIds=103&leagueIds=104&fields=teams&fields=name&fields=id";
            path = BASE_URL + $"{queryDetailed}";

            return GetJson(path);
        }
        */

        