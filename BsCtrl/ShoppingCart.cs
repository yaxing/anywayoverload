using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace BsCtrl
{
    //定义图书类,保存图书的各种属性
    [Serializable]
    public class Stat_Class
    { 
        String Book_ID; //图书ID
        String Book_Name; //图书名称
        decimal Book_Price; //图书价格
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

        /*图书价格字段*/
        public decimal Price
        {
            get { return Book_Price; }
            set { Book_Price = value; }
        }

        /*图书数量字段*/
        public int Quantity
        {
            get { return Quan; }
            set { Quan = value; }
        }

        /*构造方法，初始化图书的各个属性
         * 参数： 图书的各个属性值
         * 返回值：无
         */

        public Stat_Class(String ItemID, String bName, decimal bPrice, int Quantity)
        { 

            Book_ID = ItemID;
            Book_Name = bName;
            Book_Price = bPrice;
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
        public decimal TotalCost
        { 
            get
            {
                decimal total = 0;
                foreach (DictionaryEntry entry in Cart_Orders)
                {
                    Stat_Class order = (Stat_Class)entry.Value;
                    total += (order.Price * order.Quantity);
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
