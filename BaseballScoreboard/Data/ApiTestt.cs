using System.Text.Json;

namespace BaseballScoreboard.Data
{
    internal class ApiTestt
    {
        const string BASE_URL = "https://statsapi.mlb.com/api/v1/";
        HttpClient client = new();

        public string getPlayerInfo()
        {
            const int PERSON_ID = 660271;
            const string DETAILED_QUERY = "?fields=people%2C+fullName%2C+id%2C+primaryNumber";
            string path = BASE_URL + $"people/{PERSON_ID}{DETAILED_QUERY}";

            HttpResponseMessage response = client.GetAsync(path).Result;
            string jsonStr = response.Content.ReadAsStringAsync().Result;

            try
            {
                PlayerList tList = JsonSerializer.Deserialize<PlayerList>(jsonStr);
                StorageTest.CopyList(tList);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

            return jsonStr;
        }
    }
}

/*
 public class TestClass
    {
        string BASE_URL = "https://statsapi.mlb.com/api/v1/";

        static HttpClient client = new HttpClient();
        HttpResponseMessage? response;
        string? queryDetailed = "?fields=people%2C+fullName%2C+id%2C+primaryNumber";
        string? path;

        //Recieves Json of a player, and stores it as an element of PlayerList
        public void GetInfo()
        {
            int personId = 660271; //Shohei Otani player id

            path = BASE_URL + $"people/{personId}{queryDetailed}";

            response = client.GetAsync(path).Result;
            string jsonStr = response.Content.ReadAsStringAsync().Result;

            Console.WriteLine(jsonStr + '\n');
            PlayerList? playerList = JsonSerializer.Deserialize<PlayerList>(jsonStr);

            if (playerList != null && playerList.people != null)
            { 
                Console.WriteLine($"Full name: {playerList.people[0].fullName} \n" +
                                  $"Id: {playerList.people[0].id} \n" +
                                  $"Primary number: {playerList.people[0].primaryNumber}");
            }
            else
            {
                Console.WriteLine("playerList.people is null");
            }
        }

    }

    //Case sensitive, names of the variables cannot be changed
    public class Player()
{
    public int? id { get; set; }
    public string? fullName { get; set; }
    public string? primaryNumber { get; set; }
}

public class PlayerList()
{
    public List<Player> people { get; set; }
}
}
 */