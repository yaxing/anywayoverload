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

public partial class _Default : System.Web.UI.Page
{
    private BsBookInfo bookInfo;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            string strDbConn = ConfigurationManager.AppSettings["dbConnString"];
            bookInfo = new BsBookInfo(strDbConn);

            if (Session["sContent"] == null)
            {
                Response.Redirect("index.aspx");
            }

            string[] keyWords = (string[])Session["sContent"];
            DataSet ds = bookInfo.SearchBooks(keyWords);
            if(ds.Tables[0].Rows.Count != 0)
            {
                gvSearchResult.DataSource = bookInfo.SearchBooks(keyWords);
                gvSearchResult.DataBind();
                lblSearch.Text = "搜索结果";
            }
            else
            {
                lblSearch.Text = "无对应书籍";
            }

            Session.Remove("sContent");
        }
    }
}
