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

public partial class CartView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ShoppingCart cart = (ShoppingCart)Session["MyShoppingCart"]; //创建实例

        if (cart != null)
        {

            MyDataGrid.DataSource = cart.Orders;

            MyDataGrid.DataBind();

            Total.Text = String.Format("合计:{0:c}", cart.TotalCost);

        }

    }

    public void OnItemCommand(Object sender, DataGridCommandEventArgs e)
    {

        if (e.CommandName == "DelFromCart")
        {

            ShoppingCart cart = (ShoppingCart)Session["MyShoppingCart"];

            if (cart != null)
            {

                cart.DeleteItem(e.Item.Cells[0].Text);

                MyDataGrid.DataBind();

                Total.Text = String.Format("合计:{0:c}", cart.TotalCost);

            }

        }

    }

    public void Gonoshopping(Object sender, EventArgs e)
    {

        Response.Redirect("addTest.aspx");

    }
}
