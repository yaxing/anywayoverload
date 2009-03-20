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
    protected void Page_Load(object sender, EventArgs e)
    {
        string server = ConfigurationManager.AppSettings["dbServer"];
        string userName = ConfigurationManager.AppSettings["dbUserName"];
        string passWord = ConfigurationManager.AppSettings["dbPassWord"]; 
        BsBookInfo bookInfo = new BsBookInfo(server, userName, passWord);

        gvClassList.DataSource = bookInfo.GetBookClassify();
        gvClassList.DataBind();
    }
}
