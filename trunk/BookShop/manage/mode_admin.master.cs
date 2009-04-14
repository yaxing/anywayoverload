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

public partial class manage_mode_admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //判断管理页面类型
        String[] url = Request.Url.ToString().Split('/');//获取当前URL
        String[] urlWithoutParameter = url[url.Length - 1].Split('?') ;//去除URL所带的参数
        String currentURL = urlWithoutParameter[0];
        userManage.Visible = false;
        orderManage.Visible = false;
        BBS.Visible = false;
        Poll.Visible = false;
        memberSearch.Visible = false;
        adminAdd.Visible = false;
        adminSearch.Visible = false;
        pollDetail.Visible = false;
        adminEdit.Visible = false;
        memberEdit.Visible = false;
        Buttons.Visible = false;
        if (currentURL.Equals("userManage.aspx")) 
        {
            adminType.Text = "用户管理";
            userManage.Visible = true;
        }
        else if (currentURL.Equals("orderManage.aspx"))
        {
            adminType.Text = "订单管理";
            orderManage.Visible = true;
        }
        else if (currentURL.Equals("BBS.aspx"))
        {
            adminType.Text = "公告管理";
            BBS.Visible = true;
        }
        else if (currentURL.Equals("Poll.aspx"))
        {
            adminType.Text = "投票管理";
            Poll.Visible = true;
        }
        else if (currentURL.Equals("memberSearch.aspx"))
        {
            adminType.Text = "用户搜索";
            memberSearch.Visible = true;
            Buttons.Visible = true;
        }
        else if (currentURL.Equals("adminAdd.aspx"))
        {
            adminType.Text = "添加管理员";
            adminAdd.Visible = true;
            Buttons.Visible = true;
        }
        else if (currentURL.Equals("adminSearch.aspx"))
        {
            adminType.Text = "查询或修改管理员";
            adminSearch.Visible = true;
            Buttons.Visible = true;
        }
        else if (currentURL.Equals("pollDetail.aspx"))
        {
            adminType.Text = "投票详请";
            pollDetail.Visible = true;
        }
        else if (currentURL.Equals("adminEdit.aspx"))
        {
            adminType.Text = "编辑管理员信息";
            adminEdit.Visible = true;
            Buttons.Visible = true;
        }
        else if (currentURL.Equals("memberEdit.aspx"))
        {
            adminType.Text = "编辑普通用户信息";
            memberEdit.Visible = true;
            Buttons.Visible = true;
        }
        
    }
    protected void manageB_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("userManage.aspx");
    }
    protected void usermanageB_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("memberSearch.aspx");

    }
    protected void adminmanageB_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("adminSearch.aspx");
    }
    protected void adminaddB_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("adminAdd.aspx");
    }
}
