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
            txtHomeTeam = new TextBox();
            lblGuestTeam = new Label();
            txtGuestTeam = new TextBox();
            lblHomePlayers = new Label();
            lblHomePos = new Label();
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
            txtTest = new TextBox();
            SuspendLayout();
            // 
            // lblHomeTeam
            // 
            lblHomeTeam.AutoSize = true;
            lblHomeTeam.Location = new Point(40, 36);
            lblHomeTeam.Name = "lblHomeTeam";
            lblHomeTeam.Size = new Size(90, 20);
            lblHomeTeam.TabIndex = 0;
            lblHomeTeam.Text = "Home Team";
            // 
            // txtHomeTeam
            // 
            txtHomeTeam.Location = new Point(40, 59);
            txtHomeTeam.Name = "txtHomeTeam";
            txtHomeTeam.Size = new Size(125, 27);
            txtHomeTeam.TabIndex = 1;
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
            lblHomePlayers.Location = new Point(40, 168);
            lblHomePlayers.Name = "lblHomePlayers";
            lblHomePlayers.Size = new Size(49, 20);
            lblHomePlayers.TabIndex = 3;
            lblHomePlayers.Text = "Player";
            // 
            // lblHomePos
            // 
            lblHomePos.AutoSize = true;
            lblHomePos.Location = new Point(140, 168);
            lblHomePos.Name = "lblHomePos";
            lblHomePos.Size = new Size(31, 20);
            lblHomePos.TabIndex = 4;
            lblHomePos.Text = "Pos";
            // 
            // lblGuestPlayer
            // 
            lblGuestPlayer.AutoSize = true;
            lblGuestPlayer.Location = new Point(585, 168);
            lblGuestPlayer.Name = "lblGuestPlayer";
            lblGuestPlayer.Size = new Size(49, 20);
            lblGuestPlayer.TabIndex = 3;
            lblGuestPlayer.Text = "Player";
            // 
            // lblGuestPos
            // 
            lblGuestPos.AutoSize = true;
            lblGuestPos.Location = new Point(685, 168);
            lblGuestPos.Name = "lblGuestPos";
            lblGuestPos.Size = new Size(31, 20);
            lblGuestPos.TabIndex = 4;
            lblGuestPos.Text = "Pos";
            // 
            // lblHomeBench
            // 
            lblHomeBench.AutoSize = true;
            lblHomeBench.Location = new Point(214, 168);
            lblHomeBench.Name = "lblHomeBench";
            lblHomeBench.Size = new Size(49, 20);
            lblHomeBench.TabIndex = 3;
            lblHomeBench.Text = "Bench";
            // 
            // lblGuestBench
            // 
            lblGuestBench.AutoSize = true;
            lblGuestBench.Location = new Point(762, 168);
            lblGuestBench.Name = "lblGuestBench";
            lblGuestBench.Size = new Size(49, 20);
            lblGuestBench.TabIndex = 3;
            lblGuestBench.Text = "Bench";
            // 
            // lblHomeBullpen
            // 
            lblHomeBullpen.AutoSize = true;
            lblHomeBullpen.Location = new Point(380, 168);
            lblHomeBullpen.Name = "lblHomeBullpen";
            lblHomeBullpen.Size = new Size(59, 20);
            lblHomeBullpen.TabIndex = 3;
            lblHomeBullpen.Text = "Bullpen";
            // 
            // lblGuestBullpen
            // 
            lblGuestBullpen.AutoSize = true;
            lblGuestBullpen.Location = new Point(932, 168);
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
            cBoxHomePlayers.AutoCompleteMode = AutoCompleteMode.Append;
            cBoxHomePlayers.FormattingEnabled = true;
            cBoxHomePlayers.ImeMode = ImeMode.NoControl;
            cBoxHomePlayers.Location = new Point(40, 193);
            cBoxHomePlayers.Name = "cBoxHomePlayers";
            cBoxHomePlayers.Size = new Size(138, 28);
            cBoxHomePlayers.Sorted = true;
            cBoxHomePlayers.TabIndex = 5;
            cBoxHomePlayers.SelectedIndexChanged += cBoxHomePlayers_SelectedIndexChanged;
            cBoxHomePlayers.TextChanged += cBoxHomePlayer_TextChanged;
            // 
            // cBoxHomeBench
            // 
            cBoxHomeBench.DropDownStyle = ComboBoxStyle.Simple;
            cBoxHomeBench.FormattingEnabled = true;
            cBoxHomeBench.Location = new Point(214, 191);
            cBoxHomeBench.Name = "cBoxHomeBench";
            cBoxHomeBench.Size = new Size(140, 142);
            cBoxHomeBench.Sorted = true;
            cBoxHomeBench.TabIndex = 5;
            // 
            // cBoxHomeBullpen
            // 
            cBoxHomeBullpen.DropDownStyle = ComboBoxStyle.Simple;
            cBoxHomeBullpen.FormattingEnabled = true;
            cBoxHomeBullpen.Location = new Point(380, 191);
            cBoxHomeBullpen.Name = "cBoxHomeBullpen";
            cBoxHomeBullpen.Size = new Size(140, 262);
            cBoxHomeBullpen.Sorted = true;
            cBoxHomeBullpen.TabIndex = 5;
            // 
            // cBoxGuestPlayers
            // 
            cBoxGuestPlayers.DropDownStyle = ComboBoxStyle.Simple;
            cBoxGuestPlayers.FormattingEnabled = true;
            cBoxGuestPlayers.Location = new Point(585, 193);
            cBoxGuestPlayers.Name = "cBoxGuestPlayers";
            cBoxGuestPlayers.Size = new Size(138, 262);
            cBoxGuestPlayers.Sorted = true;
            cBoxGuestPlayers.TabIndex = 5;
            cBoxGuestPlayers.TextChanged += cBoxGuestPlayer_TextChanged;
            // 
            // cBoxGuestBench
            // 
            cBoxGuestBench.DropDownStyle = ComboBoxStyle.Simple;
            cBoxGuestBench.FormattingEnabled = true;
            cBoxGuestBench.Location = new Point(762, 191);
            cBoxGuestBench.Name = "cBoxGuestBench";
            cBoxGuestBench.Size = new Size(140, 142);
            cBoxGuestBench.Sorted = true;
            cBoxGuestBench.TabIndex = 5;
            // 
            // cBoxGuestBullpen
            // 
            cBoxGuestBullpen.DropDownStyle = ComboBoxStyle.Simple;
            cBoxGuestBullpen.FormattingEnabled = true;
            cBoxGuestBullpen.Location = new Point(932, 193);
            cBoxGuestBullpen.Name = "cBoxGuestBullpen";
            cBoxGuestBullpen.Size = new Size(140, 262);
            cBoxGuestBullpen.Sorted = true;
            cBoxGuestBullpen.TabIndex = 5;
            // 
            // lBoxHomePlayers
            // 
            lBoxHomePlayers.FormattingEnabled = true;
            lBoxHomePlayers.Location = new Point(40, 227);
            lBoxHomePlayers.Name = "lBoxHomePlayers";
            lBoxHomePlayers.Size = new Size(138, 104);
            lBoxHomePlayers.TabIndex = 6;
            // 
            // txtTest
            // 
            txtTest.Location = new Point(747, 12);
            txtTest.Multiline = true;
            txtTest.Name = "txtTest";
            txtTest.Size = new Size(325, 137);
            txtTest.TabIndex = 7;
            // 
            // frmSearchTeam
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1101, 500);
            Controls.Add(txtTest);
            Controls.Add(lBoxHomePlayers);
            Controls.Add(cBoxGuestBullpen);
            Controls.Add(cBoxHomeBullpen);
            Controls.Add(cBoxGuestBench);
            Controls.Add(cBoxHomeBench);
            Controls.Add(cBoxGuestPlayers);
            Controls.Add(cBoxHomePlayers);
            Controls.Add(lblGuestPos);
            Controls.Add(lblHomePos);
            Controls.Add(lblGuestPlayer);
            Controls.Add(lblGuestBench);
            Controls.Add(lblHomeBench);
            Controls.Add(lblGuestBullpen);
            Controls.Add(lblHomeBullpen);
            Controls.Add(lblHomePlayers);
            Controls.Add(txtGuestTeam);
            Controls.Add(txtDate);
            Controls.Add(txtHomeTeam);
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
        private TextBox txtHomeTeam;
        private Label lblGuestTeam;
        private TextBox txtGuestTeam;
        private Label lblHomePlayers;
        private Label lblHomePos;
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
        private TextBox txtTest;
    }
}