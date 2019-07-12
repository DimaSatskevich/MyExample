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
    public partial class FormEditTeam : Form
    {
        private string Id { get; set; }

        public FormEditTeam(string id, string name, string numbOfWin)
        {   
            InitializeComponent();
            Id = id;
            textBox1.Text = name;
            if(decimal.TryParse(numbOfWin, out decimal _))
            {
                numericUpDown1.Value = Convert.ToDecimal(numbOfWin);
            }
        }

        private bool Check()
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                WorkWithMessage.MessageBoxShow("Введите название команды!");
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                WorkWithBD.EditTeam(Id, textBox1.Text, Convert.ToString(numericUpDown1.Value));
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
