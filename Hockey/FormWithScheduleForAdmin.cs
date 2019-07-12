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
    public partial class FormWithScheduleForAdmin : Form
    {
        public FormWithScheduleForAdmin()
        {
            InitializeComponent();
        }

        private void FormWithSchedule_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            WorkWithBD.ReadScheduleForDataGridView(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormAddPlay form = new FormAddPlay();
            form.ShowDialog();
            dataGridView1.Rows.Clear();
            WorkWithBD.ReadScheduleForDataGridView(dataGridView1);
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormEditPlay form = new FormEditPlay(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value),
                Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value),
                Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value),
                Convert.ToBoolean(dataGridView1.CurrentRow.Cells[6].Value), Convert.ToBoolean(dataGridView1.CurrentRow.Cells[7].Value),
                Convert.ToString(dataGridView1.CurrentRow.Cells[8].Value));
            form.ShowDialog();
            dataGridView1.Rows.Clear();
            WorkWithBD.ReadScheduleForDataGridView(dataGridView1);
            this.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите удалить данную игру?", "Сообщение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                WorkWithBD.DeletePlay(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                dataGridView1.Rows.Clear();
                WorkWithBD.ReadScheduleForDataGridView(dataGridView1);
            }
        }
    }
}
