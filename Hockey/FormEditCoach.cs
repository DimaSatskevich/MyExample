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
    public partial class FormEditCoach : Form
    {
        private string Id { get; set; }
        private string Team { get; set; }

        public FormEditCoach(string id, string name, string surname, string patronymic, string team, string matches)
        {
            InitializeComponent();
            textBox1.Text = name;
            textBox2.Text = surname;
            textBox3.Text = patronymic;
            if(decimal.TryParse(matches, out decimal _))
            {
                numericUpDown1.Value = Convert.ToDecimal(matches);
            }
            Team = team;
            Id = id;
        }

        private void FormEditCoach_Load(object sender, EventArgs e)
        {
            WorkWithBD.ReadTeamOfDatabaseInComboBox(comboBox1);
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(Team);
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                WorkWithBD.EditCoach(Id, textBox1.Text, textBox2.Text, textBox3.Text, numericUpDown1.Value.ToString(), comboBox1.Text);
                this.Close();
            }
        }
    }
}
