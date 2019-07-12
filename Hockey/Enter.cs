using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hockey
{
    public partial class Enter : Form
    {
        public Enter()
        {
            InitializeComponent();
        }

        private void EnterBut_Click(object sender, EventArgs e)
        {
            if (WorkWithBD.CheckUser(LoginTXTBox.Text, PasswordTXTBox.Text))
            {
                switch (WorkWithBD.GetNamePrivilegeForLoginPrivelege(LoginTXTBox.Text))
                {
                    case "Admin":
                        {
                            this.Visible = false;
                            AdminForm form = new AdminForm(LoginTXTBox.Text);
                            LoginTXTBox.Text = string.Empty;
                            PasswordTXTBox.Text = string.Empty;
                            form.ShowDialog();
                            this.Visible = true;
                            break;
                        }
                    case "User":
                        {
                            this.Visible = false;
                            UserForm form = new UserForm(LoginTXTBox.Text);
                            LoginTXTBox.Text = string.Empty;
                            PasswordTXTBox.Text = string.Empty;
                            form.ShowDialog();
                            this.Visible = true;
                            break;
                        }
                    default:
                        {
                            WorkWithMessage.MessageBoxShow("Привилегия пользователя непоределена!");
                            break;
                        }
                }
            }
            else
            {
                WorkWithMessage.MessageBoxShow("Неверный логин и пароль!");
            }
        }

        private void ExitBut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Reg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible = false;
            FormAddUser form = new FormAddUser();
            form.ShowDialog();
            this.Visible = true;
        }

        private void Enter_Load(object sender, EventArgs e)
        {
            WorkWithMessage.MessageBoxShow("Для входа под правами администратора введите: \n Логин: admin \n Пароль: admin");
        }
    }
}
