using BaseballScoreboard.Data;
using frmScoreCard;
using System.Data;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.AxHost;

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

        private void cBoxHomeTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayPlayers(cBoxHomeTeams, cBoxHomePlayers);
        }

        private void cBoxGuestTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayPlayers(cBoxGuestTeams, cBoxGuestPlayers);

            fillUmpires();
        }

        private void cBoxGuestPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddPlayers(cBoxGuestPlayers, lBoxGuestPlayers);
        }

        private void cBoxHomePlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddPlayers(cBoxHomePlayers, lBoxHomePlayers);
        }

        private void fillUmpires()
        {
            // Ideally, this works during season (when schedules for the season get filled - currently doesn't exist)
            //int teamId = Controller.GetTeams()[cBoxGuestTeams.Text];
            //int gamePk = Controller.GetGameId(DateTime.Now.ToString("yyyy-MM-dd"), teamId); => or hardcode '138' for teamId for Cards

            int gamePk = Controller.GetGameId("2024-04-30", 138);

            Umpires ump = Controller.GetUmpires(gamePk);
            if (ump?.officials != null)
            {
                foreach (GameInfo gi in ump.officials)
                {
                    if (gi?.official != null && gi?.officialType != null)
                    {
                        string data = $"{gi.officialType[0]}{gi.officialType[gi.officialType.IndexOf(' ') + 1]} - {gi.official.fullName}";
                        lBoxUmpires.Items.Add(data);
                    }
                }
            }
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

        private void lBoxHomePlayers_DrawItem(object sender, DrawItemEventArgs e)
        {
            drawPlayerItems(lBoxHomePlayers, e);
        }

        private void lBoxGuestPlayers_DrawItem(object sender, DrawItemEventArgs e)
        {
            drawPlayerItems(lBoxGuestPlayers, e);
        }
        private void lBoxUmpires_DrawItem(object sender, DrawItemEventArgs e)
        {
            drawPlayerItems(lBoxUmpires, e);
        }

        private void drawPlayerItems(ListBox lBox, DrawItemEventArgs e)
        {
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            if ((e.Index % 2) == 0)
            {
                e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            }

            e.Graphics.DrawString(lBox.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds, format);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SB stat = Controller.GetSB(137);

            MessageBox.Show(stat.splits[0].stats.hitting.standard.groundIntoDoublePlay.ToString());
            MessageBox.Show(stat.splits[0].stats.hitting.standard.caughtStealing.ToString());
            MessageBox.Show(stat.splits[0].stats.hitting.standard.stolenBases.ToString());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var wpfWindow = new MainWindow();
            wpfWindow.Tag = "hello";

            wpfWindow.Show();
        }


    //*****************************************************************************************************
}
}
