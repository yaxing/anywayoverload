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
        orderManObj = new orderManage();
        orderManObj.setSql("select * from v_orderManage");
        orderManObj.getDsRecord();
        orderManObj.initPages();
        lblPageAll.Text = orderManObj.getPageAmount() + "";
        if (!IsPostBack)
        {
            lblPageNow.Text = orderManObj.getCurrentPage() + "";
        }
        else
        {
            orderManObj.setCurrentPage(Convert.ToInt32(lblPageNow.Text));
        }
        lblContent.Text = orderManObj.recordToShow();
    }



    protected void lBtnPriPage_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(lblPageNow.Text) > 1)
        {
            lblPageNow.Text = (Convert.ToInt32(lblPageNow.Text) - 1) + "";
        }
    }

    protected void lBtnNextPage_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(lblPageNow.Text) < Convert.ToInt32(lblPageAll.Text))
        {
            lblPageNow.Text = (Convert.ToInt32(lblPageNow.Text) + 1) + "";
        }
    }
}
