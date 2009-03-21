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

        /*功能：获取书籍分类列表
          返回值：返回书籍的分类列表集。*/
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

        /*功能：获取公告信息
          返回值：需要显示的公告字符串。*/
        public string DataSetGetPost()
        {
            string ret = null;
            return ret;
        }

        /*功能： 返回最新的iTopN本书
          返回值： 书的详细信息表*/
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


        /*功能： 返回最热销的iTopN本书
          返回值： 书的详细信息表*/
        public DataSet GetHotBooks(int iTopN)
        {
            DataSet ret = null;

            return ret;
        }

        /*功能： 根据strKeyWords数组查询图书
          返回值：查询到的图书详细信息*/
        public DataSet SearchBooks(string[] strKeyWords)
        {
            DataSet ret = null;

            return ret;
        }

        /*功能：获取一本书籍的信息
         参数：bookId   书籍的索引号
        返回值：标记书籍的所有信息。形式即为表的结构*/
        public DataSet GetBookInfo(int iBookId)
        {
            DataSet ret = null;

            return ret;
        }
    }
}
