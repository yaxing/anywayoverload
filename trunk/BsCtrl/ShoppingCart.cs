using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Configuration;

namespace BsCtrl
{
    //����ͼ����,����ͼ��ĸ�������
    [Serializable]
    public class Stat_Class
    { 
        String Book_ID; //ͼ��ID
        String Book_Name; //ͼ������
        String Book_Cover;//ͼ�����
        Double Book_Price; //ͼ��۸�
        Double Book_Discount;//ͼ���ۿ�
        int Quan; //ͼ������

        /*ͼ��ID�ֶ�*/
        public String ID
        {
            get { return Book_ID; }
            set { Book_ID = value; }
        }

        /*ͼ�������ֶ�*/
        public String BookName
        {
            get { return Book_Name; }
            set { Book_Name = value; }
        }

        /*ͼ������ֶ�*/
        public String Cover
        {
            get { return Book_Cover; }
            set { Book_Cover = value; }
        }

        /*ͼ��۸��ֶ�*/
        public Double Price
        {
            get { return Book_Price; }
            set { Book_Price = value; }
        }

        /*ͼ���ۿ��ֶ�*/
        public Double Discount
        {
            get { return Book_Discount; }
            set { Book_Discount = value; }
        }

        /*ͼ�������ֶ�*/
        public int Quantity
        {
            get { return Quan; }
            set { Quan = value; }
        }

        /*���췽������ʼ��ͼ��ĸ�������
         * ������ ͼ���ID
         * ����ֵ����
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

        /*���췽������ʼ��ͼ��ĸ�������
         * ������ ͼ��ĸ�������ֵ
         * ����ֵ����
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

    //����ShoppingCart��
    [Serializable]
    public class ShoppingCart
    {
        //����һ��Hashtable
        Hashtable Cart_Orders = new Hashtable();
        int totalRecords = 0;


        /*��������Hashtable��ֵ���������е�ͼ����
         * ������ ��
         * ����ֵ��Hashtable��ֵ
         */
        public ICollection Orders
        {
            get { return Cart_Orders.Values; }
        }

        /*��������ArrayList��Ԫ�ظ���
         * ������ ��
         * ����ֵ��ArrayList��Ԫ�ظ���
         */
        public int TotalRecords
        {
            get { return Cart_Orders.Count; }
        }


        /*�����������ﳵ��ͼ��۸�
         * ������ ��
         * ����ֵ���������ﳵ��ͼ��۸�
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

        /*�����ﳵ���һ��ͼ����
         * ������Ҫ��ӵ�ͼ����
         * ����ֵ����
         */
        public void AddItem(Stat_Class Order)
        {
            Stat_Class order = (Stat_Class)Cart_Orders[Order.ID];
            if (order != null)
                order.Quantity += Order.Quantity;
            else
                Cart_Orders.Add(Order.ID, Order);
        }

        /*�����ﳵɾ��һ��ͼ����
         * ������Ҫɾ����ͼ����ID
         * ����ֵ����
         */
        public void DeleteItem(String ItemID)
        { 
            if (Cart_Orders[ItemID] != null)
                Cart_Orders.Remove(ItemID);
        }

        /*�ѹ��ﳵ��Ϣ��ӵ�OrderDetail��
         * ������iOrderID��ʾҪ��ӵĶ�����
         * ����ֵ����
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

        /*��չ��ﳵ
        * ��������
        * ����ֵ����
        */
        public void ClearCart()
        {
            Cart_Orders.Clear();
        }

        /*�����ﳵĳ��ͼ����������1
         * ������Ҫ��1��ͼ����ID
         * ����ֵ����
         */
        public void ItemAddOne(String ItemID)
        {
            Stat_Class order = (Stat_Class)Cart_Orders[ItemID];
            
            order.Quantity++;
        }

        /*�����ﳵĳ��ͼ����������1
         * ������Ҫ��1��ͼ����ID
         * ����ֵ����
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

        /*���ع��ﳵpageIndx��pageSize��ͼ��
         * ������pageIndx��pageSize
         * ����ֵ�����ﳵpageIndx��pageSize��ͼ��
         */
        //public ArrayList GetCarts(int pageIndx, int pageSize)
        //{

        //}
    }

}
