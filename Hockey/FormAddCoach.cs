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
    public partial class FormAddCoach : Form
    {
        public FormAddCoach()
        {
            InitializeComponent();
        }

        private void FormAddCoach_Load(object sender, EventArgs e)
        {
            WorkWithBD.ReadTeamOfDatabaseInComboBox(comboBox1);
        }

        private bool Check()
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                WorkWithMessage.MessageBoxShow("Введите имя!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(textBox2.Text))
            {
                WorkWithMessage.MessageBoxShow("Введите фамилию!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(textBox3.Text))
            {
                WorkWithMessage.MessageBoxShow("Введите отчество!");
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                WorkWithBD.AddCoach(textBox1.Text, textBox2.Text, textBox3.Text, numericUpDown1.Value.ToString(), comboBox1.Text);
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
