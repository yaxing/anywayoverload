﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class manage_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //判断权限

        //若不是管理员，回到管理员登录页面
        if (Session["AdminN"] == null)
        {
            Response.Redirect("adminLogin.html");
        }

        //判断管理员等级是否>=3级
        //等级<=3级
        if (Session["AdminLv"].ToString() == "1" || Session["AdminLv"].ToString() == "2")
        {
           // Response.Redirect("adminLogin.html");
           //提示权限不够
            Panel1.Visible = false;
            Panel_quanxian.Visible = true;
        }
    }

    protected void Bt_search_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {

            String strID = TB_ID.Text.Trim();
            String strName = TB_Name.Text.Trim();
            String strTEL = TB_TEL.Text.Trim();
            String strEmail = TB_Email.Text.Trim();

           //查询条件>=1项
           if (strID != "" || strName != "" || strTEL != "" || strEmail != "" )
           {  
             //转向memberEdit页面，并将查询条件以参数str的形式传递给它
               Response.Redirect("memberEdit.aspx?id=" + strID  + "&name=" + strName + "&tel=" + strTEL + "&email=" + strEmail );
            }

            else
            {  //查询条件为0项

                Lb_ret.Text = "你没有输入任何查询条件";
            }
        }
    }


}
