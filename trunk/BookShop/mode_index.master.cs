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
using BsCtrl;
public partial class mode_index : System.Web.UI.MasterPage
{
    String name;
    String pass;
    //String server;
    //String userName;
    //String passWord;
    modeIndex indexCtrl;

    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string dbConnStr = ConfigurationManager.AppSettings["dbConnString"];   //初始化数据库连接信息
        indexCtrl = new modeIndex();  //建立控制类对象
        indexCtrl.initial(dbConnStr);  //数据库连接初始化
        if (Session["selected"] != null)//判断是否能投票
        {
            panelPoll.Visible = false;
            bPoll.Visible = false;
            panelPollResult.Visible = true;
        }
        else 
        {
            panelPoll.Visible = true;
            bPoll.Visible = true;
            panelPollResult.Visible = false;
        }
        if (Session["Grade"]!=null)//每次进入页面时根据session判断登录框显示内容
        {
            String uN = Session["userName"].ToString();
            String aT = Session["Grade"].ToString();
            if (aT.Equals("0")) 
            {
                aT = "会员";
            }
            logName.Text = uN;
            grade.Text = "会员";
            Panel1.Visible = false;
            Panel2.Visible = true;
        }
        else 
        {
            Panel1.Visible = true;
            Panel2.Visible = false; 
        }
        Bbs.DataSource = indexCtrl.GetBbs();
        Bbs.DataBind() ;
        ds = indexCtrl.GetAvailablePoll();
        rblPoll.DataSource = ds;
        pollTheme.DataSource = ds;
        pollTheme.DataBind();
        rblPoll.DataValueField = ds.Tables[0].Columns[4].ToString();
        rblPoll.DataTextField = ds.Tables[0].Columns[6].ToString();
        if (!IsPostBack)
        {
            rblPoll.DataBind();
        }

    }

    protected void LogIn_Click(object sender, EventArgs e)
    {

        DataSet loginInfo;//获取数据库匹配信息数据集
        name = uName.Text;//从页面取出登录信息
        pass = pWord.Text;
        loginInfo = indexCtrl.VerifyUserInfo(name,pass);//数据库匹配登录信息
        if (loginInfo.Tables[0].Rows.Count > 0)//如果信息匹配，登录成功设置session，并修改登录框显示内容
        {
            Session.Add("userName", name);//用户名session
            Session.Add("Grade", loginInfo.Tables[0].Rows[0][8].ToString());//用户权限session
            logName.Text = name;
            grade.Text = loginInfo.Tables[0].Rows[0][8].ToString();
            Panel1.Visible = false;
            Panel2.Visible = true;
        
        }
        else 
        {
            Response.Write("<script>alert('用户名或密码错误！');</script>");
        }
    }

    protected void Button2_Click(object sender, EventArgs e)//退出登录时撤销session
    {
        Session.Abandon();
        Response.Redirect("indexTest.aspx");
    }

    protected void Regisiter_Click(object sender, EventArgs e)
    {
        Response.Redirect("RegistereUser.aspx");
    }
    protected void Reput_Click(object sender, EventArgs e)
    {
        pWord.Text = "";
        uName.Text = "";
    }
    protected void bPoll_Click(object sender, EventArgs e)
    {
        Session.Add("selected","true");
        int pID = 0;
        String selected = rblPoll.SelectedValue;
        //Response.Write("ri"+selected);
        pID = int.Parse(selected);
        indexCtrl.ModifyPoll(pID);
        panelPoll.Visible = false;
        bPoll.Visible = false;
        panelPollResult.Visible = true;
        return;
    }
}
