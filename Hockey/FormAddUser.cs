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
    public partial class FormAddUser : Form
    {
        public FormAddUser()
        {
            InitializeComponent();
        }

        private bool Check()
        {
            if (String.IsNullOrWhiteSpace(LoginTXTBox.Text))
            {
                WorkWithMessage.MessageBoxShow("Введите логин!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(PasswordTXTBox.Text))
            {
                WorkWithMessage.MessageBoxShow("Введите пароль!");
                return false;
            }
            return true;

        }

        private void EnterBut_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                if(WorkWithBD.CheckUser(LoginTXTBox.Text, PasswordTXTBox.Text))
                {
                    WorkWithMessage.MessageBoxShow("Данный логин уже занят!");
                    return;
                }
                else
                {
                    WorkWithBD.AddUser(LoginTXTBox.Text, PasswordTXTBox.Text);
                    this.Close();
                }
            }
        }

        private void ExitBut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
