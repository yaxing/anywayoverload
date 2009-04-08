using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DbConnect;
using System.Configuration;
using System.Security.Cryptography;

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


        /////////对管理员操作///////////

        /*功能：添加新管理员
          参数：strName    管理员用户名
                strPwd     密码
                strEmail   Email
                strLevel   管理员等级
         */
        public int addAdmin(String strName, String strPwd, String strEmail, String strLevel)
        {
            int ret;
            int intLevel = Convert.ToInt32(strLevel);
            String strConn = ConfigurationSettings.AppSettings["dbConnString"];
            String sql = "insert admin values (" + "'" + strName + "'" + "," + "'" + strPwd + "'" + "," + "'" + strEmail + "'" + "," + intLevel + ")";

            //链接数据库，执行插入操作
            DbConnector connIns = new DbConnector();
            connIns.connDB(strConn);
            ret = connIns.executeUpdate(sql);

            //关闭数据库链接
            connIns.close();

            //返回结果
            return ret;
        }


        /*功能：查询管理员信息
          参数：strID
                strName
                strEmail
                intLevel
         */
        public DataSet searchAdmin(String strID, String strName, String strEmail, String strLevel)
        {
            DataSet ret = null;
            String strConn = ConfigurationSettings.AppSettings["dbConnString"];
            String sql = "select id,username,password,email,level from admin where 1=1 and ";

            if (strID != "")
                sql += "id = " + "'" + strID + "'";
            if (strName != "")
                sql += "username = " + "'" + strName + "'";
            if (strEmail != "")
                sql += "email = " + "'" + strEmail + "'";
            if (strLevel != "不选")
            {
                int intLevel = Convert.ToInt32(strLevel);
                sql += "level = " + strLevel;
            }

            //链接数据库，执行查询操作
            DbConnector connSch = new DbConnector();
            connSch.connDB(strConn);
            ret = connSch.executeQuery(sql);
            connSch.close();

            return ret;
        }

        /*功能：更新管理员信息
          参数：
         */
        public bool updateAdmin(String strID, String strName, String strPwd, String strEmail, String strLevel)
        {
            bool ret = true;
            String strConn = ConfigurationSettings.AppSettings["dbConnString"];
            int intID = Convert.ToInt32(strID);
            String sql = "Update admin set password=" + "'" + strPwd + "'" + ",email=" + "'" + strEmail + "'" + ",level=" + strLevel + "Where id=" + intID;

            //链接数据库，执行更新操作
            DbConnector connUp = new DbConnector();
            connUp.connDB(strConn);
            connUp.executeUpdate(sql);
            connUp.close(); //关闭数据库链接

            return ret;

        }


        /*功能：删除管理员
          参数：intID   表示管理员ID
         
         */
        public bool deleteAdmin(int intID)
        {
            bool ret = true;
            String strConn = ConfigurationSettings.AppSettings["dbConnString"];
            String sql = "Delete from admin where 1=1 and id =" + intID;
            DbConnector connDel = new DbConnector();
            connDel.connDB(strConn);
            connDel.executeUpdate(sql); //执行删除操作
            connDel.close();    //关闭数据库链接

            return ret;

        }

        ////////对普通用户操作/////////////

        /* 功能：查询已注册用户信息。
           参数：strID	表示用户的ID号	
                strName	表示用户的姓名	
                strTEL	表示用户的联系电话	
                strEmail	表示用户的Email
                strGrade*/

        public DataSet searchMember(String strID, String strName, String strTEL, String strEmail)
        {
            DataSet ret = null;
            String strConn = ConfigurationSettings.AppSettings["dbConnString"];
            String sql = "select id,username,password,tel,email,grade from users where 1=1 and ";

            if (strID != "")
            {
                int intID = Convert.ToInt32(strID);
                sql += "id = " + "'" + intID + "'";
            }
             
            if (strName != "")
                sql += "username = " + "'" + strName + "'";
            if (strTEL != "")
                sql += "tel = " + "'" + strTEL + "'";
            if (strEmail != "")
                sql += "email = " + "'" + strEmail + "'";
            

            //链接数据库，执行查询操作
            DbConnector connSch = new DbConnector();
            connSch.connDB(strConn);
            ret = connSch.executeQuery(sql);
            connSch.close();

            return ret;
        }


        /*功能：删除用户信息
          参数：strDelID[]	存放待删除用户的ID号*/
        public bool deleteMember(int intID)
        {
            bool ret = true;
            String strConn = ConfigurationSettings.AppSettings["dbConnString"];
            String sql = "Delete from users where 1=1 and id =" + intID;

            DbConnector connDel = new DbConnector();
            connDel.connDB(strConn);
            connDel.executeUpdate(sql); //执行更新操作
            connDel.close();    //关闭数据库链接

            return ret;
        }

        /*功能：更新（修改）用户信息
         参数：id,userName,password,tel,email,grade*/
        public bool updateMember(String strID, String strName, String strPwd, String strTEL, String strEmail)
        {
            bool ret = true;
            int intID = Convert.ToInt32(strID);
            String strConn = ConfigurationSettings.AppSettings["dbConnString"];
            String sql = "Update users set password=" + "'" + strPwd + "'" + ",tel="
                + "'" + strTEL + "'" + ",email=" + "'" + strEmail + "'" + "Where id=" + intID;

            //链接数据库，执行更新操作
            DbConnector connUp = new DbConnector();
            connUp.connDB(strConn);
            connUp.executeUpdate(sql);
            connUp.close(); //关闭数据库链接

            return ret;
        }

        ///////  王超   ////////////////////



        /*功能：返回用户ID
         参数：用户的userName
       */
        public int findUser(String userName)
        {
            DataSet ds = null;
            DbConnector db = new DbConnector();

            String connStr = ConfigurationSettings.AppSettings["dbConnString"];
            db.connDB(connStr);

            string SqlState = "Select ID from users where username = '" + userName + "'";
            ds = db.executeQuery(SqlState);

            int userid = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

            return userid;
        }



        /*功能：匹配登录用户信息，获取验证结果DbConnect
        参数：strUserName 用户登录名
        strPassWord 用户登录密码*/
        public bool VerifyUserInfo(String strUserName, String strPassWord)
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
            DbConnector db = new DbConnector();

            String connStr = ConfigurationSettings.AppSettings["dbConnString"];
            db.connDB(connStr);
            string SqlState = "insert into users(username,password,TrueName,email,address,postcode,tel) values('" + UserName + "','" + UserPwd + "','" + TrueName + "','" + UserEmail + "','" + Address + "','" + UserPost + "','" + UserTel + "')"; 

            if (db.executeUpdate(SqlState) > 0)
            {
                db.close();
                return ret;
            }
            else
            {
                db.close();
                return false;
            }
        }

        /*功能：查看是否已经存在此用户
          参数：strUserName 存放待用户的名称*/
        public bool IsUserExist(String strUserName)
        {
            bool ret = true;
            DataSet ds = null;
            DbConnector db = new DbConnector();

            String connStr = ConfigurationSettings.AppSettings["dbConnString"];
            db.connDB(connStr);
            string SqlState = "Select Count(*) from users where userName = '" + strUserName + "'";
            ds = db.executeQuery(SqlState);

            int count = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            if (count > 0)
            {
                ret = true;
            }
            else ret = false;

            db.close();
            return ret;
        }

        /*功能：密码md5加密
          参数：原密码strPwd
          返回：加密后的密码（String）
        */

        public static string MD5(string strPwd)
        {
            MD5CryptoServiceProvider MD5CSP = new MD5CryptoServiceProvider();
            byte[] MD5Pwd = System.Text.Encoding.UTF8.GetBytes(strPwd);
            byte[] MD5Out = MD5CSP.ComputeHash(MD5Pwd);
            return Convert.ToBase64String(MD5Out);
        } 
    }

}
