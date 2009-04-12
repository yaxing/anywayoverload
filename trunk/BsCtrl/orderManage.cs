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
        private int recordAmount;       //记录的总条数
        private const int pageSize=10;  //一页显示的条数

        private string connStr;

        private DataSet dsRecord;
        private string strSql;
        private DbConnector DbconnObj=new DbConnector();

        //
        public orderManage(String connStr)
        {
            this.connStr = connStr;
        }

        //设置查询语句
        public void setSql(String sql)
        {
            this.strSql = sql;
        }

        //取出查询结果
        public void getDsRecord()
        {
            DbconnObj.connDB(connStr);
            dsRecord = null;
            dsRecord = DbconnObj.executeQuery(strSql);
            DbconnObj.close();
        }
        
        //执行语句strSql
        public void executeSql()
        {
            DbconnObj.connDB(connStr);
            DbconnObj.executeUpdate(strSql);
            DbconnObj.close();
        }

        //初始化页数
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

        //设定所有页数
        public void setPageAmount(int pageAmount)
        {
            this.pageAmount = pageAmount;
        }

        //获取所有的页数
        public int getPageAmount()
        {
            return pageAmount;
        }

       /*
        返回订单记录
        * 参数：flag 标识该订单所在的标，1 orders 、0 orders_done
        */
        public String recordToShow(int flag)
        {
            string strContent = "";
            strContent += "<table cellspacing=2  cellpadding=2   bordercolordark='#ffffff'  bordercolorlight='#000000' width='100%'> ";
            strContent += "<tr><th width='25%'>用户名</th><th width='20%'>下单时间</th><th width='15%'>交易金额</th><th>交易状态</th><th>更改</th><th></th></tr>";
            if (pageAmount == 0)
            {
                strContent += "<tr><td colspan='6'>没有任何记录!!</td></tr>";
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
                    strContent += "<td align='center'>" +"<a href='customerInfo.aspx?id="+dsRecord.Tables[0].Rows[i]["ID"]+"&flag="+flag+"'>"+ dsRecord.Tables[0].Rows[i]["userName"] +"</a>"+ "</td>";
                    strContent += "<td align='center'>" + dsRecord.Tables[0].Rows[i]["orderdatetime"] + "</td>";
                    strContent += "<td align='center'>" + dsRecord.Tables[0].Rows[i]["amount"] + "</td>";
                    if (dsRecord.Tables[0].Rows[i]["pay"].ToString().Equals("1"))
                    {
                        strContent += "<td align='center'>" + "发货中" + "</td>";
                        strContent += "<td align='center'>" + "<a href='orderDeal.aspx?id=" + dsRecord.Tables[0].Rows[i]["ID"] + "&value=-1'>" + "取消" + "</a>" + "</td>";
                    }
                    else if (dsRecord.Tables[0].Rows[i]["pay"].ToString().Equals("2"))
                    {
                        strContent += "<td align='center'>" + "交易完成" + "</td>";
                        if (flag == 1)
                        {
                            strContent += "<td align='center'>" + "<a href='orderDeal.aspx?id=" + dsRecord.Tables[0].Rows[i]["ID"] + "&value=1'>" + "配货中" + "</a>" + "</td>";
                        }
                        else
                        {
                            strContent += "<td align='center'>&nbsp;&nbsp;</td>";
                        }
                    }
                    else
                    {
                        strContent += "<td align='center'>" + "交易取消" + "</td>";
                        strContent += "<td align='center'>" + "&nbsp;&nbsp;" + "</td>";
                    }
                    strContent += "<td align='center'>" +"<a href='orderDetail.aspx?id="+dsRecord.Tables[0].Rows[i]["ID"]+"&flag="+flag+"'>"+ "详情" +"</a>"+ "</td>";
                    strContent += "</tr>";
                }
            }
            strContent += "</table>";

            return strContent;
        }

        /*
         * 返回用户信息
         * 参数：orderID,订单的ID；flag 标识该订单所在的表，1 orders、0 orders_done
         */
        public String customerInfo(int orderID,int flag)
        {
            if (flag == 1)
            {
                setSql("select * from v_orderManage where ID=" + orderID);
            }
            else
            {
                setSql("select * from v_orderManage_done where ID=" + orderID);
            }
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


        /*返回订单详细信息
         * 参数： orderID(主订单的ID)；flag 标识该订单所在的表，1 orders,0 orders_done
         * 返回值：显示订单详细信息的html脚本
         */
        public String orderDetail(int orderID,int flag)
        {
            if (flag == 1)
            {
                setSql("select * from v_orderDetailManage where orderID=" + orderID);
            }
            else
            {
                setSql("select * from v_orderDetailManage_done where orderID=" + orderID);
            }
            getDsRecord();
            String strContent = "";
            strContent += "<table cellspacing=2  cellpadding=2   bordercolordark='#ffffff'  bordercolorlight='#000000' width='100%'> ";
            strContent += "<tr><th width='25%'>书名</th><th width='20%'>出版社</th><th width='15%'>索书号</th><th>单价</th><th>数量</th><th>折扣</th></tr>";
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
