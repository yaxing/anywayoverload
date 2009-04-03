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

public partial class LoginCheck : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String userName = Request["userName"].ToString();
        String userPwd = Request["userPwd"].ToString();
        String DbConnectString = ConfigurationSettings.AppSettings["dbConnString"];

        AdminControl AdminC = new AdminControl(DbConnectString);
        if(userName.Length == 0 || userPwd.Length == 0)
        {
            Response.Write("<script type='text/javascript'>alert('请输入用户名或密码。');</script>");
            Response.Write("<script type='text/javascript'>location.href('adminLogin.html');</script>");
        }
        else
        {
            if(AdminC.AdminLogin(userName,userPwd))
            {
                Session.Add("AdminN",userName);
                String lv = AdminC.AdminLv();
                Session.Add("AdminLv",lv);
                Response.Redirect("bookManage.aspx");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('用户名或密码错误！');</script>");
                Response.Write("<script type='text/javascript'>location.href('adminLogin.html');</script>");
            }
        }
    }
}
