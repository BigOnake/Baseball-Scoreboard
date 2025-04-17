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
                    // 1stP
                    if (players[idx]?.fp?.splits != null && players[idx].fp.splits.Count > 0)
                    {
                        if (rowGrid2.Children[0] is Grid columnGrid1stP)
                        {
                            if (columnGrid1stP.Children[1] is Grid columnGrid4 && columnGrid4.Children[0] is Viewbox viewbox3
                                && viewbox3.Child is TextBlock textBlock3)
                            {
                                textBlock3.Text = players[idx].fp.splits[0].stats?.hitting?.tracking?.hitProbability?.averageValue.ToString();                 
                            }
                            if (columnGrid1stP.Children[2] is Grid columnGrid5 && columnGrid5.Children[0] is Viewbox viewbox4
                                && viewbox4.Child is TextBlock textBlock4)
                            {
                                textBlock4.Text = players[idx].fp.splits[0].stats?.hitting?.standard?.avg;
                            }
                            if (columnGrid1stP.Children[3] is Grid columnGrid6 && columnGrid6.Children[0] is Viewbox viewbox5
                                && viewbox5.Child is TextBlock textBlock5)
                            {
                                textBlock5.Text = players[idx].fp.splits[0].stats?.hitting?.standard?.ops;
                            }
                        }
                    }

                    // RISP
                    if (players[idx]?.risp?.splits != null && players[idx].risp.splits.Count > 0)
                    {
                        if (rowGrid2.Children[1] is Grid columnGridRISP)
                        {
                            if (columnGridRISP.Children[1] is Grid columnGrid4 && columnGrid4.Children[0] is Viewbox viewbox3
                                && viewbox3.Child is TextBlock textBlock3)
                            {
                                textBlock3.Text = $"{players[idx].risp.splits[0].stats?.hitting?.standard?.hits}-" +
                                    $"{players[idx].risp.splits[0].stats?.hitting?.standard?.atBats}";
                            }
                            if (columnGridRISP.Children[2] is Grid columnGrid5 && columnGrid5.Children[0] is Viewbox viewbox4
                                && viewbox4.Child is TextBlock textBlock4)
                            {
                                textBlock4.Text = players[idx].risp.splits[0].stats?.hitting?.standard?.avg;
                            }
                            if (columnGridRISP.Children[3] is Grid columnGrid6 && columnGrid6.Children[0] is Viewbox viewbox5
                                && viewbox5.Child is TextBlock textBlock5)
                            {
                                textBlock5.Text = players[idx].risp.splits[0].stats?.hitting?.standard?.homeRuns.ToString();
                            }
                        }
                    }

                    // RISP2o
                    if (players[idx]?.risp2o?.splits != null && players[idx].risp2o.splits.Count > 0)
                    {
                        if (rowGrid2.Children[2] is Grid columnGridRISP2o)
                        {
                            if (columnGridRISP2o.Children[1] is Grid columnGrid4 && columnGrid4.Children[0] is Viewbox viewbox3
                                && viewbox3.Child is TextBlock textBlock3)
                            {
                                textBlock3.Text = $"{players[idx].risp2o.splits[0].stats?.hitting?.standard?.hits}-" +
                                    $"{players[idx].risp2o.splits[0].stats?.hitting?.standard?.atBats}";
                            }
                            if (columnGridRISP2o.Children[2] is Grid columnGrid5 && columnGrid5.Children[0] is Viewbox viewbox4
                                && viewbox4.Child is TextBlock textBlock4)
                            {
                                textBlock4.Text = players[idx].risp2o.splits[0].stats?.hitting?.standard?.avg;
                            }
                            if (columnGridRISP2o.Children[3] is Grid columnGrid6 && columnGrid6.Children[0] is Viewbox viewbox5
                                && viewbox5.Child is TextBlock textBlock5)
                            {
                                textBlock5.Text = players[idx].risp2o.splits[0].stats?.hitting?.standard?.homeRuns.ToString();
                            }
                        }
                    }

                    // vsLH
                    if (players[idx]?.vsLeft?.splits != null && players[idx].vsLeft.splits.Count > 0)
                    {
                        if (rowGrid2.Children[3] is Grid columnGridvsLH)
                        {
                            if (columnGridvsLH.Children[1] is Grid columnGrid4 && columnGrid4.Children[0] is Viewbox viewbox3
                                && viewbox3.Child is TextBlock textBlock3)
                            {
                                textBlock3.Text = $"{players[idx].vsLeft.splits[0].stats?.hitting?.standard?.hits}-" +
                                    $"{players[idx].vsLeft.splits[0].stats?.hitting?.standard?.atBats}";
                            }
                            if (columnGridvsLH.Children[2] is Grid columnGrid5 && columnGrid5.Children[0] is Viewbox viewbox4
                                && viewbox4.Child is TextBlock textBlock4)
                            {
                                textBlock4.Text = players[idx].vsLeft.splits[0].stats?.hitting?.standard?.homeRuns.ToString();
                            }
                            if (columnGridvsLH.Children[3] is Grid columnGrid6 && columnGrid6.Children[0] is Viewbox viewbox5
                                && viewbox5.Child is TextBlock textBlock5)
                            {
                                textBlock5.Text = players[idx].vsLeft.splits[0].stats?.hitting?.standard?.avg;
                            }
                            if (columnGridvsLH.Children[4] is Grid columnGrid7 && columnGrid7.Children[0] is Viewbox viewbox6
                                && viewbox6.Child is TextBlock textBlock6)
                            {
                                textBlock6.Text = players[idx].vsLeft.splits[0].stats?.hitting?.standard?.ops;
                            }
                        }
                    }

                    // vsRH
                    if (players[idx]?.vsRight?.splits != null && players[idx].vsRight.splits.Count > 0)
                    {
                        if (rowGrid2.Children[4] is Grid columnGridvsRH)
                        {
                            if (columnGridvsRH.Children[1] is Grid columnGrid4 && columnGrid4.Children[0] is Viewbox viewbox3
                                && viewbox3.Child is TextBlock textBlock3)
                            {
                                textBlock3.Text = $"{players[idx].vsRight.splits[0].stats?.hitting?.standard?.hits}-" +
                                    $"{players[idx].vsRight.splits[0].stats?.hitting?.standard?.atBats}";
                            }
                            if (columnGridvsRH.Children[2] is Grid columnGrid5 && columnGrid5.Children[0] is Viewbox viewbox4
                                && viewbox4.Child is TextBlock textBlock4)
                            {
                                textBlock4.Text = players[idx].vsRight.splits[0].stats?.hitting?.standard?.homeRuns.ToString();
                            }
                            if (columnGridvsRH.Children[3] is Grid columnGrid6 && columnGrid6.Children[0] is Viewbox viewbox5
                                && viewbox5.Child is TextBlock textBlock5)
                            {
                                textBlock5.Text = players[idx].vsRight.splits[0].stats?.hitting?.standard?.avg;
                            }
                            if (columnGridvsRH.Children[4] is Grid columnGrid7 && columnGrid7.Children[0] is Viewbox viewbox6
                                && viewbox6.Child is TextBlock textBlock6)
                            {
                                textBlock6.Text = players[idx].vsRight.splits[0].stats?.hitting?.standard?.ops;
                            }
                        }
                    }

                    // 7+
                    if (players[idx]?.plus7?.splits != null && players[idx].plus7.splits.Count > 0)
                    {
                        if (rowGrid2.Children[5] is Grid columnGridvs7Plus)
                        {
                            if (columnGridvs7Plus.Children[1] is Grid columnGrid4 && columnGrid4.Children[0] is Viewbox viewbox3
                                && viewbox3.Child is TextBlock textBlock3)
                            {
                                textBlock3.Text = players[idx].plus7.splits[0].stats?.hitting?.standard?.avg;
                            }
                            if (columnGridvs7Plus.Children[2] is Grid columnGrid5 && columnGrid5.Children[0] is Viewbox viewbox4
                                && viewbox4.Child is TextBlock textBlock4)
                            {
                                textBlock4.Text = players[idx].plus7.splits[0].stats?.hitting?.standard?.ops;
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
