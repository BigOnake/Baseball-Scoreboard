using frmScoreCard.Data;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace frmScoreCard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Master stats;

        public MainWindow(string json)
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(json))
            {
                stats = JsonSerializer.Deserialize<Master>(json);
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

            // Loop to populate each hitter's stats(each hitter has 3 rows of stats)
            for (int i = 0; i < 9; i++)
            {
                tableRow hitterRowFirst = new tableRow();                

                hitterRowFirst.col1 = "Hitter Name";
                hitterRowFirst.col2 = "POS";
                hitterRowFirst.col3 = "1stP: A B C";   
                hitterRowFirst.col4 = "RISP: A-B C D";
                hitterRowFirst.col5 = "RISP2o: A-B C D";
                hitterRowFirst.col6 = "vsLH: A-B C D E";
                hitterRowFirst.col7 = "vsRH: A-B C D E";
                hitterRowFirst.col8 = "7+: A B";

                DataGridHitters.Items.Add(hitterRowFirst);

                tableRow hitterRowSecond = new tableRow();

                hitterRowSecond.col1 = " ";
                hitterRowSecond.col2 = " ";
                hitterRowSecond.col3 = "X";
                hitterRowSecond.col4 = "X";
                hitterRowSecond.col5 = "X";
                hitterRowSecond.col6 = "X";
                hitterRowSecond.col7 = "X";
                hitterRowSecond.col8 = "X Y";

                DataGridHitters.Items.Add(hitterRowSecond);

                tableRow hitterRowThird = new tableRow();

                hitterRowThird.col1 = " ";
                hitterRowThird.col2 = " ";
                hitterRowThird.col3 = "X";
                hitterRowThird.col4 = "X";
                hitterRowThird.col5 = "X";
                hitterRowThird.col6 = "X";
                hitterRowThird.col7 = "X";
                hitterRowThird.col8 = "X";

                DataGridHitters.Items.Add(hitterRowThird);
            }

            //*****************************************************************************************************
            //  UMPIRES & SB/SBA + DP TOTAL PER TEAM TABLE
            //*****************************************************************************************************
            
            tableRow umpireRowOne = new tableRow();

            umpireRowOne.col1 = "Umpire Name";
            umpireRowOne.col2 = "R";
            umpireRowOne.col3 = " ";
            umpireRowOne.col4 = " ";
            umpireRowOne.col5 = " ";
            umpireRowOne.col6 = " ";
            umpireRowOne.col7 = "Home Team";
            umpireRowOne.col8 = "X Y";           // SB-SBA stat Total for selected Home team

            DataGridHitters.Items.Add(umpireRowOne);
            
            tableRow umpireRowTwo = new tableRow();

            umpireRowTwo.col1 = "Umpire Name";
            umpireRowTwo.col2 = "H";
            umpireRowTwo.col3 = " ";
            umpireRowTwo.col4 = " ";
            umpireRowTwo.col5 = " ";
            umpireRowTwo.col6 = " ";
            umpireRowTwo.col7 = " ";
            umpireRowTwo.col8 = "X";             // DP stat Total for selected Home team

            DataGridHitters.Items.Add(umpireRowTwo);

            tableRow umpireRowThree = new tableRow();

            umpireRowThree.col1 = "Umpire Name";
            umpireRowThree.col2 = "E";
            umpireRowThree.col3 = " ";
            umpireRowThree.col4 = " ";
            umpireRowThree.col5 = " ";
            umpireRowThree.col6 = " ";
            umpireRowThree.col7 = "Opp Team";
            umpireRowThree.col8 = "X Y";          // SB-SBA stat Total for selected Opponent team

            DataGridHitters.Items.Add(umpireRowThree);

            tableRow umpireRowFour = new tableRow();

            umpireRowFour.col1 = "Umpire Name";
            umpireRowFour.col2 = "LOB";
            umpireRowFour.col3 = " ";
            umpireRowFour.col4 = " ";
            umpireRowFour.col5 = " ";
            umpireRowFour.col6 = " ";
            umpireRowFour.col7 = " ";
            umpireRowFour.col8 = "X";             // SB-SBA stat Total for selected Opponent team

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

            for (int i = 0; i < 5; i++)
            {
                tableRow buschRow = new tableRow();

                buschRow.col1 = "X";
                buschRow.col2 = "X";
                buschRow.col3 = "X";
                buschRow.col4 = "X";
                buschRow.col5 = "X";
                buschRow.col6 = "X";

                DataGridBuschStadium.Items.Add(buschRow);
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

            for (int i = 0; i < 8; i++)
            {                
                tableRow coachRow = new tableRow();

                coachRow.col1 = "X";
                coachRow.col2 = "X";
                
                DataGridManagers.Items.Add(coachRow);
            }

            //*****************************************************************************************************
            //  SCORE TABLE
            //*****************************************************************************************************
                        
            tableRow scoreRowOne = new tableRow();
            
            scoreRowOne.col1 = "Team Name";
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

            scoreRowTwo.col1 = "Opp Name";
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