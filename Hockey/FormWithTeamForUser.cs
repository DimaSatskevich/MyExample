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
    public partial class FormWithTeamForUser : Form
    {
        public FormWithTeamForUser()
        {
            InitializeComponent();
        }

        private void FormWithTeam_Load(object sender, EventArgs e)
        {
            WorkWithBD.ReadTeamOfDataBaseInDataGridView(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormAddTeam form = new FormAddTeam();
            form.ShowDialog();
            dataGridView1.Rows.Clear();
            WorkWithBD.ReadTeamOfDataBaseInDataGridView(dataGridView1);
            this.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormEditTeam form = new FormEditTeam(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value));
            form.ShowDialog();
            dataGridView1.Rows.Clear();
            WorkWithBD.ReadTeamOfDataBaseInDataGridView(dataGridView1);
            this.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите удалить данную команду?", "Сообщение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                WorkWithBD.DeleteTeam(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                dataGridView1.Rows.Clear();
                WorkWithBD.ReadTeamOfDataBaseInDataGridView(dataGridView1);
            }
        }
    }
}
