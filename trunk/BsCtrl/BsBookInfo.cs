using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DbConnect;

namespace BsCtrl
{
    public class BsBookInfo
    {
        private String strDbServer;
        private String strDbUserName;
        private String strDbPassWord;
        private DbConnector conn;

        public BsBookInfo(String strDbServer, String strDbUserName, String strDbPassWord)
        {
            this.strDbServer = strDbServer;
            this.strDbUserName = strDbUserName;
            this.strDbPassWord = strDbPassWord;
            conn = new DbConnector();
            conn.connDB(strDbServer, strDbUserName, strDbPassWord);
        }

        /*���ܣ���ȡ�鼮�����б�
          ����ֵ�������鼮�ķ����б���*/
        public DataSet GetBookClassify()
        {
            DataSet ret = null;
            try 
            {
                ret = conn.executeQuery("select * from bookClass");
            }
            catch(Exception e)
            {
                ret = null;
            }
            return ret;
        }

        /*���ܣ���ȡ������Ϣ
          ����ֵ����Ҫ��ʾ�Ĺ����ַ�����*/
        public string DataSetGetPost()
        {
            string ret = null;
            return ret;
        }

        /*���ܣ� �������µ�iTopN����
          ����ֵ�� �����ϸ��Ϣ��*/
        public DataSet GetNewBooks(int iTopN)
        {
            DataSet ret = null;
            string sql = "select top " + iTopN.ToString() + "* from bookInfo order by indatetime desc";

            try
            {
                ret = conn.executeQuery(sql);
            }
            catch (System.Exception e)
            {
                ret = null;
            }

            return ret;
        }


        /*���ܣ� ������������iTopN����
          ����ֵ�� �����ϸ��Ϣ��*/
        public DataSet GetHotBooks(int iTopN)
        {
            DataSet ret = null;

            return ret;
        }

        /*���ܣ� ����strKeyWords�����ѯͼ��
          ����ֵ����ѯ����ͼ����ϸ��Ϣ*/
        public DataSet SearchBooks(string[] strKeyWords)
        {
            DataSet ret = null;

            return ret;
        }

        /*���ܣ���ȡһ���鼮����Ϣ
         ������bookId   �鼮��������
        ����ֵ������鼮��������Ϣ����ʽ��Ϊ��Ľṹ*/
        public DataSet GetBookInfo(int iBookId)
        {
            DataSet ret = null;

            return ret;
        }
    }
}
