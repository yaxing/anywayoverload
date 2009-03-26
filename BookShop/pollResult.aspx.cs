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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["selected"] == null)//判断是否能投票
        {
            Response.Write("<script>alert('对不起，您还未投票，不能查看投票结果！');</script>");
            Response.Write("<script>history.back(1);</script>");
        }
    }
}
