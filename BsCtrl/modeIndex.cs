using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DbConnect;
using System.Data.SqlClient;

namespace BsCtrl
{
    public class modeIndex
    {
        //mode_index.master母版页使用功能类
        String Server;
        String uName;
        String pWord;
        public void initial(String s, String u, String p)
        {
            //初始化数据库连接信息
            this.Server = s;
            this.uName = u;
            this.pWord = p;
        }
        public DataSet VerifyUserInfo(String strUserName, String strPassWord)
        {
            //连接数据库并查询是否有与登录用户信息匹配项，返回dataset
            DbConnector conn = new DbConnector();
            DataSet ds = null;
            conn.connDB(Server, uName, pWord);
            ds = conn.executeQuery("select * from users where username = '" + strUserName + "' and password = '" + strPassWord + "'");
            //SqlConnection conn = new SqlConnection("Data Source = localhost;" + "Integrated Security = SSPI;" + "Initial Catalog = shanzhai");
            //SqlDataAdapter myAdp = new SqlDataAdapter("select * from users where username = '" + strUserName + "' and password = '" + strPassWord + "'", conn);
            //DataSet ds = new DataSet();
            //myAdp.Fill(ds);
            return ds;
        }
    }
}
