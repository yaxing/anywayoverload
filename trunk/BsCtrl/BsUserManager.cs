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


        /////////�Թ���Ա����///////////

        /*���ܣ�����¹���Ա
          ������strName    ����Ա�û���
                strPwd     ����
                strEmail   Email
                strLevel   ����Ա�ȼ�
         */
        public int addAdmin(String strName, String strPwd, String strEmail, String strLevel)
        {
            int ret;
            int intLevel = Convert.ToInt32(strLevel);
            String strConn = ConfigurationSettings.AppSettings["dbConnString"];
            String sql = "insert admin values (" + "'" + strName + "'" + "," + "'" + strPwd + "'" + "," + "'" + strEmail + "'" + "," + intLevel + ")";

            //�������ݿ⣬ִ�в������
            DbConnector connIns = new DbConnector();
            connIns.connDB(strConn);
            ret = connIns.executeUpdate(sql);

            //�ر����ݿ�����
            connIns.close();

            //���ؽ��
            return ret;
        }


        /*���ܣ���ѯ����Ա��Ϣ
          ������strID
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
            if (strLevel != "��ѡ")
            {
                int intLevel = Convert.ToInt32(strLevel);
                sql += "level = " + strLevel;
            }

            //�������ݿ⣬ִ�в�ѯ����
            DbConnector connSch = new DbConnector();
            connSch.connDB(strConn);
            ret = connSch.executeQuery(sql);
            connSch.close();

            return ret;
        }

        /*���ܣ����¹���Ա��Ϣ
          ������
         */
        public bool updateAdmin(String strID, String strName, String strPwd, String strEmail, String strLevel)
        {
            bool ret = true;
            String strConn = ConfigurationSettings.AppSettings["dbConnString"];
            int intID = Convert.ToInt32(strID);
            String sql = "Update admin set password=" + "'" + strPwd + "'" + ",email=" + "'" + strEmail + "'" + ",level=" + strLevel + "Where id=" + intID;

            //�������ݿ⣬ִ�и��²���
            DbConnector connUp = new DbConnector();
            connUp.connDB(strConn);
            connUp.executeUpdate(sql);
            connUp.close(); //�ر����ݿ�����

            return ret;

        }


        /*���ܣ�ɾ������Ա
          ������intID   ��ʾ����ԱID
         
         */
        public bool deleteAdmin(int intID)
        {
            bool ret = true;
            String strConn = ConfigurationSettings.AppSettings["dbConnString"];
            String sql = "Delete from admin where 1=1 and id =" + intID;
            DbConnector connDel = new DbConnector();
            connDel.connDB(strConn);
            connDel.executeUpdate(sql); //ִ��ɾ������
            connDel.close();    //�ر����ݿ�����

            return ret;

        }

        ////////����ͨ�û�����/////////////

        /* ���ܣ���ѯ��ע���û���Ϣ��
           ������strID	��ʾ�û���ID��	
                strName	��ʾ�û�������	
                strTEL	��ʾ�û�����ϵ�绰	
                strEmail	��ʾ�û���Email
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
            

            //�������ݿ⣬ִ�в�ѯ����
            DbConnector connSch = new DbConnector();
            connSch.connDB(strConn);
            ret = connSch.executeQuery(sql);
            connSch.close();

            return ret;
        }


        /*���ܣ�ɾ���û���Ϣ
          ������strDelID[]	��Ŵ�ɾ���û���ID��*/
        public bool deleteMember(int intID)
        {
            bool ret = true;
            String strConn = ConfigurationSettings.AppSettings["dbConnString"];
            String sql = "Delete from users where 1=1 and id =" + intID;

            DbConnector connDel = new DbConnector();
            connDel.connDB(strConn);
            connDel.executeUpdate(sql); //ִ�и��²���
            connDel.close();    //�ر����ݿ�����

            return ret;
        }

        /*���ܣ����£��޸ģ��û���Ϣ
         ������id,userName,password,tel,email,grade*/
        public bool updateMember(String strID, String strName, String strPwd, String strTEL, String strEmail)
        {
            bool ret = true;
            int intID = Convert.ToInt32(strID);
            String strConn = ConfigurationSettings.AppSettings["dbConnString"];
            String sql = "Update users set password=" + "'" + strPwd + "'" + ",tel="
                + "'" + strTEL + "'" + ",email=" + "'" + strEmail + "'" + "Where id=" + intID;

            //�������ݿ⣬ִ�и��²���
            DbConnector connUp = new DbConnector();
            connUp.connDB(strConn);
            connUp.executeUpdate(sql);
            connUp.close(); //�ر����ݿ�����

            return ret;
        }

        ///////  ����   ////////////////////



        /*���ܣ������û�ID
         �������û���userName
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



        /*���ܣ�ƥ���¼�û���Ϣ����ȡ��֤���DbConnect
        ������strUserName �û���¼��
        strPassWord �û���¼����*/
        public bool VerifyUserInfo(String strUserName, String strPassWord)
        {
            bool ret = true;

            return ret;
        }

        /*���ܣ�����û���Ϣ
          ��������Ŵ��û�����Ϣ
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

        /*���ܣ��鿴�Ƿ��Ѿ����ڴ��û�
          ������strUserName ��Ŵ��û�������*/
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

        /*���ܣ�����md5����
          ������ԭ����strPwd
          ���أ����ܺ�����루String��
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
