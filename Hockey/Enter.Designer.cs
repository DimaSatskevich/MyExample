namespace Hockey
{
    partial class Enter
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.ExitBut = new System.Windows.Forms.Button();
            this.EnterBut = new System.Windows.Forms.Button();
            this.PasswordTXTBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LoginTXTBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Reg = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Введите данные";
            // 
            // ExitBut
            // 
            this.ExitBut.Location = new System.Drawing.Point(319, 90);
            this.ExitBut.Name = "ExitBut";
            this.ExitBut.Size = new System.Drawing.Size(92, 31);
            this.ExitBut.TabIndex = 16;
            this.ExitBut.Text = "Выход";
            this.ExitBut.UseVisualStyleBackColor = true;
            this.ExitBut.Click += new System.EventHandler(this.ExitBut_Click);
            // 
            // EnterBut
            // 
            this.EnterBut.Location = new System.Drawing.Point(319, 32);
            this.EnterBut.Name = "EnterBut";
            this.EnterBut.Size = new System.Drawing.Size(92, 52);
            this.EnterBut.TabIndex = 13;
            this.EnterBut.Text = "Вход";
            this.EnterBut.UseVisualStyleBackColor = true;
            this.EnterBut.Click += new System.EventHandler(this.EnterBut_Click);
            // 
            // PasswordTXTBox
            // 
            this.PasswordTXTBox.Location = new System.Drawing.Point(84, 63);
            this.PasswordTXTBox.Margin = new System.Windows.Forms.Padding(4);
            this.PasswordTXTBox.Name = "PasswordTXTBox";
            this.PasswordTXTBox.PasswordChar = '*';
            this.PasswordTXTBox.Size = new System.Drawing.Size(228, 20);
            this.PasswordTXTBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Пароль:";
            // 
            // LoginTXTBox
            // 
            this.LoginTXTBox.Location = new System.Drawing.Point(84, 32);
            this.LoginTXTBox.Margin = new System.Windows.Forms.Padding(4);
            this.LoginTXTBox.Name = "LoginTXTBox";
            this.LoginTXTBox.Size = new System.Drawing.Size(228, 20);
            this.LoginTXTBox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Логин:";
            // 
            // Reg
            // 
            this.Reg.AutoSize = true;
            this.Reg.Location = new System.Drawing.Point(19, 99);
            this.Reg.Name = "Reg";
            this.Reg.Size = new System.Drawing.Size(72, 13);
            this.Reg.TabIndex = 18;
            this.Reg.TabStop = true;
            this.Reg.Text = "Регистрация";
            this.Reg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Reg_LinkClicked);
            // 
            // Enter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 127);
            this.Controls.Add(this.Reg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ExitBut);
            this.Controls.Add(this.EnterBut);
            this.Controls.Add(this.PasswordTXTBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LoginTXTBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Enter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.Enter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ExitBut;
        private System.Windows.Forms.Button EnterBut;
        private System.Windows.Forms.TextBox PasswordTXTBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LoginTXTBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel Reg;
    }
}

