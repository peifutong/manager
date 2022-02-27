using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class user1 : Form
    {
        public user1()
        {
            InitializeComponent();
        }

        private void 图书借阅ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user21 user = new user21();
            this.Hide();
            user.ShowDialog();
            this.Show();
        }

        private void 图书归还ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user3 user = new user3();
            this.Hide();
            user.ShowDialog();
            this.Show();
        }

        private void 返回ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
