using System;
using System.Collections.Generic;
using System.Text;

namespace BsCtrl
{
    public class BsBookInfo
    {
        /*功能：获取书籍分类列表
          返回值：返回书籍的分类列表集。*/
        public DataSet GetBookClassify()
        {
            DataSet ret = null;

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
    }
}
