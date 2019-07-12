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
    public partial class UserForm : Form
    {
        public UserForm(string name)
        {
            InitializeComponent();
            this.Text += name;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormWithUsersForAdmin form = new FormWithUsersForAdmin();
            form.ShowDialog();
            this.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormWithTournamentForAdmin form = new FormWithTournamentForAdmin();
            form.ShowDialog();
            this.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormWithJudgeForAdmin form = new FormWithJudgeForAdmin();
            form.ShowDialog();
            this.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormWithCoachesForAdmin form = new FormWithCoachesForAdmin();
            form.ShowDialog();
            this.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormWithScheduleForAdmin form = new FormWithScheduleForAdmin();
            form.ShowDialog();
            this.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormWithStadiumForAdmin form = new FormWithStadiumForAdmin();
            form.ShowDialog();
            this.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormWithPlayersForAdmin form = new FormWithPlayersForAdmin();
            form.ShowDialog();
            this.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormWithTeamForAdmin form = new FormWithTeamForAdmin();
            form.ShowDialog();
            this.Visible = true;
        }
    }
}
