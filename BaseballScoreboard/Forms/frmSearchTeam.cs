using BaseballScoreboard.Data;
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

namespace BaseballScoreboard.Forms
{
    public partial class frmSearchTeam : Form
    {
        Dictionary<string, int> playersList = new Dictionary<string, int>();
        List<string> teamsList = new List<string>();
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
            StorageTest data = new StorageTest();
            data.teams = Controller.GetTeams();
            foreach (KeyValuePair<int, string> team in data.teams)
            {
                cBoxHomeTeams.Items.Add(team.Value);
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

        private void cBoxHomePlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxHomePlayers.SelectedIndex != -1 && cBoxHomePlayers.SelectedItem != null)
            {
                if (!lBoxHomePlayers.Items.Contains(cBoxHomePlayers.SelectedItem))
                {
                    lBoxHomePlayers.Items.Add(cBoxHomePlayers.SelectedItem);
                }
            }
        }

        private void AddShohei_Click_1(object sender, EventArgs e)
        {
            //txtTest.Text = Controller.ReturnShohei().fullName;
        }

        private void cBoxHomeTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxHomeTeams.SelectedIndex >= 0)
            {
                ApiTest rosterCall = new ApiTest();
                StorageTest data = new StorageTest();

                Controller.GetTeams();

                //data.rosterList = rosterCall.GetRoster();
            }
        }
    }
}
