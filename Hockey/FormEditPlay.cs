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
    public partial class FormEditPlay : Form
    {
        private string Id { get; set; }
        private string Tournament { get; set; }
        private string Command1 { get; set; }
        private string Command2 { get; set; }

        public FormEditPlay(string id, string nameCommand1, string goalCommand1, string goalCommand2, string nameCommand2, string nameTournament, bool WinInOT, bool WinInB, string datePlay)
        {
            InitializeComponent();
            Id = id;
            Command1 = nameCommand1;
            if(decimal.TryParse(goalCommand1, out decimal _))
            {
                numericUpDown1.Value = Convert.ToDecimal(goalCommand1);
            }
            if (decimal.TryParse(goalCommand2, out decimal _))
            {
                numericUpDown2.Value = Convert.ToDecimal(goalCommand2);
            }
            Command2 = nameCommand2;
            Tournament = nameTournament;
            radioButton2.Checked = WinInOT;
            radioButton3.Checked = WinInB;
            dateTimePicker1.Value = Convert.ToDateTime(datePlay);
        }

        private void FormEditPlay_Load(object sender, EventArgs e)
        {
            if(numericUpDown1.Value == numericUpDown2.Value)
            {
                panel1.Visible = false;
                this.Width = 330;
            }
            else
            {
                this.Width = 610;
                panel1.Visible = true;
                checkBox1.Checked = true;
            }

            WorkWithBD.ReadTeamOfDatabaseInComboBox(comboBox1);
            WorkWithBD.ReadTeamOfDatabaseInComboBox(comboBox2);
            WorkWithBD.ReadTournamentOfDatabaseInComboBox(comboBox3);
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(Command1);
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Command2);
            comboBox3.SelectedIndex = comboBox3.Items.IndexOf(Tournament);
        }

        private bool Check()
        {
            if (String.IsNullOrWhiteSpace(comboBox1.Text))
            {
                WorkWithMessage.MessageBoxShow("Выберите команду №1");
                return false;
            }
            if (String.IsNullOrWhiteSpace(comboBox2.Text))
            {
                WorkWithMessage.MessageBoxShow("Выберите команду №2");
                return false;
            }
            if (String.IsNullOrWhiteSpace(comboBox3.Text))
            {
                WorkWithMessage.MessageBoxShow("Выберите турнир");
                return false;
            }
            if (comboBox1.Text == comboBox2.Text)
            {
                WorkWithMessage.MessageBoxShow("Команды должны быть разными");
                return false;
            }
            if (checkBox1.Checked)
            {
                if (numericUpDown1.Value == numericUpDown2.Value)
                {
                    WorkWithMessage.MessageBoxShow("Счёт не может быть одинаковым!");
                    return false;
                }
                if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false)
                {
                    WorkWithMessage.MessageBoxShow("Выберите в какой период закончился матч!");
                    return false;
                }
                if (radioButton2.Checked == true || radioButton3.Checked == true)
                {
                    if (Math.Abs(numericUpDown1.Value - numericUpDown2.Value) != 1)
                    {
                        WorkWithMessage.MessageBoxShow("Счёт должен отличаться на 1-у шайбу (т.к. победа была не в основное время)!");
                        return false;
                    }
                }
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                WorkWithBD.EditPlay(Id, comboBox1.Text, Convert.ToString(numericUpDown1.Value), comboBox2.Text, Convert.ToString(numericUpDown2.Value), comboBox3.Text, radioButton2.Checked, radioButton3.Checked, Convert.ToString(dateTimePicker1.Value));
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                this.Width = 610;
                panel1.Visible = true;
            }
            else
            {
                this.Width = 330;
                panel1.Visible = false;
            }
        }
    }
}
