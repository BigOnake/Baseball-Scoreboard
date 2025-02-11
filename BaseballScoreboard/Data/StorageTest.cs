using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BaseballScoreboard.Data
{
    internal static class StorageTest
    {
        static PlayerList storageList = new();
        
        static public void CopyList(PlayerList pl)
        {
            if (pl != null)
            {
                storageList.people = pl.people;
            }
        }

        static public string DisplayList()
        {
            string str = "Empty";
            try
            {
                str = ($"Full name: {storageList.people[0].fullName} \n" +
                       $"Id: {storageList.people[0].id} \n" +
                       $"Primary number: {storageList.people[0].primaryNumber}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return str;
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

