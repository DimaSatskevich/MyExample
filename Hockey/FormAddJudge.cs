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
    public partial class FormAddJudge : Form
    {
        public FormAddJudge()
        {
            InitializeComponent();
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
            if (String.IsNullOrWhiteSpace(textBox2.Text))
            {
                WorkWithMessage.MessageBoxShow("Введите отчество!");
                return false;
            }
            if(dateTimePicker1.Value > DateTime.Now)
            {
                WorkWithMessage.MessageBoxShow("Неправильная дата рождения!");
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                WorkWithBD.AddJudge(textBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Value.ToString("yyyyMMdd"), numericUpDown1.Value.ToString()); ;
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
