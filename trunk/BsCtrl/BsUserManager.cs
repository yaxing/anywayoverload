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



        /* ���ܣ���ѯ��ע���û���Ϣ��
           ������strUserID	��ʾ�û���ID��	
                strUserName	��ʾ�û�������	
                strTEL	��ʾ�û�����ϵ�绰	
                str Email	��ʾ�û���Email*/
        public DataSet searchUser(String str)
        {
            DataSet ret = null;

            DbConnector connSch = new  DbConnector();
            connSch.connDB("localhost","sa",".");
            ret = connSch.executeQuery(str);
            connSch.close();

            return ret;
        }

        /*���ܣ�ɾ���û���Ϣ
          ������strDelID[]	��Ŵ�ɾ���û���ID��*/
        public bool deleteUser(int id)
        {
            bool ret = true;

            String sql = "Delete from users where 1=1 and id =" + id;

            DbConnector connDel = new DbConnector();
            connDel.connDB("localhost","sa",".");
            connDel.executeUpdate(sql); //ִ�и��²���
            connDel.close();    //�ر����ݿ�����

            return ret;
        }

        /*���ܣ����£��޸ģ��û���Ϣ
         ������id,userName,password,tel,email,grade*/
        public bool updateUser(int id, string useName, string password, string tel, string email, int grade) {
            bool ret = true;

            String sql = "Update users set userName=" + "'" + useName + "'" + ",password=" +"'" + password + "'" + ",tel="
                + "'" + tel + "'" + ",email=" + "'" + email + "'" + ",grade=" + grade + "Where id=" + id;
            DbConnector connUp = new DbConnector();
            connUp.connDB("localhost","sa",".");
            connUp.executeUpdate(sql);
            connUp.close(); //�ر����ݿ�����

            return ret;
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
