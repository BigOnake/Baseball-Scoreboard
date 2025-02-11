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

            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(FILE_NAME))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string contents = reader.ReadToEnd();
                    List<Team> teams = JsonSerializer.Deserialize<List<Team>>(contents);
                    
                    if(teams != null)
                    {
                        storageTest.setAllTeams(teams);
                    }
                }
            }
        }

        static public string[] ReturnAllTeams()
        {
            return storageTest.GetAllTeams();
        }

        /* Returns string that can be desrealized in the following way:
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

        /* Returns string that can be desrealized in the following way:
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
