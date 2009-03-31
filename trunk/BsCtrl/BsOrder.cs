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
            
            string server = ConfigurationSettings.AppSettings["dbServer"];
            string userName = ConfigurationSettings.AppSettings["dbUserName"];
            string passWord = ConfigurationSettings.AppSettings["dbPassWord"];

            db.connDB(server, userName, passWord);
            string SqlState = "select * from orders where userID = " + Convert.ToString(iUserID);

            ds = db.executeQuery(SqlState);

            return ds.Tables[0];
        }

        /*���ܣ��鿴�˶�����״̬
          ������pay��Ŵ��û���״̬*/
        public static String ShowOrderStatus(int pay)
        {
            String status="";

            if(pay!=0)
            {
                status = "�Ѹ���";
            }
            else
            {
                status = "δ����";
            }
            return status;
        }

        /*���ܣ��鿴�˶�������ϸ����
          ������iOrderID��Ŵ�������ID
          ���أ��˶�������ϸ����*/
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
