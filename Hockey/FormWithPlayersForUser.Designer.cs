namespace Hockey
{
    partial class FormWithPlayersForUser
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IdPlayer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamePlayer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SurnamePlayer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatronymicPlayer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Goals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdPlayer,
            this.NamePlayer,
            this.SurnamePlayer,
            this.PatronymicPlayer,
            this.IdTeam,
            this.IdPosition,
            this.Goals});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(644, 185);
            this.dataGridView1.TabIndex = 0;
            // 
            // IdPlayer
            // 
            this.IdPlayer.HeaderText = "Id";
            this.IdPlayer.Name = "IdPlayer";
            this.IdPlayer.ReadOnly = true;
            this.IdPlayer.Visible = false;
            // 
            // NamePlayer
            // 
            this.NamePlayer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NamePlayer.HeaderText = "Имя";
            this.NamePlayer.Name = "NamePlayer";
            this.NamePlayer.ReadOnly = true;
            // 
            // SurnamePlayer
            // 
            this.SurnamePlayer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SurnamePlayer.HeaderText = "Фамилия";
            this.SurnamePlayer.Name = "SurnamePlayer";
            this.SurnamePlayer.ReadOnly = true;
            // 
            // PatronymicPlayer
            // 
            this.PatronymicPlayer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PatronymicPlayer.HeaderText = "Отчество";
            this.PatronymicPlayer.Name = "PatronymicPlayer";
            this.PatronymicPlayer.ReadOnly = true;
            // 
            // IdTeam
            // 
            this.IdTeam.HeaderText = "Команда";
            this.IdTeam.Name = "IdTeam";
            this.IdTeam.ReadOnly = true;
            // 
            // IdPosition
            // 
            this.IdPosition.HeaderText = "Позиция";
            this.IdPosition.Name = "IdPosition";
            this.IdPosition.ReadOnly = true;
            // 
            // Goals
            // 
            this.Goals.HeaderText = "Забито шайб";
            this.Goals.Name = "Goals";
            this.Goals.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(563, 204);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Выйти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormWithPlayersForUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 240);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.Name = "FormWithPlayersForUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Игроки";
            this.Load += new System.EventHandler(this.FormWithPlayers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPlayer;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamePlayer;
        private System.Windows.Forms.DataGridViewTextBoxColumn SurnamePlayer;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatronymicPlayer;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn Goals;
    }
}