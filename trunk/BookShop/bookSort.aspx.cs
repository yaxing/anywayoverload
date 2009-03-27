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
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            string strDbConn = ConfigurationManager.AppSettings["dbConnString"];
            bookInfo = new BsBookInfo(strDbConn);

            //�����б�
            string classId = Request.QueryString["classID"];
            int id = -1;
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
                lblClassName.Text = bookInfo.GetClassName(id);
            }
            else
            {
                gvBookList.DataSource = bookInfo.GetNewBooks(100);
                gvBookList.DataBind();
                lblClassName.Text = "���з���";
            }
        }
    }
}
