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

public partial class dbTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DbConnector conn = new DbConnector();
        DataSet ds = null;
        int result;

//        Response.Write("testtest...");

        conn.connDB("localhost", "sa", "");
        result = conn.executeUpdate("insert into admin values( 'linsi', '43201', 'linsiran@163', 2)");
        ds = conn.executeQuery("select * from admin"); 
        result = conn.executeUpdate_id("insert into admin values( 'linsi', '43201', 'linsiran@163', 2)");
        Response.Write(result);

        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
}
