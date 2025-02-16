using BaseballScoreboard.Data;
using System.Data;

namespace BaseballScoreboard.Forms
{
    public partial class frmSearchTeam : Form
    {
        List<string> playersList = new();

        /***********************
         * Event Call Methods  *
         ***********************/

        // Forms Methods

        public frmSearchTeam()
        {
            InitializeComponent();
        }

        private void frmSearchTeam_Load(object sender, EventArgs e)
        {
            SortedList<string, int> data = Controller.GetTeams();

            foreach (KeyValuePair<string, int> team in data)
            {
                cBoxHomeTeams.Items.Add(team.Key);
                cBoxGuestTeams.Items.Add(team.Key);
            }
        }

        // Combo Box Methods

        private void cBoxHomePlayer_TextChanged(object sender, EventArgs e)
        {
            SearchName(cBoxHomePlayers, playersList);
        }

        private void cBoxGuestPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddPlayers(cBoxGuestPlayers, lBoxGuestPlayers);
        }

        private void cBoxHomePlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddPlayers(cBoxHomePlayers, lBoxHomePlayers);
        }

        private void AddShohei_Click_1(object sender, EventArgs e)
        {
            //txtTest.Text = Controller.ReturnShohei().fullName;
        }

        private void cBoxGuestTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayPlayers(cBoxGuestTeams, cBoxGuestPlayers);
        }

        private void cBoxHomeTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayPlayers(cBoxHomeTeams, cBoxHomePlayers);
        }

        private void cBoxHomeTeams_TextChanged(object sender, EventArgs e)
        {
            ShowTeams(cBoxHomeTeams);
        }

        private void cBoxGuestTeams_TextChanged(object sender, EventArgs e)
        {
            ShowTeams(cBoxGuestTeams);
        }

        // Button moethods

        private void btnHomePlayersRemove_Click(object sender, EventArgs e)
        {
            RemovePlayer(lBoxHomePlayers);
        }

        private void btnGuestPlayersRemove_Click(object sender, EventArgs e)
        {
            RemovePlayer(lBoxGuestPlayers);
        }

        private void btnHomePlayersClear_Click(object sender, EventArgs e)
        {
            RemovePlayers(lBoxHomePlayers);
        }

        private void btnGuestPlayersClear_Click(object sender, EventArgs e)
        {
            RemovePlayers(lBoxGuestPlayers);
        }

        //*****************************************************************************************************

        /********************
         * Utility Methods  *
         ********************/

        private List<string> GetMatches(List<string> fullList, string searchTxt)
        {
            List<string> suggestedItems = new List<string>();
            searchTxt = searchTxt.ToUpper();

            foreach (string str in fullList)
            {
                if (str.ToUpper().Contains(searchTxt))
                {
                    suggestedItems.Add(str);
                }
            }

            return suggestedItems;
        }

        private void AddPlayers(ComboBox cBox, ListBox lBox)
        {
            if (cBox.SelectedIndex != -1 && cBox.SelectedItem != null)
            {
                if (!lBox.Items.Contains(cBox.SelectedItem))
                {
                    lBox.Items.Add(cBox.SelectedItem);
                }
            }
        }

        private void RemovePlayer(ListBox lBox)
        {
            if (lBox.SelectedIndex != -1)
            {
                lBox.Items.RemoveAt(lBox.SelectedIndex);
            }
        }

        private void DisplayPlayers(ComboBox src, ComboBox dst)
        {
            dst.Items.Clear();

            if (src.SelectedIndex >= 0 && src.SelectedItem != null)
            {
                RosterList rosterList = new();
                int teamId = Controller.GetTeamId((string)src.SelectedItem);

                if (teamId != -1)
                { 
                    rosterList = Controller.getTeamRoster(teamId); 
                }
                else
                {
                    MessageBox.Show($"{(string)src.SelectedItem} could not be found.");
                    return; 
                }

                if (rosterList.roster != null)
                {
                    foreach (People p in rosterList.roster)
                    {
                        if (p.person != null && p.person.fullName != null)
                        {
                            playersList.Add(p.person.fullName);
                        }
                    }

                    dst.Items.AddRange(playersList.ToArray());
                }
            }
        }

        private void ShowTeams(ComboBox cBox)
        {
            SortedList<string, int> data = Controller.GetTeams();

            cBox.Items.Clear();

            string filter = cBox.Text;
            if (string.IsNullOrEmpty(filter))
            {
                cBox.Items.AddRange(data.Keys.ToArray());
            }
            else
            {
                string[] filteredItems = data.Keys.Where(x => x.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToArray();

                cBox.Items.AddRange(filteredItems);
            }

            cBox.DroppedDown = true;
            cBox.Select(filter.Length, 0);
        }

        private void SearchName(ComboBox cb, List<string> fullList)
        {
            string? autocomplete;

            try
            {
                if (!string.IsNullOrEmpty(cb.Text))
                {
                    autocomplete = cb.Text;
                    var matchList = GetMatches(fullList, autocomplete.ToUpper());

                    if (matchList.Count > 0)
                    {
                        cb.DroppedDown = true;
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
                    cb.Items.AddRange(fullList.ToArray());
                }
            }
            catch (Exception ex) 
            {
            MessageBox.Show(ex.Message.ToString());
            }
        }

        private void RemovePlayers(ListBox lBox)
        {
            lBox.Items.Clear();
        }

        //*****************************************************************************************************
    }
}
