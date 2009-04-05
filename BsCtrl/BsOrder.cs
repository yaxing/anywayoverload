using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DbConnect;

namespace BsCtrl
{
    /*订单类*/
    public class BsOrder
    {
        /*功能：查看此用户的订单
          参数：iUserID 存放待用户的ID*/
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

        /*功能：添加此用户的订单
         参数：存放订单信息
         返回：生成的订单ID*/
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

        /*功能：添加此订单的OrderDetails
         参数：iOrderID存放订单的ID,sOrder存放购物车单条信息
         返回值：无*/
        public Boolean AddOrderDetails(int iOrderID, Stat_Class sOrder)
        {
            DbConnector db = new DbConnector();
            String connStr = ConfigurationSettings.AppSettings["dbConnString"];
            db.connDB(connStr);

            string SqlState = "insert into orderDetail(orderID,bookID,price,number,discount) values (" + iOrderID + "," + sOrder.ID + "," + sOrder.Price + "," + sOrder.Quantity + "," + sOrder.Discount + ")";

            if (db.executeUpdate(SqlState) == 1) return true;
            else return false;
        }

        /*功能：取消此订单
          参数：iOrderID存放待订单的ID
          返回：无*/
        public void CancelOrder(int iOrderID)
        {
            DbConnector db = new DbConnector();

            String connStr = ConfigurationSettings.AppSettings["dbConnString"];
            db.connDB(connStr);

            string SqlState = "Update orders Set pay = -1 where ID = " + Convert.ToString(iOrderID);
            db.executeUpdate(SqlState);
        }

        /*功能：查看此订单的状态
          参数：pay存放待用户的状态*/
        public static String ShowOrderStatus(int pay)
        {
            String status="";

            if(pay==1)
            {
                status = "已付款";
            }
            else if(pay==0)
            {
                status = "未付款";
            }
            else if(pay==-1)
            {
                status = "已取消";
            }
            return status;
        }

        /*功能：查看此订单的详细表项OrderDetail
          参数：iOrderID存放待订单的ID
          返回：此订单的详细表项*/
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

        /*功能：查看此订单的内容Orders
          参数：iOrderID存放待订单的ID
          返回：此订单的的内容*/
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

        /*功能：返回此用户的详细信息
          参数：iUserID存放待用户的ID
          返回：此用户的详细信息*/
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
