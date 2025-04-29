using System;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Serialization;
using frmScoreCard.Data;

namespace frmScoreCard.Form
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Scorecard : Window
    {
        public Master stats;

        public Scorecard()
        {            
            InitializeComponent();

            stats = Controller.GetMaster();
           
            scoreCardTitle();
            venueTable();
            benchTable();
            hitterTable();
            umpsTeamsSBTable();
            scoreTable();
            bullpenTable();
            coachTable();
            startingPitcher();
        }

        private void scoreCardTitle()
        {
            Blob.Text = stats?.homeTeamName ?? string.Empty;
        }

        // diamond(), not used yet. Will maybe use if decide to place
        // players into the field automatically.
        private void diamond()
        {
            for (int i = 0; i < FieldGrid.Children.Count; i++)
            {
                if (FieldGrid.Children[0] is Viewbox viewbox && viewbox.Child is Canvas canvas
                    && canvas.Children[i] is TextBox textbox)
                {
                    textbox.Text = "XX-Player Name";
                }
            }
        }

        private void venueTable()                                                
        {            
            int idx = 0;

            // Venue Name           
            VenueName.Text = stats?.venue?.dates?[0]?.games?[0]?.venue?.name ?? string.Empty;

            // Date
            GameDate.Text = DateTime.Now.ToString("MM/dd/yyyy");

            for (int i = 1; i < VenueGrid.Children.Count; i++)
            {
                // If there are no or not enough stats to fit the grid, the function will stop.
                if (stats?.stadium?.splits == null || idx >= stats.stadium.splits.Count)
                    return;
                
                // Pitch Type
                if (VenueGrid.Children[i] is Grid rowGrid1 && rowGrid1.Children[0] is Grid columnGridPT
                    && columnGridPT.Children[0] is Viewbox viewboxPT && viewboxPT.Child is TextBlock textblockPT)
                {
                    textblockPT.Text = stats?.stadium?.splits?[idx]?.pitchType?.code?.ToString() ?? string.Empty;
                }

                // Velocity
                if (VenueGrid.Children[i] is Grid rowGrid2 && rowGrid2.Children[2] is Grid columnGrid
                    && columnGrid.Children[0] is Viewbox viewbox && viewbox.Child is TextBlock textblock)
                {
                    textblock.Text = stats?.stadium?.splits?[idx]?.stats?.pitching?.tracking?.releaseSpeed?.averageValue?.ToString() ?? string.Empty;
                }

                // Batting avg
                if (VenueGrid.Children[i] is Grid rowGrid3 && rowGrid3.Children[4] is Grid columnGridAvg
                    && columnGridAvg.Children[0] is Viewbox viewboxAvg && viewboxAvg.Child is TextBlock textblockAvg)
                {
                    textblockAvg.Text = stats?.stadium?.splits?[idx]?.stats?.pitching?.standard?.avg ?? string.Empty;
                }

                // Ops
                if (VenueGrid.Children[i] is Grid rowGrid4 && rowGrid4.Children[5] is Grid columnGridOps
                    && columnGridOps.Children[0] is Viewbox viewboxOps && viewboxOps.Child is TextBlock textblockOps)
                {
                    textblockOps.Text = stats?.stadium?.splits?[idx]?.stats?.pitching?.standard?.ops ?? string.Empty;
                }
                    
                idx++;
            }
        }

        private void benchTable()                                                
        {           
            var benchPlayers = stats?.homeTeamBench?.Values.Cast<BenchStats>().ToList();
            int idx = 0;

            BenchName.Text = $"{stats?.homeTeamName ?? string.Empty} Bench";

            for (int i = 1; i < BenchGrid.Children.Count; i++)
            {
                // Function stops if bench players are null or less than could fit the grid.
                if (benchPlayers == null || idx >= benchPlayers.Count)
                    return;

                if (BenchGrid.Children[i] is Grid rowGrid)
                {
                    // Jersey Number
                    if (rowGrid.Children[0] is Grid columnGridNum && columnGridNum.Children[0] is Viewbox viewboxNum
                        && viewboxNum.Child is TextBlock textBlockNum)
                    {
                        textBlockNum.Text = benchPlayers[idx].jerseyNumber ?? string.Empty;
                    }

                    // Name
                    if (rowGrid.Children[1] is Grid columnGridName && columnGridName.Children[0] is Viewbox viewboxName 
                        && viewboxName.Child is TextBlock textBlockName)
                    {     
                       
                        if (benchPlayers[idx].sides?.people?[0]?.batSide?.description == "Left")
                        {
                            textBlockName.Foreground = System.Windows.Media.Brushes.Red;
                        }
                        else if (benchPlayers[idx].sides?.people?[0]?.batSide?.description == "Right")
                        {
                            textBlockName.Foreground = System.Windows.Media.Brushes.Black;
                        }
                        else
                        {
                            textBlockName.Foreground = System.Windows.Media.Brushes.Blue;
                        }
                        
                        textBlockName.Text = benchPlayers?[idx]?.name ?? string.Empty;
                    }

                    // Bench Player Stats
                    if (benchPlayers?[idx]?.hitterStats?.splits?.Count != null && benchPlayers[idx].hitterStats?.splits?.Count > 0)
                    {
                        if (rowGrid.Children[2] is Grid columnGridAvg && columnGridAvg.Children[0] is Viewbox viewboxAvg
                            && viewboxAvg.Child is TextBlock textBlockAvg)
                        {
                            textBlockAvg.Text = benchPlayers?[idx]?.hitterStats?.splits?[0]?.stats?.hitting?.standard?.avg ?? string.Empty;
                        }

                        if (rowGrid.Children[3] is Grid columnGridHR && columnGridHR.Children[0] is Viewbox viewboxHR
                            && viewboxHR.Child is TextBlock textBlockHR)
                        {
                            textBlockHR.Text = benchPlayers?[idx]?.hitterStats?.splits?[0]?.stats?.hitting?.standard?.homeRuns.ToString() ?? string.Empty;
                        }

                        if (rowGrid.Children[4] is Grid columnGridRbi && columnGridRbi.Children[0] is Viewbox viewboxRbi
                            && viewboxRbi.Child is TextBlock textBlockRbi)
                        {
                            textBlockRbi.Text = benchPlayers?[idx]?.hitterStats?.splits?[0]?.stats?.hitting?.standard?.rbi.ToString() ?? string.Empty;
                        }

                        if (rowGrid.Children[5] is Grid columnGridOps && columnGridOps.Children[0] is Viewbox viewboxOps
                            && viewboxOps.Child is TextBlock textBlockOps)
                        {
                            textBlockOps.Text = benchPlayers?[idx]?.hitterStats?.splits?[0]?.stats?.hitting?.standard?.ops ?? string.Empty;
                        }
                    }
                }

                idx++;
            }
        }

        private void hitterTable()                                               
        {           
            var players = stats?.homeTeamSelectedPlayers?.Values.Cast<PlayerStats>().ToList();
            int idx = 0;

            // 1,3,5,7,9,11,13,15,17
            for (int i = 1; i < HitterGrid.Children.Count; i += 2)
            {
                // 2,4,6,8,10,12,14,16,18
                int j = i + 1;

                // Function stops if players are null or aren't enough to fit the grid.
                if (players == null || idx >= players.Count)
                    return;

                //Player Names, Positions & AVG, OPS, K, BB and etc.
                if (HitterGrid.Children[i] is Grid rowGrid)
                {
                    // Name 
                    if (rowGrid.Children[0] is Grid columnGrid1 
                        && columnGrid1.Children[0] is Viewbox viewboxPlayer && viewboxPlayer.Child is TextBlock textBlockPlayer)
                    {
                        if (players[idx].sides?.people?[0]?.pitchHand?.description == "Left")
                            textBlockPlayer.Foreground = System.Windows.Media.Brushes.Red;
                        else if (players[idx].sides?.people?[0]?.pitchHand?.description == "Right")
                            textBlockPlayer.Foreground = System.Windows.Media.Brushes.Black;
                        else
                            textBlockPlayer.Foreground = System.Windows.Media.Brushes.Blue;

                        textBlockPlayer.Text = $"{players[idx].jerseyNumber ?? string.Empty}-{players[idx].name ?? string.Empty}";
                    }

                    // Position
                    if (rowGrid.Children[1] is Grid columnGrid2 
                        && columnGrid2.Children[0] is Viewbox viewboxPos && viewboxPos.Child is TextBox textBoxPos)
                    {
                        textBoxPos.Text = players[idx].position ?? string.Empty;
                    }

                    // Checks if the 'splits' property contains values
                    if (players[idx].hitterStats?.splits?.Count != null && players[idx].hitterStats?.splits?.Count > 0)                   
                    {
                        // AVG, OPS                   
                        if (rowGrid.Children[14] is Grid columnGrid3)
                        {
                            if (columnGrid3.Children[0] is Grid rowGridAvg && rowGridAvg.Children[0] is Viewbox viewboxAvg
                                && viewboxAvg.Child is TextBlock textBlockAvg)
                            {
                                textBlockAvg.Text = players[idx].hitterStats?.splits?[0]?.stats?.hitting?.standard?.avg ?? string.Empty;
                            }

                            if (columnGrid3.Children[1] is Grid rowGridOps && rowGridOps.Children[0] is Viewbox viewboxOps
                                && viewboxOps.Child is TextBlock textBlockOps)
                            {
                                textBlockOps.Text = players[idx].hitterStats?.splits?[0]?.stats?.hitting?.standard?.ops ?? string.Empty;
                            }
                        }

                        // K, BB
                        if (rowGrid.Children[15] is Grid columnGrid4)
                        {
                            if (columnGrid4.Children[0] is Grid rowGridK && rowGridK.Children[0] is Viewbox viewboxK
                                && viewboxK.Child is TextBlock textBlockK)
                            {
                                textBlockK.Text = players[idx].hitterStats?.splits?[0]?.stats?.hitting?.standard?.strikeOuts.ToString() ?? string.Empty;
                            }

                            if (columnGrid4.Children[1] is Grid rowGridBB && rowGridBB.Children[0] is Viewbox viewboxBB
                                && viewboxBB.Child is TextBlock textBlockBB)
                            {
                                textBlockBB.Text = players[idx].hitterStats?.splits?[0]?.stats?.hitting?.standard?.baseOnBalls.ToString() ?? string.Empty;
                            }
                        }

                        // 2B, 3B
                        if (rowGrid.Children[16] is Grid columnGrid5)
                        {
                            if (columnGrid5.Children[0] is Grid rowGrid2b && rowGrid2b.Children[0] is Viewbox viewbox2b
                                && viewbox2b.Child is TextBlock textBlock2b)
                            {
                                textBlock2b.Text = players[idx].hitterStats?.splits?[0]?.stats?.hitting?.standard?.doubles.ToString() ?? string.Empty;
                            }

                            if (columnGrid5.Children[1] is Grid rowGrid3b && rowGrid3b.Children[0] is Viewbox viewbox3b
                                && viewbox3b.Child is TextBlock textBlock3b)
                            {
                                textBlock3b.Text = players[idx].hitterStats?.splits?[0]?.stats?.hitting?.standard?.triples.ToString() ?? string.Empty;
                            }
                        }

                        // HR, RBI
                        if (rowGrid.Children[17] is Grid columnGrid6)
                        {
                            if (columnGrid6.Children[0] is Grid rowGridHr && rowGridHr.Children[0] is Viewbox viewboxHr
                                && viewboxHr.Child is TextBlock textBlockHr)
                            {
                                textBlockHr.Text = players[idx].hitterStats?.splits?[0]?.stats?.hitting?.standard?.homeRuns.ToString() ?? string.Empty;
                            }

                            if (columnGrid6.Children[1] is Grid rowGridRbi && rowGridRbi.Children[0] is Viewbox viewboxRbi
                                && viewboxRbi.Child is TextBlock textBlockRbi)
                            {
                                textBlockRbi.Text = players[idx].hitterStats?.splits?[0]?.stats?.hitting?.standard?.rbi.ToString() ?? string.Empty;
                            }
                        }

                        // Runs, BACON
                        if (rowGrid.Children[18] is Grid columnGrid7)
                        {
                            if (columnGrid7.Children[0] is Grid rowGridRuns && rowGridRuns.Children[0] is Viewbox viewboxRuns
                                && viewboxRuns.Child is TextBlock textBlockRuns)
                            {
                                textBlockRuns.Text = players[idx].hitterStats?.splits?[0]?.stats?.hitting?.standard?.runs.ToString() ?? string.Empty;
                            }

                            if (columnGrid7.Children[1] is Grid rowGridBacon && rowGridBacon.Children[0] is Viewbox viewboxBacon
                                && viewboxBacon.Child is TextBlock textBlockBacon)
                            {
                                textBlockBacon.Text = players[idx].hitterStats?.splits?[0]?.stats?.hitting?.standard?.babip ?? string.Empty;
                            }
                        }

                        // SB-SBA, DP
                        if (rowGrid.Children[19] is Grid columnGrid8)
                        {
                            if (columnGrid8.Children[0] is Grid rowGridSb && rowGridSb.Children[0] is Viewbox viewboxSb
                                && viewboxSb.Child is TextBlock textBlockSb)
                            {
                                textBlockSb.Text = $"{players[idx].hitterStats?.splits?[0]?.stats?.hitting?.standard?.stolenBases.ToString() ?? string.Empty}-" +
                                    $"{players[idx].hitterStats?.splits?[0]?.stats?.hitting?.standard?.caughtStealing.ToString() ?? string.Empty}";
                            }

                            if (columnGrid8.Children[1] is Grid rowGridDp && rowGridDp.Children[0] is Viewbox viewboxDp
                                && viewboxDp.Child is TextBlock textBlockDp)
                            {
                                textBlockDp.Text = players[idx].hitterStats?.splits?[0]?.stats?.hitting?.standard?.groundIntoDoublePlay.ToString() ?? string.Empty;
                            }
                        }
                    }
                    
                }

                // 1stP, RISP, RISP2o, vsLH, vsRH, 7+.
                if (HitterGrid.Children[j] is Grid rowGrid2)
                {
                    // 1stP
                    if (players[idx].fp?.splits?.Count != null && players[idx].fp?.splits?.Count > 0)
                    {
                        if (rowGrid2.Children[1] is Grid columnGrid1stP)
                        {
                            if (columnGrid1stP.Children[1] is Grid columnGrid4 && columnGrid4.Children[0] is Viewbox viewbox3
                                && viewbox3.Child is TextBlock textBlock3)
                            {
                                textBlock3.Text = players[idx].fp?.splits?[0]?.stats?.hitting?.tracking?.hitProbability?.averageValue.ToString() ?? string.Empty;
                            }
                            if (columnGrid1stP.Children[2] is Grid columnGrid5 && columnGrid5.Children[0] is Viewbox viewbox4
                                && viewbox4.Child is TextBlock textBlock4)
                            {
                                textBlock4.Text = players[idx].fp?.splits?[0]?.stats?.hitting?.standard?.avg ?? string.Empty;
                            }
                            if (columnGrid1stP.Children[3] is Grid columnGrid6 && columnGrid6.Children[0] is Viewbox viewbox5
                                && viewbox5.Child is TextBlock textBlock5)
                            {
                                textBlock5.Text = players[idx].fp?.splits?[0]?.stats?.hitting?.standard?.ops ?? string.Empty;
                            }
                        }
                    }
                    

                    // RISP
                    if (players[idx].risp?.splits?.Count != null && players[idx].risp?.splits?.Count > 0)
                    { 
                        if (rowGrid2.Children[2] is Grid columnGridRISP)
                        {
                            if (columnGridRISP.Children[1] is Grid columnGrid4 && columnGrid4.Children[0] is Viewbox viewbox3
                                && viewbox3.Child is TextBlock textBlock3)
                            {
                                textBlock3.Text = $"{players[idx].risp?.splits?[0]?.stats?.hitting?.standard?.hits.ToString() ?? string.Empty}-" +
                                    $"{players[idx].risp?.splits?[0]?.stats?.hitting?.standard?.atBats.ToString() ?? string.Empty}";
                            }
                            if (columnGridRISP.Children[2] is Grid columnGrid5 && columnGrid5.Children[0] is Viewbox viewbox4
                                && viewbox4.Child is TextBlock textBlock4)
                            {
                                textBlock4.Text = players[idx].risp?.splits?[0]?.stats?.hitting?.standard?.avg ?? string.Empty;
                            }
                            if (columnGridRISP.Children[3] is Grid columnGrid6 && columnGrid6.Children[0] is Viewbox viewbox5
                                && viewbox5.Child is TextBlock textBlock5)
                            {
                                textBlock5.Text = players[idx].risp?.splits?[0]?.stats?.hitting?.standard?.homeRuns.ToString() ?? string.Empty;
                            }
                        }
                    }

                    // RISP2o
                    if (players[idx].risp2o?.splits?.Count != null && players[idx].risp2o?.splits?.Count > 0)
                    { 
                        if (rowGrid2.Children[3] is Grid columnGridRISP2o)
                        {
                            if (columnGridRISP2o.Children[1] is Grid columnGrid4 && columnGrid4.Children[0] is Viewbox viewbox3
                                && viewbox3.Child is TextBlock textBlock3)
                            {
                                textBlock3.Text = $"{players[idx].risp2o?.splits?[0]?.stats?.hitting?.standard?.hits.ToString() ?? string.Empty}-" +
                                    $"{players[idx].risp2o?.splits?[0]?.stats?.hitting?.standard?.atBats.ToString() ?? string.Empty}";
                            }
                            if (columnGridRISP2o.Children[2] is Grid columnGrid5 && columnGrid5.Children[0] is Viewbox viewbox4
                                && viewbox4.Child is TextBlock textBlock4)
                            {
                                textBlock4.Text = players[idx].risp2o?.splits?[0]?.stats?.hitting?.standard?.avg ?? string.Empty;
                            }
                            if (columnGridRISP2o.Children[3] is Grid columnGrid6 && columnGrid6.Children[0] is Viewbox viewbox5
                                && viewbox5.Child is TextBlock textBlock5)
                            {
                                textBlock5.Text = players[idx].risp2o?.splits?[0]?.stats?.hitting?.standard?.homeRuns.ToString() ?? string.Empty;
                            }
                        }
                    }

                    // vsLH
                    if (players[idx].vsLeft?.splits?.Count != null && players[idx].vsLeft?.splits?.Count > 0)
                    { 
                        if (rowGrid2.Children[4] is Grid columnGridvsLH)
                        {
                            if (columnGridvsLH.Children[1] is Grid columnGrid4 && columnGrid4.Children[0] is Viewbox viewbox3
                                && viewbox3.Child is TextBlock textBlock3)
                            {
                                textBlock3.Text = $"{players[idx].vsLeft?.splits?[0]?.stats?.hitting?.standard?.hits.ToString() ?? string.Empty}-" +
                                    $"{players[idx].vsLeft?.splits?[0]?.stats?.hitting?.standard?.atBats.ToString() ?? string.Empty}";
                            }
                            if (columnGridvsLH.Children[2] is Grid columnGrid5 && columnGrid5.Children[0] is Viewbox viewbox4
                                && viewbox4.Child is TextBlock textBlock4)
                            {
                                textBlock4.Text = players[idx].vsLeft?.splits?[0]?.stats?.hitting?.standard?.homeRuns.ToString() ?? string.Empty;
                            }
                            if (columnGridvsLH.Children[3] is Grid columnGrid6 && columnGrid6.Children[0] is Viewbox viewbox5
                                && viewbox5.Child is TextBlock textBlock5)
                            {
                                textBlock5.Text = players[idx].vsLeft?.splits?[0]?.stats?.hitting?.standard?.avg ?? string.Empty;
                            }
                            if (columnGridvsLH.Children[4] is Grid columnGrid7 && columnGrid7.Children[0] is Viewbox viewbox6
                                && viewbox6.Child is TextBlock textBlock6)
                            {
                                textBlock6.Text = players[idx].vsLeft?.splits?[0]?.stats?.hitting?.standard?.ops ?? string.Empty;
                            }
                        }
                    }

                    // vsRH
                    if (players[idx].vsRight?.splits?.Count != null && players[idx].vsRight?.splits?.Count > 0)
                    { 
                        if (rowGrid2.Children[5] is Grid columnGridvsRH)
                        {
                            if (columnGridvsRH.Children[1] is Grid columnGrid4 && columnGrid4.Children[0] is Viewbox viewbox3
                                && viewbox3.Child is TextBlock textBlock3)
                            {
                                textBlock3.Text = $"{players[idx].vsRight?.splits?[0]?.stats?.hitting?.standard?.hits.ToString() ?? string.Empty}-" +
                                    $"{players[idx].vsRight?.splits?[0]?.stats?.hitting?.standard?.atBats.ToString() ?? string.Empty}";
                            }
                            if (columnGridvsRH.Children[2] is Grid columnGrid5 && columnGrid5.Children[0] is Viewbox viewbox4
                                && viewbox4.Child is TextBlock textBlock4)
                            {
                                textBlock4.Text = players[idx].vsRight?.splits?[0]?.stats?.hitting?.standard?.homeRuns.ToString() ?? string.Empty;
                            }
                            if (columnGridvsRH.Children[3] is Grid columnGrid6 && columnGrid6.Children[0] is Viewbox viewbox5
                                && viewbox5.Child is TextBlock textBlock5)
                            {
                                textBlock5.Text = players[idx].vsRight?.splits?[0]?.stats?.hitting?.standard?.avg ?? string.Empty;
                            }
                            if (columnGridvsRH.Children[4] is Grid columnGrid7 && columnGrid7.Children[0] is Viewbox viewbox6
                                && viewbox6.Child is TextBlock textBlock6)
                            {
                                textBlock6.Text = players[idx].vsRight?.splits?[0]?.stats?.hitting?.standard?.ops ?? string.Empty;
                            }
                        }
                    }

                    // 7+
                    if (players[idx].plus7?.splits?.Count != null && players[idx].plus7?.splits?.Count > 0)
                    { 
                        if (rowGrid2.Children[6] is Grid columnGridvs7Plus)
                        {
                            if (columnGridvs7Plus.Children[1] is Grid columnGrid4 && columnGrid4.Children[0] is Viewbox viewbox3
                                && viewbox3.Child is TextBlock textBlock3)
                            {
                                textBlock3.Text = players[idx].plus7?.splits?[0]?.stats?.hitting?.standard?.avg ?? string.Empty;
                            }
                            if (columnGridvs7Plus.Children[2] is Grid columnGrid5 && columnGrid5.Children[0] is Viewbox viewbox4
                                && viewbox4.Child is TextBlock textBlock4)
                            {
                                textBlock4.Text = players[idx].plus7?.splits?[0]?.stats?.hitting?.standard?.ops ?? string.Empty;
                            }
                        }
                    }
                }
                
                idx++;
            }
             
        }

        private void umpsTeamsSBTable()                                          
        {
            int idx = 0;

            // Populate Umpires
            for (int i = 0; i < UmpireGrid.Children.Count; i++)
            {
                // Stop function if there not enough umpires to fill the grid.
                if (stats?.umps?.officials?.Count != null && i >= stats.umps.officials.Count)
                    return;

                if (UmpireGrid.Children[i] is Grid rowGrid && rowGrid.Children[0] is Grid columnGrid)
                {
                    // Check if officials property contain values
                    if (stats?.umps?.officials?.Count > 0)
                    { 
                        if (columnGrid.Children[0] is Grid columnGridUmpType && columnGridUmpType.Children[0] is Viewbox viewboxUmpType
                            && viewboxUmpType.Child is TextBlock textBlockUmpType)
                        {
                            // The value won't be null before accessing it. 
                            if (stats?.umps?.officials?[i]?.officialType != null)
                            {
                                // Still giving me a warning for some reason. 
                                idx = stats.umps.officials[i].officialType.IndexOf(' ') + 1;

                                textBlockUmpType.Text = $"{stats?.umps?.officials?[i]?.officialType?[0].ToString() ?? string.Empty}" +
                                    $"{stats?.umps?.officials?[i]?.officialType?[idx].ToString() ?? string.Empty}";
                            }
                        }

                        if (columnGrid.Children[1] is Grid columnGridUmpName && columnGridUmpName.Children[0] is Viewbox viewboxUmpName
                            && viewboxUmpName.Child is TextBlock textBlockUmpName)
                        {
                            textBlockUmpName.Text = stats?.umps?.officials?[i]?.official?.fullName ?? string.Empty;
                        }
                    }
                }

                
            }          

            // Populate SB-SBA, DP stats for Home Team
            if (stats?.homeTeamSB?.splits?.Count != null && stats.homeTeamSB.splits.Count > 0)
            { 
                if (UmpireGrid.Children[0] is Grid rowGrid2 && rowGrid2.Children[14] is Grid columnGrid2)
                {
                    if (columnGrid2.Children[0] is Viewbox viewboxTeamStat
                        && viewboxTeamStat.Child is TextBlock textBlockTeamStat)
                    {
                        textBlockTeamStat.Text = $"{stats?.homeTeamSB?.splits?[0]?.stats?.hitting?.standard?.stolenBases.ToString() ?? string.Empty}-" +
                            $"{stats?.homeTeamSB?.splits?[0]?.stats?.hitting?.standard?.caughtStealing.ToString() ?? string.Empty}";
                    }                  
                }

                if (UmpireGrid.Children[1] is Grid rowGrid3 && rowGrid3.Children[14] is Grid columnGrid3)
                {
                    if (columnGrid3.Children[0] is Viewbox viewboxTeamStat
                        && viewboxTeamStat.Child is TextBlock textBlockTeamStat)
                    {
                        textBlockTeamStat.Text = stats?.homeTeamSB?.splits?[0]?.stats?.hitting?.standard?.groundIntoDoublePlay.ToString() ?? string.Empty;
                    }
                }
            }

            // Populate SB-SBA, DP stats for Opponent Team
            if (stats?.guestTeamSB?.splits?.Count != null && stats.guestTeamSB.splits.Count > 0)
            {
                if (UmpireGrid.Children[2] is Grid rowGrid4 && rowGrid4.Children[14] is Grid columnGrid4)
                {
                    if (columnGrid4.Children[0] is Viewbox viewboxTeamStat
                        && viewboxTeamStat.Child is TextBlock textBlockTeamStat)
                    {
                        textBlockTeamStat.Text = $"{stats?.guestTeamSB?.splits?[0]?.stats?.hitting?.standard?.stolenBases.ToString() ?? string.Empty}-" +
                            $"{stats?.guestTeamSB?.splits?[0]?.stats?.hitting?.standard?.caughtStealing.ToString() ?? string.Empty}";
                    }
                }

                if (UmpireGrid.Children[3] is Grid rowGrid5 && rowGrid5.Children[14] is Grid columnGrid5)
                {
                    if (columnGrid5.Children[0] is Viewbox viewboxTeamStat
                        && viewboxTeamStat.Child is TextBlock textBlockTeamStat)
                    {
                        textBlockTeamStat.Text = stats?.guestTeamSB?.splits?[0]?.stats?.hitting?.standard?.groundIntoDoublePlay.ToString() ?? string.Empty;
                    }
                }
            }
        }

        private void scoreTable()                                                
        {
            if (stats.homeTeamName != null)
                HomeTeam.Text = stats.homeTeamName;

            if (stats.guestTeamName != null)
                GuestTeam.Text = stats.guestTeamName;
        }

        private void bullpenTable()                                              
        {
            if (stats.guestTeamBullpen != null && stats.guestTeamBullpen.Values.Count > 0)
            {
                var guestBullpenPlayers = stats.guestTeamBullpen.Values.Cast<BullpenStats>().ToList();

                int idx = 0;

                for (int i = 0; i < BullpenGrid.Children.Count; i++)
                {
                    if (BullpenGrid.Children[i] is Grid columnGrid && columnGrid.Children[1] is Grid rowGrid)
                    {
                        for (int j = 0; j < rowGrid.Children.Count; j += 2)
                        {
                            // Function will return back to the caller if there are no more bullpen players to fill the grid.
                            if (idx >= guestBullpenPlayers.Count)
                                return;
                            
                            // G, S/Holds, W-L, ERA, IP, K, BB
                            if (rowGrid.Children[j] is Grid rowGridStats)
                            {
                                // Name
                                if (rowGridStats.Children[0] is Grid columnGridName && columnGridName.Children[0] is Viewbox viewboxName
                                && viewboxName.Child is TextBlock textBlockName)
                                {
                                    if (guestBullpenPlayers[idx].sides?.people?[0]?.pitchHand?.description == "Left")
                                    {
                                        textBlockName.Foreground = System.Windows.Media.Brushes.Red;
                                    }                                    
                                    else
                                    {
                                        textBlockName.Foreground = System.Windows.Media.Brushes.Black;
                                    }

                                    textBlockName.Text = guestBullpenPlayers[idx].name ?? string.Empty;
                                }

                                // Check if the splits property is not null and contain values
                                if (guestBullpenPlayers[idx].pitcherStats?.splits?.Count != null && guestBullpenPlayers[idx].pitcherStats?.splits?.Count > 0)
                                { 
                                    // G
                                    if (rowGridStats.Children[1] is Grid columnGridG && columnGridG.Children[0] is Viewbox viewboxG
                                    && viewboxG.Child is TextBlock textBlockG)
                                    {
                                        textBlockG.Text = guestBullpenPlayers[idx].pitcherStats?.splits?[0]?.stats?.pitching?.standard?.gamesPlayed.ToString() ?? string.Empty;
                                    }

                                    // S/Holds
                                    if (rowGridStats.Children[2] is Grid columnGridSH)
                                    {
                                        if (columnGridSH.Children[0] is Grid columnGridS && columnGridS.Children[0] is Viewbox viewboxS
                                            && viewboxS.Child is TextBlock textBlockS)
                                        {
                                            textBlockS.Text = $"{guestBullpenPlayers[idx].pitcherStats?.splits?[0]?.stats?.pitching?.standard?.saves.ToString() ?? string.Empty}-" +
                                                $"{guestBullpenPlayers[idx].pitcherStats?.splits?[0]?.stats?.pitching?.standard?.blownSaves.ToString() ?? string.Empty}";
                                        }

                                        if (columnGridSH.Children[1] is Grid columnGridH && columnGridH.Children[0] is Viewbox viewboxH
                                            && viewboxH.Child is TextBlock textBlockH)
                                        {
                                            textBlockH.Text = guestBullpenPlayers[idx].pitcherStats?.splits?[0]?.stats?.pitching?.standard?.holds.ToString() ?? string.Empty;
                                        }
                                    }

                                    if (rowGridStats.Children[3] is Grid columnGridWL && columnGridWL.Children[0] is Viewbox viewboxWL
                                    && viewboxWL.Child is TextBlock textBlockWL)
                                    {
                                        textBlockWL.Text = $"{guestBullpenPlayers[idx].pitcherStats?.splits?[0]?.stats?.pitching?.standard?.wins.ToString() ?? string.Empty}-" +
                                                $"{guestBullpenPlayers[idx].pitcherStats?.splits?[0]?.stats?.pitching?.standard?.losses.ToString() ?? string.Empty}";
                                    }

                                    if (rowGridStats.Children[4] is Grid columnGridEra && columnGridEra.Children[0] is Viewbox viewboxEra
                                    && viewboxEra.Child is TextBlock textBlockEra)
                                    {
                                        textBlockEra.Text = guestBullpenPlayers[idx].pitcherStats?.splits?[0]?.stats?.pitching?.standard?.era?.ToString() ?? string.Empty;
                                    }

                                    if (rowGridStats.Children[5] is Grid columnGridIP && columnGridIP.Children[0] is Viewbox viewboxIP
                                    && viewboxIP.Child is TextBlock textBlockIP)
                                    {
                                        textBlockIP.Text = guestBullpenPlayers[idx].pitcherStats?.splits?[0]?.stats?.pitching?.standard?.inningsPitched?.ToString() ?? string.Empty;
                                    }

                                    if (rowGridStats.Children[6] is Grid columnGridK && columnGridK.Children[0] is Viewbox viewboxK
                                    && viewboxK.Child is TextBlock textBlockK)
                                    {
                                        textBlockK.Text = guestBullpenPlayers[idx].pitcherStats?.splits?[0]?.stats?.pitching?.standard?.strikeOuts.ToString() ?? string.Empty;
                                    }

                                    if (rowGridStats.Children[7] is Grid columnGridBB && columnGridBB.Children[0] is Viewbox viewboxBB
                                    && viewboxBB.Child is TextBlock textBlockBB)
                                    {
                                        textBlockBB.Text = guestBullpenPlayers[idx].pitcherStats?.splits?[0]?.stats?.pitching?.standard?.baseOnBalls.ToString() ?? string.Empty;
                                    }
                                }
                            }

                            // Pitch Type & Velocity
                            if (rowGrid.Children[j + 1] is Grid rowGridPitchTypes)
                            {
                                // Check if the splits property is not null and contain values    
                                if (guestBullpenPlayers[idx].bullpenPitches?.splits?.Count != null && guestBullpenPlayers[idx].bullpenPitches?.splits?.Count > 0)
                                {
                                    for (int z = 0; z < rowGridPitchTypes.Children.Count; z++)
                                    {
                                        // Extra Null Checks because some pitch codes are null
                                        if (rowGridPitchTypes.Children[z] is Grid colGridPT && colGridPT.Children[0] is Grid colGridPTstats
                                            && colGridPTstats.Children[0] is Viewbox viewboxPT && viewboxPT.Child is TextBlock textBlockPT
                                            && guestBullpenPlayers[idx].bullpenPitches?.splits?.Count != null 
                                            && z < guestBullpenPlayers[idx].bullpenPitches?.splits?.Count)
                                        {
                                            textBlockPT.Text = guestBullpenPlayers[idx].bullpenPitches?.splits?[z]?.pitchType?.code?.ToString() ?? string.Empty;
                                        }

                                        // Extra Null Checks because some release speed values are null
                                        if (rowGridPitchTypes.Children[z] is Grid colGridV && colGridV.Children[2] is Grid colGridVstats
                                            && colGridVstats.Children[0] is Viewbox viewboxV && viewboxV.Child is TextBlock textBlockV
                                            && guestBullpenPlayers[idx].bullpenPitches?.splits?.Count != null
                                            && z < guestBullpenPlayers[idx].bullpenPitches?.splits?.Count)
                                        {
                                        textBlockV.Text = guestBullpenPlayers[idx].bullpenPitches?.splits?[z]?.stats?.pitching?.tracking?.releaseSpeed?.averageValue.ToString() ?? string.Empty;
                                        }
                                    }                                                                                                         
                                }                                 
                            }
                                
                            idx++;
                            
                        }
                    }

                }

            }
        }       

        private void coachTable()                                                
        {
            // Check if roster is emoty, return back to the caller if it's true
            if (stats?.homeTeamCoaches?.roster?.Count == null || stats.homeTeamCoaches.roster.Count == 0)
                return;

            Dictionary<string, string> coachesDict = new Dictionary<string, string>();

            // Exctract only needed coaches
            for (int i = 0; i < stats.homeTeamCoaches?.roster.Count; i++)
            {               
                if (stats.homeTeamCoaches.roster[i].jobId != null && !coachesDict.ContainsKey(stats.homeTeamCoaches.roster[i].jobId))
                { 
                    if (stats.homeTeamCoaches.roster[i].jobId == "MNGR")
                    {
                        coachesDict.Add("MNGR", stats.homeTeamCoaches?.roster?[i]?.person?.fullName ?? string.Empty);
                    }
                    else if (stats.homeTeamCoaches.roster[i].jobId == "COAB")
                    {
                        coachesDict.Add("COAB", stats.homeTeamCoaches?.roster?[i]?.person?.fullName ?? string.Empty);
                    }
                    else if (stats.homeTeamCoaches.roster[i].jobId == "COAP")
                    {
                        coachesDict.Add("COAP", stats.homeTeamCoaches?.roster?[i]?.person?.fullName ?? string.Empty);
                    }
                    else if (stats.homeTeamCoaches.roster[i].jobId == "COPA")
                    {
                        coachesDict.Add("COPA", stats.homeTeamCoaches?.roster?[i]?.person?.fullName ?? string.Empty);
                    }
                    else if (stats.homeTeamCoaches.roster[i].jobId == "COA1")
                    {
                        coachesDict.Add("COA1", stats.homeTeamCoaches?.roster?[i]?.person?.fullName ?? string.Empty);
                    }
                    else if (stats.homeTeamCoaches.roster[i].jobId == "COA3")
                    {
                        coachesDict.Add("COA3", stats.homeTeamCoaches?.roster?[i]?.person?.fullName ?? string.Empty);
                    }
                    else if (stats.homeTeamCoaches.roster[i].jobId == "COAT")
                    {
                        coachesDict.Add("COAT", stats.homeTeamCoaches?.roster?[i]?.person?.fullName ?? string.Empty);
                    }
                    else if (stats.homeTeamCoaches.roster[i].jobId == "COAA")
                    {
                        coachesDict.Add("COAA", stats.homeTeamCoaches?.roster?[i]?.person?.fullName ?? string.Empty);
                    }
                    else if (stats.homeTeamCoaches.roster[i].jobId == "BCAT")
                    {
                        coachesDict.Add("BCAT", stats.homeTeamCoaches?.roster?[i]?.person?.fullName ?? string.Empty);
                    }
                }
                
            }

            // Populate Coaches Table
            if (CoachesGrid.Children[0] is Grid rowGrid && rowGrid.Children[1] is Grid colGrid && colGrid.Children[0] is Viewbox viewbox
                    && viewbox.Child is TextBlock textblock)
            {
                if (coachesDict.ContainsKey("MNGR"))
                    textblock.Text = coachesDict["MNGR"];
            }

            if (CoachesGrid.Children[1] is Grid rowGridBC && rowGridBC.Children[1] is Grid colGridBC && colGridBC.Children[0] is Viewbox viewboxBC
                    && viewboxBC.Child is TextBlock textblockBC)
            {
                if (coachesDict.ContainsKey("COAB"))
                    textblockBC.Text = coachesDict["COAB"];
            }

            if (CoachesGrid.Children[2] is Grid rowGridPC && rowGridPC.Children[1] is Grid colGridPC && colGridPC.Children[0] is Viewbox viewboxPC
                    && viewboxPC.Child is TextBlock textblockPC)
            {
                if (coachesDict.ContainsKey("COAP"))
                    textblockPC.Text = coachesDict["COAP"];
            }

            if (CoachesGrid.Children[3] is Grid rowGridAPC && rowGridAPC.Children[1] is Grid colGridAPC && colGridAPC.Children[0] is Viewbox viewboxAPC
                    && viewboxAPC.Child is TextBlock textblockAPC)
            {
                if (coachesDict.ContainsKey("COPA"))
                    textblockAPC.Text = coachesDict["COPA"];
            }

            if (CoachesGrid.Children[4] is Grid rowGridFBC && rowGridFBC.Children[1] is Grid colGridFBC && colGridFBC.Children[0] is Viewbox viewboxFBC
                    && viewboxFBC.Child is TextBlock textblockFBC)
            {
                if (coachesDict.ContainsKey("COA1"))
                    textblockFBC.Text = coachesDict["COA1"];
            }

            if (CoachesGrid.Children[5] is Grid rowGridTBC && rowGridTBC.Children[1] is Grid colGridTBC && colGridTBC.Children[0] is Viewbox viewboxTBC
                    && viewboxTBC.Child is TextBlock textblockTBC)
            {
                if (coachesDict.ContainsKey("COA3"))
                    textblockTBC.Text = coachesDict["COA3"];
            }

            if (CoachesGrid.Children[6] is Grid rowGridHC && rowGridHC.Children[1] is Grid colGridHC && colGridHC.Children[0] is Viewbox viewboxHC
                    && viewboxHC.Child is TextBlock textblockHC)
            {
                if (coachesDict.ContainsKey("COAT"))
                    textblockHC.Text = coachesDict["COAT"];
            }

            if (CoachesGrid.Children[7] is Grid rowGridAHC && rowGridAHC.Children[1] is Grid colGridAHC && colGridAHC.Children[0] is Viewbox viewboxAHC
                    && viewboxAHC.Child is TextBlock textblockAHC)
            {
                if (coachesDict.ContainsKey("COAA"))
                    textblockAHC.Text = coachesDict["COAA"];
            }

            if (CoachesGrid.Children[8] is Grid rowGridBUC && rowGridBUC.Children[1] is Grid colGridBUC && colGridBUC.Children[0] is Viewbox viewboxBUC
                    && viewboxBUC.Child is TextBlock textblockBUC)
            {
                if (coachesDict.ContainsKey("BCAT"))
                    textblockBUC.Text = coachesDict["BCAT"];
            }
        }

        // Clears cursor when "Enter" is pressed
        private void P1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Move focus to another element
                Keyboard.ClearFocus();               
            }
        }        

    
        private void startingPitcher()
        {
            if(stats.guestTeamSelectedPlayers != null && stats.guestTeamSelectedPlayers.Count >= 10)
            {
                var startingPitcher = stats.guestTeamSelectedPlayers.Values.Cast<PlayerStats>().ToList();

                if (StartingPitcher.Children[0] is Grid colGridName && colGridName.Children[0] is Viewbox viewboxName
                    && viewboxName.Child is TextBlock textblockName)
                {
                    if (startingPitcher[9].sides?.people?[0]?.pitchHand?.description == "Left")
                    {
                        textblockName.Foreground = System.Windows.Media.Brushes.Red;
                    }                    
                    else
                    {
                        textblockName.Foreground = System.Windows.Media.Brushes.Black;
                    }

                    textblockName.Text = startingPitcher[9].name;
                }
               
                if (startingPitcher[9].pitcherStats?.splits?.Count != null && startingPitcher[9].pitcherStats?.splits?.Count > 0)
                {
                    if (StartingPitcher.Children[1] is Grid colGridGO && colGridGO.Children[0] is Viewbox viewboxGO
                    && viewboxGO.Child is TextBlock textblockGO)
                    {
                        textblockGO.Text = startingPitcher[9].pitcherStats?.splits?[0]?.stats?.pitching?.standard?.gamesStarted?.ToString() ?? string.Empty;
                    }

                    if (StartingPitcher.Children[2] is Grid colGridWL && colGridWL.Children[0] is Viewbox viewboxWL
                    && viewboxWL.Child is TextBlock textblockWL)
                    {
                        textblockWL.Text = $"{startingPitcher[9].pitcherStats?.splits?[0]?.stats?.pitching?.standard?.wins?.ToString() ?? string.Empty}-" +
                            $"{startingPitcher[9].pitcherStats?.splits?[0]?.stats?.pitching?.standard?.losses.ToString() ?? string.Empty}";
                    }

                    if (StartingPitcher.Children[3] is Grid colGridEra && colGridEra.Children[0] is Viewbox viewboxEra
                    && viewboxEra.Child is TextBlock textblockEra)
                    {
                        textblockEra.Text = startingPitcher[9].pitcherStats?.splits?[0]?.stats?.pitching?.standard?.era?.ToString() ?? string.Empty;
                    }

                    if (StartingPitcher.Children[4] is Grid colGridIp && colGridIp.Children[0] is Viewbox viewboxIp
                    && viewboxIp.Child is TextBlock textblockIp)
                    {
                        textblockIp.Text = startingPitcher[9].pitcherStats?.splits?[0]?.stats?.pitching?.standard?.inningsPitched?.ToString() ?? string.Empty;
                    }

                    if (StartingPitcher.Children[5] is Grid colGridH && colGridH.Children[0] is Viewbox viewboxH
                    && viewboxH.Child is TextBlock textblockH)
                    {
                        textblockH.Text = startingPitcher[9].pitcherStats?.splits?[0]?.stats?.pitching?.standard?.hits?.ToString() ?? string.Empty;
                    }

                    if (StartingPitcher.Children[6] is Grid colGridER && colGridER.Children[0] is Viewbox viewboxER
                    && viewboxER.Child is TextBlock textblockER)
                    {
                        textblockER.Text = startingPitcher[9].pitcherStats?.splits?[0]?.stats?.pitching?.standard?.earnedRuns?.ToString() ?? string.Empty;
                    }

                    if (StartingPitcher.Children[7] is Grid colGridBB && colGridBB.Children[0] is Viewbox viewboxBB
                    && viewboxBB.Child is TextBlock textblockBB)
                    {
                        textblockBB.Text = startingPitcher[9].pitcherStats?.splits?[0]?.stats?.pitching?.standard?.baseOnBalls?.ToString() ?? string.Empty;
                    }

                    if (StartingPitcher.Children[8] is Grid colGridK && colGridK.Children[0] is Viewbox viewboxK
                    && viewboxK.Child is TextBlock textblockK)
                    {
                        textblockK.Text = startingPitcher[9].pitcherStats?.splits?[0]?.stats?.pitching?.standard?.strikeOuts?.ToString() ?? string.Empty;
                    }

                    if (StartingPitcher.Children[9] is Grid colGridHR && colGridHR.Children[0] is Viewbox viewboxHR
                    && viewboxHR.Child is TextBlock textblockHR)
                    {
                        textblockHR.Text = startingPitcher[9].pitcherStats?.splits?[0]?.stats?.pitching?.standard?.homeRuns?.ToString() ?? string.Empty;
                    }

                    if (StartingPitcher.Children[10] is Grid colGridAVG && colGridAVG.Children[0] is Viewbox viewboxAVG
                    && viewboxAVG.Child is TextBlock textblockAVG)
                    {
                        textblockAVG.Text = startingPitcher[9].pitcherStats?.splits?[0]?.stats?.pitching?.standard?.avg?.ToString() ?? string.Empty;
                    }

                    if (StartingPitcher.Children[11] is Grid colGridWHIP && colGridWHIP.Children[0] is Viewbox viewboxWHIP
                    && viewboxWHIP.Child is TextBlock textblockWHIP)
                    {
                        textblockWHIP.Text = startingPitcher[9].pitcherStats?.splits?[0]?.stats?.pitching?.standard?.whip?.ToString() ?? string.Empty;
                    }

                    if (StartingPitcher.Children[12] is Grid colGridGB && colGridGB.Children[0] is Viewbox viewboxGB
                    && viewboxGB.Child is TextBlock textblockGB)
                    {
                        textblockGB.Text = startingPitcher[9].pitcherStats?.splits?[0]?.stats?.pitching?.standard?.groundOuts?.ToString() ?? string.Empty;
                    }
                }                                                  
            }
        }
    }

}
