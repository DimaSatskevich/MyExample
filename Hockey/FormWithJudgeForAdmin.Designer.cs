namespace Hockey
{
    partial class FormWithJudgeForAdmin
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
            this.IdJudge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameJudge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SurnameJudge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Patronymic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirthdayJidge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatchesJudge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdJudge,
            this.NameJudge,
            this.SurnameJudge,
            this.Patronymic,
            this.BirthdayJidge,
            this.MatchesJudge});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(549, 177);
            this.dataGridView1.TabIndex = 0;
            // 
            // IdJudge
            // 
            this.IdJudge.HeaderText = "Id";
            this.IdJudge.Name = "IdJudge";
            this.IdJudge.Visible = false;
            // 
            // NameJudge
            // 
            this.NameJudge.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NameJudge.HeaderText = "Имя";
            this.NameJudge.Name = "NameJudge";
            // 
            // SurnameJudge
            // 
            this.SurnameJudge.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SurnameJudge.HeaderText = "Фамилия";
            this.SurnameJudge.Name = "SurnameJudge";
            // 
            // Patronymic
            // 
            this.Patronymic.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Patronymic.HeaderText = "Отчество";
            this.Patronymic.Name = "Patronymic";
            // 
            // BirthdayJidge
            // 
            this.BirthdayJidge.HeaderText = "День рождение";
            this.BirthdayJidge.Name = "BirthdayJidge";
            // 
            // MatchesJudge
            // 
            this.MatchesJudge.HeaderText = "Матчей";
            this.MatchesJudge.Name = "MatchesJudge";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(474, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(166, 195);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(148, 33);
            this.button3.TabIndex = 3;
            this.button3.Text = "Редактировать судью";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(320, 195);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(148, 33);
            this.button4.TabIndex = 4;
            this.button4.Text = "Удалить судью";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 195);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 33);
            this.button2.TabIndex = 5;
            this.button2.Text = "Добавить судью";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormWithJudge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 231);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.Name = "FormWithJudge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Судьи";
            this.Load += new System.EventHandler(this.FormWithJudge_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdJudge;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameJudge;
        private System.Windows.Forms.DataGridViewTextBoxColumn SurnameJudge;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patronymic;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirthdayJidge;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatchesJudge;
    }
}