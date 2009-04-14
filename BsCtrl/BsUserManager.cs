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
            String sql = "insert admin values (" + "'" + strName + "'" + "," + "'" + strPwd + "'" + "," + "'" + strEmail + "'" + "," + intLevel + ")";

            //�������ݿ⣬ִ�в������
            connCmd.connDB(strConn);
            ret = connCmd.executeUpdate(sql);

            //�ر����ݿ�����
            connCmd.close();

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
            String sql = "select id,username,password,email,level from admin where 1=1 ";

            if (strID != "")
                sql += "and id = " + "'" + strID + "'";
            if (strName != "")
                sql += "and username = " + "'" + strName + "'";
            if (strEmail != "")
                sql += "and email = " + "'" + strEmail + "'";
            if (strLevel != "��ѡ")
            {
                int intLevel = Convert.ToInt32(strLevel);
                sql += "and level = " + strLevel;
            }

            //�������ݿ⣬ִ�в�ѯ����
            connCmd.connDB(strConn);
            ret = connCmd.executeQuery(sql);
            connCmd.close();

            return ret;
        }

        /*���ܣ����¹���Ա��Ϣ
          ������
         */
        public bool updateAdmin(String strID, String strName, String strPwd, String strEmail, String strLevel)
        {
            bool ret = true;
            int intID = Convert.ToInt32(strID);
            String sql = "Update admin set password=" + "'" + strPwd + "'" + ",email=" + "'" + strEmail + "'" + ",level=" + strLevel + "Where id=" + intID;

            //�������ݿ⣬ִ�и��²���
            connCmd.connDB(strConn);
            connCmd.executeUpdate(sql);
            connCmd.close(); //�ر����ݿ�����

            return ret;

        }


        /*���ܣ�ɾ������Ա
          ������intID   ��ʾ����ԱID
         
         */
        public bool deleteAdmin(int intID)
        {
            bool ret = true;
            String sql = "Delete from admin where 1=1 and id =" + intID;

            connCmd.connDB(strConn);
            connCmd.executeUpdate(sql); //ִ��ɾ������
            connCmd.close();    //�ر����ݿ�����

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
            

            //�������ݿ⣬ִ�в�ѯ����
            connCmd.connDB(strConn); ;
            ret = connCmd.executeQuery(sql);
            connCmd.close();

            return ret;
        }


        /*���ܣ�ɾ���û���Ϣ
          ������strDelID[]	��Ŵ�ɾ���û���ID��*/
        public bool deleteMember(int intID)
        {
            bool ret = true;
            String sql = "Delete from users where 1=1 and id =" + intID;

            connCmd.connDB(strConn);
            connCmd.executeUpdate(sql); //ִ�и��²���
            connCmd.close();    //�ر����ݿ�����

            return ret;
        }

        /*���ܣ����£��޸ģ��û���Ϣ
         ������id,userName,password,tel,email,grade*/
        public bool updateMember(String strID, String strName, String strPwd, String strTEL, String strEmail)
        {
            bool ret = true;
            int intID = Convert.ToInt32(strID);
            String sql = "Update users set password=" + "'" + strPwd + "'" + ",tel="
                + "'" + strTEL + "'" + ",email=" + "'" + strEmail + "'" + "Where id=" + intID;

            //�������ݿ⣬ִ�и��²���
            connCmd.connDB(strConn);
            connCmd.executeUpdate(sql);
            connCmd.close(); //�ر����ݿ�����

            return ret;
        }


        /*���ܣ������û�ID
         �������û���userName
       */
        public int findUser(String userName)
        {
            DataSet ds = null;
            
            string SqlState = "Select ID from users where username = '" + userName + "'";
            ds = connCmd.executeQuery(SqlState);

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

        /*���ܣ��鿴�Ƿ��Ѿ����ڴ��û�
          ������strUserName ��Ŵ��û�������*/
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

        /*���ܣ������û���Ϣ
          �������û�ID
          ���أ����û���������Ϣ
        */
        public DataTable ShowUserInfo(int iUserID)
        {
            DataSet ds = null;
            
            string SqlState = "Select * from users where ID = " + iUserID;
            ds = connCmd.executeQuery(SqlState);
            connCmd.close();

            return ds.Tables[0];
        }

        /*���ܣ������û���Ϣ
          �������û�ID
          ���أ������Ƿ�ɹ�
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

        /*���ܣ������û�����
          �������û�ID
          ���أ������Ƿ�ɹ�
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
