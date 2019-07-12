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
    public partial class FormAddPlay : Form
    {
        public FormAddPlay()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
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
            if(comboBox1.Text == comboBox2.Text)
            {
                WorkWithMessage.MessageBoxShow("Команды должны быть разными");
                return false;
            }
            if (checkBox1.Checked)
            {
                if(numericUpDown1.Value == numericUpDown2.Value)
                {
                    WorkWithMessage.MessageBoxShow("Счёт не может быть одинаковым!");
                    return false;
                }
                if(radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false)
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

        private void FormAddPlay_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            this.Width = 330;
            WorkWithBD.ReadTeamOfDatabaseInComboBox(comboBox1);
            WorkWithBD.ReadTeamOfDatabaseInComboBox(comboBox2);
            WorkWithBD.ReadTournamentOfDatabaseInComboBox(comboBox3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                if(checkBox1.Checked == false)
                {
                    numericUpDown1.Value = 0;
                    numericUpDown2.Value = 0;
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                }

                WorkWithBD.AddPlay(comboBox1.Text, Convert.ToString(numericUpDown1.Value), comboBox2.Text, Convert.ToString(numericUpDown2.Value), comboBox3.Text, radioButton2.Checked, radioButton3.Checked, Convert.ToString(dateTimePicker1.Value));
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
