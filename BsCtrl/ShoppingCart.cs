using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace BsCtrl
{
    [Serializable]
    public class Stat_Class
    { //定义商品类,保存商品的各种属性
        String Book_ID; //商品ID
        String Book_Name; //商品名称
        decimal Book_Price; //商品价格
        int Quan; //商品数量
        public String ID
        {
            get { return Book_ID; }
            set { Book_ID = value; }
        }

        public String BookName
        {
            get { return Book_Name; }
            set { Book_Name = value; }
        }

        public decimal Price
        {
            get { return Book_Price; }
            set { Book_Price = value; }
        }

        public int Quantity
        {
            get { return Quan; }
            set { Quan = value; }
        }

        public Stat_Class(String ItemID, String bName, decimal bPrice, int Quantity)
        { //构造方法，初始化商品的各个属性

            Book_ID = ItemID;
            Book_Name = bName;
            Book_Price = bPrice;
            Quan = Quantity;
        }
    }

    [Serializable]
    public class ShoppingCart
    {
        Hashtable Cart_Orders = new Hashtable();
        public ICollection Orders
        {
            get { return Cart_Orders.Values; }
        }

        public decimal TotalCost
        { //计算总价格
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

        public void AddItem(Stat_Class Order)
        { //添加物件方法
            Stat_Class order = (Stat_Class)Cart_Orders[Order.ID];
            if (order != null)
                order.Quantity += Order.Quantity;
            else
                Cart_Orders.Add(Order.ID, Order);
        }

        public void DeleteItem(String ItemID)
        { //删除物件
            if (Cart_Orders[ItemID] != null)
                Cart_Orders.Remove(ItemID);
        }

        public void ItemAddOne(String ItemID)
        {//为该物件数目加1
            Stat_Class order = (Stat_Class)Cart_Orders[ItemID];
            
            order.Quantity++;
        }

        public void ItemDelOne(String ItemID)
        {//为该物件数目减1
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
    }

}
