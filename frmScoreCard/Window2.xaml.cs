using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xaml;
using frmScoreCard.Data;

namespace frmScoreCard
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private Master stats;
        public Window2(string json)
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(json))
            {
                stats = JsonSerializer.Deserialize<Master>(json);
            }

            scoreCardTitle();
            venueTable();
            benchTable();
        }

        private void scoreCardTitle()                                            // Title for the ScoreCard
        {                       
            Title.Text = "St. Louis Cardinals";            
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


    }
}
