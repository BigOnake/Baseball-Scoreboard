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
        private Storage stats;
        public Window2(string json)
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(json))
            {
                stats = JsonSerializer.Deserialize<Storage>(json);
            }

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

        // Trying to figure out a way on how to change color based on left,right,switch hand
        /*
        private void playerHand(string stat)
        {            
            if (stat == "left")
                HandType.Hand = true;
            else if (stat == "rightHand")
                HandType.Hand = false;
        }
        */
    }
    
    /*
    public static class HandType
    {
        public static bool Hand { get; set; } = false; 
    }
    

    public static class HandType
    {
        public static HandTypeNotifier Instance { get; } = new HandTypeNotifier();
    }

    public class HandTypeNotifier : INotifyPropertyChanged
    {
        private bool _hand;
        public bool Hand
        {
            get => _hand;
            set
            {
                if (_hand != value)
                {
                    _hand = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Hand)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    */
}
