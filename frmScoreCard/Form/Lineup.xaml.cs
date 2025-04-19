using System;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using frmScoreCard.Data;

namespace frmScoreCard.Form
{
    /// <summary>
    /// Interaction logic for Lineup.xaml
    /// </summary>
    public partial class Lineup : Window
    {
        public Lineup()
        {
            InitializeComponent();
        }

        private void Lineup_Loaded(object sender, RoutedEventArgs e)
        {
            lblDate.Content = DateTime.Now.ToString("MM/dd/yyyy");

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

        private void cBoxHomeTeams_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            RemoveAllPlayers(lBoxHomePlayers, "home");

            AddRoster(cBoxHomeTeams, cBoxHomePlayers, "home");

            AddUmpires();
        }

        private void cBoxGuestTeams_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            RemoveAllPlayers(lBoxGuestPlayers, "guest");

            AddRoster(cBoxGuestTeams, cBoxGuestPlayers, "guest");

            AddUmpires();
        }

        private async void AddRoster(ComboBox source, ComboBox destination, string teamType)
        {
            if (source?.SelectedItem != null)
            {
                Controller.SetRoster(Controller.GetTeamId(source.SelectedItem.ToString()), teamType);
                Controller.SetGamePk(Controller.GetTeamId(source.SelectedItem.ToString()));
                Controller.SetTeamName(source.SelectedItem.ToString(), teamType);
                if (Controller.GetGamePk() == -1)
                {
                    MessageBox.Show("No games today.", "ERROR");
                    return;
                }

                MessageBox.Show(Controller.GetGamePk().ToString());
                await Controller.SetLiveData(Controller.GetGamePk());
                Controller.AddBenchPlayers(teamType, Controller.FetchLiveData());
                Controller.AddBullpenPlayers(teamType, Controller.FetchLiveData());
                Controller.SetSB(teamType, Controller.GetTeamId(source.SelectedItem.ToString()));
                Controller.SetVenues(Controller.GetGamePk());
                Controller.SetStadiumData();
                Controller.SetCoaches(teamType, Controller.GetTeamId(source.SelectedItem.ToString()));

                destination.Items.Clear();

                foreach (PlayerInfo pi in Controller.GetRoster(teamType).roster)
                {
                    destination.Items.Add(pi);
                }
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

        private void cBoxHomePlayers_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (Controller.GetMaster().homeTeamSelectedPlayers.Count != 9)
                AddPlayer(cBoxHomePlayers, "home");
        }

        private void cBoxGuestPlayers_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (Controller.GetMaster().guestTeamSelectedPlayers.Count != 9)
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

        private void btnHomePlayersRemove_Click(object sender, RoutedEventArgs e)
        {
            RemovePlayer(lBoxHomePlayers, "home");
        }

        private void btnGuestPlayersRemove_Click(object sender, RoutedEventArgs e)
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

        private void btnHomePlayersClear_Click(object sender, RoutedEventArgs e)
        {
            RemoveAllPlayers(lBoxHomePlayers, "home");
        }

        private void btnGuestPlayersClear_Click(object sender, RoutedEventArgs e)
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

        private void btnScorecard_Click(object sender, RoutedEventArgs e)
        {
            //string json = JsonSerializer.Serialize(Controller.GetMaster());
            //MessageBox.Show(json);

            MessageBox.Show(JsonSerializer.Serialize(Controller.GetMaster().homeTeamBench));
            MessageBox.Show(JsonSerializer.Serialize(Controller.GetMaster().homeTeamBullpen));

            MessageBox.Show(JsonSerializer.Serialize(Controller.GetMaster().guestTeamBench));
            MessageBox.Show(JsonSerializer.Serialize(Controller.GetMaster().guestTeamBullpen));

            //var wpfWindow = new frmScoreCard.MainWindow(json);

            var wpfWindow2 = new frmScoreCard.Window2();
            wpfWindow2.Show();
        }
    }
}
