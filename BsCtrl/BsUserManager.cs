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

        /*���ܣ�ƥ���¼�û���Ϣ����ȡ��֤���
          ������strUserName �û���¼��
                strPassWord �û���¼����*/
        public bool VerifyUserInfo(String strUserName, String strPassWord)
        {
            bool ret = true;

            return ret;
        }

        /* ���ܣ���ѯ��ע���û���Ϣ��
           ������strUserID	��ʾ�û���ID��	
                strUserName	��ʾ�û�������	
                strTEL	��ʾ�û�����ϵ�绰	
                str Email	��ʾ�û���Email*/
        public DataSet FindUser(String strUserID, String strUserName, String strTEL, String strEmail)
        {
            DataSet ret = null;

            return ret;
        }

        /*���ܣ�ɾ���û���Ϣ
          ������strDelID[]	��Ŵ�ɾ���û���ID��*/
        public bool DeleteUser(String[] strDelID)
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

        /*���ܣ��鿴�Ƿ��Ѿ����ڴ��û�
          ������strUserName ��Ŵ��û�������*/
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
