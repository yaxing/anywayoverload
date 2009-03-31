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
            
            string server = ConfigurationSettings.AppSettings["dbServer"];
            string userName = ConfigurationSettings.AppSettings["dbUserName"];
            string passWord = ConfigurationSettings.AppSettings["dbPassWord"];

            db.connDB(server, userName, passWord);
            string SqlState = "select * from orders where userID = " + Convert.ToString(iUserID);

            ds = db.executeQuery(SqlState);

            return ds.Tables[0];
        }

        /*功能：查看此订单的状态
          参数：pay存放待用户的状态*/
        public static String ShowOrderStatus(int pay)
        {
            String status="";

            if(pay!=0)
            {
                status = "已付款";
            }
            else
            {
                status = "未付款";
            }
            return status;
        }

        /*功能：查看此订单的详细表项
          参数：iOrderID存放待订单的ID
          返回：此订单的详细表项*/
        public DataTable ShowOrderDetails(int iOrderID)
        {
            DataSet ds = new DataSet();
            DbConnector db = new DbConnector();

            string server = ConfigurationSettings.AppSettings["dbServer"];
            string userName = ConfigurationSettings.AppSettings["dbUserName"];
            string passWord = ConfigurationSettings.AppSettings["dbPassWord"];

            db.connDB(server, userName, passWord);
            string SqlState = "select * from orders,orderDetail,bookInfo where orders.ID =orderDetail.orderID and orderDetail.bookID = bookInfo.ID and orderDetail.orderID = " + Convert.ToString(iOrderID);

            ds = db.executeQuery(SqlState);

            return ds.Tables[0];
        }
    }
}
