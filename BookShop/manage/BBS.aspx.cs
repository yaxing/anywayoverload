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
    String strConn = ConfigurationManager.AppSettings["dbConnString"];

    protected void BindData()
    {
        connStr.connDB(strConn);
        String BindDataStr = "select * from bbs";
        DataSet BindDataSet = connStr.executeQuery(BindDataStr);
        BBS.DataSource = BindDataSet.Tables[0].DefaultView;
        BBS.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Tittle.Text = "";
        Updates.Text = "";
        String QueryString = "select * from bbs";
        connStr.connDB(strConn);
        DataSet Result = connStr.executeQuery(QueryString);
        if (Result.Tables[0].Rows.Count == 0)
        {
            Tittle.Text = "暂时没有公告！";
        } 
        else
        {
            Tittle.Text = "公告内容如下：";
            BBS.DataSource = Result.Tables[0].DefaultView;
            BBS.DataBind();
        }
        connStr.close();
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
        string bbs_content = ((TextBox)BBS.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
        string bbs_postTime = ((TextBox)BBS.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
        string QueryStr = "select id from bbs where id = " + id;
        DataSet ResultDataset = connStr.executeQuery(QueryStr);
        if (ResultDataset.Tables[0].Rows.Count > 1)
        {
            Updates.Text = "序号不能重复！";
        } 
        else
        {
            string UpdataString = "update bbs set content = '" + bbs_content + "', postTime = '" + bbs_postTime + "' where ID = " + id;
            int ResultFlags = connStr.executeUpdate(UpdataString);
            if (ResultFlags == 0)
            {
                Updates.Text = "更新失败！";
            } 
            else
            {
                Updates.Text = "更新成功！";
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
        String DelStr = "delete * from bbs";
        connStr.connDB(strConn);
        connStr.executeUpdate(DelStr);
        connStr.close();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void WordOut_Click(object sender, EventArgs e)
    {
        //string QueryStr = "select * from bbs";
        //connStr.connDB(strConn);
        //DataSet WordResult = connStr.executeQuery(QueryStr);
        //connStr.close();
        //DataTable dataTable1 = WordResult.Tables[0];
        //Response.Clear();
        //Response.Buffer = true;
        //Response.ContentType = "web/vnd.ms-word";
        //Response.ContentEncoding = System.Text.Encoding.UTF8;
        //Response.Charset = "Word文档";
        //this.EnableViewState = false;
        //StringWriter oStringWriter = new StringWriter();
        //HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);
        //GridView gv = new GridView();
        //gv.DataSource = dataTable1;
        //gv.DataBind();
        ////Response.Clear();
        ////Response.BufferOutput = true;
        ////Response.Charset = "GB2312";
        ////Response.AppendHeader("Content-Disposition", "attachment; filename = FileName.doc");
        ////Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
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
