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

            scoreCardTitle();
            venueTable();
            benchTable();
            hitterTable();
            umpsTeamsSBTable();

            // Umpire Obj; cout << obj prints Umpire Type
        }

        private void scoreCardTitle()                                            // Title for the ScoreCard
        {                       
            Blob.Text = stats.homeTeamName;            
        }

        private void venueTable()                                                // Data for Venue Table
        {
            if (stats.venue != null && stats.venue.dates != null)
            { 
                VenueName.Text = stats.venue.dates[0].games[0].venue.name;
                GameDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            }

            int idx = 0;

            // Loop through each child of the main VenueGrid (skipping first row)
            for (int i = 1; i < VenueGrid.Children.Count; i++)   
            {
                // Null check for standard and tracking is added too, because 
                // some stadium have null values in those for some reason. Just to be safe.
                if (stats.stadium != null && stats.stadium.splits != null && stats.stadium.splits.Count() > 0  
                    && stats.stadium.splits[idx].stats.pitching.standard != null 
                    && stats.stadium.splits[idx].stats.pitching.tracking != null)
                { 
                    // Pitch Type
                    if (VenueGrid.Children[i] is Grid rowGrid1 && rowGrid1.Children[0] is Grid columnGridPT
                        && columnGridPT.Children[0] is Viewbox viewboxPT && viewboxPT.Child is TextBlock textblockPT)
                    {
                        textblockPT.Text = stats.stadium.splits[idx].pitchType.code.ToString();
                    }

                    // Velocity
                    if (VenueGrid.Children[i] is Grid rowGrid2 && rowGrid2.Children[2] is Grid columnGrid
                        && columnGrid.Children[0] is Viewbox viewbox && viewbox.Child is TextBlock textblock)
                    {
                        textblock.Text = stats.stadium.splits[idx].stats.pitching.tracking.releaseSpeed.averageValue.ToString();
                    }

                    // Batting avg
                    if (VenueGrid.Children[i] is Grid rowGrid3 && rowGrid3.Children[4] is Grid columnGridAvg
                        && columnGridAvg.Children[0] is Viewbox viewboxAvg && viewboxAvg.Child is TextBlock textblockAvg)
                    {
                        textblockAvg.Text = stats.stadium.splits[idx].stats.pitching.standard.avg.ToString();
                    }

                    // Ops
                    if (VenueGrid.Children[i] is Grid rowGrid4 && rowGrid4.Children[5] is Grid columnGridOps
                        && columnGridOps.Children[0] is Viewbox viewboxOps && viewboxOps.Child is TextBlock textblockOps)
                    {
                        textblockOps.Text = stats.stadium.splits[idx].stats.pitching.standard.ops.ToString();
                    }
                }

                idx++;
            }
        }

        private void benchTable()                                                // Data for Bench Table
        {           
            BenchName.Text = $"{stats.homeTeamName} Bench";

            int idx = 0;

            for (int i = 1; i < BenchGrid.Children.Count; i++)
            {
                if (BenchGrid.Children[i] is Grid rowGrid)
                {
                    if (rowGrid.Children[0] is Grid columnGridNum && columnGridNum.Children[0] is Viewbox viewboxNum
                        && viewboxNum.Child is TextBlock textBlockNum)
                    {
                        textBlockNum.Text = "0";
                    }

                    if (rowGrid.Children[1] is Grid columnGridName && columnGridName.Children[0] is Viewbox viewboxName
                        && viewboxName.Child is TextBlock textBlockName)
                    {
                        textBlockName.Text = "Player";
                    }

                    if (rowGrid.Children[2] is Grid columnGridAvg && columnGridAvg.Children[0] is Viewbox viewboxAvg
                        && viewboxAvg.Child is TextBlock textBlockAvg)
                    {
                        textBlockAvg.Text = "0";
                    }

                    if (rowGrid.Children[3] is Grid columnGridHR && columnGridHR.Children[0] is Viewbox viewboxHR
                        && viewboxHR.Child is TextBlock textBlockHR)
                    {
                        textBlockHR.Text = "0";
                    }

                    if (rowGrid.Children[4] is Grid columnGridRbi && columnGridRbi.Children[0] is Viewbox viewboxRbi
                        && viewboxRbi.Child is TextBlock textBlockRbi)
                    {
                        textBlockRbi.Text = "0";
                    }

                    if (rowGrid.Children[5] is Grid columnGridOps && columnGridOps.Children[0] is Viewbox viewboxOps
                        && viewboxOps.Child is TextBlock textBlockOps)
                    {
                        textBlockOps.Text = "0";
                    }
                }

                idx++;
            }
        }

        private void hitterTable()                                               // Data for Hitter Table
        {
            if (stats?.homeTeamSelectedPlayers == null || stats.homeTeamSelectedPlayers.Count == 0)
                return;

            var players = stats.homeTeamSelectedPlayers.Values.ToList();
            int idx = 0;

            MessageBox.Show(players.Count.ToString());

            // 1,3,5,7,9,11,13,15,17
            for (int i = 1; i < HitterGrid.Children.Count; i += 2)
            {
                // 2,4,6,8,10,12,14,16,18
                int j = i + 1;

                if (idx >= players.Count)
                    return;

                //MessageBox.Show(players[idx].name);
                //MessageBox.Show(players[idx].position);

                //Player Names, Positions & AVG, OPS, K, BB and etc.
                if (HitterGrid.Children[i] is Grid rowGrid)
                {
                    // Name 
                    if (rowGrid.Children[0] is Grid columnGrid1 && columnGrid1.Children[0] is Viewbox viewboxPlayer
                        && viewboxPlayer.Child is TextBlock textBlockPlayer)
                    {
                        if (players[idx]?.sides?.people?[0]?.pitchHand?.description == "Left")
                            textBlockPlayer.Foreground = System.Windows.Media.Brushes.Red;
                        else if (players[idx]?.sides?.people?[0]?.pitchHand?.description == "Right")
                            textBlockPlayer.Foreground = System.Windows.Media.Brushes.Blue;
                        else
                            textBlockPlayer.Foreground = System.Windows.Media.Brushes.Black;

                        textBlockPlayer.Text = players[idx].name;
                    }

                    // Position
                    if (rowGrid.Children[1] is Grid columnGrid2 && columnGrid2.Children[0] is Viewbox viewboxPos
                        && viewboxPos.Child is TextBlock textBlockPos)
                    {
                        textBlockPos.Text = players[idx].position;
                    }

                    // Stats
                    if (players[idx]?.hitterStats?.splits != null && players[idx].hitterStats.splits.Count > 0)
                    {

                        // AVG, OPS                   
                        if (rowGrid.Children[14] is Grid columnGrid3)
                        {
                            if (columnGrid3.Children[0] is Grid rowGridAvg && rowGridAvg.Children[0] is Viewbox viewboxAvg
                                && viewboxAvg.Child is TextBlock textBlockAvg)
                            {
                                textBlockAvg.Text = players[idx].hitterStats.splits[0].stats?.hitting?.standard?.avg;
                            }

                            if (columnGrid3.Children[1] is Grid rowGridOps && rowGridOps.Children[0] is Viewbox viewboxOps
                                && viewboxOps.Child is TextBlock textBlockOps)
                            {
                                textBlockOps.Text = players[idx].hitterStats.splits[0].stats?.hitting?.standard?.ops;
                            }
                        }

                        // K, BB
                        if (rowGrid.Children[15] is Grid columnGrid4)
                        {
                            if (columnGrid4.Children[0] is Grid rowGridK && rowGridK.Children[0] is Viewbox viewboxK
                                && viewboxK.Child is TextBlock textBlockK)
                            {
                                textBlockK.Text = players[idx].hitterStats.splits[0].stats?.hitting?.standard?.strikeOuts.ToString();
                            }

                            if (columnGrid4.Children[1] is Grid rowGridBB && rowGridBB.Children[0] is Viewbox viewboxBB
                                && viewboxBB.Child is TextBlock textBlockBB)
                            {
                                textBlockBB.Text = players[idx].hitterStats.splits[0].stats?.hitting?.standard?.baseOnBalls.ToString();
                            }
                        }

                        // 2B, 3B
                        if (rowGrid.Children[16] is Grid columnGrid5)
                        {
                            if (columnGrid5.Children[0] is Grid rowGrid2b && rowGrid2b.Children[0] is Viewbox viewbox2b
                                && viewbox2b.Child is TextBlock textBlock2b)
                            {
                                textBlock2b.Text = players[idx].hitterStats.splits[0].stats?.hitting?.standard?.doubles.ToString();
                            }

                            if (columnGrid5.Children[1] is Grid rowGrid3b && rowGrid3b.Children[0] is Viewbox viewbox3b
                                && viewbox3b.Child is TextBlock textBlock3b)
                            {
                                textBlock3b.Text = players[idx].hitterStats.splits[0].stats?.hitting?.standard?.triples.ToString();
                            }
                        }

                        // HR, RBI
                        if (rowGrid.Children[17] is Grid columnGrid6)
                        {
                            if (columnGrid6.Children[0] is Grid rowGridHr && rowGridHr.Children[0] is Viewbox viewboxHr
                                && viewboxHr.Child is TextBlock textBlockHr)
                            {
                                textBlockHr.Text = players[idx].hitterStats.splits[0].stats?.hitting?.standard?.homeRuns.ToString();
                            }

                            if (columnGrid6.Children[1] is Grid rowGridRbi && rowGridRbi.Children[0] is Viewbox viewboxRbi
                                && viewboxRbi.Child is TextBlock textBlockRbi)
                            {
                                textBlockRbi.Text = players[idx].hitterStats.splits[0].stats?.hitting?.standard?.rbi.ToString();
                            }
                        }

                        // Runs, BACON
                        if (rowGrid.Children[18] is Grid columnGrid7)
                        {
                            if (columnGrid7.Children[0] is Grid rowGridRuns && rowGridRuns.Children[0] is Viewbox viewboxRuns
                                && viewboxRuns.Child is TextBlock textBlockRuns)
                            {
                                textBlockRuns.Text = players[idx].hitterStats.splits[0].stats?.hitting?.standard?.runs.ToString();
                            }

                            if (columnGrid7.Children[1] is Grid rowGridBacon && rowGridBacon.Children[0] is Viewbox viewboxBacon
                                && viewboxBacon.Child is TextBlock textBlockBacon)
                            {
                                textBlockBacon.Text = players[idx].hitterStats.splits[0].stats?.hitting?.standard?.babip;
                            }
                        }

                        // SB-SBA, DP
                        if (rowGrid.Children[19] is Grid columnGrid8)
                        {
                            if (columnGrid8.Children[0] is Grid rowGridSb && rowGridSb.Children[0] is Viewbox viewboxSb
                                && viewboxSb.Child is TextBlock textBlockSb)
                            {
                                textBlockSb.Text = $"{players[idx].hitterStats.splits[0].stats?.hitting?.standard?.stolenBases}-" +
                                    $"{players[idx].hitterStats.splits[0].stats?.hitting?.standard?.caughtStealing}";
                            }

                            if (columnGrid8.Children[1] is Grid rowGridDp && rowGridDp.Children[0] is Viewbox viewboxDp
                                && viewboxDp.Child is TextBlock textBlockDp)
                            {
                                textBlockDp.Text = players[idx].hitterStats.splits[0].stats?.hitting?.standard?.groundIntoDoublePlay.ToString();
                            }
                        }

                    }
                }

                // 1stP, RISP, RISP2o, vsLH, vsRH, 7+.
                if (HitterGrid.Children[j] is Grid rowGrid2)
                {
                    // 1stP
                    if (players[idx]?.fp?.splits != null && players[idx].fp.splits.Count > 0)
                    {
                        if (rowGrid2.Children[1] is Grid columnGrid1stP)
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
                        if (rowGrid2.Children[2] is Grid columnGridRISP)
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
                        if (rowGrid2.Children[3] is Grid columnGridRISP2o)
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
                        if (rowGrid2.Children[4] is Grid columnGridvsLH)
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
                        if (rowGrid2.Children[5] is Grid columnGridvsRH)
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
                        if (rowGrid2.Children[6] is Grid columnGridvs7Plus)
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

        private void umpsTeamsSBTable()
        {
            // Populate Umpires
            if (stats.umps != null && stats.umps.officials != null && stats.umps.officials.Count > 0)
            {
                for (int i = 0; i < UmpireGrid.Children.Count; i++)
                {
                    if (UmpireGrid.Children[i] is Grid rowGrid && rowGrid.Children[0] is Grid columnGrid)
                    {
                        if (columnGrid.Children[0] is Grid columnGridUmpType && columnGridUmpType.Children[0] is Viewbox viewboxUmpType
                            && viewboxUmpType.Child is TextBlock textBlockUmpType)
                        {
                            textBlockUmpType.Text = stats.umps.officials[i].officialType;
                        }

                        if (columnGrid.Children[1] is Grid columnGridUmpName && columnGridUmpName.Children[0] is Viewbox viewboxUmpName
                            && viewboxUmpName.Child is TextBlock textBlockUmpName)
                        {
                            textBlockUmpName.Text = stats.umps.officials[i].official.fullName;
                        }
                    }
                }
            }

            // Populate SB-SBA, DP stats for Home Team
            if (stats.homeTeamSB != null && stats.homeTeamSB.splits != null && stats.homeTeamSB.splits.Count > 0)
            { 
                if (UmpireGrid.Children[0] is Grid rowGrid2 && rowGrid2.Children[14] is Grid columnGrid2)
                {
                    if (columnGrid2.Children[0] is Viewbox viewboxTeamStat
                        && viewboxTeamStat.Child is TextBlock textBlockTeamStat)
                    {
                        textBlockTeamStat.Text = $"{stats.homeTeamSB.splits[0].stats.hitting.standard.stolenBases}-" +
                            $"{stats.homeTeamSB.splits[0].stats.hitting.standard.caughtStealing}";
                    }                  
                }

                if (UmpireGrid.Children[1] is Grid rowGrid3 && rowGrid3.Children[14] is Grid columnGrid3)
                {
                    if (columnGrid3.Children[0] is Viewbox viewboxTeamStat
                        && viewboxTeamStat.Child is TextBlock textBlockTeamStat)
                    {
                        textBlockTeamStat.Text = stats.homeTeamSB.splits[0].stats.hitting.standard.groundIntoDoublePlay.ToString();
                    }
                }
            }

            // Populate SB-SBA, DP stats for Opponent Team
            if (stats.guestTeamSB != null && stats.guestTeamSB.splits != null && stats.guestTeamSB.splits.Count > 0)
            {
                if (UmpireGrid.Children[2] is Grid rowGrid4 && rowGrid4.Children[14] is Grid columnGrid4)
                {
                    if (columnGrid4.Children[0] is Viewbox viewboxTeamStat
                        && viewboxTeamStat.Child is TextBlock textBlockTeamStat)
                    {
                        textBlockTeamStat.Text = $"{stats.guestTeamSB.splits[0].stats.hitting.standard.stolenBases}-" +
                            $"{stats.guestTeamSB.splits[0].stats.hitting.standard.caughtStealing}";
                    }
                }

                if (UmpireGrid.Children[3] is Grid rowGrid5 && rowGrid5.Children[14] is Grid columnGrid5)
                {
                    if (columnGrid5.Children[0] is Viewbox viewboxTeamStat
                        && viewboxTeamStat.Child is TextBlock textBlockTeamStat)
                    {
                        textBlockTeamStat.Text = stats.guestTeamSB.splits[0].stats.hitting.standard.groundIntoDoublePlay.ToString();
                    }
                }
            }
        }

    }
}
