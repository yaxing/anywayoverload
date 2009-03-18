using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DbConnect
{
    public class DbConnector
    {
        SqlConnection sqlConnection;
        SqlCommand commend;
        DataSet ds;

        public void connDB(string server, string userName, string passWord)
        {
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
            "Server=" + server + ";Database=shanzhai;User ID=" + userName + ";Password=" + passWord
            + ";Trusted_Connection=False";
            sqlConnection.Open();
        }

        public DataSet executeQuery(String sql)
        {
            try
            {
                commend = new SqlCommand(sql, sqlConnection);
                SqlDataAdapter MyDataAdapter = new SqlDataAdapter(commend);
                //SqlDataAdapter MyDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                ds = new DataSet();
                MyDataAdapter.Fill(ds);
            }
            catch (Exception ee)
            {
                ds = null;
            }
            return ds;
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
                ds = new DataSet();
                MyDataAdapter.Fill(ds);
                if (ds != null && ds.Tables.Count != 0)
                {
                    int autoID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
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
