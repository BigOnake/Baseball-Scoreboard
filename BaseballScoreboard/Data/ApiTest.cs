using System.Text.Json;

namespace BaseballScoreboard.Data
{
    internal class ApiTest
    {
        const string BASE_URL = "https://statsapi.mlb.com/api/v1/";

        static HttpClient client = new HttpClient();
        string? path;
        string? jsonStr;


        //Recieves Json of a player, and stores it as an element of PlayerList
        public Player GetPlayerInfo(int personId)
        {
            Player? player = null;
            string queryDetailed = "?fields=people%2C+fullName%2C+id%2C+primaryNumber";

            path = BASE_URL + $"people/{personId}{queryDetailed}";

            try
            {
                

                HttpResponseMessage response = client.GetAsync(path).Result;
                jsonStr = response.Content.ReadAsStringAsync().Result;

                jsonStr = extractObject(jsonStr);
                player = JsonSerializer.Deserialize<Player>(jsonStr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return player;
        }

        private string extractObject(string jsonStr)
        {
            string str = jsonStr;

            (int idxOpen, int idxClose) = (jsonStr.IndexOf('['), jsonStr.LastIndexOf(']'));

            if (idxOpen != -1 && idxClose != -1)
            {
                str = jsonStr.Substring(idxOpen + 1, idxClose - idxOpen - 1);
            }

            return str;
        }
    }
}
