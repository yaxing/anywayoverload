using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DbConnect
{
    public class DbConnect
    {
        SqlConnection sqlConnection;
        SqlCommand commend;
        DataSet rs;

        public void connDB(string server, string userName, string passWord)
        {
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
            "Server=" + server + ";Database=olBookShop;User ID=" + userName + ";Password=" + passWord
            + ";Trusted_Connection=False";
            sqlConnection.Open();
        }

        public DataSet executeQuery(String sql)
        {
            try
            {
                commend = new SqlCommand(sql, sqlConnection);
                SqlDataAdapter MyDataAdapter = new SqlDataAdapter(commend.CommandText, commend.Connection);
                MyDataAdapter.Fill(rs);
            }
            catch (Exception ee)
            {
                rs = null;
            }
            return rs;
        }

        public int executeUpdate(String sql)
        {
            int result;
            try
            {
                commend = new SqlCommand(sql, sqlConnection);
                result = commend.ExecuteNonQuery();
            }
            catch (Exception ee)
            {
                result = 0;
            }
            return result;
        }

        public int executeUpdate_id(String sql)
        {
            int result;
            try
            {
                commend = new SqlCommand(sql, sqlConnection);
                result = commend.ExecuteNonQuery();
                String ID = "select @@IDENTITY as id";
                SqlDataAdapter MyDataAdapter = new SqlDataAdapter(ID, commend.Connection);
                MyDataAdapter.Fill(rs);
                if (rs != null && rs.Tables.Count != 0)
                {
                    int autoID = Convert.ToInt32(rs.Tables[0].Rows[0]["ID"]);
                    result = autoID;
                }
            }
            catch (Exception ee)
            {
                result = 0;
            }
            return result;
        }

        public void close()
        {
            sqlConnection.Close();
        }
    }

}
