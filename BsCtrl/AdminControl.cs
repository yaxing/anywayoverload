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
        public Boolean AdminLogin(String adminName,String adminPwd)
        {
            
            DbConnector con = new DbConnector();
            con.connDB("localhost","sa","2019608");
            adminInfo = con.executeQuery("select * from admin where userName = '" + adminName + "' and passWord = '" + adminPwd+"'");
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
