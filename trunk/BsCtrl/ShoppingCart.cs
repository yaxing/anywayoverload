using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Configuration;
using BsCtrl;
using DbConnect;

namespace BsCtrl
{
    //定义图书类,保存图书的各种属性
    [Serializable]
    public class Stat_Class
    { 
        String Book_ID; //图书ID
        String Book_Name; //图书名称
        String Book_Cover;//图书封面
        Double Book_Price; //图书价格
        Double Book_Discount;//图书折扣
        int Quan; //图书数量
        int Ava;//图书库存量

        /*图书ID字段*/
        public String ID
        {
            get { return Book_ID; }
            set { Book_ID = value; }
        }

        /*图书名字字段*/
        public String BookName
        {
            get { return Book_Name; }
            set { Book_Name = value; }
        }

        /*图书封面字段*/
        public String Cover
        {
            get { return Book_Cover; }
            set { Book_Cover = value; }
        }

        /*图书价格字段*/
        public Double Price
        {
            get { return Book_Price; }
            set { Book_Price = value; }
        }

        /*图书折扣字段*/
        public Double Discount
        {
            get { return Book_Discount; }
            set { Book_Discount = value; }
        }

        /*图书数量字段*/
        public int Quantity
        {
            get { return Quan; }
            set { Quan = value; }
        }

        /*图书库存量字段*/
        public int Available
        {
            get { return Ava; }
            set { Ava = value; }
        }

        /*构造方法，初始化图书的各个属性
         * 参数： 图书的ID
         * 返回值：无
         */
        public Stat_Class(String ItemID)
        {
            Book_ID = ItemID;
            String connectString = ConfigurationManager.ConnectionStrings["shanzhaiConnectionString"].ToString();
            BsBookInfo bs = new BsBookInfo(connectString);
            int bookID = Convert.ToInt32(ItemID);
            DataSet ds = bs.GetBookInfo(bookID);
            Book_Name = ds.Tables[0].Rows[0]["bookName"].ToString();
            Book_Cover = ds.Tables[0].Rows[0]["coverPath"].ToString();
            Book_Price = Convert.ToDouble(ds.Tables[0].Rows[0]["price"].ToString());
            Book_Discount = Convert.ToDouble(ds.Tables[0].Rows[0]["discount"].ToString());
            Ava = Convert.ToInt32(ds.Tables[0].Rows[0]["available"]);
            Quan = 1;
        }

        /*构造方法，初始化图书的各个属性
         * 参数： 图书的各个属性值
         * 返回值：无
         */

        public Stat_Class(String ItemID, String bName, Double bPrice, Double bDiscount,int Quantity)
        { 

            Book_ID = ItemID;
            Book_Name = bName;
            Book_Price = bPrice;
            Book_Discount = bDiscount;
            Quan = Quantity;
        }
    }

    //定义ShoppingCart类
    [Serializable]
    public class ShoppingCart
    {
        //定义一个Hashtable
        Hashtable Cart_Orders = new Hashtable();
        int totalRecords = 0;


        /*返回整个Hashtable的值，包含所有的图书类
         * 参数： 无
         * 返回值：Hashtable的值
         */
        public ICollection Orders
        {
            get { return Cart_Orders.Values; }
        }

        /*返回整个ArrayList的元素个数
         * 参数： 无
         * 返回值：ArrayList的元素个数
         */
        public int TotalRecords
        {
            get { return Cart_Orders.Count; }
        }


        /*返回整个购物车的图书价格
         * 参数： 无
         * 返回值：整个购物车的图书价格
         */
        public Double TotalCost
        { 
            get
            {
                Double total = 0;
                foreach (DictionaryEntry entry in Cart_Orders)
                {
                    Stat_Class order = (Stat_Class)entry.Value;
                    total += (order.Price * order.Quantity * order.Discount);
                }
                return total;
            }
        }

        /*给购物车添加一个图书类
         * 参数：要添加的图书类
         * 返回值：无
         */
        public Boolean AddItem(Stat_Class Order)
        {
            Stat_Class order = (Stat_Class)Cart_Orders[Order.ID];
            int sum;
            if (order != null)
            {
                sum = order.Quantity + Order.Quantity;
                if (sum <= order.Available)
                {
                    order.Quantity = sum;
                    return true;
                }
                else return false;
            }
            else
            {
                String connStr = ConfigurationManager.ConnectionStrings["shanzhaiConnectionString"].ToString();
                BsBookInfo bi = new BsBookInfo(connStr);
                DataSet ds = new DataSet();
                ds = bi.GetBookInfo(Convert.ToInt32(Order.ID));
                int iAva = Convert.ToInt32(ds.Tables[0].Rows[0]["available"]);
                if (Order.Quantity <= iAva)
                    Cart_Orders.Add(Order.ID, Order);
                else return false;

                return true;
            }
        }

        /*给购物车删除一个图书类
         * 参数：要删除的图书类ID
         * 返回值：无
         */
        public void DeleteItem(String ItemID)
        {
            if (Cart_Orders[ItemID] != null)
            {
                Cart_Orders.Remove(ItemID);
            }
        }

        /*把购物车信息添加到OrderDetail表
         * 参数：iOrderID表示要添加的订单号
         * 返回值：无
         */
        public Boolean AddToOrder(int iOrderID)
        {
            BsOrder bo = new BsOrder();
            foreach (DictionaryEntry entry in Cart_Orders)
            {
                Stat_Class order = (Stat_Class)entry.Value;
                String connStr = ConfigurationManager.ConnectionStrings["shanzhaiConnectionString"].ToString();
                BsBookInfo bi = new BsBookInfo(connStr);
                DataSet ds = new DataSet();
                ds = bi.GetBookInfo(Convert.ToInt32(order.ID));
                int iAva = Convert.ToInt32(ds.Tables[0].Rows[0]["available"]);
                if(order!=null && order.Quantity <= iAva)
                {
                    if(bo.AddOrderDetails(iOrderID, order) == false)
                        return false;
                }
            }
            return true;
        }

        /*清空购物车
        * 参数：无
        * 返回值：无
        */
        public void ClearCart()
        {
            Cart_Orders.Clear();
        }

        /*给购物车某个图书类数量加1
         * 参数：要加1的图书类ID
         * 返回值：无
         */
        public Boolean ItemAddOne(String ItemID)
        {
            Stat_Class order = (Stat_Class)Cart_Orders[ItemID];
            if (order.Quantity < order.Available)
            {
                order.Quantity++;
                return true;
            }
            else return false;
        }

        /*给购物车某个图书类数量减1
         * 参数：要减1的图书类ID
         * 返回值：无
         */
        public void ItemDelOne(String ItemID)
        {
            Stat_Class order = (Stat_Class)Cart_Orders[ItemID];
            if(order.Quantity==1)
            {
                Cart_Orders.Remove(ItemID);
            }
            else
            {
                order.Quantity--;
            }
        }

        /*根据当前的Quantity值更新数据库available字段
         * 参数：图书ID iBookId值
         * 返回值：成功与否
         */
        public Boolean UpdateAvalible()
        {

            foreach (DictionaryEntry entry in Cart_Orders)
            {
                Stat_Class order = (Stat_Class)entry.Value;
                if (order != null)
                {
                    int iAva = order.Available - order.Quantity;
                    DbConnector db = new DbConnector();

                    String connStr = ConfigurationManager.ConnectionStrings["shanzhaiConnectionString"].ToString();
                    db.connDB(connStr);

                    string SqlState = "Update bookInfo Set available = " + iAva + " where ID = " + order.ID;

                    if (db.executeUpdate(SqlState) != 1)
                        return false;
                }
            }
            return true;
        }

        /*返回购物车pageIndx到pageSize的图书
         * 参数：pageIndx，pageSize
         * 返回值：购物车pageIndx到pageSize的图书
         */
        //public ArrayList GetCarts(int pageIndx, int pageSize)
        //{

        //}
    }

}
