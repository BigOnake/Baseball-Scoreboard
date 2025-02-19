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
            lblDate.Text = DateTime.Now.ToString("MM/dd/yyyy");

            SortedList<string, int> data = Controller.GetTeams();

            foreach (KeyValuePair<string, int> team in data)
            {
                cBoxHomeTeams.Items.Add(team.Key);
                cBoxGuestTeams.Items.Add(team.Key);
            }
        }

        // Combo Box Methods

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

        // Button Methods

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

        private void AddPlayers(ComboBox cBox, ListBox lBox)
        {
            if (cBox.SelectedItem != null && cBox.SelectedIndex > -1)
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
            playersList.Clear();

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
                        if (p.person != null && p.person.fullName != null && p.position != null && p.position.abbreviation != null)
                        {
                            playersList.Add($"{p.person.fullName} - {p.position.abbreviation}");
                        }
                    }

                    dst.Items.AddRange(playersList.ToArray());
                }
            }
        }

        private void RemovePlayers(ListBox lBox)
        {
            lBox.Items.Clear();
        }

        //*****************************************************************************************************
    }
}
