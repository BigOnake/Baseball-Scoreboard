using System.Text.Json;
using System.Windows;

using frmScoreCard.Data;

namespace frmScoreCard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Storage stats;

        public MainWindow(string json)
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(json))
            {
                stats = JsonSerializer.Deserialize<Storage>(json);

                
            }

            //*****************************************************************************************************
            //  HITTERS TABLE
            //*****************************************************************************************************

            tableRow hitterRowOne = new tableRow();

            hitterRowOne.col1 = " ";
            hitterRowOne.col2 = " ";
            hitterRowOne.col3 = "OPS";
            hitterRowOne.col4 = "BB";
            hitterRowOne.col5 = "3B";
            hitterRowOne.col6 = "RBI";
            hitterRowOne.col7 = "BACON";
            hitterRowOne.col8 = "DP";
            
            DataGridHitters.Items.Add(hitterRowOne);

            if (stats.data.homeTeamSelectedPlayers.Values != null || stats.data.homeTeamSelectedPlayers.Values.Count > 0)
            {
                foreach (PlayerStats p in stats.data.homeTeamSelectedPlayers.Values)
                {
                    tableRow hitterRowFirst = new tableRow();

                    hitterRowFirst.col1 = p.name;
                    hitterRowFirst.col2 = p.position;

                    if (p?.fp?.splits != null && p.fp.splits.Count > 0)
                        hitterRowFirst.col3 = $"1stP: {p.fp.splits[0].stats?.hitting?.standard?.avg} {p.fp.splits[0].stats?.hitting?.standard?.ops} " +
                        $"{p.fp.splits[0].stats?.hitting?.tracking?.hitProbability?.averageValue}";
                    else
                        hitterRowFirst.col3 = "1stP: ~";

                    if (p?.risp?.splits != null && p.risp.splits.Count > 0)
                        hitterRowFirst.col4 = $"RISP: {p.risp.splits[0].stats?.hitting?.standard?.homeRuns} {p.risp.splits[0].stats?.hitting?.standard?.hits} " +
                        $"{p.risp.splits[0].stats?.hitting?.standard?.avg} {p.risp.splits[0].stats?.hitting?.standard?.atBats}";
                    else
                        hitterRowFirst.col4 = "RISP: ~";

                    if (p?.risp2o?.splits != null && p.risp2o.splits.Count > 0)
                        hitterRowFirst.col5 = $"RISP2o: {p.risp2o.splits[0].stats?.hitting?.standard?.homeRuns} {p.risp2o.splits[0].stats?.hitting?.standard?.hits} " +
                        $"{p.risp2o.splits[0].stats?.hitting?.standard?.avg} {p.risp2o.splits[0].stats?.hitting?.standard?.atBats}";
                    else
                        hitterRowFirst.col5 = "RISP2o: ~";

                    if (p?.vsLeft?.splits != null && p.vsLeft.splits.Count > 0)
                        hitterRowFirst.col6 = $"vsLH: {p.vsLeft.splits[0].stats?.hitting?.standard?.homeRuns} {p.vsLeft.splits[0].stats?.hitting?.standard?.hits} " +
                        $"{p.vsLeft.splits[0].stats?.hitting?.standard?.avg} " + $"{p.vsLeft.splits[0].stats?.hitting?.standard?.atBats} " +
                        $"{p.vsLeft.splits[0].stats?.hitting?.standard?.ops}";
                    else
                        hitterRowFirst.col6 = "vsLH: ~";

                    if (p?.vsRight?.splits != null && p.vsRight.splits.Count > 0)
                        hitterRowFirst.col7 = $"vsRH: {p.vsRight.splits[0].stats?.hitting?.standard?.homeRuns} {p.vsRight.splits[0].stats?.hitting?.standard?.hits} " +
                        $"{p.vsRight.splits[0].stats?.hitting?.standard?.avg} " + $"{p.vsRight.splits[0].stats?.hitting?.standard?.atBats} " +
                        $"{p.vsRight.splits[0].stats?.hitting?.standard?.ops}";
                    else
                        hitterRowFirst.col7 = "vsRH: ~";

                    if (p?.plus7?.splits != null && p.plus7.splits.Count > 0)
                        hitterRowFirst.col8 = $"7+: {p.plus7.splits[0].stats?.hitting?.standard?.avg} {p.plus7.splits[0].stats?.hitting?.standard?.ops}";
                    else
                        hitterRowFirst.col8 = "7+ ~";

                    DataGridHitters.Items.Add(hitterRowFirst);

                    // Second Row for each player includes the AVG, K, 2B, HR, R, SB-SBA stats
                    tableRow hitterRowSecond = new tableRow();

                    hitterRowSecond.col1 = " ";
                    hitterRowSecond.col2 = " ";
                   
                    if (p?.hitterStats?.splits != null && p.hitterStats.splits.Count > 0)
                        hitterRowSecond.col3 = p.hitterStats.splits[0].stats?.hitting?.standard?.avg.ToString();                        
                    else
                        hitterRowSecond.col3 = "~";

                    if (p?.hitterStats?.splits != null && p.hitterStats.splits.Count > 0)
                        hitterRowSecond.col4 = p.hitterStats.splits[0].stats?.hitting?.standard?.strikeOuts.ToString();
                    else
                        hitterRowSecond.col4 = "~";

                    if (p?.hitterStats?.splits != null && p.hitterStats.splits.Count > 0)
                        hitterRowSecond.col5 = p.hitterStats.splits[0].stats?.hitting?.standard?.doubles.ToString();
                    else
                        hitterRowSecond.col5 = "~";

                    if (p?.hitterStats?.splits != null && p.hitterStats.splits.Count > 0)
                        hitterRowSecond.col6 = p.hitterStats.splits[0].stats?.hitting?.standard?.homeRuns.ToString();
                    else
                        hitterRowSecond.col6 = "~";

                    if (p?.hitterStats?.splits != null && p.hitterStats.splits.Count > 0)
                        hitterRowSecond.col7 = p.hitterStats.splits[0].stats?.hitting?.standard?.runs.ToString();
                    else
                        hitterRowSecond.col7 = "~";

                    if (p?.hitterStats?.splits != null && p.hitterStats.splits.Count > 0)
                        hitterRowSecond.col8 = $"{p.hitterStats.splits[0].stats?.hitting?.standard?.stolenBases} - {p.hitterStats.splits[0].stats?.hitting?.standard?.caughtStealing}";
                    else
                        hitterRowSecond.col8 = "~";                                     

                    DataGridHitters.Items.Add(hitterRowSecond);                                       

                    // Third Row for each player includes the OPS BB 3B RBI BACON DP stats
                    tableRow hitterRowThird = new tableRow();

                    hitterRowThird.col1 = " ";
                    hitterRowThird.col2 = " ";

                    if (p?.hitterStats?.splits != null && p.hitterStats.splits.Count > 0)
                        hitterRowThird.col3 = p.hitterStats.splits[0].stats?.hitting?.standard?.ops.ToString();
                    else
                        hitterRowThird.col3 = "~";
                    if (p?.hitterStats?.splits != null && p.hitterStats.splits.Count > 0)
                        hitterRowThird.col4 = p.hitterStats.splits[0].stats?.hitting?.standard?.baseOnBalls.ToString();     
                    else
                        hitterRowThird.col4 = "~";
                    if (p?.hitterStats?.splits != null && p.hitterStats.splits.Count > 0)
                        hitterRowThird.col5 = p.hitterStats.splits[0].stats?.hitting?.standard?.triples.ToString();
                    else
                        hitterRowThird.col5 = "~";
                    if (p?.hitterStats?.splits != null && p.hitterStats.splits.Count > 0)
                        hitterRowThird.col6 = p.hitterStats.splits[0].stats?.hitting?.standard?.rbi.ToString();
                    else
                        hitterRowThird.col6 = "~";
                    if (p?.hitterStats?.splits != null && p.hitterStats.splits.Count > 0)
                        hitterRowThird.col7 = p.hitterStats.splits[0].stats?.hitting?.standard?.babip.ToString();
                    else
                        hitterRowThird.col7 = "~";
                    if (p?.hitterStats?.splits != null && p.hitterStats.splits.Count > 0)
                        hitterRowThird.col8 = p.hitterStats.splits[0].stats?.hitting?.standard?.groundIntoDoublePlay.ToString();
                    else
                        hitterRowThird.col8 = "~";                   

                    DataGridHitters.Items.Add(hitterRowThird);
                    
                }
            }


            //*****************************************************************************************************
            //  UMPIRES & SB/SBA + DP TOTAL PER TEAM TABLE
            //*****************************************************************************************************

            // Adding the first row and SB-SBA stats for the Home team
            tableRow umpireRowOne = new tableRow();

            if (stats.data.umps!= null && stats.data.umps.officials != null && stats.data.umps.officials.Count > 0)
                umpireRowOne.col1 = stats.data.umps.officials[0].official.fullName;
            else
                umpireRowOne.col1 = "Umpire: ~~~";

            umpireRowOne.col2 = "R";
            umpireRowOne.col3 = " ";
            umpireRowOne.col4 = " ";
            umpireRowOne.col5 = " ";
            umpireRowOne.col6 = " ";
            umpireRowOne.col7 = "Home Team";

            if (stats.data.homeTeamSB != null && stats.data.homeTeamSB.splits != null && stats.data.homeTeamSB.splits.Count > 0)
                umpireRowOne.col8 = stats.data.homeTeamSB.splits[0].stats.hitting.standard.stolenBases.ToString() + "   " + stats.data.homeTeamSB.splits[0].stats.hitting.standard.caughtStealing.ToString();           
            else
                umpireRowOne.col8 = "~   ~";

            DataGridHitters.Items.Add(umpireRowOne);

            // Adding the second row and DP stats for the Home team
            tableRow umpireRowTwo = new tableRow();

            if (stats.data.umps != null && stats.data.umps.officials != null && stats.data.umps.officials.Count > 0)
                umpireRowTwo.col1 = stats.data.umps.officials[1].official.fullName;
            else
                umpireRowTwo.col1 = "Umpire: ~~~";
            
            umpireRowTwo.col2 = "H";
            umpireRowTwo.col3 = " ";
            umpireRowTwo.col4 = " ";
            umpireRowTwo.col5 = " ";
            umpireRowTwo.col6 = " ";
            umpireRowTwo.col7 = " ";

            if (stats.data.homeTeamSB != null && stats.data.homeTeamSB.splits != null && stats.data.homeTeamSB.splits.Count > 0)
                umpireRowTwo.col8 = stats.data.homeTeamSB.splits[0].stats.hitting.standard.groundIntoDoublePlay.ToString();             
            else
                umpireRowTwo.col8 = "~";

            DataGridHitters.Items.Add(umpireRowTwo);

            // Adding the third row and SB-SBA stats for the Opponent team
            tableRow umpireRowThree = new tableRow();

            if (stats.data.umps != null && stats.data.umps.officials != null && stats.data.umps.officials.Count > 0)
                umpireRowThree.col1 = stats.data.umps.officials[2].official.fullName;
            else
                umpireRowThree.col1 = "Umpire: ~~~";

            umpireRowThree.col2 = "E";
            umpireRowThree.col3 = " ";
            umpireRowThree.col4 = " ";
            umpireRowThree.col5 = " ";
            umpireRowThree.col6 = " ";
            umpireRowThree.col7 = "Opp Team";

            if (stats.data.guestTeamSB != null && stats.data.guestTeamSB.splits != null && stats.data.guestTeamSB.splits.Count > 0)
                umpireRowThree.col8 = stats.data.guestTeamSB.splits[0].stats?.hitting?.standard?.stolenBases.ToString() + "   " + stats.data.guestTeamSB.splits[0].stats.hitting.standard.caughtStealing.ToString();          
            else 
                umpireRowThree.col8 = "~   ~";

            DataGridHitters.Items.Add(umpireRowThree);

            // Adding the fourth row and DP stats for the Opponent team
            tableRow umpireRowFour = new tableRow();

            if (stats.data.umps != null && stats.data.umps.officials != null && stats.data.umps.officials.Count > 0)
                umpireRowFour.col1 = stats.data.umps.officials[3].official.fullName;
            else
                umpireRowFour.col1 = "Umpire: ~~~";

            umpireRowFour.col2 = "LOB";
            umpireRowFour.col3 = " ";
            umpireRowFour.col4 = " ";
            umpireRowFour.col5 = " ";
            umpireRowFour.col6 = " ";
            umpireRowFour.col7 = " ";

            if (stats.data.guestTeamSB != null && stats.data.guestTeamSB.splits != null && stats.data.guestTeamSB.splits.Count > 0)
                umpireRowFour.col8 = stats.data.guestTeamSB.splits[0].stats.hitting.standard.groundIntoDoublePlay.ToString();             
            else
                umpireRowFour.col8 = "~";
            
            DataGridHitters.Items.Add(umpireRowFour);

            //*****************************************************************************************************
            //  PITCHERS TOP TABLE
            //*****************************************************************************************************

            // Loop to populate each pitcher's stats(each pitcher has 2 rows of stats)
            for (int i = 0; i < 5; i++)
            {
                tableRow pitcherTopRowFirst = new tableRow();

                pitcherTopRowFirst.col1 = "Name";
                pitcherTopRowFirst.col2 = "X";
                pitcherTopRowFirst.col3 = "X Y";
                pitcherTopRowFirst.col4 = "X";
                pitcherTopRowFirst.col5 = "X";
                pitcherTopRowFirst.col6 = "X";
                pitcherTopRowFirst.col7 = "X";
                pitcherTopRowFirst.col8 = "X";
                pitcherTopRowFirst.col9 = "X";
                pitcherTopRowFirst.col10 = "X";
                pitcherTopRowFirst.col11 = "X";
                pitcherTopRowFirst.col12 = "X";
                pitcherTopRowFirst.col13 = "X";

                DataGridPitchersTop.Items.Add(pitcherTopRowFirst);

                tableRow pitcherTopRowSecond = new tableRow();

                pitcherTopRowSecond.col1 = " ";
                pitcherTopRowSecond.col2 = " ";
                pitcherTopRowSecond.col3 = " ";
                pitcherTopRowSecond.col4 = " ";
                pitcherTopRowSecond.col5 = " ";
                pitcherTopRowSecond.col6 = " ";
                pitcherTopRowSecond.col7 = " ";
                pitcherTopRowSecond.col8 = " ";
                pitcherTopRowSecond.col9 = " ";
                pitcherTopRowSecond.col10 = " ";
                pitcherTopRowSecond.col11 = " ";
                pitcherTopRowSecond.col12 = "p";
                pitcherTopRowSecond.col13 = "x";

                DataGridPitchersTop.Items.Add(pitcherTopRowSecond);
            }

            //*****************************************************************************************************
            //  BUSCH STADIUM TABLE
            //*****************************************************************************************************

            tableRow buschRowOne = new tableRow();
            
            if (stats.data.venue != null && stats.data.venue.dates != null)
                buschRowOne.col1 = stats.data.venue.dates[0].games[0].venue.name;
            else
                buschRowOne.col1 = "~~~~";

            buschRowOne.col2 = " ";
            buschRowOne.col3 = " ";
            buschRowOne.col4 = " ";
            buschRowOne.col5 = " ";
            buschRowOne.col6 = " ";

            DataGridBuschStadium.Items.Add(buschRowOne);

            if (stats.data.stadium != null && stats.data.stadium.splits != null && stats.data.stadium.splits.Count() > 0)
            {
                for (int i = 0; i < stats.data.stadium.splits.Count(); i++)
                {
                    tableRow buschRow = new tableRow();
                    if (stats.data.stadium.splits[i].pitchType != null && stats.data.stadium.splits[i].pitchType.code != null)
                        buschRow.col1 = stats.data.stadium.splits[i].pitchType.code.ToString();
                    else
                        buschRow.col1 = "~";
                    
                    buschRow.col2 = " ";                                           // Blank column(Mike requested) 
                    
                    if (stats.data.stadium.splits[i].stats.pitching.tracking.releaseSpeed != null && stats.data.stadium.splits[i].stats.pitching.tracking.releaseSpeed.averageValue != null)
                        buschRow.col3 = stats.data.stadium.splits[i].stats.pitching.tracking.releaseSpeed.averageValue.ToString();
                    else
                        buschRow.col3 = "~";

                    buschRow.col4 = " ";                                           // Blank column(Mike requested)
                    
                    if (stats.data.stadium.splits[i].stats.pitching.standard.avg != null)
                        buschRow.col5 = stats.data.stadium.splits[i].stats.pitching.standard.avg.ToString();
                    else
                        buschRow.col5 = "~";

                    if (stats.data.stadium.splits[i].stats.pitching.standard.ops != null)
                        buschRow.col6 = stats.data.stadium.splits[i].stats.pitching.standard.ops.ToString();
                    else
                        buschRow.col6 = "~";

                    DataGridBuschStadium.Items.Add(buschRow);
                }
            }
            
            //*****************************************************************************************************
            //  BENCH TABLE
            //*****************************************************************************************************            

            for (int i = 0; i < 5; i++)
            {                
                tableRow buschRow = new tableRow();

                buschRow.col1 = "X";
                buschRow.col2 = "Name";
                buschRow.col3 = "X";
                buschRow.col4 = "X";
                buschRow.col5 = "X";
                buschRow.col6 = "X";

                DataGridBench.Items.Add(buschRow);
            }

            //*****************************************************************************************************
            //  COACHES TABLE
            //*****************************************************************************************************           
            
            if (stats.data.homeTeamCoaches != null && stats.data.homeTeamCoaches.roster != null && stats.data.homeTeamCoaches.roster.Count() > 0)
            {
                for (int i = 0; i < stats.data.homeTeamCoaches.roster.Count(); i++)
                {
                    tableRow coachRow = new tableRow();
                    
                    if (stats.data.homeTeamCoaches.roster[i].job != null)
                        coachRow.col1 = stats.data.homeTeamCoaches.roster[i].job.ToString();
                    else
                        coachRow.col1 = "~";

                    if (stats.data.homeTeamCoaches.roster[i].person.fullName != null)
                        coachRow.col2 = stats.data.homeTeamCoaches.roster[i].person.fullName.ToString();
                    else
                        coachRow.col2 = "~";

                    DataGridManagers.Items.Add(coachRow);
                }
            }            

            //*****************************************************************************************************
            //  SCORE TABLE
            //*****************************************************************************************************
                        
            tableRow scoreRowOne = new tableRow();
            
            if(stats.data.homeTeamName != null)
                scoreRowOne.col1 = stats.data.homeTeamName;
            else 
                scoreRowOne.col1 = " ";
            
            scoreRowOne.col2 = " ";
            scoreRowOne.col3 = " ";
            scoreRowOne.col4 = " ";
            scoreRowOne.col5 = " ";
            scoreRowOne.col6 = " ";
            scoreRowOne.col7 = " ";
            scoreRowOne.col8 = " ";
            scoreRowOne.col9 = " ";
            scoreRowOne.col10 = " ";
            scoreRowOne.col11 = " ";
            scoreRowOne.col12 = " ";
            scoreRowOne.col13 = " ";
            scoreRowOne.col14 = " ";
            scoreRowOne.col15 = " ";
            scoreRowOne.col16 = " ";
            scoreRowOne.col17 = " ";

            DataGridScore.Items.Add(scoreRowOne);

            tableRow scoreRowTwo = new tableRow();

            if (stats.data.guestTeamName != null)
                scoreRowTwo.col1 = stats.data.guestTeamName;
            else 
                scoreRowTwo.col1 = " ";
            
            scoreRowTwo.col2 = " ";
            scoreRowTwo.col3 = " ";
            scoreRowTwo.col4 = " ";
            scoreRowTwo.col5 = " ";
            scoreRowTwo.col6 = " ";
            scoreRowTwo.col7 = " ";
            scoreRowTwo.col8 = " ";
            scoreRowTwo.col9 = " ";
            scoreRowTwo.col10 = " ";
            scoreRowTwo.col11 = " ";
            scoreRowTwo.col12 = " ";
            scoreRowTwo.col13 = " ";
            scoreRowTwo.col14 = " ";
            scoreRowTwo.col15 = " ";
            scoreRowTwo.col16 = " ";
            scoreRowTwo.col17 = " ";

            DataGridScore.Items.Add(scoreRowTwo);

            //*****************************************************************************************************
            //  PITCHERS BOTTOM TABLE
            //*****************************************************************************************************

            for (int i = 0; i < 6; i++)
            { 
                tableRow pitcherBottomRowOne = new tableRow();                 // Pitcher stat row

                pitcherBottomRowOne.col1 = "Name";
                pitcherBottomRowOne.col2 = "X";
                pitcherBottomRowOne.col3 = "X";
                pitcherBottomRowOne.col4 = "X";
                pitcherBottomRowOne.col5 = "X";
                pitcherBottomRowOne.col6 = "X";
                pitcherBottomRowOne.col7 = "X";
                pitcherBottomRowOne.col8 = "X";

                DataGridPitchersBottom.Items.Add(pitcherBottomRowOne);         

                tableRow pitcherBottomRowTwo = new tableRow();                // Pitcher pitching stat row

                pitcherBottomRowTwo.col1 = "X Y";
                pitcherBottomRowTwo.col2 = "Z";
                pitcherBottomRowTwo.col3 = "X Y";
                pitcherBottomRowTwo.col4 = "Z";
                pitcherBottomRowTwo.col5 = "X Y";
                pitcherBottomRowTwo.col6 = "Z";
                pitcherBottomRowTwo.col7 = "X Y";
                pitcherBottomRowTwo.col8 = "Z";

                DataGridPitchersBottom.Items.Add(pitcherBottomRowTwo);
            }
        }

        // *****************************************************************************************************
        //  This class is used to create a row of data for the DataGrid, more columns can be added as needed.
        // *****************************************************************************************************

        public class tableRow
        {
            public string col1 { get; set; }
            public string col2 { get; set; }
            public string col3 { get; set; }
            public string col4 { get; set; }
            public string col5 { get; set; }
            public string col6 { get; set; }
            public string col7 { get; set; }
            public string col8 { get; set; }
            public string col9 { get; set; }
            public string col10 { get; set; }
            public string col11 { get; set; }
            public string col12 { get; set; }
            public string col13 { get; set; }
            public string col14 { get; set; }
            public string col15 { get; set; }
            public string col16 { get; set; }
            public string col17 { get; set; }
            public string col18 { get; set; }
            public string col19 { get; set; }
            public string col20 { get; set; }
        }

        private void MainWindow_Loaded(object sender, EventArgs e)
        {

        }

    }

    

}