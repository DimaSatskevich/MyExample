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
    public partial class FormWithCoachesForAdmin : Form
    {
        public FormWithCoachesForAdmin()
        {
            InitializeComponent();
        }

        private void FormWithCoaches_Load(object sender, EventArgs e)
        {
            WorkWithBD.ReadCoachOfDatabaseInDatagridview(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormAddCoach form = new FormAddCoach();
            form.ShowDialog();
            dataGridView1.Rows.Clear();
            WorkWithBD.ReadCoachOfDatabaseInDatagridview(dataGridView1);
            this.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormEditCoach form = new FormEditCoach(dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[1].Value.ToString(),
                dataGridView1.CurrentRow.Cells[2].Value.ToString(), dataGridView1.CurrentRow.Cells[3].Value.ToString(), Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value),
                Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value));
            form.ShowDialog();
            dataGridView1.Rows.Clear();
            WorkWithBD.ReadCoachOfDatabaseInDatagridview(dataGridView1);
            this.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите удалить данного тренера?", "Сообщение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                WorkWithBD.DeleteCoach(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                dataGridView1.Rows.Clear();
                WorkWithBD.ReadCoachOfDatabaseInDatagridview(dataGridView1);
            }
        }
    }
}
