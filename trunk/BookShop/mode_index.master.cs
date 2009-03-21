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
public partial class mode_index : System.Web.UI.MasterPage
{
    String name;
    String pass;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Contents.Count > 0)
        {
            logName.Text = Session["userName"].ToString();
            grade.Text = Session["pass"].ToString();
            Panel1.Visible = false;
            Panel2.Visible = true;
        }
        else 
        {
            Panel1.Visible = true;
            Panel2.Visible = false; 
        }
    }

    protected void LogIn_Click(object sender, EventArgs e)
    {
        
        bool LogInOrNot;
        string server = ConfigurationSettings.AppSettings["dbServer"];
        string userName = ConfigurationSettings.AppSettings["dbUserName"];
        string passWord = ConfigurationSettings.AppSettings["dbPassWord"];
        modeIndex indexCtrl = new modeIndex();
        indexCtrl.initial(server, userName, passWord);
        name = uName.Text;
        pass = pWord.Text;
        LogInOrNot = indexCtrl.VerifyUserInfo(name,pass);
        if (LogInOrNot == true)
        {
            Session.Add("userName", name);
            Session.Add("pass", pass);
            logName.Text = name;
            grade.Text = pass;
            Panel1.Visible = false;
            Panel2.Visible = true;
        }
        else 
        {
            Response.Write("<script>alert('用户名或密码错误！');</script>");
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("indexTest.aspx");
    }
}
