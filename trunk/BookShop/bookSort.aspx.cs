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

            //分类列表
            string classId = Request.QueryString["classID"];
            int id = -1;
            try
            {
                id = Convert.ToInt32(classId);
            }
            catch (System.Exception ee)
            {
            	id = -1;
            }
            if(id != -1)
            {
                gvBookList.DataSource = bookInfo.GetClassBooks(id);
                gvBookList.DataBind();
            }
        }
    }
}
