using System;
using System.Collections.Generic;
using System.Text;
using DbConnect;

namespace BsCtrl
{
    class modeIndex
    {
        public bool VerifyUserInfo(String strUserName, String strPassWord)
        {
            DbConnector conn = new DbConnector();
            DataSet ds = null;
            int result;


            //运用全局变量dbServer、dbUserName、dbPassWord，要链接数据库就按照这个来-------------
            //如果要修改全局变量值的话就在Web.Config里面的<appSettings>改
            string server = ConfigurationSettings.AppSettings["dbServer"];
            string userName = ConfigurationSettings.AppSettings["dbUserName"];
            string passWord = ConfigurationSettings.AppSettings["dbPassWord"];
            conn.connDB(server, userName, passWord);
            //-----------------------------------------------------------------------------------
            ds = conn.executeQuery("select * from users where username = '"+strUserName+"' and password = '"+strPassWord+"'");
            if(ds==null)
            {
                return false;
            }
            else if (ds != null) 
            {
                return true;
            }
        }
    }
}
