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
    int totals = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        ShoppingCart cart = (ShoppingCart)Session["MyShoppingCart"]; //获取购物车

        if (cart != null)
        {

            GridView1.DataSource = cart.Orders;

            totals = cart.TotalRecords;

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

                totals = cart.TotalRecords;

                GridView1.DataBind();

                Total.Text = String.Format("合计:{0:c}", cart.TotalCost);

            }

        }

    }

    public void Gonoshopping(Object sender, EventArgs e)
    {

        Response.Redirect("index.aspx");

    }

    protected void Check_out(object sender, EventArgs e)
    {
        ShoppingCart cart = (ShoppingCart)Session["MyShoppingCart"]; //获取购物车
        
        if (Session["userName"] != null)
        {
            if(cart.TotalRecords != 0) Response.Redirect("BuyProduct.aspx");
            else ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert(\"请先购买商品！\");this.location.href='index.aspx'</script>");
        }
        else ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert(\"请先登陆！\");this.location.href='index.aspx'</script>");

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String index = Convert.ToString(e.CommandArgument);

        ShoppingCart cart = (ShoppingCart)Session["MyShoppingCart"];
        
        if(e.CommandName=="AddItemOne")
        {

            if (cart != null)
            {

                cart.ItemAddOne(Convert.ToString(index));

                totals = cart.TotalRecords;

                GridView1.DataBind();

                Total.Text = String.Format("合计:{0:c}", cart.TotalCost);

            }
        }
        else if (e.CommandName == "DelItemOne")
        {

            if (cart != null)
            {

                cart.ItemDelOne(Convert.ToString(index));

                totals = cart.TotalRecords;

                GridView1.DataBind();

                Total.Text = String.Format("合计:{0:c}", cart.TotalCost);

            }
        }
        else if (e.CommandName == "DelFromCart")
        {

            if (cart != null)
            {

                cart.DeleteItem(index);

                totals = cart.TotalRecords;

                GridView1.DataBind();

                Total.Text = String.Format("合计:{0:c}", cart.TotalCost);

            }

        }
        Response.Redirect("CartView.aspx");
    }

    //protected void PagerButton_Click(object sender, EventArgs e)
    //{
    //    int pageSize = 2;
    //    int pageIndx = Convert.ToInt32(CurrentPage.Value);
    //    int pages = (totals % pageSize) == 0 ? (totals / pageSize) : (totals / pageSize + 1);
    //    string arg = ((LinkButton)sender).CommandArgument.ToString().ToLower();
    //    switch (arg)
    //    {
    //        case "prev":
    //            if (pageIndx > 0)
    //            {
    //                pageIndx -= 1;
    //            }
    //            break;
    //        case "next":
    //            if (pageIndx < pages - 1)
    //            {
    //                pageIndx += 1;
    //            }
    //            break;
    //        case "last":
    //            pageIndx = pages - 1;
    //            break;
    //        default:
    //            pageIndx = 0;
    //            break;
    //    }
    //    CurrentPage.Value = pageIndx.ToString();
    //    GridView1.DataSource = ShoppingCart.GetCarts(pageIndx, pageSize);
    //    GridView1.DataBind();
    //}
 
}
