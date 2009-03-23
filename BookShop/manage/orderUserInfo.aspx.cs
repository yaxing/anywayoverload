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


    //��֤�����İ�ȫ��
    private void test(String id)
    {
        if (Request.QueryString.Count != 1)
        {//������������
            Response.Redirect("orderManage.aspx");
        }
        else if (!Request.QueryString[0].Equals("id"))
        {//����������
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
            {//������������
                Response.Redirect("orderManage.aspx");
            }
        }
    }
}
