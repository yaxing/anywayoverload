using System;
using System.Collections.Generic;
using System.Text;
using DbConnect;
using System.Data;

namespace BsCtrl
{
    public class orderManage
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
            dsRecord = null;
            dsRecord = DbconnObj.executeQuery(strSql);
            DbconnObj.close();
        }

        //ҳ������ֶγ�ʼ��
        public void initPage()
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


        //��ȡ��ǰҳ��
        public int getCurrentPage()
        {
            return pageCurrent;
        }

        //�趨��ǰҳ��
        public void setCurrentPage(int pageCurrent)
        {
            this.pageCurrent = pageCurrent;
        }

        //�趨������ʾ��ҳ��
        public void setPageToShow(int pageToShow)
        {
            this.pageToShow = pageToShow;
        }

        //��ȡ���е�ҳ��
        public int getPageAmount()
        {
            return pageAmount;
        }

        //��ʾ��¼
        public String recordToShow()
        {
            string strContent = "";
            strContent += "<table cellspacing=2  cellpadding=2   bordercolordark='#ffffff'  bordercolorlight='#000000' width='100%'> ";
            strContent += "<tr><th width='25%'>�û���</th><th width='25%'>�µ�ʱ��</th><th width='15%'>���׽��</th><th></th><th></th><th></th></tr>";
            if (pageAmount == 0)
            {
                strContent += "<tr><td colspan='6'>û���κμ�¼!!</td></tr>";
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
                    strContent += "<td align='center'>" +"<a href='orderUserInfo.aspx?id="+dsRecord.Tables[0].Rows[i]["ID"]+"'>"+ dsRecord.Tables[0].Rows[i]["userName"] +"</a>"+ "</td>";
                    strContent += "<td align='center'>" + dsRecord.Tables[0].Rows[i]["orderdatetime"] + "</td>";
                    strContent += "<td align='center'>" + dsRecord.Tables[0].Rows[i]["amount"] + "</td>";
                    strContent += "<td align='center'>" +"<a href='orderDeal.aspx?id="+dsRecord.Tables[0].Rows[i]["ID"]+"'>"+ "���" +"</a>"+ "</td>";
                    strContent += "<td align='center'>" +"<a href='orderDeal.aspx?id="+dsRecord.Tables[0].Rows[i]["ID"]+"'>"+ "ȡ��" +"</a>"+ "</td>";
                    strContent += "<td align='center'>" +"<a href='orderDetail.aspx?id="+dsRecord.Tables[0].Rows[i]["ID"]+"'>"+ "����" +"</a>"+ "</td>";
                    strContent += "</tr>";
                }
            }
            strContent += "</table>";

            return strContent;
        }

        //��ʾ�û���Ϣ
        public String customerInfo(int orderID)
        {
            setSql("select * from v_orderManage where ID=" + orderID);
            getDsRecord();

            string strInfo = "<p>&nbsp;</p>";
            strInfo += "<p>" + "�û�����" + dsRecord.Tables[0].Rows[0]["userName"].ToString() +"</p>";
            strInfo += "<p>" + "��ʵ������" + dsRecord.Tables[0].Rows[0]["trueName"].ToString() + "</p>";
            strInfo += "<p>" + "��ַ��" + dsRecord.Tables[0].Rows[0]["address"].ToString() + "</p>";
            strInfo += "<p>" + "�ʱࣺ" + dsRecord.Tables[0].Rows[0]["postcode"].ToString() + "</p>";
            strInfo += "<p>" + "�绰��" + dsRecord.Tables[0].Rows[0]["tel"].ToString() + "</p>";
            strInfo += "<p>" + "���䣺" + dsRecord.Tables[0].Rows[0]["email"].ToString() + "</p>";
            strInfo += "";

            return strInfo;
        }
    }
}
