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

public partial class bookSort : System.Web.UI.Page
{
    private BsBookInfo bookInfo = null;
    private int id = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            string strDbConn = ConfigurationManager.ConnectionStrings["shanzhaiConnectionString"].ToString();
            bookInfo = new BsBookInfo(strDbConn);

            //分类列表
            string classId = Request.QueryString["classID"];
            if(classId != null)
            {
                try
                {
                    id = Convert.ToInt32(classId);
                }
                catch (System.Exception ee)
                {
                    id = -1;
                }
            }

            DataSet ds = bookInfo.GetClassBooks(id);
            if(id != -1 && ds.Tables[0].Rows.Count != 0)
            {
                gvBookList.DataSource = ds;
                gvBookList.DataBind();
                //lblClassName.Text = bookInfo.GetClassName(id);
                Label lbl = (Label)gvBookList.HeaderRow.FindControl("lblClassName");
                lbl.Text = bookInfo.GetClassName(id);
            }
            else
            {
                gvBookList.DataSource = bookInfo.GetNewBooks(100);
                gvBookList.DataBind();
                //lblClassName.Text = "所有分类";
                Label lbl = (Label)gvBookList.HeaderRow.FindControl("lblClassName");
                lbl.Text = "所有分类";
            }
        }
    }
    protected void gvBookList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBookList.PageIndex = e.NewPageIndex;
        //string strDbConn = ConfigurationManager.AppSettings["dbConnString"];
        string strDbConn = ConfigurationManager.ConnectionStrings["shanzhaiConnectionString"].ToString();
        int id = -1;
        string classID = Request.QueryString["classID"];

        if (classID != null)
            id = Convert.ToInt32(classID);

        bookInfo = new BsBookInfo(strDbConn);

        if(id == -1)
        {
            gvBookList.DataSource = bookInfo.GetNewBooks(100);
            gvBookList.DataBind();
        }
        else
        {
            gvBookList.DataSource = bookInfo.GetClassBooks(id);
            gvBookList.DataBind();
        }
    }
}
