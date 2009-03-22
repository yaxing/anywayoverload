using System;
using System.Collections.Generic;
using System.Text;
using DbConnect;
using System.Data;

namespace BsCtrl
{
    class orderManage
    {
        private int pageCurrent;        //��ǰ��ҳ��
        private int pageAmount;         //���е�ҳ��
        private int pageToShow;         //������ʾ��ҳ���������ҳ��ť��
        private int recordAmount;       //��¼��������
        private const int pageSize=10;  //һҳ��ʾ������

        private DataSet dsRecord;
        private string strSql;
        private DbConnector DbconnObj=new DbConnector();

        //���ò�ѯ���
        public void setSql(String sql)
        {
            this.strSql = sql;
        }

        //ȡ����ѯ���
        public void getDsRecord()
        {
            DbconnObj.connDB("server=PCOFWAP\\SQLEXPRESS;Initial Catalog=shanzhai;Integrated Security=SSPI");
            dsRecord = DbconnObj.executeQuery(strSql);
            DbconnObj.close();
        }

        //�ֶγ�ʼ��
        public void init()
        {
            recordAmount = dsRecord.Tables[0].Rows.Count;
            if (recordAmount % pageSize == 0)
            {
                pageAmount = recordAmount / pageSize;
            }
            else
            {
                pageAmount = recordAmount / pageSize + 1;
            }
            pageCurrent = 1;
            pageToShow = 1;
        }

        //��ʾ��¼
        public String recordToShow()
        {
            string strContent = "";
            strContent += "<table>";
            strContent += "<tr><th>�û���</th><th>�µ�ʱ��</th><th>���׽��</th><th></th><th></th><th></th></tr>";
            if (pageAmount == 0)
            {
                strContent += "<tr><td colspan='6'>no record!</td></tr>";
            }
            else
            {
                int fRecordID = (pageToShow - 1) * pageSize;
                int lRecordID = fRecordID + pageSize - 1;
                if (lRecordID > (this.recordAmount - 1) )
                {
                    lRecordID = this.recordAmount - 1;
                }
                for (int i = fRecordID; i <= lRecordID; i++)
                {
                    strContent += "<tr>";
                    strContent += "<td>" + dsRecord.Tables[0].Rows[i]["userName"] + "</td>";
                    strContent += "<td>" + dsRecord.Tables[0].Rows[i]["orderdatetime"] + "</td>";
                    strContent += "<td>" + dsRecord.Tables[0].Rows[i]["amount"] + "</td>";
                    strContent += "<td>" + "���" + "</td>";
                    strContent += "<td>" + "ȡ��" + "</td>";
                    strContent += "<td>" + "����" + "</td>";
                    strContent += "</tr>";
                }
            }
            strContent += "</table>";

            return strContent;
        }
    }
}
