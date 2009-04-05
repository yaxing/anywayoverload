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
        if(!Page.IsPostBack)
        {
            string dbConnStr = ConfigurationManager.ConnectionStrings["shanzhaiConnectionString"].ToString();

            bsBookInfo = new BsBookInfo(dbConnStr);

            //新书列表
            rpBookInfo.DataSource = bsBookInfo.GetNewBooks(8);
            rpBookInfo.DataBind();

            //最热门分类
            rpTopClass.DataSource = bsBookInfo.GetHotClasses(10);
            rpTopClass.DataBind();

            //最热图书
            rpRank.DataSource = bsBookInfo.GetHotBooks(10);
            rpRank.DataBind();
        }
    }
}
