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
    public partial class FormEditPlayer : Form
    {
        private string Id { get; set; }
        private string Team { get; set; }
        private string Position { get; set; }
        public FormEditPlayer(string id, string name, string surname, string patronymic, string nameTeam, string position, string goals)
        {
            InitializeComponent();
            Id = id;
            textBox1.Text = name;
            textBox2.Text = surname;
            textBox3.Text = patronymic;
            Team = nameTeam;
            Position = position;
            if(decimal.TryParse(goals, out decimal _))
            {
                numericUpDown1.Value = Convert.ToDecimal(goals);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                WorkWithBD.EditPlayer(Id, textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.Text, comboBox2.Text, Convert.ToString(numericUpDown1.Value));
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

        private void FormEditPlayer_Load(object sender, EventArgs e)
        {
            WorkWithBD.ReadTeamOfDatabaseInComboBox(comboBox1);
            WorkWithBD.ReadPositionOfDatabaseInComboBox(comboBox2);
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(Team);
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Position);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
