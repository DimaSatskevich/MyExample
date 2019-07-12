namespace Hockey
{
    partial class FormWithScheduleForAdmin
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
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCommand1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoalCommand1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoalsGommand2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Command2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tournament = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WinInOT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.WinInB = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DatePlay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.IdCommand1,
            this.GoalCommand1,
            this.GoalsGommand2,
            this.Command2,
            this.Tournament,
            this.WinInOT,
            this.WinInB,
            this.DatePlay});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(887, 185);
            this.dataGridView1.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // IdCommand1
            // 
            this.IdCommand1.HeaderText = "Команда №1";
            this.IdCommand1.Name = "IdCommand1";
            this.IdCommand1.ReadOnly = true;
            // 
            // GoalCommand1
            // 
            this.GoalCommand1.HeaderText = "Шайб забито командой №1";
            this.GoalCommand1.Name = "GoalCommand1";
            this.GoalCommand1.ReadOnly = true;
            // 
            // GoalsGommand2
            // 
            this.GoalsGommand2.HeaderText = "Шайб забито командой №2";
            this.GoalsGommand2.Name = "GoalsGommand2";
            this.GoalsGommand2.ReadOnly = true;
            // 
            // Command2
            // 
            this.Command2.HeaderText = "Команда №2";
            this.Command2.Name = "Command2";
            this.Command2.ReadOnly = true;
            // 
            // Tournament
            // 
            this.Tournament.HeaderText = "Турнир";
            this.Tournament.Name = "Tournament";
            this.Tournament.ReadOnly = true;
            // 
            // WinInOT
            // 
            this.WinInOT.HeaderText = "Победа в ОТ";
            this.WinInOT.Name = "WinInOT";
            this.WinInOT.ReadOnly = true;
            // 
            // WinInB
            // 
            this.WinInB.HeaderText = "Победа по Б";
            this.WinInB.Name = "WinInB";
            this.WinInB.ReadOnly = true;
            // 
            // DatePlay
            // 
            this.DatePlay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DatePlay.HeaderText = "Дата игры";
            this.DatePlay.Name = "DatePlay";
            this.DatePlay.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(824, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "Выйти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 203);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(201, 34);
            this.button2.TabIndex = 2;
            this.button2.Text = "Добавить игру";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(219, 203);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(201, 34);
            this.button3.TabIndex = 3;
            this.button3.Text = "Редактировать игру";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(426, 203);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(201, 34);
            this.button4.TabIndex = 4;
            this.button4.Text = "Удалить игру";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // FormWithSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 249);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.Name = "FormWithSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Расписание";
            this.Load += new System.EventHandler(this.FormWithSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCommand1;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoalCommand1;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoalsGommand2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Command2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tournament;
        private System.Windows.Forms.DataGridViewCheckBoxColumn WinInOT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn WinInB;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatePlay;
    }
}