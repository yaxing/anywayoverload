using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace BsCtrl
{
    /*���ﳵ��*/
    public class BsCart
    {
        /*�ڹ��ﳵ������һ������Ŀ��������Ѿ��ڸ���Ŀ�У���ʲôҲ����
         ������iBookId��ʾ����ͼ���ID
               bBook��ʾҪ�����ͼ�����*/
        public void AddItem(int iBookId, BsBook bBook)
        {

        }

        /*�ӹ��ﳵ��ɾ��һ����Ŀ
         ������ iBookId	 ͼ��ID*/
        public void DeleteItem(int iBookId)
        {

        }

        /*������ﳵ��������Ŀ*/
        public void ClearCart()
        {

        }

        /*��ù��ﳵ��ͼ����Ŀ������
         ����ֵ��ͼ����Ŀ������ */
        public int GetNumOfItems()
        {
            int ret = 0;

            return ret;
        }

        /*����ĳ��ͼ��Ĺ�������
             ������iBookId ͼ���ID��
                   iQuantity Ҫ���õ�����*/
        public void SetItemNum(int iBookId, int iQuantity)
        {

        }

        /*��ȡ���ﳵ������ͼ����ܼ۸�
           ����ֵ���ܼ۸�*/
        public float GetTotalPrice()
        {
            float ret = 0;

            return ret;
        }

        /*�õ����ﳵ�����е�ͼ����Ŀ
         ����ֵ�� ͼ����Ŀ��*/
        public Collection<BsCartItem> GetItems()
        {
            Collection<BsCartItem> ret = null;

            return ret;
        }

        /*�жϸ�ͼ���Ƿ��Ѿ�����˹��ﳵ
          ������iBookId ͼ��ID
          ����ֵ����ΪTure����ʾ��ͼ���Ѿ����빺�ﳵ������û��*/
        public bool IsExist(int iBookId)
        {
            bool ret = true;

            return ret;
        }
    }



    /*���ﳵ��Ŀ��*/
    public class BsCartItem
    {
        /*���캯��*/
        public BsCartItem(BsBook bBook)
        {

        }

        /*����ͼ��
          ������bBook Ҫ���õ�ͼ�����*/
        public void SetBook(BsBook bBook)
        {

        }

        /*���ͼ��
          ����ֵ�����ػ�ȡ��ͼ�����*/
        public BsBook GetBook()
        {
            BsBook ret = null;

            return ret;
        }

        /*����ͼ������
         ������iQuantity Ҫ���õ�ͼ������*/
        public void SetQuantity(int iQuantity)
        {

        }

        /*���ͼ������
          ����ֵ����ȡ��ͼ������ֵ*/
        public int GetQuantity()
        {
            int ret = 0;

            return ret;
        }
    }
}
