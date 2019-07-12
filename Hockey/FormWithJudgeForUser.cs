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
    public partial class FormWithJudgeForUser : Form
    {
        public FormWithJudgeForUser()
        {
            InitializeComponent();
        }

        private void FormWithJudge_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            WorkWithBD.ReadJudgeForDataGridView(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormAddJudge form = new FormAddJudge();
            form.ShowDialog();
            dataGridView1.Rows.Clear();
            WorkWithBD.ReadJudgeForDataGridView(dataGridView1);
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormEditJudge form = new FormEditJudge(dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[1].Value.ToString(), dataGridView1.CurrentRow.Cells[2].Value.ToString(), 
                dataGridView1.CurrentRow.Cells[3].Value.ToString(), dataGridView1.CurrentRow.Cells[4].Value.ToString(), dataGridView1.CurrentRow.Cells[5].Value.ToString());
            form.ShowDialog();
            dataGridView1.Rows.Clear();
            WorkWithBD.ReadJudgeForDataGridView(dataGridView1);
            this.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите удалить данного судью?", "Сообщение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                WorkWithBD.DeleteJudge(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                dataGridView1.Rows.Clear();
                WorkWithBD.ReadJudgeForDataGridView(dataGridView1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
