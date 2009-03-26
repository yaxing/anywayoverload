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

            GridView1.DataSource = cart.Orders;

            GridView1.DataBind();

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

                GridView1.DataBind();

                Total.Text = String.Format("合计:{0:c}", cart.TotalCost);

            }

        }

    }

    public void Gonoshopping(Object sender, EventArgs e)
    {

        Response.Redirect("addTest.aspx");

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String index = Convert.ToString(e.CommandArgument);
        
        if(e.CommandName=="AddItemOne")
        {
            ShoppingCart cart = (ShoppingCart)Session["MyShoppingCart"];

            if (cart != null)
            {

                cart.ItemAddOne(Convert.ToString(index));

                GridView1.DataBind();

                Total.Text = String.Format("合计:{0:c}", cart.TotalCost);

            }
        }
        else if (e.CommandName == "DelItemOne")
        {
            ShoppingCart cart = (ShoppingCart)Session["MyShoppingCart"];

            if (cart != null)
            {

                cart.ItemDelOne(Convert.ToString(index));

                GridView1.DataBind();

                Total.Text = String.Format("合计:{0:c}", cart.TotalCost);

            }
        }
        else if (e.CommandName == "DelFromCart")
        {

            ShoppingCart cart = (ShoppingCart)Session["MyShoppingCart"];

            if (cart != null)
            {

                cart.DeleteItem(index);

                GridView1.DataBind();

                Total.Text = String.Format("合计:{0:c}", cart.TotalCost);

            }

        }
    }
}
