using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace BsCtrl
{
    /*购物车类*/
    public class BsCart
    {
        /*在购物车中增加一个书条目，如果书已经在该条目中，则什么也不做
         参数：iBookId表示加入图书的ID
               bBook表示要加入的图书对象*/
        public void AddItem(int iBookId, BsBook bBook)
        {

        }

        /*从购物车中删除一个条目
         参数： iBookId	 图书ID*/
        public void DeleteItem(int iBookId)
        {

        }

        /*清除购物车的所有条目*/
        public void ClearCart()
        {

        }

        /*获得购物车中图书条目的总数
         返回值：图书条目的总数 */
        public int GetNumOfItems()
        {
            int ret = 0;

            return ret;
        }

        /*设置某本图书的购买数量
             参数：iBookId 图书的ID号
                   iQuantity 要设置的数量*/
        public void SetItemNum(int iBookId, int iQuantity)
        {

        }

        /*获取购物车中所有图书的总价格
           返回值：总价格*/
        public float GetTotalPrice()
        {
            float ret = 0;

            return ret;
        }

        /*得到购物车中所有的图书条目
         返回值： 图书条目表*/
        public Collection<BsCartItem> GetItems()
        {
            Collection<BsCartItem> ret = null;

            return ret;
        }

        /*判断该图书是否已经加入此购物车
          参数：iBookId 图书ID
          返回值：若为Ture，表示该图书已经加入购物车，否则没有*/
        public bool IsExist(int iBookId)
        {
            bool ret = true;

            return ret;
        }
    }



    /*购物车条目类*/
    public class BsCartItem
    {
        /*构造函数*/
        public BsCartItem(BsBook bBook)
        {

        }

        /*设置图书
          参数：bBook 要设置的图书对象*/
        public void SetBook(BsBook bBook)
        {

        }

        /*获得图书
          返回值：返回获取的图书对象*/
        public BsBook GetBook()
        {
            BsBook ret = null;

            return ret;
        }

        /*设置图书数量
         参数：iQuantity 要设置的图书数量*/
        public void SetQuantity(int iQuantity)
        {

        }

        /*获得图书数量
          返回值：获取的图书数量值*/
        public int GetQuantity()
        {
            int ret = 0;

            return ret;
        }
    }
}
