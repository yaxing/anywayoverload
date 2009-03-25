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
        private String strDbConn;
        private DbConnector conn;

        public BsBookInfo(String strDbServer, String strDbUserName, String strDbPassWord)
        {
            this.strDbServer = strDbServer;
            this.strDbUserName = strDbUserName;
            this.strDbPassWord = strDbPassWord;
            conn = new DbConnector();
            conn.connDB(strDbServer, strDbUserName, strDbPassWord);
        }

        public BsBookInfo(String strDbConn)
        {
            this.strDbConn = strDbConn;
            conn = new DbConnector();
            conn.connDB(strDbConn);
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
            string sql = "select top " + iTopN.ToString() + " bookInfo.ID, bookName, publisher, author, price, indatetime, available, bookClass.className, coverPath " + 
                         "from bookInfo left join bookClass on bookClass.ID = classID order by indatetime desc";

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
            string sql = "select top " + iTopN.ToString() + " ID, bookName, sale from bookInfo order by sale desc";
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

        /*���ܣ�����������iTopN����
          ����ֵ��������ϸ��Ϣ*/
        public DataSet GetHotClasses(int iTopN)
        {
            DataSet ret = null;
            string sql = "select top " + iTopN.ToString() + " * from bookClass order by bookCount desc";
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

        /*���ܣ����iClassId��Ӧ�������鼮��Ϣ
         * ����ֵ���鼮��Ϣ
         */
        public DataSet GetClassBooks(int iClassId)
        {
            DataSet ret = null;
            try
            {
                string sql = "select ID, bookName, author, publisher, price, available from bookInfo where classID=" + iClassId.ToString();
                ret = conn.executeQuery(sql);
            }
            catch (System.Exception e)
            {
                ret = null;
            }
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
