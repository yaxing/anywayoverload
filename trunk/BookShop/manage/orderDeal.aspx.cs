using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BsCtrl;

public partial class manage_orderDeal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        test();
        string dbConnStr = ConfigurationManager.AppSettings["dbConnString"];
        orderManage orderManObj = new orderManage(dbConnStr);
        string ID = Request.QueryString["id"].ToString();
        String value = Request.QueryString["value"].ToString();
        orderManObj.setSql("update orders set pay="+value+" where ID="+ID);
        orderManObj.executeSql();
        Response.Redirect("orderManage.aspx");
    }

    //验证参数的安全性
    private void test()
    {
        if (Request.QueryString.Count != 2)
        {//参数个数不对
            Response.Redirect("orderManage.aspx");
        }
        else
        {
            try
            {
                Convert.ToInt32(Request.QueryString["id"].ToString());
                Convert.ToInt32(Request.QueryString["value"].ToString());
                return;
            }
            catch
            {//参数不是数字
                Response.Redirect("orderManage.aspx");
            }
        }
    }
}
