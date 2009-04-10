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
using System.IO;

public partial class manage_Poll : System.Web.UI.Page
{
    DbConnector connStr = new DbConnector();
    String connection = ConfigurationManager.AppSettings["dbConnString"];

    protected void BindData()
    {
        connStr.connDB(connection);
        string BindStr = "select * from poll order by available desc,id desc";
        DataSet BindDataSet = connStr.executeQuery(BindStr);
        Poll.DataSource = BindDataSet.Tables[0].DefaultView;
        Poll.DataBind();
        connStr.close();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminN"] == null || Session["AdminLv"] == null)
        {
            Response.Redirect("../index.aspx");
        }
        if (!IsPostBack)
        {
            BindData();
        }
        DeleteAll.Attributes.Add("onclick", "return confirm('真的要删除所有的投票吗?');");

        connStr.connDB(connection);
        string QueryStr = "select * from poll order by available desc,id desc";
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
            OutWord.Visible = false;
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
        string DelOption = "delete from pollDetail where pollID = " + id;
        int flag1 = connStr.executeUpdate(DelOption);
        if (flag1!=0)
        {
            int flag = connStr.executeUpdate(DelCmd);
            if (flag == 0)
            {
                availableFlags.Text = "删除成功！";
            }
            else
            {
                availableFlags.Text = "删除失败！";
            }
        }
        else
        {
            availableFlags.Text = "删除投票选项出错！";
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
        TextBox poll_theme = (TextBox)this.Poll.Rows[e.RowIndex].Cells[3].FindControl("TextBox2") as TextBox;
        TextBox poll_introdue = (TextBox)this.Poll.Rows[e.RowIndex].Cells[4].FindControl("TextBox3") as TextBox;
        TextBox poll_available = (TextBox)this.Poll.Rows[e.RowIndex].Cells[5].FindControl("TextBox4") as TextBox;
        if (poll_theme != null && poll_introdue != null && poll_available != null)
        {
            string PollUpdateStr = "update poll set theme = '" + poll_theme.Text + "', introduce = '" + poll_introdue.Text + "', available = '" + poll_available.Text + "' where ID = " + id;
            string FindActive = "select * from poll where available = 1";
            DataSet flag1 = connStr.executeQuery(FindActive);
            if (flag1.Tables[0].Rows.Count == 0 && poll_available.Text == "1"||poll_available.Text == "0")
            {
                int flag = connStr.executeUpdate(PollUpdateStr);

                if (flag == 0)
                {
                    availableFlags.Text = "更新失败！";
                }
                else
                {
                    availableFlags.Text = "更新成功！";
                    Poll.EditIndex = -1;
                    DataBind();
                    Response.Redirect(Request.Url.ToString());
                }
            }
            else 
            {
                availableFlags.Text = "当前已经有活动主题了！";
            }
            this.Poll.EditIndex = -1;
        }
        connStr.close();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void DeleteAll_Click(object sender, EventArgs e)
    {
        connStr.connDB(connection);
        string DelAllStr1 = "delete from pollDetail";
        string QueryPollDetail = "select * from pollDetail";
        DataSet R = connStr.executeQuery(QueryPollDetail);
        int num = R.Tables[0].Rows.Count;
        string DelAllStr2 = "delete from poll";
        int flag1 = connStr.executeUpdate(DelAllStr1);
        int flag2 = connStr.executeUpdate(DelAllStr2);
        if (flag2 >= 1 && num == 0|| flag2 >= 1 && flag1 >= 1)
        {
            availableFlags.Text = "删除成功！";
            Response.Redirect(Request.Url.ToString());

        } 
        else 
        {
            availableFlags.Text = "删除失败！";
        }
        connStr.close();
    }
    protected void OutWord_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.BufferOutput = true;
        Response.Charset = "GB2312";
        Response.AppendHeader("Content-Disposition", "attachment; filename = Filename.doc");
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        Response.ContentType = "application/ms-word";
        Poll.EnableViewState = false;
        System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("ZH-CN", true);
        System.IO.StringWriter stringwriter = new StringWriter(cultureInfo);
        System.Web.UI.HtmlTextWriter textWriter = new HtmlTextWriter(stringwriter);
        Poll.RenderControl(textWriter);
        Response.Write(stringwriter.ToString());
        Response.End();
    }
}
