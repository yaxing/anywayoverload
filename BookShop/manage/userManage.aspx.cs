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

public partial class manage_userManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //判断权限

        //若不是管理员，回到管理员登录页面
        if (Session["AdminN"] == null)
        {
            Response.Redirect("adminLogin.html");
        }

        //判断管理员等级是否>=3，只有>=3级的管理员能访问该页面
        //等级低于3级
        if (Session["AdminLv"].ToString() == "1" || Session["AdminLv"].ToString() == "2")
        {
        //提示权限不够
            Panel_content.Visible = false;
            Panel_quanxian.Visible = true;

        }
    }
    protected void LB_addAdmin_Click(object sender, EventArgs e)
    {
        Response.Redirect("adminAdd.aspx");
    }
    protected void LB_searchAdmin_Click(object sender, EventArgs e)
    {
        Response.Redirect("adminSearch.aspx");
    }
    protected void LB_searchMember_Click(object sender, EventArgs e)
    {
        Response.Redirect("memberSearch.aspx");
    }
}
