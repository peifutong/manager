using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    class Dao
    {
        SqlConnection sc;
        public SqlConnection connect()
        {
            string str = @"Data Source=USP;Initial Catalog=BData;Integrated Security=True";
            sc = new SqlConnection(str);
            sc.Open();
            return sc;

            //string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        public SqlCommand command(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, connect());
            return cmd;
        }

        public int Execute(string sql)
        {
            return command(sql).ExecuteNonQuery();

        }

        public SqlDataReader read(string sql)
        {
            return command(sql).ExecuteReader();
        }

        public void DaoClose()
        {
            sc.Close();
        }
    }
}
