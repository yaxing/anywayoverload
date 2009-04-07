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
        //loginChk();
        string dbConnStr = ConfigurationManager.ConnectionStrings["shanzhaiConnectionString"].ToString();
        orderManage orderManObj = new orderManage(dbConnStr);
        if (!IsPostBack)
        {
            test();
            String id = Request.QueryString["id"].ToString();
            String flag = Request.QueryString["flag"].ToString();
            lblContent.Text = orderManObj.customerInfo(Convert.ToInt32(id), Convert.ToInt32(flag));
        }
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
                Convert.ToInt32(Request.QueryString["flag"].ToString());
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