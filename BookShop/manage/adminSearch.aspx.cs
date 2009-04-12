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

public partial class manage_adminSearch : System.Web.UI.Page
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
           // Response.Redirect("adminLogin.html");
           // 提示权限不够信息
            Panel1.Visible = false;
            Panel_quanxian.Visible = true;
        }
    }

    //查询事件
    protected void Bt_search_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            int intSelectedIndex = DDL_level.SelectedIndex; //下拉框选中的index

            String strID = TB_id.Text.Trim();
            String strName = TB_name.Text.Trim();
            String strEmail = TB_email.Text.Trim();
            String strLevel = DDL_level.Items[intSelectedIndex].Value;

            //查询条件>=1项
            if (strID != "" || strName != "" || strEmail != "" || strLevel != "不选")
            {
                //转向adminEdit.apsx页面，并传递查询条件
                Response.Redirect("adminEdit.aspx?id=" + strID  + "&name=" + strName +"&email=" + strEmail +"&level=" + strLevel);
            }

            else
            {  //查询条件为0项

                Lb_error.Text = "你没有输入任何查询条件";
            }
        }
    }
    protected void Bt_return_Click(object sender, EventArgs e)
    {
        Response.Redirect("userManage.aspx");
    }
}