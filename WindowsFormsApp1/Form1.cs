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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && textBox2.Text!="")
            {
                Login();
            }
            else
            {
                MessageBox.Show("输入有空，请重新输入");
            }
        }
        //登录身份
        public Boolean Login()
        {
            //用户
            if(radioButtonUser.Checked == true)
            {


                Dao dao = new Dao();
                //string sql1 = "select * from t_user where id='"+textBox1.Text+ "' and psw='" +textBox2.Text+ "'";
                //string sql2 = String.Format("select * from t_user where id='{0}'and psw='{1}'", textBox1.Text, textBox2.Text);
                string sql = $"select * from t_user where id='{textBox1.Text}' and psw='{textBox2.Text}'";
                IDataReader dc = dao.read(sql);
                if(dc.Read())
                {

                    Data.UID = dc["id"].ToString();
                    Data.UName = dc["name"].ToString();

                    MessageBox.Show("登陆成功");
                    user1 user = new user1();
                    this.Hide();
                    user.ShowDialog();
                    this.Show();
                    return true;
                }
                else
                {
                    MessageBox.Show("登陆失败");
                    return false;
                }

                //MessageBox.Show(dc[0].ToString(), dc["name"].ToString());
                dao.DaoClose();

            }
            //管理员
            if(radioButtonAdmin.Checked == true)
            {
                Dao dao = new Dao();
                string sql = $"select * from t_admin where id='{textBox1.Text}' and psw='{textBox2.Text}'";
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    MessageBox.Show("登陆成功");
                    admin1 admin = new admin1();
                    this.Hide();
                    admin.ShowDialog();
                    this.Show();
                    return true;
                }
                else
                {
                    MessageBox.Show("登陆失败");
                    return false;
                }
                dao.DaoClose();
            }
            
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
