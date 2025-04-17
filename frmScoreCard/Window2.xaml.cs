using System;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

using frmScoreCard.Data;

namespace frmScoreCard
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Master stats;

        public Window2()
        {
            InitializeComponent();

            stats = Controller.GetMaster();

            //HandType.Hand = false;
            //HandType.Instance.Hand = true;

            scoreCardTitle();
            venueTable();
            benchTable();
            hitterTable();
        }

        private void scoreCardTitle()                                            // Title for the ScoreCard
        {                       
            Blob.Text = "St. Louis Cardinals";            
        }

        private void venueTable()                                                // Data for Venue Table
        {
            VenueName.Text = "Busch Stadium";
            GameDate.Text = "1/10/2025";

            // Loop through each child of the main VenueGrid (skipping first row)
            for (int i = 1; i < VenueGrid.Children.Count; i++)   
            {
                // Each child is a Grid.Row placed in a Grid
                if (VenueGrid.Children[i] is Grid rowGrid)
                {
                    for (int j = 0; j < rowGrid.Children.Count; j++)
                    {
                        if (rowGrid.Children[j] is Grid columnGrid)
                        {
                            // Loop through the children of that column Grid
                            foreach (var element in columnGrid.Children)
                            {
                                // Look for the Viewbox inside
                                if (element is Viewbox viewbox)
                                {
                                    // Inside the Viewbox is the actual TextBlock
                                    if (viewbox.Child is TextBlock textBlock)
                                    {
                                        // Assign stats here
                                        textBlock.Text = "XX";
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void benchTable()                                                // Data for Bench Table
        {
            // XX is a team name(title)
            BenchName.Text = "XX BENCH";

            for (int i = 1; i < BenchGrid.Children.Count; i++)
            {
                if (BenchGrid.Children[i] is Grid rowGrid)
                {
                    for (int j = 0; j < rowGrid.Children.Count; j++)
                    {
                        if (rowGrid.Children[j] is Grid columnGrid)
                        {
                            foreach (var element in columnGrid.Children)
                            {                               
                                if (element is Viewbox viewbox)
                                {                                   
                                    if (viewbox.Child is TextBlock textBlock)
                                    {
                                        //Assign stats here
                                        textBlock.Text = "XX";
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void hitterTable()
        {
            if (stats?.homeTeamSelectedPlayers == null || stats.homeTeamSelectedPlayers.Count == 0)
                return;

            var players = stats.homeTeamSelectedPlayers.Values.ToList();
            int idx = 0;

            for (int i = 1; i < HitterGrid.Children.Count; i++)
            {
                if (idx >= players.Count)
                    return;

                MessageBox.Show(players[idx].name);
                MessageBox.Show(players[idx].position);

                if (HitterGrid.Children[i] is Grid rowGrid)
                {
                    if (rowGrid.Children[0] is Grid columnGrid1 && columnGrid1.Children[0] is Viewbox viewbox
                        && viewbox.Child is TextBlock textBlock)
                    {
                        if (players[idx]?.sides?.people?[0]?.pitchHand?.description == "Left")
                            textBlock.Foreground = System.Windows.Media.Brushes.Red;
                        else if (players[idx]?.sides?.people?[0]?.pitchHand?.description == "Right")
                            textBlock.Foreground = System.Windows.Media.Brushes.Blue;
                        else
                            textBlock.Foreground = System.Windows.Media.Brushes.Black;

                        textBlock.Text = players[idx].name;
                    }

                    if (rowGrid.Children[1] is Grid columnGrid2 && columnGrid2.Children[0] is Viewbox viewbox2
                        && viewbox2.Child is TextBlock textBlock2)
                    {
                            textBlock2.Text = players[idx].position;
                    }
                }

                idx++;
            }
             
        }
    }
}
