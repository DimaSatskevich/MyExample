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
    public partial class FormAddTournament : Form
    {
        public FormAddTournament()
        {
            InitializeComponent();
        }

        private void FormAddTournament_Load(object sender, EventArgs e)
        {
            WorkWithBD.ReadTeamOfDatabaseInComboBox(comboBox1);
        }

        private bool Check()
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                WorkWithMessage.MessageBoxShow("Введите название турнира!");
                return false;
            }
            if (WorkWithBD.CheckTournament(textBox1.Text))
            {
                WorkWithMessage.MessageBoxShow("Такой турнир уже существует!");
                return false;
            }
                return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                WorkWithBD.AddTournament(textBox1.Text, comboBox1.Text);
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
