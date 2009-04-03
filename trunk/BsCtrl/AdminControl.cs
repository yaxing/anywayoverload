using System;
using System.Collections.Generic;
using System.Text;
using DbConnect;
using System.Data;
using System.Data.SqlClient;

namespace BsCtrl
{
    public class AdminControl
    {
        DataSet adminInfo;
        String strDbServer;
        String strDbUserName;
        String strDbPassWord;
        String strDbConn;
        private DbConnector conn;
        public AdminControl(String strDbConn)
        {
            this.strDbConn = strDbConn;
            conn = new DbConnector();
            conn.connDB(strDbConn);
        }

        public AdminControl(String strDbServer, String strDbUserName, String strDbPassWord)
        {
            this.strDbServer = strDbServer;
            this.strDbUserName = strDbUserName;
            this.strDbPassWord = strDbPassWord;
            conn = new DbConnector();
            conn.connDB(strDbServer, strDbUserName, strDbPassWord);
        }

        public Boolean AdminLogin(String adminName,String adminPwd)
        {
            adminInfo = conn.executeQuery("select * from admin where userName = '" + adminName + "' and passWord = '" + adminPwd+"'");
            if (adminInfo.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        public String AdminLv()
        {
            return adminInfo.Tables[0].Rows[0][4].ToString();
        }

    }
}
