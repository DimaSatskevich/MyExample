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
    public partial class FormWithTournamentForUser : Form
    {
        public FormWithTournamentForUser()
        {
            InitializeComponent();
        }

        private void FormWithTournament_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            WorkWithBD.ReadTournamentForDataGridView(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormAddTournament form = new FormAddTournament();
            form.ShowDialog();
            dataGridView1.Rows.Clear();
            WorkWithBD.ReadTournamentForDataGridView(dataGridView1);
            this.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormEditTournament form = new FormEditTournament(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value),
                Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value));
            form.ShowDialog();
            dataGridView1.Rows.Clear();
            WorkWithBD.ReadTournamentForDataGridView(dataGridView1);
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите удалить данный турнир?", "Сообщение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                WorkWithBD.DeleteTournament(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                dataGridView1.Rows.Clear();
                WorkWithBD.ReadTournamentForDataGridView(dataGridView1);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
