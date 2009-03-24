using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DbConnect;
using System.Configuration;

namespace BsCtrl
{
    public class BsUserManager
    {
        private String strDbServer;
        private String strDbUserName;
        private String strDbPassWord;

        public BsUserManager()
        {
            
        }

        public BsUserManager(String strDbServer, String strDbUserName, String strDbPassWord)
        {
            this.strDbServer = strDbServer;
            this.strDbUserName = strDbUserName;
            this.strDbPassWord = strDbPassWord;
        }

        /*功能：匹配登录用户信息，获取验证结果
          参数：strUserName 用户登录名
                strPassWord 用户登录密码*/
        public bool VerifyUserInfo(String strUserName, String strPassWord)
        {
            bool ret = true;

            return ret;
        }

        /* 功能：查询已注册用户信息。
           参数：strUserID	表示用户的ID号	
                strUserName	表示用户的姓名	
                strTEL	表示用户的联系电话	
                str Email	表示用户的Email*/
        public DataSet FindUser(String strUserID, String strUserName, String strTEL, String strEmail)
        {
            DataSet ret = null;

            return ret;
        }

        /*功能：删除用户信息
          参数：strDelID[]	存放待删除用户的ID号*/
        public bool DeleteUser(String[] strDelID)
        {
            bool ret = true;

            return ret;
        }
        /*功能：添加用户信息
          参数：存放待用户的信息
        */
        public bool InsertUser(string UserName, string UserPwd, string TrueName, string UserEmail, string Address, string UserPost, string UserTel)
        {
            bool ret = true;

            DbConnector conn = new DbConnector();

            string server = ConfigurationSettings.AppSettings["dbServer"];
            string userName = ConfigurationSettings.AppSettings["dbUserName"];
            string passWord = ConfigurationSettings.AppSettings["dbPassWord"];
            string SqlState = "insert into users(username,password,TrueName,email,address,postcode,tel) values('" + UserName + "','" + UserPwd + "','" + TrueName + "','" + UserEmail + "','" + Address + "','" + UserPost + "','" + UserTel + "')"; ;

            conn.connDB(server, userName, passWord);
            if (conn.executeUpdate(SqlState) > 0)
            {
                conn.close();
                return ret;
            }
            else
            {
                conn.close();
                return false;
            }
        }

        /*功能：查看是否已经存在此用户
          参数：strUserName 存放待用户的名称*/
        public bool IsUserExist(String strUserName)
        {
            bool ret = true;
            DbConnector conn = new DbConnector();
            DataSet ds = null;

            string server = ConfigurationSettings.AppSettings["dbServer"];
            string userName = ConfigurationSettings.AppSettings["dbUserName"];
            string passWord = ConfigurationSettings.AppSettings["dbPassWord"];
            string SqlState = "Select Count(*) from users where userName = '" + strUserName + "'";

            conn.connDB(server, userName, passWord);
            ds = conn.executeQuery(SqlState);

            int count = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            if (count > 0)
            {
                ret = true;
            }
            else ret = false;

            conn.close();
            return ret;
        }
    }
}
