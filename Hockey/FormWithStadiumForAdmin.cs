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
    public partial class FormWithStadiumForAdmin : Form
    {
        public FormWithStadiumForAdmin()
        {
            InitializeComponent();
        }

        private void FormWithStadium_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            WorkWithBD.ReadStadiumForDataGridView(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormAddStadium form = new FormAddStadium();
            form.ShowDialog();
            dataGridView1.Rows.Clear();
            WorkWithBD.ReadStadiumForDataGridView(dataGridView1);
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormEditStadium form = new FormEditStadium(dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[1].Value.ToString(),
                dataGridView1.CurrentRow.Cells[2].Value.ToString(), dataGridView1.CurrentRow.Cells[3].Value.ToString());
            form.ShowDialog();
            dataGridView1.Rows.Clear();
            WorkWithBD.ReadStadiumForDataGridView(dataGridView1);
            this.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите удалить данный стадион?", "Сообщение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                WorkWithBD.DeleteStadium(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                dataGridView1.Rows.Clear();
                WorkWithBD.ReadStadiumForDataGridView(dataGridView1);
            }
        }
    }
}
