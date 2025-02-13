
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
            txtGuestTeam = new TextBox();
            lblHomePlayers = new Label();
            lblGuestPlayer = new Label();
            lblGuestPos = new Label();
            lblHomeBench = new Label();
            lblGuestBench = new Label();
            lblHomeBullpen = new Label();
            lblGuestBullpen = new Label();
            lblDate = new Label();
            txtDate = new TextBox();
            cBoxHomePlayers = new ComboBox();
            cBoxHomeBench = new ComboBox();
            cBoxHomeBullpen = new ComboBox();
            cBoxGuestPlayers = new ComboBox();
            cBoxGuestBench = new ComboBox();
            cBoxGuestBullpen = new ComboBox();
            lBoxHomePlayers = new ListBox();
            AddShohei = new Button();
            txtTest = new TextBox();
            cBoxHomeTeams = new ComboBox();
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
            lblGuestTeam.Location = new Point(585, 36);
            lblGuestTeam.Name = "lblGuestTeam";
            lblGuestTeam.Size = new Size(86, 20);
            lblGuestTeam.TabIndex = 0;
            lblGuestTeam.Text = "Guest Team";
            // 
            // txtGuestTeam
            // 
            txtGuestTeam.Location = new Point(585, 59);
            txtGuestTeam.Name = "txtGuestTeam";
            txtGuestTeam.Size = new Size(125, 27);
            txtGuestTeam.TabIndex = 1;
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
            lblGuestPlayer.Location = new Point(579, 122);
            lblGuestPlayer.Name = "lblGuestPlayer";
            lblGuestPlayer.Size = new Size(49, 20);
            lblGuestPlayer.TabIndex = 3;
            lblGuestPlayer.Text = "Player";
            // 
            // lblGuestPos
            // 
            lblGuestPos.AutoSize = true;
            lblGuestPos.Location = new Point(679, 122);
            lblGuestPos.Name = "lblGuestPos";
            lblGuestPos.Size = new Size(31, 20);
            lblGuestPos.TabIndex = 4;
            lblGuestPos.Text = "Pos";
            // 
            // lblHomeBench
            // 
            lblHomeBench.AutoSize = true;
            lblHomeBench.Location = new Point(216, 122);
            lblHomeBench.Name = "lblHomeBench";
            lblHomeBench.Size = new Size(49, 20);
            lblHomeBench.TabIndex = 3;
            lblHomeBench.Text = "Bench";
            // 
            // lblGuestBench
            // 
            lblGuestBench.AutoSize = true;
            lblGuestBench.Location = new Point(756, 122);
            lblGuestBench.Name = "lblGuestBench";
            lblGuestBench.Size = new Size(49, 20);
            lblGuestBench.TabIndex = 3;
            lblGuestBench.Text = "Bench";
            // 
            // lblHomeBullpen
            // 
            lblHomeBullpen.AutoSize = true;
            lblHomeBullpen.Location = new Point(382, 122);
            lblHomeBullpen.Name = "lblHomeBullpen";
            lblHomeBullpen.Size = new Size(59, 20);
            lblHomeBullpen.TabIndex = 3;
            lblHomeBullpen.Text = "Bullpen";
            // 
            // lblGuestBullpen
            // 
            lblGuestBullpen.AutoSize = true;
            lblGuestBullpen.Location = new Point(926, 122);
            lblGuestBullpen.Name = "lblGuestBullpen";
            lblGuestBullpen.Size = new Size(59, 20);
            lblGuestBullpen.TabIndex = 3;
            lblGuestBullpen.Text = "Bullpen";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(350, 36);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(41, 20);
            lblDate.TabIndex = 0;
            lblDate.Text = "Date";
            // 
            // txtDate
            // 
            txtDate.Location = new Point(307, 59);
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
            cBoxHomeBench.Location = new Point(216, 145);
            cBoxHomeBench.Name = "cBoxHomeBench";
            cBoxHomeBench.Size = new Size(140, 142);
            cBoxHomeBench.Sorted = true;
            cBoxHomeBench.TabIndex = 5;
            // 
            // cBoxHomeBullpen
            // 
            cBoxHomeBullpen.DropDownStyle = ComboBoxStyle.Simple;
            cBoxHomeBullpen.FormattingEnabled = true;
            cBoxHomeBullpen.Location = new Point(382, 145);
            cBoxHomeBullpen.Name = "cBoxHomeBullpen";
            cBoxHomeBullpen.Size = new Size(140, 262);
            cBoxHomeBullpen.Sorted = true;
            cBoxHomeBullpen.TabIndex = 5;
            // 
            // cBoxGuestPlayers
            // 
            cBoxGuestPlayers.DropDownStyle = ComboBoxStyle.Simple;
            cBoxGuestPlayers.FormattingEnabled = true;
            cBoxGuestPlayers.Location = new Point(579, 147);
            cBoxGuestPlayers.Name = "cBoxGuestPlayers";
            cBoxGuestPlayers.Size = new Size(138, 262);
            cBoxGuestPlayers.Sorted = true;
            cBoxGuestPlayers.TabIndex = 5;
            // 
            // cBoxGuestBench
            // 
            cBoxGuestBench.DropDownStyle = ComboBoxStyle.Simple;
            cBoxGuestBench.FormattingEnabled = true;
            cBoxGuestBench.Location = new Point(756, 145);
            cBoxGuestBench.Name = "cBoxGuestBench";
            cBoxGuestBench.Size = new Size(140, 142);
            cBoxGuestBench.Sorted = true;
            cBoxGuestBench.TabIndex = 5;
            // 
            // cBoxGuestBullpen
            // 
            cBoxGuestBullpen.DropDownStyle = ComboBoxStyle.Simple;
            cBoxGuestBullpen.FormattingEnabled = true;
            cBoxGuestBullpen.Location = new Point(926, 147);
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
            lBoxHomePlayers.Size = new Size(156, 104);
            lBoxHomePlayers.TabIndex = 6;
            // 
            // AddShohei
            // 
            AddShohei.Location = new Point(945, 12);
            AddShohei.Name = "AddShohei";
            AddShohei.Size = new Size(144, 29);
            AddShohei.TabIndex = 7;
            AddShohei.Text = "Add Shohei";
            AddShohei.UseVisualStyleBackColor = true;
            AddShohei.Click += AddShohei_Click_1;
            // 
            // txtTest
            // 
            txtTest.Location = new Point(945, 58);
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
            // frmSearchTeam
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(196, 30, 58);
            ClientSize = new Size(1101, 500);
            Controls.Add(cBoxHomeTeams);
            Controls.Add(txtTest);
            Controls.Add(AddShohei);
            Controls.Add(lBoxHomePlayers);
            Controls.Add(cBoxGuestBullpen);
            Controls.Add(cBoxHomeBullpen);
            Controls.Add(cBoxGuestBench);
            Controls.Add(cBoxHomeBench);
            Controls.Add(cBoxGuestPlayers);
            Controls.Add(cBoxHomePlayers);
            Controls.Add(lblGuestPos);
            Controls.Add(lblGuestPlayer);
            Controls.Add(lblGuestBench);
            Controls.Add(lblHomeBench);
            Controls.Add(lblGuestBullpen);
            Controls.Add(lblHomeBullpen);
            Controls.Add(lblHomePlayers);
            Controls.Add(txtGuestTeam);
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
        private TextBox txtGuestTeam;
        private Label lblHomePlayers;
        private Label lblGuestPlayer;
        private Label lblGuestPos;
        private Label lblHomeBench;
        private Label lblGuestBench;
        private Label lblHomeBullpen;
        private Label lblGuestBullpen;
        private Label lblDate;
        private TextBox txtDate;
        private ComboBox cBoxHomePlayers;
        private ComboBox cBoxHomeBench;
        private ComboBox cBoxHomeBullpen;
        private ComboBox cBoxGuestPlayers;
        private ComboBox cBoxGuestBench;
        private ComboBox cBoxGuestBullpen;
        private ListBox lBoxHomePlayers;
        private Button AddShohei;
        private TextBox txtTest;
        private ComboBox cBoxHomeTeams;
    }
}