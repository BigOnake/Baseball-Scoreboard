using BaseballScoreboard.Data;

namespace BaseballScoreboard.Forms
{
    public partial class frmSearchTeam : Form
    {
        private Dictionary<string, int> playersList = new Dictionary<string, int>();
        private string[] players = { "Nolan Arenado", "Dylan Carlson", "Matt Carpenter", "Steven Matz", "Paul DeJong",
                            "Tommy Edman", "Paul Goldschmidt", "Giovanny Gallegos", "Ryan Helsley", "Jordan Hicks",
                            "Dakota Hudson", "Tyler O'Neill", "Corey Dickerson", "Adam Wainwright", "Yadier Molina",
                            "Harrison Bader", "Juan Yepez", "Lars Nootbaar", "Miles Mikolas", "Jack Flaherty",
                            "Alex Reyes", "Génesis Cabrera", "Andrew Knizner", "Edmundo Sosa", "Kodi Whitley",
                            "Drew VerHagen", "Nick Wittgren", "Zack Thompson", "Brendan Donovan", "Nolan Gorman",
                            "Andre Pallante", "Packy Naughton", "Jake Woodford", "Aaron Brooks", "Conner Capel"};

        //########################
        // Event Handlers
        //########################

        public frmSearchTeam()
        {
            InitializeComponent();
        }

        private void frmSearchTeam_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < players.Length; i++)
            {
                playersList.Add(players[i], i);
                cBoxHomePlayers.Items.Add(players[i]);
            }

            ApiTestt api = new ApiTestt();
            txtTest.Text = api.getPlayerInfo();
        }

        private void cBoxHomePlayer_TextChanged(object sender, EventArgs e)
        {
            SearchName(cBoxHomePlayers, playersList);
        }

        private void cBoxGuestPlayer_TextChanged(object sender, EventArgs e)
        {
            SearchName(cBoxGuestPlayers, playersList);
        }

        private void cBoxHomePlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxHomePlayers.SelectedIndex != -1 && cBoxHomePlayers.SelectedItem != null)
            {
                if (!lBoxHomePlayers.Items.Contains(cBoxHomePlayers.SelectedItem))
                {
                    lBoxHomePlayers.Items.Add(cBoxHomePlayers.SelectedItem);
                }
            }
        }

        //########################
        // User Methods
        //########################

        private void SearchName(ComboBox cb, Dictionary<string, int> fullList)
        {
            string autocomplete;

            if (!string.IsNullOrEmpty(cb.Text))
            {
                autocomplete = cb.Text;
                List<string> matchList = GetMatches(fullList, autocomplete.ToUpper());

                if (matchList.Count > 0)
                {
                    cb.Items.Clear();
                    cb.Items.AddRange(matchList.ToArray());
                    cb.Select(autocomplete.Length, 0);
                    return;
                }
                else
                { cb.SelectionStart = autocomplete.Length; }
            }
            else
            {
                cb.Items.Clear();
                cb.Items.AddRange(fullList.Keys.ToArray());
            }
        }

        private List<string> GetMatches(Dictionary<string, int> fullList, string searchTxt)
        {
            List<string> suggestedItems = new List<string>();
            searchTxt = searchTxt.ToUpper();

            foreach (string str in fullList.Keys)
            {
                if (str.ToUpper().Contains(searchTxt))
                {
                    suggestedItems.Add(str);
                }
            }

            return suggestedItems;
        }
    }
}
