using System;
using System.Collections.Generic;
using System.Text;
using DbConnect;
using System.Data;

namespace BsCtrl
{
    public class orderManage
    {
        private int pageCurrent;        //当前的页数
        private int pageAmount;         //所有的页数
        private int pageToShow;         //即将显示的页数（点击翻页按钮）
        private int recordAmount;       //记录的总条数
        private const int pageSize=10;  //一页显示的条数

        private DataSet dsRecord;
        private string strSql;
        private DbConnector DbconnObj=new DbConnector();

        //设置查询语句
        public void setSql(String sql)
        {
            this.strSql = sql;
        }

        //取出查询结果
        public void getDsRecord()
        {
            DbconnObj.connDB("server=PCOFWAP\\SQLEXPRESS;Initial Catalog=shanzhai;Integrated Security=SSPI");
            dsRecord = null;
            dsRecord = DbconnObj.executeQuery(strSql);
            DbconnObj.close();
        }

        //页数相关字段初始化
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


        //获取当前页数
        public int getCurrentPage()
        {
            return pageCurrent;
        }

        //设定当前页数
        public void setCurrentPage(int pageCurrent)
        {
            this.pageCurrent = pageCurrent;
        }

        //设定即将显示的页数
        public void setPageToShow(int pageToShow)
        {
            this.pageToShow = pageToShow;
        }

        //获取所有的页数
        public int getPageAmount()
        {
            return pageAmount;
        }

        //显示记录
        public String recordToShow()
        {
            string strContent = "";
            strContent += "<table cellspacing=2  cellpadding=2   bordercolordark='#ffffff'  bordercolorlight='#000000' width='100%'> ";
            strContent += "<tr><th width='25%'>用户名</th><th width='25%'>下单时间</th><th width='15%'>交易金额</th><th></th><th></th><th></th></tr>";
            if (pageAmount == 0)
            {
                strContent += "<tr><td colspan='6'>没有任何记录!!</td></tr>";
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
                    strContent += "<td align='center'>" +"<a href='orderDeal.aspx?id="+dsRecord.Tables[0].Rows[i]["ID"]+"'>"+ "完成" +"</a>"+ "</td>";
                    strContent += "<td align='center'>" +"<a href='orderDeal.aspx?id="+dsRecord.Tables[0].Rows[i]["ID"]+"'>"+ "取消" +"</a>"+ "</td>";
                    strContent += "<td align='center'>" +"<a href='orderDetail.aspx?id="+dsRecord.Tables[0].Rows[i]["ID"]+"'>"+ "详情" +"</a>"+ "</td>";
                    strContent += "</tr>";
                }
            }
            strContent += "</table>";

            return strContent;
        }

        //显示用户信息
        public String customerInfo(int orderID)
        {
            setSql("select * from v_orderManage where ID=" + orderID);
            getDsRecord();

            string strInfo = "<p>&nbsp;</p>";
            strInfo += "<p>" + "用户名：" + dsRecord.Tables[0].Rows[0]["userName"].ToString() +"</p>";
            strInfo += "<p>" + "真实姓名：" + dsRecord.Tables[0].Rows[0]["trueName"].ToString() + "</p>";
            strInfo += "<p>" + "地址：" + dsRecord.Tables[0].Rows[0]["address"].ToString() + "</p>";
            strInfo += "<p>" + "邮编：" + dsRecord.Tables[0].Rows[0]["postcode"].ToString() + "</p>";
            strInfo += "<p>" + "电话：" + dsRecord.Tables[0].Rows[0]["tel"].ToString() + "</p>";
            strInfo += "<p>" + "邮箱：" + dsRecord.Tables[0].Rows[0]["email"].ToString() + "</p>";
            strInfo += "";

            return strInfo;
        }
    }
}
