using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BsCtrl;

public partial class addTest : System.Web.UI.Page
{
    void Page_Load(Object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            String ConnectString = ConfigurationSettings.AppSettings["dbConnString"];

            SqlDataAdapter adapter = new SqlDataAdapter("select * from bookInfo", ConnectString);

            DataSet ds = new DataSet();

            adapter.Fill(ds);

            MyDataGrid.DataSource = ds;

            MyDataGrid.DataBind();

        }

    }

    //�����Ʒ

    public void OnItemCommand(Object sender, DataGridCommandEventArgs e)
    {

        if (e.CommandName == "AddToCart")
        {

            Stat_Class order = new Stat_Class(e.Item.Cells[0].Text);

            ShoppingCart cart = (ShoppingCart)Session["MyShoppingCart"]; //����ʵ��

            if (cart != null)

                cart.AddItem(order);

        }

    }

    //�鿴���ﳵ,ͨ��Response.Redirect()ת��View_ShoppingCart.aspxҳ��

    public void View_ShoppingCart(Object sender, EventArgs e)
    {

        Response.Redirect("CartView.aspx");

    }


}
