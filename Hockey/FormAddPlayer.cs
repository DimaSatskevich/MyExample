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
    public partial class FormAddPlayer : Form
    {
        public FormAddPlayer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                WorkWithBD.AddPlayer(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.Text, comboBox2.Text, Convert.ToString(numericUpDown1.Value));
                this.Close();
            }
        }

        private bool Check()
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                WorkWithMessage.MessageBoxShow("Введите имя!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                WorkWithMessage.MessageBoxShow("Введите фамилию!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                WorkWithMessage.MessageBoxShow("Введите отчество!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(comboBox1.Text))
            {
                WorkWithMessage.MessageBoxShow("Выберите команду!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(comboBox2.Text))
            {
                WorkWithMessage.MessageBoxShow("Выберите позицию игрока!");
                return false;
            }
            return true;
        }

        private void FormAddPlayer_Load(object sender, EventArgs e)
        {
            WorkWithBD.ReadTeamOfDatabaseInComboBox(comboBox1);
            WorkWithBD.ReadPositionOfDatabaseInComboBox(comboBox2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
