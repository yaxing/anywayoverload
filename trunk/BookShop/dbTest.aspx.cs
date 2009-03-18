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
using System.Configuration; 

public partial class dbTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DbConnector conn = new DbConnector();
        DataSet ds = null;
        int result;


        //运用全局变量dbServer、dbUserName、dbPassWord，要链接数据库就按照这个来-------------
        //如果要修改全局变量值的话就在Web.Config里面的<appSettings>改
        string server = ConfigurationSettings.AppSettings["dbServer"];
        string userName = ConfigurationSettings.AppSettings["dbUserName"];
        string passWord = ConfigurationSettings.AppSettings["dbPassWord"]; 
        conn.connDB(server, userName, passWord);
        //-----------------------------------------------------------------------------------

        result = conn.executeUpdate("insert into admin values( 'linsi', '43201', 'linsiran@163', 2)");
        ds = conn.executeQuery("select * from admin"); 
        result = conn.executeUpdate_id("insert into admin values( 'linsi', '43201', 'linsiran@163', 2)");
        Response.Write(result);

        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
}
