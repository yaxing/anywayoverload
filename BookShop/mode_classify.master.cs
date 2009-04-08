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

public partial class mode_classify : System.Web.UI.MasterPage
{
    private BsBookInfo bookInfo = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            string strDbConn = ConfigurationManager.AppSettings["dbConnString"];
            bookInfo = new BsBookInfo(strDbConn);

            rpClass.DataSource = bookInfo.GetBookClassify();
            rpClass.DataBind();
        }
        this.searchContent.Attributes.Add("onMouseOver", "this.select()"); //鼠标移至搜索框时全选其中内容
    }

    protected void searchButton_Click(object sender, ImageClickEventArgs e)
    {
        String searchC = searchContent.Text.Trim();
        String[] sC = searchC.Split(' ');
        Session.Add("sContent", sC);
        Response.Redirect("searchDeal.aspx");
    }
}
