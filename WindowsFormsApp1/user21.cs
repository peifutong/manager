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
    public partial class user21 : Form
    {
        public user21()
        {
            InitializeComponent();
            Table();
        }

        public void Table()
        {
            dataGridView1.Rows.Clear();//清空
            Dao dao = new Dao();
            string sql = "select * from t_book";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int number = int.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            if(number<1)
            {
                MessageBox.Show("库存不足，请联系管理员");

            }
            else
            {
                string sql = $"insert into t_lend1 ([uid],bid,[datetime]) values('{Data.UID}','{id}',getdate());update t_book set number =number-1 where id='{id}'";
                Dao dao = new Dao();
                if(dao.Execute(sql)>1)
                {
                    MessageBox.Show($"用户{Data.UName}借出图书{id}！");
                }
            }
            Table();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
