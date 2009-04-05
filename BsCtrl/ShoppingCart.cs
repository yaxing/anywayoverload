using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Configuration;

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

        /*构造方法，初始化图书的各个属性
         * 参数： 图书的ID
         * 返回值：无
         */
        public Stat_Class(String ItemID)
        {
            Book_ID = ItemID;
            String connectString = ConfigurationSettings.AppSettings["dbConnString"];
            BsBookInfo bs = new BsBookInfo(connectString);
            int bookID = Convert.ToInt32(ItemID);
            DataSet ds = bs.GetBookInfo(bookID);
            Book_Name = ds.Tables[0].Rows[0]["bookName"].ToString();
            Book_Cover = ds.Tables[0].Rows[0]["coverPath"].ToString();
            Book_Price = Convert.ToDouble(ds.Tables[0].Rows[0]["price"].ToString());
            Book_Discount = Convert.ToDouble(ds.Tables[0].Rows[0]["discount"].ToString());
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
        public void AddItem(Stat_Class Order)
        {
            Stat_Class order = (Stat_Class)Cart_Orders[Order.ID];
            if (order != null)
                order.Quantity += Order.Quantity;
            else
                Cart_Orders.Add(Order.ID, Order);
        }

        /*给购物车删除一个图书类
         * 参数：要删除的图书类ID
         * 返回值：无
         */
        public void DeleteItem(String ItemID)
        { 
            if (Cart_Orders[ItemID] != null)
                Cart_Orders.Remove(ItemID);
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
                if(order!=null)
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
        public void ItemAddOne(String ItemID)
        {
            Stat_Class order = (Stat_Class)Cart_Orders[ItemID];
            
            order.Quantity++;
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

        /*返回购物车pageIndx到pageSize的图书
         * 参数：pageIndx，pageSize
         * 返回值：购物车pageIndx到pageSize的图书
         */
        //public ArrayList GetCarts(int pageIndx, int pageSize)
        //{

        //}
    }

}
