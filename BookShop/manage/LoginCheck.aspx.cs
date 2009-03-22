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

public partial class LoginCheck : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userName = Request["userName"].ToString();
        string userPwd = Request["userPwd"].ToString();
        if(userName.Length == 0 || userPwd.Length == 0)
        {
            Response.Write("<script type='text/javascript'>alert('请输入用户名或密码。');</script>");
            Response.Write("<script type='text/javascript'>location.href('adminLogin.html');</script>");
        }
        else
        {
            
        }
    }
}
