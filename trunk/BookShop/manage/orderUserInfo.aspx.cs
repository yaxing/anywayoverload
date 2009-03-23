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

public partial class manage_orderUserInfo : System.Web.UI.Page
{
    orderManage orderManObj = new orderManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String id = Request.QueryString["id"].ToString();
            lblContent.Text = orderManObj.customerInfo(Convert.ToInt32(id));
        }
    }


    //验证参数的安全性
    private void test(String id)
    {
        if (Request.QueryString.Count != 1)
        {//参数个数不对
            Response.Redirect("orderManage.aspx");
        }
        else if (!Request.QueryString[0].Equals("id"))
        {//参数名不对
            Response.Redirect("orderManage.aspx");
        }
        else
        {
            try
            {
                Convert.ToInt32(id);
                return;
            }
            catch
            {//参数不是数字
                Response.Redirect("orderManage.aspx");
            }
        }
    }
}
