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
using static System.Runtime.InteropServices.JavaScript.JSType;
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
            foreach (KeyValuePair<string, int> team in data.teams)
            {
                cBoxHomeTeams.Items.Add(team.Key);
                cBoxGuestTeams.Items.Add(team.Key);
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
        private void cBoxGuestPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddPlayers(cBoxGuestPlayers, lBoxGuestPlayers);
        }

        private void cBoxHomePlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddPlayers(cBoxHomePlayers, lBoxHomePlayers);
        }

        private void AddPlayers(ComboBox cBox, ListBox lBox)
        {
            if (cBox.SelectedIndex != -1 && cBox.SelectedItem != null)
            {
                if (!lBox.Items.Contains(cBox.SelectedItem))
                {
                    lBox.Items.Add(cBox.SelectedItem);
                }
            }
        }

        private void AddShohei_Click_1(object sender, EventArgs e)
        {
            //txtTest.Text = Controller.ReturnShohei().fullName;
        }

        private void cBoxGuestTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayPlayers(cBoxGuestTeams, cBoxGuestPlayers);
        }

        private void cBoxHomeTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayPlayers(cBoxHomeTeams, cBoxHomePlayers);
        }

        private void DisplayPlayers(ComboBox src, ComboBox dst)
        {
            dst.Items.Clear();

            if (src.SelectedIndex >= 0 && src.SelectedItem != null)
            {
                StorageTest storageData = new StorageTest();
                ApiTest rosterData = new ApiTest();
                int teamId;

                try
                {
                    teamId = storageData.teams[(string)src.SelectedItem];
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{(string)src.SelectedItem} could not be found.");
                    return;
                }

                storageData.rosterList = rosterData.GetRoster(teamId);

                if (storageData.rosterList.roster != null)
                {
                    foreach (People p in storageData.rosterList.roster)
                    {
                        if (p.person != null && p.person.fullName != null)
                            dst.Items.Add(p.person.fullName);
                    }
                }
            }
        }

        private void ShowTeams(ComboBox cBox)
        {
            SortedList<string, int> data = Controller.GetTeams();


            string text = cBox.Text;
            if (text == "")
            {
                foreach (KeyValuePair<string, int> team in data)
                {
                    if (!cBox.Items.Contains(team.Key))
                    {
                        cBox.Items.Add(team.Key);
                    }
                }
            }
            else
            {
                cBox.Items.Clear();
                foreach (KeyValuePair<string, int> team in data)
                {
                    if (team.Key.Contains(text, StringComparison.OrdinalIgnoreCase))
                    {
                        cBox.Items.Add(team.Key);
                    }
                }
            }

            cBox.Select(text.Length, 0);
            cBox.DroppedDown = true;
        }

        private void cBoxHomeTeams_TextChanged(object sender, EventArgs e)
        {
            ShowTeams(cBoxHomeTeams);
        }

        private void cBoxGuestTeams_TextChanged(object sender, EventArgs e)
        {
            ShowTeams(cBoxGuestTeams);
        }

        private void btnHomePlayersRemove_Click(object sender, EventArgs e)
        {
            RemovePlayer(lBoxHomePlayers);
        }

        private void btnGuestPlayersRemove_Click(object sender, EventArgs e)
        {
            RemovePlayer(lBoxGuestPlayers);
        }

        private void RemovePlayer(ListBox lBox)
        {
            if (lBox.SelectedIndex != -1)
            {
                lBox.Items.RemoveAt(lBox.SelectedIndex);
            }
        }

        private void btnHomePlayersClear_Click(object sender, EventArgs e)
        {
            RemovePlayers(lBoxHomePlayers);
        }

        private void btnGuestPlayersClear_Click(object sender, EventArgs e)
        {
            RemovePlayers(lBoxGuestPlayers);
        }

        private void RemovePlayers(ListBox lBox)
        {
            lBox.Items.Clear();
            cBoxHomeTeams.Select(text.Length, 0);
            cBoxHomeTeams.DroppedDown = true;
        }
    }
}
