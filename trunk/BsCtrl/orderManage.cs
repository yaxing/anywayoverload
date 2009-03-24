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
            //DbconnObj.connDB("server=PCOFWAP\\SQLEXPRESS;Initial Catalog=shanzhai;Integrated Security=SSPI");
            dsRecord = null;
            dsRecord = DbconnObj.executeQuery(strSql);
            DbconnObj.close();
        }
        
        //ִ�����strSql
        public void executeSql()
        {
            DbconnObj.connDB("server=PCOFWAP\\SQLEXPRESS;Initial Catalog=shanzhai;Integrated Security=SSPI");
            DbconnObj.executeUpdate(strSql);
            DbconnObj.close();
        }

        //��ʼ��ҳ��
        public void initPages()
        {
            this.recordAmount = dsRecord.Tables[0].Rows.Count;
            if (recordAmount == 0)
            {
                pageCurrent = 0;
                pageAmount = 0;
            }
            else
            {
                pageCurrent = 1;
                if (recordAmount % pageSize == 0)
                {
                    pageAmount = recordAmount / 10;
                }
                else
                {
                    pageAmount = recordAmount / 10 + 1;
                }
            }
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

        //�趨����ҳ��
        public void setPageAmount(int pageAmount)
        {
            this.pageAmount = pageAmount;
        }

        //��ȡ���е�ҳ��
        public int getPageAmount()
        {
            return pageAmount;
        }

        //���ض�����¼
        public String recordToShow()
        {
            string strContent = "";
            strContent += "<table cellspacing=2  cellpadding=2   bordercolordark='#ffffff'  bordercolorlight='#000000' width='100%'> ";
            strContent += "<tr><th width='25%'>�û���</th><th width='25%'>�µ�ʱ��</th><th width='15%'>���׽��</th><th>����״̬</th><th></th><th></th></tr>";
            if (pageAmount == 0)
            {
                strContent += "<tr><td colspan='6'>û���κμ�¼!!</td></tr>";
            }
            else
            {
                int fRecordID = (pageCurrent - 1) * pageSize;
                int lRecordID = fRecordID + pageSize - 1;
                if (lRecordID > (this.recordAmount - 1) )
                {
                    lRecordID = this.recordAmount - 1;
                }
                for (int i = fRecordID; i <= lRecordID; i++)
                {
                    strContent += "<tr>";
                    strContent += "<td align='center'>" +"<a href='customerInfo.aspx?id="+dsRecord.Tables[0].Rows[i]["ID"]+"'>"+ dsRecord.Tables[0].Rows[i]["userName"] +"</a>"+ "</td>";
                    strContent += "<td align='center'>" + dsRecord.Tables[0].Rows[i]["orderdatetime"] + "</td>";
                    strContent += "<td align='center'>" + dsRecord.Tables[0].Rows[i]["amount"] + "</td>";
                    if (dsRecord.Tables[0].Rows[i]["pay"].ToString().Equals("1"))
                    {
                        strContent += "<td align='center'>" + "�������" + "</td>";
                        strContent += "<td align='center'>&nbsp;</td>";
                    }
                    else if (dsRecord.Tables[0].Rows[i]["pay"].ToString().Equals("0"))
                    {
                        strContent += "<td align='center'>" + "���δ����" + "</td>";
                        strContent += "<td align='center'>" + "<a href='orderDeal.aspx?id=" + dsRecord.Tables[0].Rows[i]["ID"] + "&value=1'>" + "�Ѹ���" + "</a>";
                        strContent += "&nbsp;&nbsp;&nbsp;&nbsp;<a href='orderDeal.aspx?id=" + dsRecord.Tables[0].Rows[i]["ID"] + "&value=-1'>" + "ȡ��" + "</a>" + "</td>";
                    }
                    else
                    {
                        strContent += "<td align='center'>" + "����ȡ��" + "</td>";
                        strContent += "<td align='center'>&nbsp;</td>";
                    }
                    strContent += "<td align='center'>" +"<a href='orderDetail.aspx?id="+dsRecord.Tables[0].Rows[i]["ID"]+"'>"+ "����" +"</a>"+ "</td>";
                    strContent += "</tr>";
                }
            }
            strContent += "</table>";

            return strContent;
        }

        //�����û���Ϣ
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


        /*���ض�����ϸ��Ϣ
         * ������ orderID(��������ID)
         * ����ֵ����ʾ������ϸ��Ϣ��html�ű�
         */
        public String orderDetail(int orderID)
        {
            setSql("select * from v_orderDetailManage where orderID="+orderID);
            getDsRecord();
            String strContent = "";
            strContent += "<table cellspacing=2  cellpadding=2   bordercolordark='#ffffff'  bordercolorlight='#000000' width='100%'> ";
            strContent += "<tr><th width='25%'>����</th><th width='20%'>������</th><th width='15%'>�����</th><th>����</th><th>����</th><th>�ۿ�</th></tr>";
            for (int i = 0; i < dsRecord.Tables[0].Rows.Count; i++)
            {
                strContent += "<tr>";
                strContent += "<td align='center'>" + dsRecord.Tables[0].Rows[i]["bookName"] + "</td>";
                strContent += "<td align='center'>" + dsRecord.Tables[0].Rows[i]["publisher"] + "</td>";
                strContent += "<td align='center'>" + dsRecord.Tables[0].Rows[i]["ISBN"] + "</td>";
                strContent += "<td align='center'>" + dsRecord.Tables[0].Rows[i]["price"] + "</td>";
                strContent += "<td align='center'>" + dsRecord.Tables[0].Rows[i]["number"] + "</td>";
                strContent += "<td align='center'>" + dsRecord.Tables[0].Rows[i]["discount"] + "</td>";
                strContent += "</tr>";
            }
            strContent += "</table>";

            return strContent;
        }
        //end orderDeatail()

    }
}
