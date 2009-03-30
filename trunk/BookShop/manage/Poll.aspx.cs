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
using System.Data.SqlClient;
using DbConnect;

public partial class manage_Poll : System.Web.UI.Page
{
    public string gridview1id = "";
    String strConn = ConfigurationManager.AppSettings["dbConnString"];
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Label5.Text = "";
        DbConnector myConn = new DbConnector();
        string SqlQuery = "select * from poll";
        myConn.connDB(strConn);
        DataSet Datas = myConn.executeQuery(SqlQuery);
        if (Datas.Tables[0].Rows.Count > 0)
        {
            Label4.Text = "";
            GridView1.Visible = true;
            GridView1.DataSource = Datas.Tables[0].DefaultView;
            GridView1.DataBind();
        } 
        else
        {
            Label4.Visible = true;
            Label4.Text = "暂时没有投票！";
            Label5.Text = "";
        }
        myConn.close();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        Label4.Text = "";
        Label5.Text = "";
        RadioButton1.Checked = true;
        RadioButton2.Checked = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        GridView1.Visible = false;
        int flags1, flags2;
        DbConnector connStr = new DbConnector();
        connStr.connDB(strConn);
        String str = "";
        if (RadioButton1.Checked == true)
        {
            flags1 = 1;
            str = "insert into poll (theme, introduce, available) values ('" + TextBox1.Text + "', '" + TextBox2.Text + "', 1)";
        } 
        else if (RadioButton2.Checked == true)
        {
            flags1 = 0;
            str = "insert into poll (theme, introduce, available) values ('" + TextBox1.Text + "', '" + TextBox2.Text + "', 0)";
        }
        string Querystring = "select * from poll where available = 1";
        DataSet mydataset1 = connStr.executeQuery(Querystring);
        if (mydataset1.Tables[0].Rows.Count >= 1 && RadioButton1.Checked == true)
            Label5.Text = "当前已经有活动的投票了!";
        else
        {
            flags2 = connStr.executeUpdate(str);
            if (flags2 == 0)
            {
                Label5.Visible = true;
                Label5.Text = "添加操作失败！";
            }
            else
            {
                Label5.Visible = true;
                Label5.Text = "添加操作成功！";
            }
            TextBox1.Text = "";
            TextBox2.Text = "";
            connStr.close();
        }
    }

    protected void BindData()
    {
        DbConnector connStr = new DbConnector();
        connStr.connDB(strConn);
        string Query = "select * from poll";
        DataSet mydataset = new DataSet();
        mydataset = connStr.executeQuery(Query);
        if (mydataset.Tables[0].Rows.Count >= 0)
        {
            Label5.Text = "所有的公告";
            GridView1.DataSource = mydataset.Tables[0].DefaultView;
            GridView1.DataBind();
        }
        else
        {
            Label5.Text = "没有公告";
            GridView1.Visible = false;
        }
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
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DbConnector connStr = new DbConnector();
        connStr.connDB(strConn);
        string id = this.GridView1.DataKeys[e.RowIndex]["ID"].ToString();
        gridview1id = id;
        //string id = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        string delCmd = "delete from poll where id = " + id;
        int flags = connStr.executeUpdate(delCmd);
        if (flags == 0) Label5.Text = "失败！";
        else Label5.Text = "成功！";
        BindData();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.GridView1.EditIndex = e.NewEditIndex;
        BindData();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DbConnector connStr = new DbConnector();
        connStr.connDB(strConn);
        string id = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        gridview1id = id;
        string poll_theme = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
        string poll_introduce = ((TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
        string poll_available = ((TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[0]).Text;
        string sqlStr = "update poll set theme = '" + poll_theme + "', introduce = '" + poll_introduce + "', available = '"+poll_available+"' where ID = " + id;
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
}
