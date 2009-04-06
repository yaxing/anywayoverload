﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using DbConnect;

public partial class manage_PollDetail : System.Web.UI.Page
{
    DbConnector connStr = new DbConnector();
    String connection = ConfigurationManager.AppSettings["dbConnString"];
    String PollID = "";

    protected void BindData()
    {
        connStr.connDB(connection);
        string BindStr = "select * from pollDetail";
        DataSet BindDataSet = connStr.executeQuery(BindStr);
        PollDetail.DataSource = BindDataSet.Tables[0].DefaultView;
        PollDetail.DataBind();
        connStr.close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["ID"] == null)
        {
            Response.Redirect("poll.aspx");
        }
        PollID = Request["ID"];
        connStr.connDB(connection);
        string QueryPollTitle = "select * from poll where ID = " + PollID;
        DataSet ResultPT = connStr.executeQuery(QueryPollTitle);
        DataTable ResultDataTable = ResultPT.Tables[0];
        PollThemeText.Text = ResultDataTable.Rows[0]["theme"].ToString();
        string QueryStr = "select * from pollDetail where pollID = " + PollID;
        DataSet pollDetailData = connStr.executeQuery(QueryStr);
        if (pollDetailData.Tables[0].Rows.Count > 0)
        {
            PollDetailTitle.Text = "当前投票主题的投票选项：";
            PollDetail.DataSource = pollDetailData.Tables[0].DefaultView;
            PollDetail.DataBind();
        } 
        else
        {
            PollDetailTitle.Text = "当前投票主题暂时没有投票选项！";
            DelAll.Visible = false;
        }
        connStr.close();
    }
    protected void Reset_Click(object sender, EventArgs e)
    {
        PollOptionText.Text = "";
    }
    protected void Save_Click(object sender, EventArgs e)
    {
        connStr.connDB(connection);
        string pollItemContent = PollOptionText.Text;
        string InsertStr = "insert into pollDetail (pollID, optionName, counts) values (" + PollID + ", '" +PollOptionText.Text+ "', 0)";
        int flag = connStr.executeUpdate(InsertStr);
        if (flag == 0)
        {
            flag2.Text = "添加失败！";
        } 
        else
        {
            flag2.Text = "添加成功！";
            Response.Redirect(Request.Url.ToString());
        }
        connStr.close();
    }
    protected void DelAll_Click(object sender, EventArgs e)
    {
        string DelCmd = "delete from pollDetail";
        connStr.connDB(connection);
        connStr.executeUpdate(DelCmd);
        connStr.close();
        Response.Redirect(Request.Url.ToString());
    }
    protected void PollDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        connStr.connDB(connection);
        string id = this.PollDetail.DataKeys[e.RowIndex]["ID"].ToString();
        string DelCmd = "delete from pollDetail where id = " + id;
        int flag = connStr.executeUpdate(DelCmd);
        if (flag == 0)
        {
            flag2.Text = "删除失败！";
        } 
        else
        {
            flag2.Text = "删除成功！";
            BindData();
            Response.Redirect(Request.Url.ToString());
        }
        connStr.close();
    }
    protected void PollDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.PollDetail.EditIndex = e.NewEditIndex;
        BindData();
    }
    protected void PollDetail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        this.PollDetail.EditIndex = -1;
        BindData();
    }
    protected void PollDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        connStr.connDB(connection);
        string id = this.PollDetail.DataKeys[e.RowIndex].Values[0].ToString();
        string pollDetailOption = ((TextBox)PollDetail.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
        string UpdateStr = "update pollDetail set optionName = '" + pollDetailOption + "' where id = " + id;
        int flag = connStr.executeUpdate(UpdateStr);
        if (flag == 0)
        {
            flag2.Text = "更新失败！";
        } 
        else
        {
            flag2.Text = "更新成功！";
        }
        connStr.close();
    }
    protected void PollDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        PollDetail.EditIndex = -1;
        BindData();
    }
}
