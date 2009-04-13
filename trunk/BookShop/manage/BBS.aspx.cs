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
using System.Data.SqlClient;
using System.IO;

public partial class manage_BBS : System.Web.UI.Page
{
    DbConnector connStr = new DbConnector();
    String strConn = ConfigurationManager.ConnectionStrings["shanzhaiConnectionString"].ToString();

    protected void BindData()
    {
        connStr.connDB(strConn);
        String BindDataStr = "select * from bbs order by postTime DESC";
        DataSet BindDataSet = connStr.executeQuery(BindDataStr);
        BBS.DataSource = BindDataSet.Tables[0].DefaultView;
        BBS.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminN"] == null || Session["AdminLv"] == null)
        {
            Response.Redirect("../index.aspx");
        }
        if (!IsPostBack)
        {
            DataBind();
        }
        DeleteAll.Attributes.Add("onclick", "return confirm('真的要删除所有的公告吗?');");
        Tittle.Text = "";
        Updates.Text = "";
        String QueryString = "select * from bbs order by postTime DESC";
        connStr.connDB(strConn);
        DataSet Result = connStr.executeQuery(QueryString);
        if (Result.Tables[0].Rows.Count == 0)
        {
            Tittle.Text = "暂时没有公告！";
            DeleteAll.Visible = false;
            WordOut.Visible = false;
        } 
        else
        {
            Tittle.Text = "公告内容如下：";
            BBS.DataSource = Result.Tables[0].DefaultView;
            BBS.DataBind();
        }
        connStr.close();

        //BBS.Attributes.Add("style", "word-break:keep-all;word-wrap:normal");
        BBS.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");

    }
    protected void Reset_Click(object sender, EventArgs e)
    {
        BBSContent.Text = "";
    }
    protected void Save_Click(object sender, EventArgs e)
    {
        connStr.connDB(strConn);
        DateTime d = DateTime.Now;
        String insertStr = "insert into bbs (content, postTime) values('" + BBSContent.Text + "', '" + d + "')";
        int ResultFlags = connStr.executeUpdate(insertStr);
        if (ResultFlags == 0)
        {
            InsertFlags.Text = "添加失败！";
        } 
        else
        {
            InsertFlags.Text = "添加成功！";
        }
        connStr.close();
        Response.Redirect(Request.Url.ToString());
    }
    protected void BBS_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        connStr.connDB(strConn);
        string id = this.BBS.DataKeys[e.RowIndex]["ID"].ToString();
        string delCmd = "delete from bbs where id = " + id;
        int flags = connStr.executeUpdate(delCmd);
        if (flags == 0)
        {
            UpdateFlags.Text = "删除失败！";
        } 
        else
        {
            UpdateFlags.Text = "删除成功！";
        }
        connStr.close();
        Response.Redirect(Request.Url.ToString());
    }
    protected void BBS_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.BBS.EditIndex = e.NewEditIndex;
        BindData();
    }
    protected void BBS_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        connStr.connDB(strConn);
        string id = BBS.DataKeys[e.RowIndex].Values[0].ToString();
        TextBox bbs_content = (TextBox)this.BBS.Rows[e.RowIndex].Cells[2].FindControl("TextBox2") as TextBox;
        if (bbs_content != null)
        {
            string UpdataString = "update bbs set content = '" + bbs_content.Text + "' where ID = " + id;
            int ResultFlags = connStr.executeUpdate(UpdataString);
            if (ResultFlags == 0)
            {
                Updates.Text = "更新失败！";
            }
            else
            {
                Updates.Text = "更新成功！";
                BBS.EditIndex = -1;
                BindData();
            }
        }
        connStr.close();
    }
    protected void BBS_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        BBS.EditIndex = -1;
        BindData();
    }
    protected void BBS_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BBS.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void DeleteAll_Click(object sender, EventArgs e)
    {
        String DelStr = "delete from bbs";
        connStr.connDB(strConn);
        connStr.executeUpdate(DelStr);
        connStr.close();
        Response.Redirect(Request.Url.ToString());
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void WordOut_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.BufferOutput = true;
        Response.Charset = "GB2312";
        Response.AppendHeader("Content-Disposition", "attachment; filename = Filename.doc");
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        Response.ContentType = "application/ms-word";
        BBS.EnableViewState = false;
        System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("ZH-CN", true);
        System.IO.StringWriter stringwriter = new StringWriter(cultureInfo);
        System.Web.UI.HtmlTextWriter textWriter = new HtmlTextWriter(stringwriter);
        BBS.RenderControl(textWriter);
        Response.Write(stringwriter.ToString());
        Response.End();
    }
}
