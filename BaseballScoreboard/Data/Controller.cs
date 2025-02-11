using System.Numerics;
using System.Reflection;
using System.Text.Json;

namespace BaseballScoreboard.Data
{
    static internal class Controller
    {
        static private ApiTest apiTest = new ApiTest();
        static private StorageTest storageTest = new StorageTest();

        static public Player ReturnShohei()
        {
            Player player = new();
            int personId = 660271; //Shohei Otani player id

            try
            {
                string jsonStr = apiTest.GetPlayerInfo(personId);

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

        static public void LoadAllTeams()
        {
            string FILE_NAME = "BaseballScoreboard.Resources.AllTeams.txt";
            string allTeamsJson;

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
