using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
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


        /*���ܣ� ������������iTopN����
          ����ֵ�� �����ϸ��Ϣ��*/
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

       /*���ܣ� ����strKeyWords�����ѯͼ��
          ����ֵ����ѯ����ͼ����ϸ��Ϣ*/
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

         /*���ܣ���ȡһ���鼮����Ϣ
         ������bookId   �鼮��������
        ����ֵ������鼮��������Ϣ����ʽ��Ϊ��Ľṹ*/
        public DataSet GetBookInfo(int iBookId)
        {
            DataSet ret = conn.executeQuery("select * from bookClass,bookInfo where bookClass.ID = bookInfo.classID and bookInfo.ID = '"+iBookId+"'");

            return ret;
        }

        /*��ȡ�����鼮����Ϣ*/
        public DataSet GetAllBooks()
        {

            DataSet ds = conn.executeQuery("select bookClass.className,bookClass.bookCount,bookInfo.* from bookClass,bookInfo where bookClass.ID = bookInfo.classID order by indatetime DESC");
            
            return ds;
        }

        /*����鼮*/
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

        /*����鼮����*/
        public Boolean InsertNewBookType(String TypeName)
        {
            String sqlcmd = "Select * from bookClass where className = '" + TypeName + "'";
            DataSet ds = new DataSet();
            try
            {
                ds = conn.executeQuery(sqlcmd);
            }
            catch (System.Exception e)
            {
                return false;
            }

            if (ds == null || ds.Tables[0].Rows.Count > 0)
            {
                return false;
            }

            sqlcmd = "Insert into bookClass(className) values('"+TypeName+"')";
            if (conn.executeUpdate(sqlcmd) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*�����鼮����*/
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

        /*ɾ���鼮����*/
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
            long num = 1;
            if (ds.Tables[0].Rows.Count > 0)
            {
                num = Convert.ToInt64(ds.Tables[0].Rows[0][0]);
            }
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

        /*�����鼮��Ϣ*/
        public Boolean UpdateOneBook(String BookID, String BookName, String BookType, String Author, String Pub, String PubTime, String ISBN, String Price, String Quantity, String ImageUrl, String BookScript,String BookDis)
        {
            String indate = DateTime.Now.ToShortDateString();
            String sqlcmd = "Update bookInfo set ISBN = '" + ISBN + "',classID = '" + BookType + "',bookName = '" + BookName + "',publisher = '" + Pub + "',author = '" + Author + "',introduce = '" + BookScript + "',price = " + Price + ",available = '" + Quantity + "',pubdatetime = '" + PubTime + "',coverPath = '" + ImageUrl + "',discount = '"+ BookDis +"' where ID = '"+BookID+"'";
            if (conn.executeUpdate(sqlcmd) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*ɾ�������鼮*/
        public Boolean DeleteOneBook(String BookID)
        {
            String sql = "Select * from orderDetail where bookID = '"+BookID+"'";
            DataSet ds = new DataSet();
            try
            {
                ds = conn.executeQuery(sql);
            }
            catch (System.Exception e)
            {
                return false;
            }
            if (ds == null || ds.Tables[0].Rows.Count > 0)
            {
                return false;
            }
            String sqlcmd = "Delete from bookInfo where ID = '"+BookID+"'";
            String sqlcmd1 = "Delete from comment where bookID = '"+BookID+"'";
            if (conn.executeUpdate(sqlcmd1) >= 0 && conn.executeUpdate(sqlcmd) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*ָ���鼮*/
        public DataSet GetFamiliarBooks(String bookName)
        {

            DataSet ds = conn.executeQuery("select bookClass.className,bookClass.bookCount,bookInfo.* from bookClass,bookInfo where bookClass.ID = bookInfo.classID and bookInfo.bookName like '%"+bookName+"%'");

            return ds;
        }

        /*��ȡһ�����������Ϣ*/
        public DataSet GetOneComment(int bookID)
        {
            String sqlcmd = "select comment.*,username from comment,users where users.ID = comment.userID and bookID = '" + bookID + "'";
            DataSet ds = new DataSet();

            try
            {
                ds = conn.executeQuery(sqlcmd);
            }
            catch (System.Exception e)
            {
                ds = null;
            }
            return ds;
        }

        /*�������*/
        public Boolean AddOneComment(int bookID,String userName,String commentTxt,int Scores)
        {
            String sqlcmd = "Select ID from users where username = '"+userName+"'";
            DataSet ds = new DataSet();
            try
            {
                ds = conn.executeQuery(sqlcmd);
            }
            catch (System.Exception e)
            {
                return false;
            }

            int userID = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

            sqlcmd = "Insert into comment(bookID,userID,comment,score) values('"+bookID+"','"+userID+"','"+commentTxt+"','"+Scores+"')";
            String sqlcmd1 = null;

            switch (Scores)
            {
                case 1: sqlcmd1 = "Update bookInfo set bad = bad + 1 where ID = '" + bookID + "'";
            	        break;
                case 2: sqlcmd1 = "Update bookInfo set middle = middle + 1 where ID = '" + bookID + "'";
                        break;
                case 3: sqlcmd1 = "Update bookInfo set good = good + 1 where ID = '" + bookID + "'";
                        break;
            }

            if (conn.executeUpdate(sqlcmd) > 0 && conn.executeUpdate(sqlcmd1) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*��XML�ļ���д������*/
        public Boolean WriteToXML(String TypeName,String FilePath)
        {
            XmlDocument xmlD = new XmlDocument();
            try
            {
                xmlD.Load(FilePath);
            }
            catch (System.Exception e)
            {
                return false;
            }
            

            XmlElement xmlEle = xmlD.CreateElement("BookType");
            xmlEle.InnerXml = "\r\n<TypeID></TypeID>\r\n<TypeName></TypeName>";
            xmlEle["TypeID"].InnerText = TypeName;
            xmlEle.AppendChild(xmlD.CreateWhitespace("\r\n"));
            xmlEle["TypeName"].InnerText = TypeName;

            xmlD.DocumentElement.AppendChild(xmlEle);
            xmlD.PreserveWhitespace = true;
            try
            {
                XmlTextWriter xmlTW = new XmlTextWriter(FilePath, Encoding.UTF8);
                xmlD.WriteTo(xmlTW);
                xmlTW.Close();
            }
            catch (System.Exception e)
            {
                return false;
            }

            return true;
        }

        /*��XML�ļ���ɾ������*/
        public Boolean DeleteFromXML(String TypeName,String FilePath)
        {
            XmlDocument xmlD = new XmlDocument();
            try
            {
                xmlD.Load(FilePath);
            }
            catch (System.Exception e)
            {
                return false;
            }
            
            XmlNodeList xmlNL = xmlD.SelectNodes("//BookType");
            foreach (XmlNode xmlN in xmlNL)
            {
                if (xmlN.FirstChild.FirstChild.Value == TypeName)
                {
                    xmlN.RemoveAll();
                    xmlN.ParentNode.RemoveChild(xmlN);
                    break;
                }
            }
            xmlD.PreserveWhitespace = true;

            try
            {
                XmlTextWriter xmlTW = new XmlTextWriter(FilePath, Encoding.UTF8);
                xmlD.WriteTo(xmlTW);
                xmlTW.Close();
            }
            catch (System.Exception e)
            {
                return false;
            }
            
            return true;
        }
    }       
}
