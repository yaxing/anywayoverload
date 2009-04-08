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

        //判断是否为4级管理员，只有4级管理员能访问该页面
        //不是4级管理员
        if (Session["AdminLv"].ToString() != "4")
        {
            Panel_content.Visible = false;
            Lb_ret.Text = "你没有权限，不能访问该页面";
            Lb_ret.Visible = true;

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
