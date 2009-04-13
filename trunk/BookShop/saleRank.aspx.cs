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

public partial class saleRank : System.Web.UI.Page
{
    private BsBookInfo bookInfo = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            string strDbConn = ConfigurationManager.ConnectionStrings["shanzhaiConnectionString"].ToString();
            bookInfo = new BsBookInfo(strDbConn);

            //销售排行
            gvSaleRank.DataSource = bookInfo.GetHotBooks(100);
            gvSaleRank.DataBind();
        }
    }
    protected void gvSaleRank_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gvSaleRank.PageIndex = e.NewPageIndex;
        string strDbConn = ConfigurationManager.ConnectionStrings["shanzhaiConnectionString"].ToString();
        bookInfo = new BsBookInfo(strDbConn);

        //销售排行
        gvSaleRank.DataSource = bookInfo.GetHotBooks(100);
        gvSaleRank.DataBind();
    }
}
