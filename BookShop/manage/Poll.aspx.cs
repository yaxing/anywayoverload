using System;
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

public partial class manage_Poll : System.Web.UI.Page
{
    DbConnector connStr = new DbConnector();
    String connection = ConfigurationManager.AppSettings["dbConnString"];

    protected void BindData()
    {
        connStr.connDB(connection);
        string BindStr = "select * from poll";
        DataSet BindDataSet = connStr.executeQuery(BindStr);
        Poll.DataSource = BindDataSet.Tables[0].DefaultView;
        Poll.DataBind();
        connStr.close();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        connStr.connDB(connection);
        string QueryStr = "select * from poll";
        DataSet pollData = connStr.executeQuery(QueryStr);
        if (pollData.Tables[0].Rows.Count > 0)
        {
            PollTitle.Text = "公告如下：";
            Poll.DataSource = pollData.Tables[0].DefaultView;
            Poll.DataBind();
        } 
        else
        {
            PollTitle.Text = "暂时没有公告！";
            DeleteAll.Visible = false;
        }
        connStr.close();
    }
    protected void Reset_Click(object sender, EventArgs e)
    {
        ThemeText.Text = "";
        introText.Text = "";
        unAble.Checked = true;
    }
    protected void Save_Click(object sender, EventArgs e)
    {
        int flags1, flags2;
        connStr.connDB(connection);
        string insertStr = "";
        if (Able.Checked == true)
        {
            insertStr = "insert into poll (theme, introduce, available) values ('"+ThemeText.Text+"', '"+introText.Text+"', 1)";
        } 
        else
        {
            insertStr = "insert into poll (theme, introduce, available) values ('" + ThemeText.Text + "', '" + introText.Text + "', 0)";
        }
        string QueryString = "select * from poll where available = 1";
        DataSet QueryResult = connStr.executeQuery(QueryString);
        if (QueryResult.Tables[0].Rows.Count >= 1 && Able.Checked == true)
        {
            availablenum.Text = "当前已有活动主题！";
        } 
        else
        {
            flags2 = connStr.executeUpdate(insertStr);
            if (flags2 == 0)
            {
                availablenum.Text = "主题添加失败！";
            } 
            else
            {
                availablenum.Text = "主题添加成功！";
                Response.Redirect(Request.Url.ToString());
            }
        }
        connStr.close();
    }
    protected void Poll_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Poll.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void Poll_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        connStr.connDB(connection);
        string id = this.Poll.DataKeys[e.RowIndex]["ID"].ToString();
        string DelCmd = "delete from poll where id = " + id;
        int flag = connStr.executeUpdate(DelCmd);
        if (flag == 0)
        {
            availableFlags.Text = "删除成功！";
        } 
        else
        {
            availableFlags.Text = "删除失败！";
        }
        DataBind();
        connStr.close();
        Response.Redirect(Request.Url.ToString());
    }
    protected void Poll_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.Poll.EditIndex = e.NewEditIndex;
        BindData();
    }
    protected void Poll_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        this.Poll.EditIndex = -1;
        BindData();
    }
    protected void Poll_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        connStr.connDB(connection);
        string id = this.Poll.DataKeys[e.RowIndex].Values[0].ToString();
        string poll_theme = ((TextBox)Poll.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
        string poll_introduce = ((TextBox)Poll.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
        string poll_available = ((TextBox)Poll.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
        string PollUpdateStr = "update poll set theme = '" + poll_theme + "', introduce = '" + poll_introduce + "', available = '" + poll_available + "' where ID = " + id;
        int flag = connStr.executeUpdate(PollUpdateStr);
        if (flag == 0)
        {
            availableFlags.Text = "更新失败！";
        } 
        else
        {
            availableFlags.Text = "更新成功！";
            DataBind();
        }
        connStr.close();
    }
    protected void DeleteAll_Click(object sender, EventArgs e)
    {
        connStr.connDB(connection);
        string DelAllStr = "delete from poll";
        int flag = connStr.executeUpdate(DelAllStr);
        if (flag == 0)
        {
            availableFlags.Text = "删除失败！";
        } 
        else
        {
            availableFlags.Text = "删除成功！";
        }
        connStr.close();
    }
}
