using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace BsCtrl
{
    [Serializable]
    public class Stat_Class
    { //������Ʒ��,������Ʒ�ĸ�������
        String Book_ID; //��ƷID
        String Book_Name; //��Ʒ����
        decimal Book_Price; //��Ʒ�۸�
        int Quan; //��Ʒ����
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
        { //���췽������ʼ����Ʒ�ĸ�������

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
        { //�����ܼ۸�
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
        { //����������
            Stat_Class order = (Stat_Class)Cart_Orders[Order.ID];
            if (order != null)
                order.Quantity += Order.Quantity;
            else
                Cart_Orders.Add(Order.ID, Order);
        }

        public void DeleteItem(String ItemID)
        { //ɾ�����
            if (Cart_Orders[ItemID] != null)
                Cart_Orders.Remove(ItemID);
        }

        public void ItemAddOne(String ItemID)
        {//Ϊ�������Ŀ��1
            Stat_Class order = (Stat_Class)Cart_Orders[ItemID];
            
            order.Quantity++;
        }

        public void ItemDelOne(String ItemID)
        {//Ϊ�������Ŀ��1
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
