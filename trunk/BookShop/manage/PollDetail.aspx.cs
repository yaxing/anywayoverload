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

public partial class manage_PollDetail : System.Web.UI.Page
{
    DbConnector connStr = new DbConnector();
    String connection = ConfigurationManager.AppSettings["dbConnString"];
    String PollID = "";

    protected void BindData()
    {
        connStr.connDB(connection);
        string BindStr = "select poll.theme, pollDetail.id, pollDetail.optionName, pollDetail.counts from poll, pollDetail where pollDetail.pollID=poll.id and poll.id = " + PollID;
        DataSet BindDataSet = connStr.executeQuery(BindStr);
        PollDetail.DataSource = BindDataSet.Tables[0].DefaultView;
        PollDetail.DataBind();
        connStr.close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminN"] == null || Session["AdminLv"] == null)
        {
            Response.Redirect("../index.aspx");
        }
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
        //string QueryStr = "select * from pollDetail where pollID = " + PollID;
        string QueryStr = "select poll.theme, pollDetail.id, pollDetail.optionName, pollDetail.counts from poll, pollDetail where pollDetail.pollID=poll.id and poll.id = " + PollID;
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
            OutWord.Visible = false;
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
        //string pollDetailOption = ((TextBox)PollDetail.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
        TextBox pollDetailOption = (TextBox)this.PollDetail.Rows[e.RowIndex].Cells[3].FindControl("TextBox3") as TextBox;
        string UpdateStr = "update pollDetail set optionName = '" + pollDetailOption.Text + "' where id = " + id;
        int flag = connStr.executeUpdate(UpdateStr);
        if (flag == 0)
        {
            flag2.Text = "更新失败！";
        } 
        else
        {
            flag2.Text = "更新成功！";
            PollDetail.EditIndex = -1;
            BindData();
        }
        connStr.close();
    }
    protected void PollDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        PollDetail.PageIndex = e.NewPageIndex;
        BindData();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void OutWord_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.BufferOutput = true;
        Response.Charset = "GB2312";
        Response.AppendHeader("Content-Disposition", "attachment; filename = Filename.doc");
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        Response.ContentType = "application/ms-word";
        PollDetail.EnableViewState = false;
        System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("ZH-CN", true);
        System.IO.StringWriter stringwriter = new StringWriter(cultureInfo);
        System.Web.UI.HtmlTextWriter textWriter = new HtmlTextWriter(stringwriter);
        PollDetail.RenderControl(textWriter);
        Response.Write(stringwriter.ToString());
        Response.End();
    }
}
