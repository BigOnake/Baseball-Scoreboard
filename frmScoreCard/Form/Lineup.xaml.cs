﻿using System;
using System.IO;
using System.IO.Packaging;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Threading;
using frmScoreCard.Data;
using System.Windows.Documents;
using System.Windows.Shapes;

namespace frmScoreCard.Form
{
    /// <summary>
    /// Interaction logic for Lineup.xaml
    /// </summary>
    public partial class Lineup : Window
    {
        private DispatcherTimer timer;

        public Lineup()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            btnScoreCard.Visibility = Visibility.Visible;
            btnScoreCardGuest.Visibility = Visibility.Visible;
        }

        private void Lineup_Loaded(object sender, RoutedEventArgs e)
        {
            lblDate.Content = DateTime.Now.ToString("MM/dd/yyyy");

            Controller.SetTeams();
            Teams team = Controller.GetTeams();

            if (team?.teams != null)
            {
                team.teams.Sort();

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
            if (cBoxHomeTeams.SelectedIndex != -1)
            {
                RemoveAllPlayers(lBoxHomePlayers, "home");

                Controller.SetGamePk(Controller.GetTeamId(cBoxHomeTeams.SelectedItem.ToString()));
                if (Controller.GetGamePk() == -1)
                {
                    MessageBox.Show("No games today.", "ERROR");
                    return;
                }

                AddRoster(cBoxHomeTeams, cBoxHomePlayers, "home");
                AddRoster(cBoxHomeTeams, cBoxHomeBullpen, "home");
                AddRoster(cBoxHomeTeams, cBoxHomeBench, "home");

                AddUmpires();
            }
        }

        private void cBoxGuestTeams_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (cBoxGuestTeams.SelectedIndex != -1)
            {
                RemoveAllPlayers(lBoxGuestPlayers, "guest");

                Controller.SetGamePk(Controller.GetTeamId(cBoxGuestTeams.SelectedItem.ToString()));
                if (Controller.GetGamePk() == -1)
                {
                    MessageBox.Show("No games today.", "ERROR");
                    return;
                }

                AddRoster(cBoxGuestTeams, cBoxGuestPlayers, "guest");
                AddRoster(cBoxGuestTeams, cBoxGuestBullpen, "guest");
                AddRoster(cBoxGuestTeams, cBoxGuestBench, "guest");

                AddUmpires();
            }
        }

        private async void AddRoster(ComboBox source, ComboBox destination, string teamType)
        {
            if (source?.SelectedItem != null)
            {
                Controller.SetGamePk(Controller.GetTeamId(source.SelectedItem.ToString()));
                Controller.SetRoster(Controller.GetTeamId(source.SelectedItem.ToString()), teamType);
                Controller.SetTeamName(source.SelectedItem.ToString(), teamType);
                await Controller.SetLiveData(Controller.GetGamePk());
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
            //Removed else clause with: MessageBox.Show("Error - Invalid Team Selection.", "ERROR");
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

        private void lBoxUmpires_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListBox lBox)
            {
                lBox.SelectedIndex = -1;
            }
        }

        /*****************************************************/

        private void cBoxHomePlayers_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (Controller.GetMaster().homeTeamSelectedPlayers.Count != 10)
            {
                if (timer.IsEnabled)
                {
                    timer.Stop();
                    timer.Start();
                }
                else
                {
                    timer.Start();

                }

                btnScoreCard.Visibility = Visibility.Hidden;
                btnScoreCardGuest.Visibility = Visibility.Hidden;

                AddPlayer(cBoxHomePlayers, "home");
            }
        }

        private void cBoxHomeBullpen_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled)
            {
                timer.Stop();
                timer.Start();
            }
            else
            {
                timer.Start();

            }
            btnScoreCard.Visibility = Visibility.Hidden;
            btnScoreCardGuest.Visibility = Visibility.Hidden;

            AddBullpenPlayer(cBoxHomeBullpen, "home");
        }

        private void cBoxHomeBench_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled)
            {
                timer.Stop();
                timer.Start();
            }
            else
            {
                timer.Start();

            }
            btnScoreCard.Visibility = Visibility.Hidden;
            btnScoreCardGuest.Visibility = Visibility.Hidden;

            AddBenchPlayer(cBoxHomeBench, "home");
        }

        private void cBoxGuestPlayers_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (Controller.GetMaster().guestTeamSelectedPlayers.Count != 10)
            {
                if (timer.IsEnabled)
                {
                    timer.Stop();
                    timer.Start();
                }
                else
                {
                    timer.Start();

                }
                btnScoreCard.Visibility = Visibility.Hidden;
                btnScoreCardGuest.Visibility = Visibility.Hidden;

                AddPlayer(cBoxGuestPlayers, "guest");
            }
        }

        private void cBoxGuestBullpen_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled)
            {
                timer.Stop();
                timer.Start();
            }
            else
            {
                timer.Start();

            }
            btnScoreCard.Visibility = Visibility.Hidden;
            btnScoreCardGuest.Visibility = Visibility.Hidden;

            AddBullpenPlayer(cBoxGuestBullpen, "guest");
        }

        private void cBoxGuestBench_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled)
            {
                timer.Stop();
                timer.Start();
            }
            else
            {
                timer.Start();

            }
            btnScoreCard.Visibility = Visibility.Hidden;
            btnScoreCardGuest.Visibility = Visibility.Hidden;

            AddBenchPlayer(cBoxGuestBench, "guest");
        }

        /*****************************************************/

        private void AddBenchPlayer(ComboBox source, string teamType)
        {
            if (source?.SelectedItem != null)
            {
                if (teamType == "home")
                {
                    if (!lBoxHomeTeamBench.Items.Contains(source.SelectedItem.ToString()))
                    {
                        lBoxHomeTeamBench.Items.Add(source.SelectedItem.ToString());
                        Controller.AddBenchPlayer("home", ParseName(source.SelectedItem.ToString()));
                    }
                }
                else
                {
                    if (!lBoxGuestTeamBench.Items.Contains(source.SelectedItem.ToString()))
                    {
                        lBoxGuestTeamBench.Items.Add(source.SelectedItem.ToString());
                        Controller.AddBenchPlayer("guest", ParseName(source.SelectedItem.ToString()));
                    }
                }
            }
        }

        private void AddBullpenPlayer(ComboBox source, string teamType)
        {
            if (source?.SelectedItem != null)
            {
                if (teamType == "home")
                {
                    if (!lBoxHomeTeamBullpen.Items.Contains(source.SelectedItem.ToString()))
                    {
                        lBoxHomeTeamBullpen.Items.Add(source.SelectedItem.ToString());
                        Controller.AddBullpenPlayer("home", ParseName(source.SelectedItem.ToString()));
                    }
                }
                else
                {
                    if (!lBoxGuestTeamBullpen.Items.Contains(source.SelectedItem.ToString()))
                    {
                        lBoxGuestTeamBullpen.Items.Add(source.SelectedItem.ToString());
                        Controller.AddBullpenPlayer("guest", ParseName(source.SelectedItem.ToString()));
                    }
                }
            }
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
            return name.Substring(0, name.LastIndexOf("-")).TrimEnd();
        }

        /*****************************************************/

        private void btnHomePlayersRemove_Click(object sender, RoutedEventArgs e)
        {
            RemovePlayer(lBoxHomePlayers, "home");
        }

        private void btnHomeBullpenRemove_Click(object sender, RoutedEventArgs e)
        {
            RemoveBullpenPlayer(lBoxHomeTeamBullpen, "home");
        }
        
        private void btnHomeBenchRemove_Click(object sender, RoutedEventArgs e)
        {
            RemoveBenchPlayer(lBoxHomeTeamBench, "home");
        }

        private void btnGuestPlayersRemove_Click(object sender, RoutedEventArgs e)
        {
            RemovePlayer(lBoxGuestPlayers, "guest");
        }

        private void btnGuestBullpenRemove_Click(object sender, RoutedEventArgs e)
        {
            RemoveBullpenPlayer(lBoxGuestTeamBullpen, "guest");
        }

        private void btnGuestBenchRemove_Click(object sender, RoutedEventArgs e)
        {
            RemoveBenchPlayer(lBoxGuestTeamBench, "guest");
        }

        private void RemoveBullpenPlayer(ListBox lBox, string teamType)
        {
            if (lBox.SelectedIndex != -1)
            {
                Controller.RemoveSelectedBullpenPlayer(teamType, ParseName(lBox.SelectedItem.ToString()));

                lBox.Items.RemoveAt(lBox.SelectedIndex);
            }
        }

        private void RemoveBenchPlayer(ListBox lBox, string teamType)
        {
            if (lBox.SelectedIndex != -1)
            {
                Controller.RemoveSelectedBenchPlayer(teamType, ParseName(lBox.SelectedItem.ToString()));

                lBox.Items.RemoveAt(lBox.SelectedIndex);
            }
        }

        private void RemovePlayer(ListBox lBox, string teamType)
        {
            if (lBox.SelectedIndex != -1)
            {
                Controller.RemoveSelectedPlayer(teamType, ParseName(lBox.SelectedItem.ToString()));

                lBox.Items.RemoveAt(lBox.SelectedIndex);
            }
        }

        /*****************************************************/

        private void OnKeyDownHomePlayer(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                RemovePlayer(lBoxHomePlayers, "home");
            }
        }

        private void OnKeyDownHomeBullpen(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                RemoveBullpenPlayer(lBoxHomeTeamBullpen, "home");
            }
        }

        private void OnKeyDownHomeBench(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                RemoveBenchPlayer(lBoxHomeTeamBench, "home");
            }
        }

        private void OnKeyDownGuestPlayer(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                RemovePlayer(lBoxGuestPlayers, "guest");
            }
        }

        private void OnKeyDownGuestBullpen(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                RemoveBullpenPlayer(lBoxGuestTeamBullpen, "guest");
            }
        }

        private void OnKeyDownGuestBench(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                RemoveBenchPlayer(lBoxGuestTeamBench, "guest");
            }
        }

        /*****************************************************/

        private void btnHomePlayersClear_Click(object sender, RoutedEventArgs e)
        {
            RemoveAllPlayers(lBoxHomePlayers, "home");
        }

        private void btnHomeBullpenClear_Click(object sender, RoutedEventArgs e)
        {
            RemoveAllBullpenPlayers(lBoxHomeTeamBullpen, "home");
        }

        private void btnHomeBenchClear_Click(object sender, RoutedEventArgs e)
        {
            RemoveAllBenchPlayers(lBoxHomeTeamBench, "home");
        }

        private void btnGuestPlayersClear_Click(object sender, RoutedEventArgs e)
        {
            RemoveAllPlayers(lBoxGuestPlayers, "guest");
        }

        private void btnGuestBullpenClear_Click(object sender, RoutedEventArgs e)
        {
            RemoveAllBullpenPlayers(lBoxGuestTeamBullpen, "guest");
        }

        private void btnGuestBenchClear_Click(object sender, RoutedEventArgs e)
        {
            RemoveAllBenchPlayers(lBoxGuestTeamBench, "guest");
        }

        private void RemoveAllBullpenPlayers(ListBox lBox, string teamType)
        {
            foreach (string name in lBox.Items)
            {
                Controller.RemoveSelectedBullpenPlayer(teamType, ParseName(name));
            }

            lBox.Items.Clear();
        }

        private void RemoveAllBenchPlayers(ListBox lBox, string teamType)
        {
            foreach (string name in lBox.Items)
            {
                Controller.RemoveSelectedBenchPlayer(teamType, ParseName(name));
            }

            lBox.Items.Clear();
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

            //MessageBox.Show(JsonSerializer.Serialize(Controller.GetMaster().homeTeamBench));  
            //MessageBox.Show(JsonSerializer.Serialize(Controller.GetMaster().homeTeamBullpen));  

            //MessageBox.Show(JsonSerializer.Serialize(Controller.GetMaster().homeTeamCoaches));  

            //MessageBox.Show(JsonSerializer.Serialize(Controller.GetMaster().guestTeamBench));  
            //MessageBox.Show(JsonSerializer.Serialize(Controller.GetMaster().guestTeamBullpen));  

            //PrintDialog printDialog = new PrintDialog();
            //if (printDialog.ShowDialog() == true)
            //{
            //    printDialog.PrintVisual(this, "what");
            //}

            var scorecard = new Scorecard();
            scorecard.Show();
        }

        private void btnScorecardGuest_Click(object sender, RoutedEventArgs e)
        {
            var scorecard = new ScorecardGuest();
            
            scorecard.Show();
        }

    }
}
