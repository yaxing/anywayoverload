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
using System.Data.SqlClient;
using DbConnect;
using System.Data.SqlClient;

public partial class manage_PollDetail : System.Web.UI.Page
{
    public String PollID = "";
    public DbConnector connStr = new DbConnector();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["ID"] == null)
            Response.Redirect("poll.aspx");
        PollID = Request["ID"];
        TextBox2.Enabled = false;
        TextBox4.Enabled = false;
        connStr.connDB("localhost", "sa", ".");
        string QueryString = "select * from poll where ID = " + PollID;
        DataSet QueryResult = connStr.executeQuery(QueryString);
        //TextBox2.Text = QueryResult.Tables[0].Rows[]
        connStr.close();
        DataTable TableResult = new DataTable();
        TableResult = QueryResult.Tables[0];
        TextBox2.Text = TableResult.Rows[0]["theme"].ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String PollItemContent = TextBox3.Text;
        String InsertString = "insert into pollDetail (pollID, optionName, counts) values (" + PollID + ", '"+TextBox3.Text+"', 0)";
        connStr.connDB("localhost", "sa", ".");
        int flags = connStr.executeUpdate(InsertString);
        connStr.close();
        if (flags == 0)
        {
            Label1.Text = "插入失败！";
        } 
        else
        {
            Label1.Text = "插入成功！";
        }
        //str = "insert into poll (theme, introduce, available) values ('" + TextBox1.Text + "', '" + TextBox2.Text + "', 1)";
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        connStr.connDB("localhost", "sa", ".");
        String QueryString = "select * from pollDetail where pollid = " + PollID;
        DataSet QueryResult = connStr.executeQuery(QueryString);
        connStr.close();
        if (QueryResult.Tables[0].Rows.Count > 0)
        {
            Label1.Text = "投票选项如下：";
            GridView1.DataSource = QueryResult.Tables[0].DefaultView;
            GridView1.DataBind();
        } 
        else
        {
            Label1.Text = "暂时还没有投票选项！";
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox3.Text = "";
        Label1.Text = "";
    }
    protected void BindData()
    {
        connStr.connDB("localhost", "sa", ".");
        String QueryString = "select * from pollDetail where pollid = " + PollID;
        DataSet QueryResult = connStr.executeQuery(QueryString);
        connStr.close();
        if (QueryResult.Tables[0].Rows.Count > 0)
        {
            Label1.Text = "投票选项如下：";
            GridView1.DataSource = QueryResult.Tables[0].DefaultView;
            GridView1.DataBind();
        } 
        else
        {
            Label1.Text = "暂时还没有投票选项！";
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        connStr.connDB("localhost", "sa", ".");
        string id = this.GridView1.DataKeys[e.RowIndex]["ID"].ToString();
        //gridview1id = id;
        string delCmd = "delete from pollDetail where id = " + id;
        int flags = connStr.executeUpdate(delCmd);
        if (flags == 0) Label1.Text = "失败！";
        else Label1.Text = "成功！";
        BindData();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.GridView1.EditIndex = e.NewEditIndex;
        BindData();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        DataBind();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindData();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        connStr.connDB("localhost", "sa", ".");
        string id = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        //gridview1id = id;
        //string PollID = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
        string pollDetailOption = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
        //string poll_available = ((TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[0]).Text;
        //string sqlStr = "update poll set theme = '" + poll_theme + "', introduce = '" + poll_introduce + "', available = '" + poll_available + "' where ID = " + id;
        String sqlStr = "update pollDetail set optionName ='" + pollDetailOption + "' where id = " + id;
        int flags = connStr.executeUpdate(sqlStr);
        if (flags == 0)
        {
            Label1.Text = "更新失败！";
        }
        else
        {
            Label1.Text = "更新成功！";
        }
    }
}
