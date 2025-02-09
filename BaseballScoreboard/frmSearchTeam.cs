using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace BaseballScoreboard
{
    public partial class frmSearchTeam : Form
    {
        Dictionary<string, int> playersList = new Dictionary<string, int>();
        string[] players = { "Nolan Arenado", "Dylan Carlson", "Matt Carpenter", "Steven Matz", "Paul DeJong",
    "Tommy Edman", "Paul Goldschmidt", "Giovanny Gallegos", "Ryan Helsley", "Jordan Hicks",
    "Dakota Hudson", "Tyler O'Neill", "Corey Dickerson", "Adam Wainwright", "Yadier Molina",
    "Harrison Bader", "Juan Yepez", "Lars Nootbaar", "Miles Mikolas", "Jack Flaherty",
    "Alex Reyes", "Génesis Cabrera", "Andrew Knizner", "Edmundo Sosa", "Kodi Whitley",
    "Drew VerHagen", "Nick Wittgren", "Zack Thompson", "Brendan Donovan", "Nolan Gorman",
    "Andre Pallante", "Packy Naughton", "Jake Woodford", "Aaron Brooks", "Conner Capel"};

        public frmSearchTeam()
        {
            InitializeComponent();
        }

        private void frmSearchTeam_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < players.Length; i++)
            {
                playersList.Add(players[i], i);
                cBoxHomePlayers.Items.Add(players[i]);
            }
        }

        private void SearchName(ComboBox cb, Dictionary<string, int> fullList)
        {
            string? autocomplete;

            if (!string.IsNullOrEmpty(cb.Text))
            {
                autocomplete = cb.Text;
                var matchList = GetMatches(fullList, autocomplete.ToUpper());

                if (matchList.Count > 0)
                {
                    cb.Items.Clear();
                    cb.Items.AddRange(matchList.ToArray());
                    cb.Select(autocomplete.Length, 0);
                    return;
                }
                else
                { cb.SelectionStart = autocomplete.Length; }
            }
            else
            {
                cb.Items.Clear();
                cb.Items.AddRange(fullList.Keys.ToArray());
            }
        }

        private List<string> GetMatches(Dictionary<string, int> fullList, string searchTxt)
        {
            List<string> suggestedItems = new List<string>();
            searchTxt = searchTxt.ToUpper();

            foreach (string str in fullList.Keys)
            {
                if (str.ToUpper().Contains(searchTxt))
                {
                    suggestedItems.Add(str);
                }
            }

            return suggestedItems;
        }

        private void cBoxHomePlayer_TextChanged(object sender, EventArgs e)
        {
            SearchName(cBoxHomePlayers, playersList);
        }

        private void cBoxGuestPlayer_TextChanged(object sender, EventArgs e)
        {

        }

        private void cBoxHomePlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cBoxHomePlayers.SelectedItem != null) 
            {
                lBoxHomePlayers.Items.Add(cBoxHomePlayers.SelectedItem);
            }
        }
    }
}
