using System;
using System.Collections.Generic;
using System.Text;
using DbConnect;
using System.Data;

namespace BsCtrl
{
    class orderManage
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
            dsRecord = DbconnObj.executeQuery(strSql);
            DbconnObj.close();
        }

        //字段初始化
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

        //显示记录
        public String recordToShow()
        {
            string strContent = "";
            strContent += "<table>";
            strContent += "<tr><th>用户名</th><th>下单时间</th><th>交易金额</th><th></th><th></th><th></th></tr>";
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
                    strContent += "<td>" + "完成" + "</td>";
                    strContent += "<td>" + "取消" + "</td>";
                    strContent += "<td>" + "详情" + "</td>";
                    strContent += "</tr>";
                }
            }
            strContent += "</table>";

            return strContent;
        }
    }
}
