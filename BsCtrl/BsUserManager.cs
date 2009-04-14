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
        private String strConn;
        private DbConnector connCmd;

        public BsUserManager(String Conn)    
        {
            strConn = Conn;
            connCmd = new DbConnector();
            connCmd.connDB(strConn);
        }


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
            String sql = "insert admin values (" + "'" + strName + "'" + "," + "'" + strPwd + "'" + "," + "'" + strEmail + "'" + "," + intLevel + ")";

            //链接数据库，执行插入操作
            connCmd.connDB(strConn);
            ret = connCmd.executeUpdate(sql);

            //关闭数据库链接
            connCmd.close();

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
            String sql = "select id,username,password,email,level from admin where 1=1 ";

            if (strID != "")
                sql += "and id = " + "'" + strID + "'";
            if (strName != "")
                sql += "and username = " + "'" + strName + "'";
            if (strEmail != "")
                sql += "and email = " + "'" + strEmail + "'";
            if (strLevel != "不选")
            {
                int intLevel = Convert.ToInt32(strLevel);
                sql += "and level = " + strLevel;
            }

            //链接数据库，执行查询操作
            connCmd.connDB(strConn);
            ret = connCmd.executeQuery(sql);
            connCmd.close();

            return ret;
        }

        /*功能：更新管理员信息
          参数：
         */
        public bool updateAdmin(String strID, String strName, String strPwd, String strEmail, String strLevel)
        {
            bool ret = true;
            int intID = Convert.ToInt32(strID);
            String sql = "Update admin set password=" + "'" + strPwd + "'" + ",email=" + "'" + strEmail + "'" + ",level=" + strLevel + "Where id=" + intID;

            //链接数据库，执行更新操作
            connCmd.connDB(strConn);
            connCmd.executeUpdate(sql);
            connCmd.close(); //关闭数据库链接

            return ret;

        }


        /*功能：删除管理员
          参数：intID   表示管理员ID
         
         */
        public bool deleteAdmin(int intID)
        {
            bool ret = true;
            String sql = "Delete from admin where 1=1 and id =" + intID;

            connCmd.connDB(strConn);
            connCmd.executeUpdate(sql); //执行删除操作
            connCmd.close();    //关闭数据库链接

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
            String sql = "select id,username,password,tel,email,grade from users where 1=1 ";

            if (strID != "")
            {
                int intID = Convert.ToInt32(strID);
                sql += "and id = " + "'" + intID + "'";
            }
             
            if (strName != "")
                sql += "and username = " + "'" + strName + "'";
            if (strTEL != "")
                sql += "and tel = " + "'" + strTEL + "'";
            if (strEmail != "")
                sql += "and email = " + "'" + strEmail + "'";
            

            //链接数据库，执行查询操作
            connCmd.connDB(strConn); ;
            ret = connCmd.executeQuery(sql);
            connCmd.close();

            return ret;
        }


        /*功能：删除用户信息
          参数：strDelID[]	存放待删除用户的ID号*/
        public bool deleteMember(int intID)
        {
            bool ret = true;
            String sql = "Delete from users where 1=1 and id =" + intID;

            connCmd.connDB(strConn);
            connCmd.executeUpdate(sql); //执行更新操作
            connCmd.close();    //关闭数据库链接

            return ret;
        }

        /*功能：更新（修改）用户信息
         参数：id,userName,password,tel,email,grade*/
        public bool updateMember(String strID, String strName, String strPwd, String strTEL, String strEmail)
        {
            bool ret = true;
            int intID = Convert.ToInt32(strID);
            String sql = "Update users set password=" + "'" + strPwd + "'" + ",tel="
                + "'" + strTEL + "'" + ",email=" + "'" + strEmail + "'" + "Where id=" + intID;

            //链接数据库，执行更新操作
            connCmd.connDB(strConn);
            connCmd.executeUpdate(sql);
            connCmd.close(); //关闭数据库链接

            return ret;
        }


        /*功能：返回用户ID
         参数：用户的userName
       */
        public int findUser(String userName)
        {
            DataSet ds = null;
            
            string SqlState = "Select ID from users where username = '" + userName + "'";
            ds = connCmd.executeQuery(SqlState);

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
            
            string SqlState = "insert into users(username,password,TrueName,email,address,postcode,tel) values('" + UserName + "','" + UserPwd + "','" + TrueName + "','" + UserEmail + "','" + Address + "','" + UserPost + "','" + UserTel + "')";

            if (connCmd.executeUpdate(SqlState) > 0)
            {
                connCmd.close();
                return ret;
            }
            else
            {
                connCmd.close();
                return false;
            }
        }

        /*功能：查看是否已经存在此用户
          参数：strUserName 存放待用户的名称*/
        public bool IsUserExist(String strUserName)
        {
            bool ret = true;
            DataSet ds = null;
            
            string SqlState = "Select Count(*) from users where userName = '" + strUserName + "'";
            ds = connCmd.executeQuery(SqlState);

            int count = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            if (count > 0)
            {
                ret = true;
            }
            else ret = false;

            connCmd.close();
            return ret;
        }

        /*功能：返回用户信息
          参数：用户ID
          返回：该用户的所有信息
        */
        public DataTable ShowUserInfo(int iUserID)
        {
            DataSet ds = null;
            
            string SqlState = "Select * from users where ID = " + iUserID;
            ds = connCmd.executeQuery(SqlState);
            connCmd.close();

            return ds.Tables[0];
        }

        /*功能：更新用户信息
          参数：用户ID
          返回：更新是否成功
        */
        public Boolean UpdateUserInfo(int iUserID,String sTureName, String sEmail, String sAddress, String sTel, String sPost)
        {
            string SqlState = "Update users Set trueName = '" + sTureName + "', email = '" + sEmail + "', address = '" + sAddress + "', tel = '" + sTel + "', postcode = '" + sPost + "' where ID = " + iUserID;
            if(connCmd.executeUpdate(SqlState) > 0)
            {
                connCmd.close();
                return true;
            }
            else 
            {
                connCmd.close(); 
                return false; 
            }
        }

        /*功能：更新用户密码
          参数：用户ID
          返回：更新是否成功
        */
        public Boolean UpdateUserPass(int iUserID,String sPassWord)
        {

            string SqlState = "Update users Set passWord = '" + sPassWord + "' where ID = " + iUserID;
            if (connCmd.executeUpdate(SqlState) > 0)
            {
                connCmd.close();
                return true;
            }
            else
            {
                connCmd.close();
                return false;
            }
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
