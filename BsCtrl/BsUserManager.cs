using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BsCtrl
{
    public class BsUserManager
    {
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
    }
}
