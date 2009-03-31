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

public partial class ShowOrder : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        BsOrder bs = new BsOrder();

        BsUserManager bm = new BsUserManager();

        if (Session["userName"] != null)
        {
            String uN = Session["userName"].ToString();
            
            int userID = bm.findUser(uN);

            this.GridView1.DataSource = bs.SelectOrders(userID);

            this.GridView1.DataBind();
        }
        else
        {
            Response.Redirect("index.aspx");
            Response.Write("<script>alert('ÇëÏÈµÇÂ½!');</script>");
        }
    }
}
