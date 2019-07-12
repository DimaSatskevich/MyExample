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
    public partial class FormEditTournament : Form
    {
        private string Id { get; set; }
        private string NameTeam { get; set; }

        public FormEditTournament(string id, string nameTournament, string nameTeam)
        {
            InitializeComponent();
            Id = id;
            textBox1.Text = nameTournament;
            NameTeam = nameTeam;
        }

        private void FormEditTournament_Load(object sender, EventArgs e)
        {
            WorkWithBD.ReadTeamOfDatabaseInComboBox(comboBox1);
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(NameTeam);
        }

        private bool Check()
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                WorkWithMessage.MessageBoxShow("Введите название турнира!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(comboBox1.Text))
            {
                WorkWithMessage.MessageBoxShow("Выберите победителя!");
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                WorkWithBD.EditTournament(Id, textBox1.Text, comboBox1.Text);
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
