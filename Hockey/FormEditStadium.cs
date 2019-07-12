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
    public partial class FormEditStadium : Form
    {
        private string Id { get; set; }

        public FormEditStadium(string id, string name, string city, string capacity)
        {
            InitializeComponent();
            Id = id;
            textBox1.Text = name;
            textBox2.Text = city;
            numericUpDown1.Value = Convert.ToInt32(capacity);
        }

        private bool Check()
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                WorkWithMessage.MessageBoxShow("Введите название!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(textBox2.Text))
            {
                WorkWithMessage.MessageBoxShow("Введите город!");
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                WorkWithBD.EditStadium(Id, textBox1.Text, textBox2.Text, numericUpDown1.Value.ToString());
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
