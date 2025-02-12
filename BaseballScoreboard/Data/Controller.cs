using System.CodeDom.Compiler;
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

        public static SortedList<int, string> GetTeams()
        {
            SortedList<int, string>? teams = new SortedList<int, string>();
            List<Team>? temp = new List<Team>();

            string filePath = "BaseballScoreboard.Resources.AllTeams.txt";
            string file = ApiTest.readFile(filePath);

            temp = JsonSerializer.Deserialize<List<Team>>(file);

            foreach (Team t in temp)
            {
                teams.Add((int)t.id, t.name);
            }

            return teams;
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
    }
}
