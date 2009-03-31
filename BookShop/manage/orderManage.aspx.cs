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

public partial class manage_orderManage : System.Web.UI.Page
{
    private orderManage orderManObj = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        loginChk();
        if (!IsPostBack)
        {
            hfUserName.Value = "";           //��һ�μ���ҳ�棬�����ؼ����ֶ�Ϊ��
            showContent(1);
        }
    }


    public void showContent(int flag)
    {
        string dbConnStr = ConfigurationManager.AppSettings["dbConnString"];
        orderManObj = new orderManage(dbConnStr);
        orderManObj.setSql("select * from v_orderManage where userName like '%" + hfUserName.Value + "%'");
        orderManObj.getDsRecord();
        orderManObj.initPages();            //����ҳ��
        lblPageAll.Text = orderManObj.getPageAmount() + "";     //��ʾ��ҳ��
        if (flag == 1)
        {
            lblPageNow.Text = orderManObj.getCurrentPage() + "";    //��ʾ��ǰҳ��
        }
        else
        {
            orderManObj.setCurrentPage(Convert.ToInt32(lblPageNow.Text));   //��ȡҳ��������Ҫ��ʾ��ҳ��
        }

        if (lblPageAll.Text.Equals("0"))                            //���÷�ҳ��ť�Ŀɼ���
        {
            lBtnNextPage.Visible = false;
            lBtnPriPage.Visible = false;
        }
        else
        {
            lBtnNextPage.Visible = true;
            lBtnPriPage.Visible = true;
        }
        lblContent.Text = orderManObj.recordToShow();          //��ʾ����
    }


    protected void lBtnPriPage_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(lblPageNow.Text) > 1)
        {
            lblPageNow.Text = (Convert.ToInt32(lblPageNow.Text) - 1) + "";
        }
        showContent(0);
    }

    protected void lBtnNextPage_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(lblPageNow.Text) < Convert.ToInt32(lblPageAll.Text))
        {
            lblPageNow.Text = (Convert.ToInt32(lblPageNow.Text) + 1) + "";
        }
        showContent(0);
    }


    protected void lBtnSearch_Click(object sender, EventArgs e)
    {
        String userName = tBoxUserName.Text;
        userName=userName.Replace("'", "��");
        userName=userName.Replace("\\", "��");
        hfUserName.Value = userName;
        showContent(1);
    }

    public void loginChk()
    {
        if (Session["AdminN"] == null || Session["AdminLv"] == null)
        {
            Response.Redirect("adminLogin.html");
        }
    }
}
