using BaseballScoreboard.Data;
using frmScoreCard;
using System.Data;
using System.Numerics;
using System.Text.Json;
using System.Windows.Forms;


namespace BaseballScoreboard.Forms
{
    public partial class frmSearchTeam : Form
    {
        public frmSearchTeam()
        {
            InitializeComponent();
        }

        private void frmSearchTeam_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("MM/dd/yyyy");

            Controller.SetTeams();
            Teams team = Controller.GetTeams();

            if (team?.teams != null)
            {
                foreach (Team t in team.teams)
                {
                    cBoxHomeTeams.Items.Add(t);
                    cBoxGuestTeams.Items.Add(t);
                }
            }
        }

        /*****************************************************/

        private void cBoxHomeTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddRoster(cBoxHomeTeams, cBoxHomePlayers, "home");

            AddUmpires();
        }

        private void cBoxGuestTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddRoster(cBoxGuestTeams, cBoxGuestPlayers, "guest");

            AddUmpires();
        }

        private void AddRoster(ComboBox source, ComboBox destination, string teamType)
        {
            if (source?.SelectedItem != null)
            {
                Controller.SetRoster(Controller.GetTeamId(source.SelectedItem.ToString()), teamType);
                Controller.SetGamePk(Controller.GetTeamId(source.SelectedItem.ToString()));
                Controller.SetSB(teamType, Controller.GetTeamId(source.SelectedItem.ToString()));
                Controller.SetVenues(Controller.GetGamePk());
                Controller.SetStadiumData();

                destination.Items.Clear();
                destination.Items.AddRange(Controller.GetRoster(teamType).roster.ToArray());
            }
            else
            {
                MessageBox.Show("Error - Invalid Team Selection.", "ERROR");
                return;
            }
        }

        private void AddUmpires()
        {
            Controller.SetUmpires();

            lBoxUmpires.Items.Clear();

            if (Controller.GetUmpires().officials != null)
            {
                foreach (Umpire u in Controller.GetUmpires().officials)
                {
                    lBoxUmpires.Items.Add(u);
                }
            }
        }

        /*****************************************************/

        private void cBoxHomePlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddPlayer(cBoxHomePlayers, "home");
        }

        private void cBoxGuestPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddPlayer(cBoxGuestPlayers, "guest");
        }

        private void AddPlayer(ComboBox source, string teamType)
        {
            if (source?.SelectedItem != null)
            {
                if (teamType == "home")
                {
                    if (!lBoxHomePlayers.Items.Contains(source.SelectedItem.ToString()))
                    {
                        lBoxHomePlayers.Items.Add(source.SelectedItem.ToString());
                        Controller.AddSelectedPlayer("home", ParseName(source.SelectedItem.ToString()));
                    }
                }
                else
                {
                    if (!lBoxGuestPlayers.Items.Contains(source.SelectedItem.ToString()))
                    {
                        lBoxGuestPlayers.Items.Add(source.SelectedItem.ToString());
                        Controller.AddSelectedPlayer("guest", ParseName(source.SelectedItem.ToString()));
                    }
                }
            }
        }

        private string ParseName(string name)
        {
            return name.Substring(0, name.IndexOf("-")).TrimEnd();
        }

        private void btnHomePlayersRemove_Click(object sender, EventArgs e)
        {
            RemovePlayer(lBoxHomePlayers, "home");
        }

        private void btnGuestPlayersRemove_Click(object sender, EventArgs e)
        {
            RemovePlayer(lBoxGuestPlayers, "guest");
        }

        private void RemovePlayer(ListBox lBox, string teamType)
        {
            if (lBox.SelectedIndex != -1)
            {
                Controller.RemoveSelectedPlayer(teamType, ParseName(lBox.SelectedItem.ToString()));

                lBox.Items.RemoveAt(lBox.SelectedIndex);
            }
        }

        private void btnHomePlayersClear_Click(object sender, EventArgs e)
        {
            RemoveAllPlayers(lBoxHomePlayers, "home");
        }

        private void btnGuestPlayersClear_Click(object sender, EventArgs e)
        {
            RemoveAllPlayers(lBoxGuestPlayers, "guest");
        }

        private void RemoveAllPlayers(ListBox lBox, string teamType)
        {
            foreach (string name in lBox.Items)
            {
                Controller.RemoveSelectedPlayer(teamType, ParseName(name));
            }

            lBox.Items.Clear();
        }

        /*****************************************************/

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

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);

                e.Graphics.DrawString(lBox.Items[e.Index].ToString(), e.Font, SystemBrushes.HighlightText, e.Bounds, format);
            }
            else
            {
                e.Graphics.DrawString(lBox.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds, format);
            }
        }

        /*****************************************************/

        private void btnScoreboard_Click(object sender, EventArgs e)
        {
            string json = JsonSerializer.Serialize(Controller.GetMaster());
            MessageBox.Show(json);

            var wpfWindow = new frmScoreCard.MainWindow(json);

            wpfWindow.Show();
        }
    }
}
