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

public partial class index : System.Web.UI.Page
{
    private BsBookInfo bsBookInfo = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        string server = ConfigurationManager.AppSettings["dbServer"];
        string userName = ConfigurationManager.AppSettings["dbUserName"];
        string passWord = ConfigurationManager.AppSettings["dbPassWord"]; 

        //新书列表
        bsBookInfo = new BsBookInfo(server, userName, passWord);
        rpBookInfo.DataSource = bsBookInfo.GetNewBooks(8);
        rpBookInfo.DataBind();
    }
}
