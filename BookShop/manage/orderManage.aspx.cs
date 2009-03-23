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
    orderManage orderManObj = new orderManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            orderManObj.setSql("select * from v_orderManage");
            orderManObj.getDsRecord();
            orderManObj.initPage();

            lblContent.Text = orderManObj.recordToShow();

            showPage();
        }
    }

    private void showPage()
    {
        if (orderManObj.getPageAmount() > 0)
        {
            lblPage.Text = "<font color='red'>" + orderManObj.getCurrentPage() + "</font>" + "/" + orderManObj.getPageAmount();
            lBtnNextPage.Visible = true;
            lBtnNextPage.Visible = true;
        }
        else
        {
            lblPage.Text = "";
            lBtnNextPage.Visible = false;
            lBtnNextPage.Visible = false;
        }
    }


    protected void lBtnPriPage_Click(object sender, EventArgs e)
    {
        if (orderManObj.getCurrentPage() > 1)
        {
            orderManObj.setPageToShow(orderManObj.getCurrentPage() - 1);
            lblContent.Text = orderManObj.recordToShow();
            orderManObj.setCurrentPage(orderManObj.getCurrentPage() - 1);
            showPage();
        }
    }

    protected void lBtnNextPage_Click(object sender, EventArgs e)
    {
        if (orderManObj.getCurrentPage() < orderManObj.getPageAmount())
        {
            orderManObj.setPageToShow(orderManObj.getCurrentPage() + 1);
            lblContent.Text = orderManObj.recordToShow();
            orderManObj.setCurrentPage(orderManObj.getCurrentPage() + 1);
            showPage();
        }
    }
}
