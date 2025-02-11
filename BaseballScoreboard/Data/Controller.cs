namespace BaseballScoreboard.Data
{
    static internal class Controller
    {
        static private ApiTest apiTest= new ApiTest();

        static public Player returnShohei()
        {
            int personId = 660271; //Shohei Otani player id
            return apiTest.GetPlayerInfo(personId);
        }
    }
}
