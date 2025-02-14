
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
            lblDate = new Label();
            txtDate = new TextBox();
            cBoxHomePlayers = new ComboBox();
            cBoxHomeBench = new ComboBox();
            cBoxHomeBullpen = new ComboBox();
            cBoxGuestBench = new ComboBox();
            cBoxGuestBullpen = new ComboBox();
            lBoxHomePlayers = new ListBox();
            AddShohei = new Button();
            txtTest = new TextBox();
            cBoxHomeTeams = new ComboBox();
            cBoxGuestTeams = new ComboBox();
            cBoxGuestPlayers = new ComboBox();
            lBoxGuestPlayers = new ListBox();
            btnHomePlayersRemove = new Button();
            btnHomePlayersClear = new Button();
            btnGuestPlayersRemove = new Button();
            btnGuestPlayersClear = new Button();
            SuspendLayout();
            // 
            // lblHomeTeam
            // 
            lblHomeTeam.AutoSize = true;
            lblHomeTeam.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHomeTeam.ForeColor = Color.White;
            lblHomeTeam.Location = new Point(57, 27);
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
            lblGuestTeam.Location = new Point(731, 25);
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
            lblHomePlayers.Location = new Point(81, 113);
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
            lblGuestPlayer.Location = new Point(752, 111);
            lblGuestPlayer.Name = "lblGuestPlayer";
            lblGuestPlayer.Size = new Size(80, 31);
            lblGuestPlayer.TabIndex = 3;
            lblGuestPlayer.Text = "Player";
            // 
            // lblHomeBench
            // 
            lblHomeBench.AutoSize = true;
            lblHomeBench.Location = new Point(307, 122);
            lblHomeBench.Name = "lblHomeBench";
            lblHomeBench.Size = new Size(49, 20);
            lblHomeBench.TabIndex = 3;
            lblHomeBench.Text = "Bench";
            // 
            // lblGuestBench
            // 
            lblGuestBench.AutoSize = true;
            lblGuestBench.Location = new Point(907, 122);
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
            lblGuestBullpen.Location = new Point(1077, 122);
            lblGuestBullpen.Name = "lblGuestBullpen";
            lblGuestBullpen.Size = new Size(59, 20);
            lblGuestBullpen.TabIndex = 3;
            lblGuestBullpen.Text = "Bullpen";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(441, 36);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(41, 20);
            lblDate.TabIndex = 0;
            lblDate.Text = "Date";
            // 
            // txtDate
            // 
            txtDate.Location = new Point(398, 59);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(125, 27);
            txtDate.TabIndex = 1;
            // 
            // cBoxHomePlayers
            // 
            cBoxHomePlayers.FormattingEnabled = true;
            cBoxHomePlayers.Location = new Point(42, 147);
            cBoxHomePlayers.Name = "cBoxHomePlayers";
            cBoxHomePlayers.Size = new Size(156, 28);
            cBoxHomePlayers.Sorted = true;
            cBoxHomePlayers.TabIndex = 5;
            cBoxHomePlayers.SelectedIndexChanged += cBoxHomePlayers_SelectedIndexChanged;
            cBoxHomePlayers.TextChanged += cBoxHomePlayer_TextChanged;
            // 
            // cBoxHomeBench
            // 
            cBoxHomeBench.DropDownStyle = ComboBoxStyle.Simple;
            cBoxHomeBench.FormattingEnabled = true;
            cBoxHomeBench.Location = new Point(307, 145);
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
            cBoxGuestBench.Location = new Point(907, 145);
            cBoxGuestBench.Name = "cBoxGuestBench";
            cBoxGuestBench.Size = new Size(140, 142);
            cBoxGuestBench.Sorted = true;
            cBoxGuestBench.TabIndex = 5;
            // 
            // cBoxGuestBullpen
            // 
            cBoxGuestBullpen.DropDownStyle = ComboBoxStyle.Simple;
            cBoxGuestBullpen.FormattingEnabled = true;
            cBoxGuestBullpen.Location = new Point(1077, 147);
            cBoxGuestBullpen.Name = "cBoxGuestBullpen";
            cBoxGuestBullpen.Size = new Size(140, 262);
            cBoxGuestBullpen.Sorted = true;
            cBoxGuestBullpen.TabIndex = 5;
            // 
            // lBoxHomePlayers
            // 
            lBoxHomePlayers.FormattingEnabled = true;
            lBoxHomePlayers.Location = new Point(42, 181);
            lBoxHomePlayers.Name = "lBoxHomePlayers";
            lBoxHomePlayers.Size = new Size(156, 204);
            lBoxHomePlayers.TabIndex = 6;
            // 
            // AddShohei
            // 
            AddShohei.Location = new Point(1096, 12);
            AddShohei.Name = "AddShohei";
            AddShohei.Size = new Size(144, 29);
            AddShohei.TabIndex = 7;
            AddShohei.Text = "Add Shohei";
            AddShohei.UseVisualStyleBackColor = true;
            AddShohei.Click += AddShohei_Click_1;
            // 
            // txtTest
            // 
            txtTest.Location = new Point(1096, 58);
            txtTest.Name = "txtTest";
            txtTest.Size = new Size(144, 27);
            txtTest.TabIndex = 8;
            // 
            // cBoxHomeTeams
            // 
            cBoxHomeTeams.AutoCompleteMode = AutoCompleteMode.Append;
            cBoxHomeTeams.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cBoxHomeTeams.FormattingEnabled = true;
            cBoxHomeTeams.Location = new Point(40, 58);
            cBoxHomeTeams.Name = "cBoxHomeTeams";
            cBoxHomeTeams.Size = new Size(183, 28);
            cBoxHomeTeams.Sorted = true;
            cBoxHomeTeams.TabIndex = 9;
            cBoxHomeTeams.SelectedIndexChanged += cBoxHomeTeams_SelectedIndexChanged;
            cBoxHomeTeams.TextChanged += cBoxHomeTeams_TextChanged;
            // 
            // cBoxGuestTeams
            // 
            cBoxGuestTeams.AutoCompleteMode = AutoCompleteMode.Append;
            cBoxGuestTeams.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cBoxGuestTeams.FormattingEnabled = true;
            cBoxGuestTeams.Location = new Point(714, 59);
            cBoxGuestTeams.Name = "cBoxGuestTeams";
            cBoxGuestTeams.Size = new Size(183, 28);
            cBoxGuestTeams.Sorted = true;
            cBoxGuestTeams.TabIndex = 10;
            cBoxGuestTeams.SelectedIndexChanged += cBoxGuestTeams_SelectedIndexChanged;
            cBoxGuestTeams.TextChanged += cBoxGuestTeams_TextChanged;
            // 
            // cBoxGuestPlayers
            // 
            cBoxGuestPlayers.FormattingEnabled = true;
            cBoxGuestPlayers.Location = new Point(714, 145);
            cBoxGuestPlayers.Name = "cBoxGuestPlayers";
            cBoxGuestPlayers.Size = new Size(156, 28);
            cBoxGuestPlayers.Sorted = true;
            cBoxGuestPlayers.TabIndex = 11;
            cBoxGuestPlayers.SelectedIndexChanged += cBoxGuestPlayers_SelectedIndexChanged;
            // 
            // lBoxGuestPlayers
            // 
            lBoxGuestPlayers.FormattingEnabled = true;
            lBoxGuestPlayers.Location = new Point(714, 181);
            lBoxGuestPlayers.Name = "lBoxGuestPlayers";
            lBoxGuestPlayers.Size = new Size(156, 204);
            lBoxGuestPlayers.TabIndex = 12;
            // 
            // btnHomePlayersRemove
            // 
            btnHomePlayersRemove.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHomePlayersRemove.Location = new Point(67, 391);
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
            btnHomePlayersClear.Location = new Point(81, 432);
            btnHomePlayersClear.Name = "btnHomePlayersClear";
            btnHomePlayersClear.Size = new Size(71, 35);
            btnHomePlayersClear.TabIndex = 14;
            btnHomePlayersClear.Text = "Clear";
            btnHomePlayersClear.UseVisualStyleBackColor = true;
            btnHomePlayersClear.Click += btnHomePlayersClear_Click;
            // 
            // btnGuestPlayersRemove
            // 
            btnGuestPlayersRemove.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuestPlayersRemove.Location = new Point(741, 391);
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
            btnGuestPlayersClear.Location = new Point(761, 432);
            btnGuestPlayersClear.Name = "btnGuestPlayersClear";
            btnGuestPlayersClear.Size = new Size(71, 35);
            btnGuestPlayersClear.TabIndex = 16;
            btnGuestPlayersClear.Text = "Clear";
            btnGuestPlayersClear.UseVisualStyleBackColor = true;
            btnGuestPlayersClear.Click += btnGuestPlayersClear_Click;
            // 
            // frmSearchTeam
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(196, 30, 58);
            ClientSize = new Size(1252, 599);
            Controls.Add(btnGuestPlayersClear);
            Controls.Add(btnGuestPlayersRemove);
            Controls.Add(btnHomePlayersClear);
            Controls.Add(btnHomePlayersRemove);
            Controls.Add(lBoxGuestPlayers);
            Controls.Add(cBoxGuestPlayers);
            Controls.Add(cBoxGuestTeams);
            Controls.Add(cBoxHomeTeams);
            Controls.Add(txtTest);
            Controls.Add(AddShohei);
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
            Controls.Add(txtDate);
            Controls.Add(lblGuestTeam);
            Controls.Add(lblDate);
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
        private Label lblDate;
        private TextBox txtDate;
        private ComboBox cBoxHomePlayers;
        private ComboBox cBoxHomeBench;
        private ComboBox cBoxHomeBullpen;
        private ComboBox cBoxGuestBench;
        private ComboBox cBoxGuestBullpen;
        private ListBox lBoxHomePlayers;
        private Button AddShohei;
        private TextBox txtTest;
        private ComboBox cBoxHomeTeams;
        private ComboBox cBoxGuestTeams;
        private ComboBox cBoxGuestPlayers;
        private ListBox lBoxGuestPlayers;
        private Button btnHomePlayersRemove;
        private Button btnHomePlayersClear;
        private Button btnGuestPlayersRemove;
        private Button btnGuestPlayersClear;
    }
}