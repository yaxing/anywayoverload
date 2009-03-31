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


public partial class manage_customerInfo : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        loginChk();
        string dbConnStr = ConfigurationManager.AppSettings["dbConnString"];
        orderManage orderManObj = new orderManage(dbConnStr);
        if (!IsPostBack)
        {
            test();
            String id = Request.QueryString["id"].ToString();
            lblContent.Text = orderManObj.customerInfo(Convert.ToInt32(id));
        }
    }


    //验证参数的安全性
    private void test()
    {
        if (Request.QueryString.Count != 1)
        {//参数个数不对
            Response.Redirect("orderManage.aspx");
        }
        else
        {
            try
            {
                Convert.ToInt32(Request.QueryString["id"].ToString());
                return;
            }
            catch
            {//参数不是数字
                Response.Redirect("orderManage.aspx");
            }
        }
    }

    public void loginChk()
    {
        if (Session["AdminN"] == null || Session["AdminLv"] == null)
        {
            Response.Redirect("adminLogin.html");
        }
    }
}