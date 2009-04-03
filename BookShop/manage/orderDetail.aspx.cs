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

public partial class manage_orderDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //loginChk();
        string dbConnStr = ConfigurationManager.AppSettings["dbConnString"];
        orderManage orderManObj = new orderManage(dbConnStr);
        test();
        String orderID = Request.QueryString["id"].ToString();
        String flag = Request.QueryString["flag"].ToString();
        lblContent.Text = orderManObj.orderDetail(Convert.ToInt32(orderID), Convert.ToInt32(flag));
    }

    //��֤�����İ�ȫ��
    private void test()
    {
        if (Request.QueryString.Count != 2)
        {//������������
            Response.Redirect("orderManage.aspx");
        }
        else
        {
            try
            {
                Convert.ToInt32(Request.QueryString["id"].ToString());
                Convert.ToInt32(Request.QueryString["id"].ToString());
                return;
            }
            catch
            {//������������
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
