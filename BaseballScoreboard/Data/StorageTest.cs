namespace BaseballScoreboard.Data
{
    internal static class StorageTest
    {
        static PlayerList storageList = new();
        
        static public void DeserializeList(PlayerList pl)
        {
            storageList.people = pl.people;
        }
       
    }

    internal class Player()
    {
        public int? id { get; set; }
        public string? fullName { get; set; }
        public string? primaryNumber { get; set; }
    }

    internal class PlayerList()
    {
        public List<Player>? people { get; set; }
    }
}

