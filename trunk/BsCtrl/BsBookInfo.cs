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
            string sql = "select top " + iTopN.ToString() + " bookInfo.ID, bookName, publisher, author, price, indatetime, available, bookClass.className, coverPath, substring(introduce, 0, 50) as intro " + 
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


        /*功能： 返回最热销的iTopN本书
          返回值： 书的详细信息表*/
        public DataSet GetHotBooks(int iTopN)
        {
            DataSet ret = null;
            string sql = "select top " + iTopN.ToString() +
                        " bookInfo.ID, coverPath, bookName, sale, price, author, publisher, substring(introduce, 0, 50) as intro, " + 
                        " bookClass.className from bookInfo left join bookClass on bookClass.ID = classID order by sale desc";
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

        /*功能：返回最热门iTopN分类
          返回值：分类详细信息*/
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

        /*功能：获得iClassId对应的所有书籍信息
         * 返回值：书籍信息
         */
        public DataSet GetClassBooks(int iClassId)
        {
            DataSet ret = null;
            try
            {
                string sql = "select ID, coverPath, bookName, author, publisher, price, available, substring(introduce, 0, 50) as intro from bookInfo where classID=" + iClassId.ToString();
                ret = conn.executeQuery(sql);
            }
            catch (System.Exception e)
            {
                ret = null;
            }
            return ret;
        }

        public string GetClassName(int iClassId)
        {
            string ret = null;
            try
            {
                string sql = "select * from bookClass where ID=" + iClassId.ToString();
                DataSet ds = conn.executeQuery(sql);
                ret = ds.Tables[0].Rows[0]["className"].ToString();
            }
            catch (System.Exception e)
            {
                ret = null;
            }
            return ret;
        }

       /*功能： 根据strKeyWords数组查询图书
          返回值：查询到的图书详细信息*/
        public DataSet SearchBooks(string[] strKeyWords)
        {
            DataSet ret = null;
            try
            {
                string sql = "select ID, coverPath, classID, bookName, publisher, author, price, indatetime, substring(introduce, 0, 50) as intro, sale from " +
                             "bookInfo where ";
                bool bFirst = true;
                foreach(string str in strKeyWords)
                {
                    if (!bFirst)
                        sql = sql + " or ";
                    sql = sql + "bookName like '%" + str + "%'";
                    bFirst = false;
                }
                ret = conn.executeQuery(sql);
            }
            catch (System.Exception e)
            {
                ret = null;
            }
            return ret;
        }

         /*功能：获取一本书籍的信息
         参数：bookId   书籍的索引号
        返回值：标记书籍的所有信息。形式即为表的结构*/
        public DataSet GetBookInfo(int iBookId)
        {
            DataSet ret = conn.executeQuery("select * from bookClass,bookInfo where bookClass.ID = bookInfo.classID and bookInfo.ID = '"+iBookId+"'");

            return ret;
        }

        /*获取所有书籍的信息*/
        public DataSet GetAllBooks()
        {

            DataSet ds = conn.executeQuery("select bookClass.className,bookClass.bookCount,bookInfo.* from bookClass,bookInfo where bookClass.ID = bookInfo.classID order by indatetime DESC");
            
            return ds;
        }

        /*添加书籍*/
        public Boolean InsertNewBook(String BookName,String BookType,String Author,String Pub,String PubTime,String ISBN,String Price,String Quantity,String ImageUrl,String BookScript)
        {
            String indate = DateTime.Now.ToString();
            String sqlcmd = "Insert into bookInfo(ISBN,classID,bookName,publisher,author,introduce,price,available,pubdatetime,indatetime,coverPath) values('"+ISBN+"','"+BookType+"','"+BookName+"','"+Pub+"','"+Author+"','"+BookScript+"',"+Price+",'"+Quantity+"','"+PubTime+"','"+indate+"','"+ImageUrl+"')";
            if (conn.executeUpdate(sqlcmd) > 0)
            {
                return true;
            } 
            else
            {
                return false;
            }
        }

        /*添加书籍分类*/
        public Boolean InsertNewBookType(String TypeName)
        {
            String sqlcmd = "Insert into bookClass(className) values('"+TypeName+"')";
            if (conn.executeUpdate(sqlcmd) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*更新书籍分类*/
        public Boolean UpdateBookType(String TypeID,int controlID)
        {
            String sqlcmd = null;
            if(controlID == 1)
            {
                sqlcmd = "Update bookClass set bookCount = bookCount+1 where ID = '"+TypeID+"'";
            }
            else
            {
                sqlcmd = "Update bookClass set bookCount = bookCount-1 where ID = '" + TypeID + "'";
            }
            if (conn.executeUpdate(sqlcmd) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean UpdateBookType(String TypeID,String OldType)
        {
            String sqlcmd = "Update bookClass set bookCount = bookCount+1 where ID = '" + TypeID + "'";
            String sqlcmd1 = "Update bookClass set bookCount = bookCount-1 where ID = '" + OldType + "'";
            if (conn.executeUpdate(sqlcmd) > 0 && conn.executeUpdate(sqlcmd1) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*删除书籍分类*/
        public Boolean DeleteBookType(String TypeName)
        {
            String sqlcmd = "select bookCount from bookClass where className ='"+TypeName+"'";
            DataSet ds = new DataSet();
            try
            {
                ds = conn.executeQuery(sqlcmd);
            }
            catch (System.Exception e)
            {
                return false;
            }
            long num = Convert.ToInt64(ds.Tables[0].Rows[0][0]);
            if (num > 0)
            {
                return false;
            }
            sqlcmd = "Delete from bookClass where className = '"+TypeName+"'";
            if (conn.executeUpdate(sqlcmd) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*更新书籍信息*/
        public Boolean UpdateOneBook(String BookID, String BookName, String BookType, String Author, String Pub, String PubTime, String ISBN, String Price, String Quantity, String ImageUrl, String BookScript)
        {
            String indate = DateTime.Now.ToShortDateString();
            String sqlcmd = "Update bookInfo set ISBN = '" + ISBN + "',classID = '" + BookType + "',bookName = '" + BookName + "',publisher = '" + Pub + "',author = '" + Author + "',introduce = '" + BookScript + "',price = " + Price + ",available = '" + Quantity + "',pubdatetime = '" + PubTime + "',coverPath = '" + ImageUrl + "' where ID = '"+BookID+"'";
            if (conn.executeUpdate(sqlcmd) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*删除单个书籍*/
        public Boolean DeleteOneBook(String BookID)
        {
            String sqlcmd = "delete from bookInfo where ID = '"+BookID+"'";
            if (conn.executeUpdate(sqlcmd) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*指定书籍*/
        public DataSet GetFamiliarBooks(String bookName)
        {

            DataSet ds = conn.executeQuery("select bookClass.className,bookClass.bookCount,bookInfo.* from bookClass,bookInfo where bookClass.ID = bookInfo.classID and bookInfo.bookName like '%"+bookName+"%'");

            return ds;
        }
    }       
}
