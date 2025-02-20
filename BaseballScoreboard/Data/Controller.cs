using System.Text.Json;

namespace BaseballScoreboard.Data
{
    static internal class Controller
    {
        /* As of now Controller behaves as a all-knowing singleton.
         * Not a bad thing, but could be changed to be more MVC/MVP like
         * Doesn't store any information, resusable information is stored in StorageTest */

        static private ApiClient apiClient = new ApiClient();
        static private Storage storage = new Storage();
        
        static public Player GetPlayer(int personId)
        {
            Player player = new();

            try
            {
                string jsonStr = apiClient.GetPlayerInfo(personId); // Calls an api for a specific player

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

        static public SortedList<string, int> GetTeams()
        {
            SortedList<string, int>? teams = new SortedList<string, int>();
            List<Team>? temp = new List<Team>();

            string filePath = "BaseballScoreboard.Resources.AllTeams.txt";
            string file = ApiClient.readFile(filePath);

            temp = JsonSerializer.Deserialize<List<Team>>(file);

            foreach (Team t in temp)
            {
                if (t.name != null && t.id != null)
                    teams.Add(t.name, (int)t.id);
            }

            return teams;
        }

        static public RosterList getTeamRoster(int teamId)
        {
            return apiClient.GetRoster(teamId);
        }

        static public int GetTeamId(string teamName)
        {
            return storage.GetTeamId(teamName);
        }

        static public string[] ReturnAllTeams()
        {
            return storage.GetAllTeams();
        }

        static public int GetGameId(string date, int teamId)
        {
            return apiClient.GetGamePk(date, teamId);
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
    }
}
