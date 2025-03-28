
namespace BaseballScoreboard.Forms
{
    partial class frmSearchTeam
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblHomeTeam = new Label();
            lblGuestTeam = new Label();
            lblHomePlayers = new Label();
            lblGuestPlayer = new Label();
            lblHomeBench = new Label();
            lblGuestBench = new Label();
            lblHomeBullpen = new Label();
            lblGuestBullpen = new Label();
            cBoxHomePlayers = new ComboBox();
            cBoxHomeBench = new ComboBox();
            cBoxHomeBullpen = new ComboBox();
            cBoxGuestBench = new ComboBox();
            cBoxGuestBullpen = new ComboBox();
            lBoxHomePlayers = new ListBox();
            cBoxHomeTeams = new ComboBox();
            cBoxGuestTeams = new ComboBox();
            cBoxGuestPlayers = new ComboBox();
            lBoxGuestPlayers = new ListBox();
            btnHomePlayersRemove = new Button();
            btnHomePlayersClear = new Button();
            btnGuestPlayersRemove = new Button();
            btnGuestPlayersClear = new Button();
            lblDate = new Label();
            lBoxUmpires = new ListBox();
            lblUmpire = new Label();
            button2 = new Button();
            SuspendLayout();
            // 
            // lblHomeTeam
            // 
            lblHomeTeam.AutoSize = true;
            lblHomeTeam.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHomeTeam.ForeColor = Color.White;
            lblHomeTeam.Location = new Point(299, 55);
            lblHomeTeam.Name = "lblHomeTeam";
            lblHomeTeam.Size = new Size(141, 31);
            lblHomeTeam.TabIndex = 0;
            lblHomeTeam.Text = "Home Team";
            // 
            // lblGuestTeam
            // 
            lblGuestTeam.AutoSize = true;
            lblGuestTeam.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGuestTeam.ForeColor = Color.White;
            lblGuestTeam.Location = new Point(976, 27);
            lblGuestTeam.Name = "lblGuestTeam";
            lblGuestTeam.Size = new Size(137, 31);
            lblGuestTeam.TabIndex = 0;
            lblGuestTeam.Text = "Guest Team";
            // 
            // lblHomePlayers
            // 
            lblHomePlayers.AutoSize = true;
            lblHomePlayers.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHomePlayers.ForeColor = Color.White;
            lblHomePlayers.Location = new Point(103, 113);
            lblHomePlayers.Name = "lblHomePlayers";
            lblHomePlayers.Size = new Size(80, 31);
            lblHomePlayers.TabIndex = 3;
            lblHomePlayers.Text = "Player";
            // 
            // lblGuestPlayer
            // 
            lblGuestPlayer.AutoSize = true;
            lblGuestPlayer.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGuestPlayer.ForeColor = Color.White;
            lblGuestPlayer.Location = new Point(777, 109);
            lblGuestPlayer.Name = "lblGuestPlayer";
            lblGuestPlayer.Size = new Size(80, 31);
            lblGuestPlayer.TabIndex = 3;
            lblGuestPlayer.Text = "Player";
            // 
            // lblHomeBench
            // 
            lblHomeBench.AutoSize = true;
            lblHomeBench.Location = new Point(299, 124);
            lblHomeBench.Name = "lblHomeBench";
            lblHomeBench.Size = new Size(49, 20);
            lblHomeBench.TabIndex = 3;
            lblHomeBench.Text = "Bench";
            // 
            // lblGuestBench
            // 
            lblGuestBench.AutoSize = true;
            lblGuestBench.Location = new Point(973, 120);
            lblGuestBench.Name = "lblGuestBench";
            lblGuestBench.Size = new Size(49, 20);
            lblGuestBench.TabIndex = 3;
            lblGuestBench.Text = "Bench";
            // 
            // lblHomeBullpen
            // 
            lblHomeBullpen.AutoSize = true;
            lblHomeBullpen.Location = new Point(473, 122);
            lblHomeBullpen.Name = "lblHomeBullpen";
            lblHomeBullpen.Size = new Size(59, 20);
            lblHomeBullpen.TabIndex = 3;
            lblHomeBullpen.Text = "Bullpen";
            // 
            // lblGuestBullpen
            // 
            lblGuestBullpen.AutoSize = true;
            lblGuestBullpen.Location = new Point(1143, 120);
            lblGuestBullpen.Name = "lblGuestBullpen";
            lblGuestBullpen.Size = new Size(59, 20);
            lblGuestBullpen.TabIndex = 3;
            lblGuestBullpen.Text = "Bullpen";
            // 
            // cBoxHomePlayers
            // 
            cBoxHomePlayers.AutoCompleteMode = AutoCompleteMode.Append;
            cBoxHomePlayers.AutoCompleteSource = AutoCompleteSource.ListItems;
            cBoxHomePlayers.FormattingEnabled = true;
            cBoxHomePlayers.IntegralHeight = false;
            cBoxHomePlayers.Location = new Point(42, 147);
            cBoxHomePlayers.MaxDropDownItems = 10;
            cBoxHomePlayers.Name = "cBoxHomePlayers";
            cBoxHomePlayers.Size = new Size(206, 28);
            cBoxHomePlayers.Sorted = true;
            cBoxHomePlayers.TabIndex = 5;
            cBoxHomePlayers.SelectedIndexChanged += cBoxHomePlayers_SelectedIndexChanged;
            // 
            // cBoxHomeBench
            // 
            cBoxHomeBench.DropDownStyle = ComboBoxStyle.Simple;
            cBoxHomeBench.FormattingEnabled = true;
            cBoxHomeBench.Location = new Point(299, 147);
            cBoxHomeBench.Name = "cBoxHomeBench";
            cBoxHomeBench.Size = new Size(140, 142);
            cBoxHomeBench.Sorted = true;
            cBoxHomeBench.TabIndex = 5;
            // 
            // cBoxHomeBullpen
            // 
            cBoxHomeBullpen.DropDownStyle = ComboBoxStyle.Simple;
            cBoxHomeBullpen.FormattingEnabled = true;
            cBoxHomeBullpen.Location = new Point(473, 145);
            cBoxHomeBullpen.Name = "cBoxHomeBullpen";
            cBoxHomeBullpen.Size = new Size(140, 262);
            cBoxHomeBullpen.Sorted = true;
            cBoxHomeBullpen.TabIndex = 5;
            // 
            // cBoxGuestBench
            // 
            cBoxGuestBench.DropDownStyle = ComboBoxStyle.Simple;
            cBoxGuestBench.FormattingEnabled = true;
            cBoxGuestBench.Location = new Point(973, 143);
            cBoxGuestBench.Name = "cBoxGuestBench";
            cBoxGuestBench.Size = new Size(140, 142);
            cBoxGuestBench.Sorted = true;
            cBoxGuestBench.TabIndex = 5;
            // 
            // cBoxGuestBullpen
            // 
            cBoxGuestBullpen.DropDownStyle = ComboBoxStyle.Simple;
            cBoxGuestBullpen.FormattingEnabled = true;
            cBoxGuestBullpen.Location = new Point(1143, 145);
            cBoxGuestBullpen.Name = "cBoxGuestBullpen";
            cBoxGuestBullpen.Size = new Size(140, 262);
            cBoxGuestBullpen.Sorted = true;
            cBoxGuestBullpen.TabIndex = 5;
            // 
            // lBoxHomePlayers
            // 
            lBoxHomePlayers.DrawMode = DrawMode.OwnerDrawFixed;
            lBoxHomePlayers.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lBoxHomePlayers.FormattingEnabled = true;
            lBoxHomePlayers.Location = new Point(42, 181);
            lBoxHomePlayers.Name = "lBoxHomePlayers";
            lBoxHomePlayers.Size = new Size(208, 204);
            lBoxHomePlayers.TabIndex = 6;
            lBoxHomePlayers.DrawItem += lBoxHomePlayers_DrawItem;
            // 
            // cBoxHomeTeams
            // 
            cBoxHomeTeams.AutoCompleteMode = AutoCompleteMode.Append;
            cBoxHomeTeams.AutoCompleteSource = AutoCompleteSource.ListItems;
            cBoxHomeTeams.FormattingEnabled = true;
            cBoxHomeTeams.IntegralHeight = false;
            cBoxHomeTeams.Location = new Point(264, 86);
            cBoxHomeTeams.MaxDropDownItems = 10;
            cBoxHomeTeams.Name = "cBoxHomeTeams";
            cBoxHomeTeams.Size = new Size(208, 28);
            cBoxHomeTeams.Sorted = true;
            cBoxHomeTeams.TabIndex = 9;
            cBoxHomeTeams.SelectedIndexChanged += cBoxHomeTeams_SelectedIndexChanged;
            // 
            // cBoxGuestTeams
            // 
            cBoxGuestTeams.AutoCompleteMode = AutoCompleteMode.Append;
            cBoxGuestTeams.AutoCompleteSource = AutoCompleteSource.ListItems;
            cBoxGuestTeams.FormattingEnabled = true;
            cBoxGuestTeams.IntegralHeight = false;
            cBoxGuestTeams.Location = new Point(941, 61);
            cBoxGuestTeams.MaxDropDownItems = 10;
            cBoxGuestTeams.Name = "cBoxGuestTeams";
            cBoxGuestTeams.Size = new Size(208, 28);
            cBoxGuestTeams.Sorted = true;
            cBoxGuestTeams.TabIndex = 10;
            cBoxGuestTeams.SelectedIndexChanged += cBoxGuestTeams_SelectedIndexChanged;
            // 
            // cBoxGuestPlayers
            // 
            cBoxGuestPlayers.AutoCompleteMode = AutoCompleteMode.Append;
            cBoxGuestPlayers.AutoCompleteSource = AutoCompleteSource.ListItems;
            cBoxGuestPlayers.FormattingEnabled = true;
            cBoxGuestPlayers.IntegralHeight = false;
            cBoxGuestPlayers.Location = new Point(713, 147);
            cBoxGuestPlayers.MaxDropDownItems = 10;
            cBoxGuestPlayers.Name = "cBoxGuestPlayers";
            cBoxGuestPlayers.Size = new Size(208, 28);
            cBoxGuestPlayers.Sorted = true;
            cBoxGuestPlayers.TabIndex = 11;
            cBoxGuestPlayers.SelectedIndexChanged += cBoxGuestPlayers_SelectedIndexChanged;
            // 
            // lBoxGuestPlayers
            // 
            lBoxGuestPlayers.DrawMode = DrawMode.OwnerDrawFixed;
            lBoxGuestPlayers.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lBoxGuestPlayers.FormattingEnabled = true;
            lBoxGuestPlayers.Location = new Point(713, 181);
            lBoxGuestPlayers.Name = "lBoxGuestPlayers";
            lBoxGuestPlayers.Size = new Size(208, 204);
            lBoxGuestPlayers.TabIndex = 12;
            lBoxGuestPlayers.DrawItem += lBoxGuestPlayers_DrawItem;
            // 
            // btnHomePlayersRemove
            // 
            btnHomePlayersRemove.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHomePlayersRemove.Location = new Point(40, 389);
            btnHomePlayersRemove.Name = "btnHomePlayersRemove";
            btnHomePlayersRemove.Size = new Size(106, 35);
            btnHomePlayersRemove.TabIndex = 13;
            btnHomePlayersRemove.Text = "Remove";
            btnHomePlayersRemove.UseVisualStyleBackColor = true;
            btnHomePlayersRemove.Click += btnHomePlayersRemove_Click;
            // 
            // btnHomePlayersClear
            // 
            btnHomePlayersClear.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHomePlayersClear.Location = new Point(152, 389);
            btnHomePlayersClear.Name = "btnHomePlayersClear";
            btnHomePlayersClear.Size = new Size(96, 35);
            btnHomePlayersClear.TabIndex = 14;
            btnHomePlayersClear.Text = "Clear";
            btnHomePlayersClear.UseVisualStyleBackColor = true;
            btnHomePlayersClear.Click += btnHomePlayersClear_Click;
            // 
            // btnGuestPlayersRemove
            // 
            btnGuestPlayersRemove.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuestPlayersRemove.Location = new Point(713, 387);
            btnGuestPlayersRemove.Name = "btnGuestPlayersRemove";
            btnGuestPlayersRemove.Size = new Size(106, 35);
            btnGuestPlayersRemove.TabIndex = 15;
            btnGuestPlayersRemove.Text = "Remove";
            btnGuestPlayersRemove.UseVisualStyleBackColor = true;
            btnGuestPlayersRemove.Click += btnGuestPlayersRemove_Click;
            // 
            // btnGuestPlayersClear
            // 
            btnGuestPlayersClear.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuestPlayersClear.Location = new Point(825, 387);
            btnGuestPlayersClear.Name = "btnGuestPlayersClear";
            btnGuestPlayersClear.Size = new Size(96, 35);
            btnGuestPlayersClear.TabIndex = 16;
            btnGuestPlayersClear.Text = "Clear";
            btnGuestPlayersClear.UseVisualStyleBackColor = true;
            btnGuestPlayersClear.Click += btnGuestPlayersClear_Click;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDate.ForeColor = Color.White;
            lblDate.Location = new Point(574, 46);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(0, 38);
            lblDate.TabIndex = 17;
            lblDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lBoxUmpires
            // 
            lBoxUmpires.DrawMode = DrawMode.OwnerDrawFixed;
            lBoxUmpires.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lBoxUmpires.FormattingEnabled = true;
            lBoxUmpires.Location = new Point(272, 465);
            lBoxUmpires.Name = "lBoxUmpires";
            lBoxUmpires.Size = new Size(206, 124);
            lBoxUmpires.TabIndex = 19;
            lBoxUmpires.DrawItem += lBoxUmpires_DrawItem;
            // 
            // lblUmpire
            // 
            lblUmpire.BackColor = Color.Gold;
            lblUmpire.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUmpire.ForeColor = Color.White;
            lblUmpire.Location = new Point(272, 432);
            lblUmpire.Name = "lblUmpire";
            lblUmpire.Padding = new Padding(20, 0, 20, 0);
            lblUmpire.Size = new Size(206, 36);
            lblUmpire.TabIndex = 20;
            lblUmpire.Text = "UMPIRES";
            lblUmpire.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            button2.Location = new Point(763, 499);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 21;
            button2.Text = "Test";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // frmSearchTeam
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(196, 30, 58);
            ClientSize = new Size(1315, 627);
            Controls.Add(button2);
            Controls.Add(lblUmpire);
            Controls.Add(lBoxUmpires);
            Controls.Add(lblDate);
            Controls.Add(btnGuestPlayersClear);
            Controls.Add(btnGuestPlayersRemove);
            Controls.Add(btnHomePlayersClear);
            Controls.Add(btnHomePlayersRemove);
            Controls.Add(lBoxGuestPlayers);
            Controls.Add(cBoxGuestPlayers);
            Controls.Add(cBoxGuestTeams);
            Controls.Add(cBoxHomeTeams);
            Controls.Add(lBoxHomePlayers);
            Controls.Add(cBoxGuestBullpen);
            Controls.Add(cBoxHomeBullpen);
            Controls.Add(cBoxGuestBench);
            Controls.Add(cBoxHomeBench);
            Controls.Add(cBoxHomePlayers);
            Controls.Add(lblGuestPlayer);
            Controls.Add(lblGuestBench);
            Controls.Add(lblHomeBench);
            Controls.Add(lblGuestBullpen);
            Controls.Add(lblHomeBullpen);
            Controls.Add(lblHomePlayers);
            Controls.Add(lblGuestTeam);
            Controls.Add(lblHomeTeam);
            Name = "frmSearchTeam";
            Text = "Search Team";
            Load += frmSearchTeam_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHomeTeam;
        private Label lblGuestTeam;
        private Label lblHomePlayers;
        private Label lblGuestPlayer;
        private Label lblHomeBench;
        private Label lblGuestBench;
        private Label lblHomeBullpen;
        private Label lblGuestBullpen;
        private ComboBox cBoxHomePlayers;
        private ComboBox cBoxHomeBench;
        private ComboBox cBoxHomeBullpen;
        private ComboBox cBoxGuestBench;
        private ComboBox cBoxGuestBullpen;
        private ListBox lBoxHomePlayers;
        private ComboBox cBoxHomeTeams;
        private ComboBox cBoxGuestTeams;
        private ComboBox cBoxGuestPlayers;
        private ListBox lBoxGuestPlayers;
        private Button btnHomePlayersRemove;
        private Button btnHomePlayersClear;
        private Button btnGuestPlayersRemove;
        private Button btnGuestPlayersClear;
        private Label lblDate;
        private ListBox lBoxUmpires;
        private Label lblUmpire;
        private Button button2;
    }
}