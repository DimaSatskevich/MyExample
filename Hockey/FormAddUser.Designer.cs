namespace Hockey
{
    partial class FormAddUser
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
            this.label3 = new System.Windows.Forms.Label();
            this.ExitBut = new System.Windows.Forms.Button();
            this.EnterBut = new System.Windows.Forms.Button();
            this.PasswordTXTBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LoginTXTBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Введите данные";
            // 
            // ExitBut
            // 
            this.ExitBut.Location = new System.Drawing.Point(234, 86);
            this.ExitBut.Name = "ExitBut";
            this.ExitBut.Size = new System.Drawing.Size(72, 31);
            this.ExitBut.TabIndex = 23;
            this.ExitBut.Text = "Выход";
            this.ExitBut.UseVisualStyleBackColor = true;
            this.ExitBut.Click += new System.EventHandler(this.ExitBut_Click);
            // 
            // EnterBut
            // 
            this.EnterBut.Location = new System.Drawing.Point(78, 86);
            this.EnterBut.Name = "EnterBut";
            this.EnterBut.Size = new System.Drawing.Size(134, 31);
            this.EnterBut.TabIndex = 22;
            this.EnterBut.Text = "Добавить";
            this.EnterBut.UseVisualStyleBackColor = true;
            this.EnterBut.Click += new System.EventHandler(this.EnterBut_Click);
            // 
            // PasswordTXTBox
            // 
            this.PasswordTXTBox.Location = new System.Drawing.Point(78, 59);
            this.PasswordTXTBox.Margin = new System.Windows.Forms.Padding(4);
            this.PasswordTXTBox.Name = "PasswordTXTBox";
            this.PasswordTXTBox.Size = new System.Drawing.Size(228, 20);
            this.PasswordTXTBox.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Пароль:";
            // 
            // LoginTXTBox
            // 
            this.LoginTXTBox.Location = new System.Drawing.Point(78, 28);
            this.LoginTXTBox.Margin = new System.Windows.Forms.Padding(4);
            this.LoginTXTBox.Name = "LoginTXTBox";
            this.LoginTXTBox.Size = new System.Drawing.Size(228, 20);
            this.LoginTXTBox.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Логин:";
            // 
            // FormAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 127);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ExitBut);
            this.Controls.Add(this.EnterBut);
            this.Controls.Add(this.PasswordTXTBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LoginTXTBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "FormAddUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление пользователя";
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
    }
}