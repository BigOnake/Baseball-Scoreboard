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

            MessageBox.Show(players.Count.ToString());

            // 1,3,5,7,9,11,13,15,17. (hidden 9 player check is here)
            for (int i = 1; i < HitterGrid.Children.Count; i += 2)
            {
                // 2,4,6,8,10,12,14,16,18
                int j = i + 1;

                if (idx >= players.Count)
                    return;

                //MessageBox.Show(players[idx].name);
                //MessageBox.Show(players[idx].position);

                //Player Names and Positions
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

                // 1stP, RISP, RISP2o, vsLH, vsRH, 7+.
                if (HitterGrid.Children[j] is Grid rowGrid2)
                {
                    // Why k is 0? Because 0 is not the first column, it is the first DEFINED column 
                    for (int k = 0; k < rowGrid2.Children.Count; k++)
                    {
                        if (rowGrid2.Children[k] is Grid columnGrid3)
                        {
                            for (int y = 1; y < columnGrid3.Children.Count; y++)
                            {
                                if (columnGrid3.Children[y] is Grid columnGrid4 && columnGrid4.Children[0] is Viewbox viewbox3
                                    && viewbox3.Child is TextBlock textBlock3)
                                {
                                    textBlock3.Text = "a";
                                }    
                            }
                        }
                    }
                }
                
                idx++;
            }
             
        }

        /*
        private void hitterTable()
        {         
            // Loop to populate player names and positions, skipping first row
            for (int i = 1; i < HitterGrid.Children.Count; i++)
            {
                // Each child is a row 
                if (HitterGrid.Children[i] is Grid rowGrid)
                {
                    // Loop through the rows 1,3,5,7,9,11,13,15,17  in HitterGrid
                    for (int j = 0; j < rowGrid.Children.Count; j += 2)
                    {
                        // First child(column 1), Player Name
                        if (rowGrid.Children[0] is Grid columnGrid1)
                        {
                            // Change the first child(Viewbox->Textblock) in column 1 and 2.
                            // Border is a second child therefore index is only set to 0.
                            if (columnGrid1.Children[0] is Viewbox viewbox)
                            {
                                if (viewbox.Child is TextBlock textBlock)
                                {
                                    textBlock.Text = "X-PLAYER NAME";                                // Player Names and Numbers
                                }
                            }
                        }

                        // Second child(column 2), Player Position
                        if (rowGrid.Children[1] is Grid columnGrid2)
                        {
                            // Change the first child(Viewbox->Textblock) in column 1 and 2.
                            // Border is a second child therefore index is only set to 0.
                            if (columnGrid2.Children[0] is Viewbox viewbox)
                            {
                                if (viewbox.Child is TextBlock textBlock)
                                {
                                    textBlock.Text = "X";                                            // Player Positions
                                }
                            }
                        }


                    }
                }
            }
             
        }

        */
    }
}
