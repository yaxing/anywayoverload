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

public partial class newBooks : System.Web.UI.Page
{
    private BsBookInfo bookInfo = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            string strDbConn = ConfigurationManager.AppSettings["dbConnString"];
            bookInfo = new BsBookInfo(strDbConn);

            //新书列表
            gvNewBooks.DataSource = bookInfo.GetNewBooks(100);
            gvNewBooks.DataBind();
        }
    }
    protected void gvNewBooks_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvNewBooks.PageIndex = e.NewPageIndex;
        string strDbConn = ConfigurationManager.AppSettings["dbConnString"];
        bookInfo = new BsBookInfo(strDbConn);

        //新书列表
        gvNewBooks.DataSource = bookInfo.GetNewBooks(100);
        gvNewBooks.DataBind();
    }
}
