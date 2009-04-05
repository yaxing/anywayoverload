using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DbConnect;

namespace BsCtrl
{
    /*������*/
    public class BsOrder
    {
        /*���ܣ��鿴���û��Ķ���
          ������iUserID ��Ŵ��û���ID*/
        public DataTable SelectOrders(int iUserID)
        {
            DataSet ds = new DataSet();
            DbConnector db = new DbConnector();

            String connStr = ConfigurationSettings.AppSettings["dbConnString"];
            db.connDB(connStr);
            string SqlState = "select * from orders where userID = " + Convert.ToString(iUserID) + "Order by orderDatetime DESC";

            ds = db.executeQuery(SqlState);

            return ds.Tables[0];
        }

        /*���ܣ���Ӵ��û��Ķ���
         ��������Ŷ�����Ϣ
         ���أ����ɵĶ���ID*/
        public int AddOrder(String user_ID, String user_Name, String user_Amount, String user_Address, String user_Email, String user_Tel, String user_Post, String user_Deal)
        {
            DbConnector db = new DbConnector();
            int orderid = 0;

            String connStr = ConfigurationSettings.AppSettings["dbConnString"];
            db.connDB(connStr);

            string SqlState = "insert into orders(userID,orderdatetime,trueName,amount,address,email,tel,postcode,dealMethod) values(" + user_ID + ",getdate(),'" + user_Name + "'," + Convert.ToDouble(user_Amount) + ",'" + user_Address + "','" + user_Email + "','" + user_Tel + "','" + user_Post + "','" + user_Deal + "')"; 
            
            orderid = db.executeUpdate_id(SqlState);
            
            return orderid;
        }

        /*���ܣ���Ӵ˶�����OrderDetails
         ������iOrderID��Ŷ�����ID,sOrder��Ź��ﳵ������Ϣ
         ����ֵ����*/
        public Boolean AddOrderDetails(int iOrderID, Stat_Class sOrder)
        {
            DbConnector db = new DbConnector();
            String connStr = ConfigurationSettings.AppSettings["dbConnString"];
            db.connDB(connStr);

            string SqlState = "insert into orderDetail(orderID,bookID,price,number,discount) values (" + iOrderID + "," + sOrder.ID + "," + sOrder.Price + "," + sOrder.Quantity + "," + sOrder.Discount + ")";

            if (db.executeUpdate(SqlState) == 1) return true;
            else return false;
        }

        /*���ܣ�ȡ���˶���
          ������iOrderID��Ŵ�������ID
          ���أ���*/
        public void CancelOrder(int iOrderID)
        {
            DbConnector db = new DbConnector();

            String connStr = ConfigurationSettings.AppSettings["dbConnString"];
            db.connDB(connStr);

            string SqlState = "Update orders Set pay = -1 where ID = " + Convert.ToString(iOrderID);
            db.executeUpdate(SqlState);
        }

        /*���ܣ��鿴�˶�����״̬
          ������pay��Ŵ��û���״̬*/
        public static String ShowOrderStatus(int pay)
        {
            String status="";

            if(pay==1)
            {
                status = "�Ѹ���";
            }
            else if(pay==0)
            {
                status = "δ����";
            }
            else if(pay==-1)
            {
                status = "��ȡ��";
            }
            return status;
        }

        /*���ܣ��鿴�˶�������ϸ����OrderDetail
          ������iOrderID��Ŵ�������ID
          ���أ��˶�������ϸ����*/
        public DataTable ShowOrderDetails(int iOrderID)
        {
            DataSet ds = new DataSet();
            DbConnector db = new DbConnector();

            String connStr = ConfigurationSettings.AppSettings["dbConnString"];
            db.connDB(connStr);
            string SqlState = "select * from orders,orderDetail,bookInfo where orders.ID =orderDetail.orderID and orderDetail.bookID = bookInfo.ID and orderDetail.orderID = " + Convert.ToString(iOrderID);

            ds = db.executeQuery(SqlState);

            return ds.Tables[0];
        }

        /*���ܣ��鿴�˶���������Orders
          ������iOrderID��Ŵ�������ID
          ���أ��˶����ĵ�����*/
        public DataTable ShowOrderInfo(int iOrderID)
        {
            DataSet ds = new DataSet();
            DbConnector db = new DbConnector();

            String connStr = ConfigurationSettings.AppSettings["dbConnString"];
            db.connDB(connStr);
            string SqlState = "select * from orders where ID = " + Convert.ToString(iOrderID);

            ds = db.executeQuery(SqlState);
            return ds.Tables[0];
        }

        /*���ܣ����ش��û�����ϸ��Ϣ
          ������iUserID��Ŵ��û���ID
          ���أ����û�����ϸ��Ϣ*/
        public DataTable ShowUserInfo(int iUserID)
        {
            DataSet ds = new DataSet();
            DbConnector db = new DbConnector();

            String connStr = ConfigurationSettings.AppSettings["dbConnString"];

            db.connDB(connStr);
            String SqlState = "select * from users where ID = " + Convert.ToString(iUserID);

            ds = db.executeQuery(SqlState);
            return ds.Tables[0];
        }
    }
}
