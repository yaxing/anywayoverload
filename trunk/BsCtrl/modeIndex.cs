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


            //����ȫ�ֱ���dbServer��dbUserName��dbPassWord��Ҫ�������ݿ�Ͱ��������-------------
            //���Ҫ�޸�ȫ�ֱ���ֵ�Ļ�����Web.Config�����<appSettings>��
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
