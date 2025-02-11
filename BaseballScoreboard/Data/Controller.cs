using System.Numerics;
using System.Reflection;
using System.Text.Json;

namespace BaseballScoreboard.Data
{
    static internal class Controller
    {
        /* As of now Controller behaves as a all-knowing singleton.
         * Not a bad thing, but could be changed to be more MVC/MVP like
         * Doesn't store any information, resusable information is stored in StorageTest */

        static private ApiTest apiTest = new ApiTest();
        static private StorageTest storageTest = new StorageTest();
        
        static public Player ReturnShohei()
        {
            Player player = new();
            int personId = 660271; //Shohei Otani player id

            try
            {
                string jsonStr = apiTest.GetPlayerInfo(personId); // Calls an api for a specific player

                if (string.IsNullOrEmpty(jsonStr))
                {
                    MessageBox.Show("Json returned empty");
                }

                jsonStr = ExtractObject(jsonStr);
                player = JsonSerializer.Deserialize<Player>(jsonStr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return player;
        }

        // Called at the start of the program in main
        static public void LoadAllTeams()
        {
            string FILE_NAME = "BaseballScoreboard.Resources.AllTeams.txt";

            string contents = readFile(FILE_NAME);
            List<Team> teams = JsonSerializer.Deserialize<List<Team>>(contents);

            if (teams != null)
            {
                storageTest.setAllTeams(teams);
            }
        }

        static public string[] ReturnAllTeams()
        {
            return storageTest.GetAllTeams();
        }

        /* Returns string that can be parsed in the following way:
         * Type object = JsonSerializer.Deserialize<Type>(json); */
        static private string ExtractObject(string jsonStr)
        {
            string str = jsonStr;

            (int idxOpen, int idxClose) = (jsonStr.IndexOf('['), jsonStr.LastIndexOf(']'));

            if (idxOpen != -1 && idxClose != -1)
            {
                str = jsonStr.Substring(idxOpen + 1, idxClose - idxOpen - 1);
            }

            return str;
        }

        /* Returns string that can be parsed in the following way:
         * List<T> list = JsonSerializer.Deserialize<List<T>>(json); */
        static private string ExtractList(string jsonStr)
        {
            string str = jsonStr;

            (int idxOpen, int idxClose) = (jsonStr.IndexOf('['), jsonStr.LastIndexOf(']'));

            if (idxOpen != -1 && idxClose != -1)
            {
                str = jsonStr.Substring(idxOpen, idxClose - idxOpen + 1);
            }

            return str; 
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
                return null;
            }
        }

        static string readFile(string fileName)
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fileName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
