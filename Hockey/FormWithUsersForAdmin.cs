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
    public partial class FormWithUsersForAdmin : Form
    {
        public FormWithUsersForAdmin()
        {
            InitializeComponent();
        }

        private void UsersFormForAdmin_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            WorkWithBD.ReadUserForAdminFormForDataGirdView(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormAddUser form = new FormAddUser();
            form.ShowDialog();
            dataGridView1.Rows.Clear();
            WorkWithBD.ReadUserForAdminFormForDataGirdView(dataGridView1);
            this.Visible = true;
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow.Cells[0].Value.ToString() != "1")
            {
                WorkWithBD.EditPrivilege(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                dataGridView1.Rows.Clear();
                WorkWithBD.ReadUserForAdminFormForDataGirdView(dataGridView1);
            }
            else
            {
                WorkWithMessage.MessageBoxShow("Главного администратора нельзя изменить!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[0].Value.ToString() != "1")
            {
                if(MessageBox.Show("Вы уверены что хотите удалить данного пользователя?", "Сообщение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    WorkWithBD.DeleteUser(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    dataGridView1.Rows.Clear();
                    WorkWithBD.ReadUserForAdminFormForDataGirdView(dataGridView1);
                }
            }
            else
            {
                WorkWithMessage.MessageBoxShow("Главного администратора нельзя удалить!");
            }
        }
    }
}
