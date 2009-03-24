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
    }
}
