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

            Title.Text = "St. Louis Cardinals";

            VenueName.Text = "Busch Stadium";

            GameDate.Text = "1/10/2025";
            
            // Sample values you want to show in each TextBlock (one for each column)
            string[] columnTexts = { "P", "C", "1B", "2B", "3B", "SS" };

            // Loop through each child of the main TestGrid
            for (int i = 0; i < TestGrid.Children.Count; i++)
            {
                // Each child is a Grid placed in a Grid.Column
                if (TestGrid.Children[i] is Grid columnGrid)
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
                                // Assign new text from the array
                                textBlock.Text = columnTexts[i];
                            }
                        }
                    }
                }
            }


        }
    }

}
