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
using DbConnect;
using System.Data.Common;
using System.Data.SqlClient;

public partial class manage_BBS : System.Web.UI.Page
{
    String strConn = ConfigurationManager.AppSettings["dbConnString"];
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.Visible = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Label2.Text = "";
        TextBox1.Text = "";
        GridView1.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DbConnector connStr = new DbConnector();
        connStr.connDB(strConn);
        DateTime d = DateTime.Now;
        String str = "insert into bbs (content, postTime) values('" + TextBox1.Text + "',  '"+d+"')";
        int flags = connStr.executeUpdate(str);
        if (flags == 0)
        {
            Label2.Text = "添加失败！";
        }
        else Label2.Text = "添加成功！";
        connStr.close();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Label2.Text = "所有公告：";
        GridView1.Visible = true;
        DbConnector myConn = new DbConnector();
        string SqlQuery = "select * from bbs";
        myConn.connDB(strConn);
        DataSet Datas = myConn.executeQuery(SqlQuery);
        if (Datas.Tables[0].Rows.Count > 0)
        {
            //Label4.Text = "";
            GridView1.Visible = true;
            GridView1.DataSource = Datas.Tables[0].DefaultView;
            GridView1.DataBind();
        }
        else
        {
            //Label4.Visible = true;
        }
        myConn.close();
    }

    protected void BindData()
    {
        DbConnector connStr = new DbConnector();
        connStr.connDB(strConn);
        string Query = "select * from bbs";
        DataSet mydataset = new DataSet();
        mydataset = connStr.executeQuery(Query);
        if (mydataset.Tables[0].Rows.Count >= 0)
        {
            Label2.Text = "所有的公告";
            GridView1.DataSource = mydataset.Tables[0].DefaultView;
            GridView1.DataBind();
        } 
        else
        {
            Label2.Text = "没有公告";
            GridView1.Visible = false;
        }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.GridView1.EditIndex = e.NewEditIndex;
        BindData();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DbConnector connStr = new DbConnector();
        connStr.connDB(strConn);
        string id = this.GridView1.DataKeys[e.RowIndex]["ID"].ToString();
        string delCmd = "delete from bbs where id = " + id;
        int flags = connStr.executeUpdate(delCmd);
        if (flags == 0) Label5.Text = "失败！";
        else Label5.Text = "成功！";
        BindData();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DbConnector connStr = new DbConnector();
        connStr.connDB(strConn);
        string id = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        string bbs_content = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
        string bbs_postTime = ((TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
        string sqlStr = "update bbs set content = '" + bbs_content + "', postTime = '" + bbs_postTime + "' where ID = " + id;
        int flags = connStr.executeUpdate(sqlStr);
        if (flags == 0)
        {
            Label5.Text = "更新失败！";
        } 
        else
        {
            Label5.Text = "更新成功！";
        }
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindData();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindData();
    }
}
