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
    public partial class FormWithPlayersForAdmin : Form
    {
        public FormWithPlayersForAdmin()
        {
            InitializeComponent();
        }

        private void FormWithPlayers_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            WorkWithBD.ReadPlayerForDataGridView(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormAddPlayer form = new FormAddPlayer();
            form.ShowDialog();
            dataGridView1.Rows.Clear();
            WorkWithBD.ReadPlayerForDataGridView(dataGridView1);
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormEditPlayer form = new FormEditPlayer(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value),
                Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value),
                Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value),
                Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value));
            form.ShowDialog();
            dataGridView1.Rows.Clear();
            WorkWithBD.ReadPlayerForDataGridView(dataGridView1);
            this.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите удалить данного игрока?", "Сообщение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                WorkWithBD.DeletePlayer(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value));
                dataGridView1.Rows.Clear();
                WorkWithBD.ReadPlayerForDataGridView(dataGridView1);
            }
        }
    }
}
