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

public partial class BuyProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShoppingCart cart = (ShoppingCart)Session["MyShoppingCart"]; //获取购物车
            BsUserManager bm = new BsUserManager();
            BsOrder bo = new BsOrder();
            DataTable dt = new DataTable();

            if (cart != null)
            {

                GridView1.DataSource = cart.Orders;

                GridView1.DataBind();

                Total.Text = String.Format("{0:n2}", cart.TotalCost);

                this.txtName.Text = "";

                this.txtAddress.Text = "";

                this.txtEmail.Text = "";

                this.txtMobile.Text = "";

                this.txtPost.Text = "";
            }

            if (Session["userName"] != null)
            {
                int userID = bm.findUser(Convert.ToString(Session["userName"]));
                this.HiddenField1.Value = Convert.ToString(userID);
                dt = bo.ShowUserInfo(userID);
                this.txtName.Text = dt.Rows[0]["TrueName"].ToString();
                this.txtAddress.Text = dt.Rows[0]["address"].ToString();
                this.txtEmail.Text = dt.Rows[0]["email"].ToString();
                if (dt.Rows[0]["tel"] != null) this.txtMobile.Text = dt.Rows[0]["tel"].ToString();
                if (dt.Rows[0]["postcode"] != null) this.txtPost.Text = dt.Rows[0]["postcode"].ToString();
            }

            else ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert(\"请先登陆！\");this.location.href='index.aspx'</script>");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.Panel1.Visible = false;
        this.Panel2.Visible = true;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        BsOrder bo = new BsOrder();
        ShoppingCart cart = (ShoppingCart)Session["MyShoppingCart"]; //获取购物车

        String user_ID = this.HiddenField1.Value;
        String user_Name = this.txtName.Text.Trim();
        String user_Amount = this.Total.Text.Trim();
        String user_Address = this.txtAddress.Text.Trim();
        String user_Email = this.txtEmail.Text.Trim();
        String user_Tel = this.txtMobile.Text.Trim();
        String user_Post = this.txtPost.Text.Trim();
        String user_Deal = Convert.ToString(this.DropDownList1.SelectedValue);
        
        int OrderID = bo.AddOrder(user_ID, user_Name, user_Amount, user_Address, user_Email, user_Tel, user_Post, user_Deal);
        if (cart.AddToOrder(OrderID) == true)
        {
            cart.ClearCart();
            ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert(\"订单创建成功！\");this.location.href='ShowOrder.aspx'</script>");
        }

        else ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert(\"数据库出现异常，订单创建失败！\");this.location.href='BuyProduct.aspx'</script>");
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.Panel1.Visible = true;
        this.Panel2.Visible = false;
    }
}
