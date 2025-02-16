namespace BaseballScoreboard.Data
{
    internal class Storage
    {
        private List<Player> playerList = new();
        private List<Team> teamList = new();

        private RosterList rosterList;
        private SortedList<string, int> teams;

        public Storage()
        {
            rosterList = new RosterList();
            teams = Controller.GetTeams();
        }

        public void AddPlayer(Player p)
        {
            playerList.Add(p);
        }

        public string[] GetAllTeams()
        {
            List<string> teams = new();

            foreach (Team t in teamList)
            {
                teams.Add(t.name);
            }

            return teams.ToArray();
        }

        public void setAllTeams(List<Team> t) { teamList = t; }

        public void setRosterList(RosterList rl)
        {
            rosterList = rl;
        }

        public int getTeamId(string teamName)
        {
            return teams[teamName];
        }
    }

    internal class Player
    {
        public int? id { get; set; }
        public string? fullName { get; set; }
        public string? primaryNumber { get; set; }
    }

    internal class Team
    {
        public int? id { get; set; }
        public string? name { get; set; }
    }

    internal class Person
    {
        public int? id { get; set; }
        public string? fullName { get; set; }
    }

    internal class People()
    {
        public Person? person { get; set; }
        public string? jerseyNumber { get; set; }
        public Person? position { get; set; }
        public Person? status { get; set; }
        public int? parentTeamId { get; set; }
    }

    internal class RosterList
    {
        public List<People>? roster { get; set; }
    }
}