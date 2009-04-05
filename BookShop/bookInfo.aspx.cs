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

public partial class _Default : System.Web.UI.Page
{
    String strDbConn = ConfigurationManager.ConnectionStrings["shanzhaiConnectionString"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["bookID"] != null) this.PageInfo_Load();
            else
            {
                Response.Write("<script language='javascript'>alert('错误的书籍索引值');location.href('index.aspx')</script>");
            }
        }
        //this.PageInfo_Load();
    }
    protected void PageInfo_Load()
    {
        //String bookNum = "2";
        //int bookID = Convert.ToInt32(bookNum);

        int bookID = Convert.ToInt32(Request.QueryString["bookID"]);
        BsBookInfo bookInfo = bookInfo = new BsBookInfo(strDbConn);
        DataSet ds = new DataSet();
        ds = bookInfo.GetBookInfo(bookID);
        this.lblBookName.Text = ds.Tables[0].Rows[0][6].ToString();
        this.lblBookType.Text = ds.Tables[0].Rows[0][1].ToString();
        this.lblAuthor.Text = ds.Tables[0].Rows[0][8].ToString();
        this.lblPub.Text = ds.Tables[0].Rows[0][7].ToString();
        String pubDate = ds.Tables[0].Rows[0][11].ToString();
        int dateIndex = pubDate.LastIndexOf(" ");
        this.lblPubDate.Text = pubDate.Substring(0, dateIndex);
        this.lblISBN.Text = ds.Tables[0].Rows[0][4].ToString();
        String price = ds.Tables[0].Rows[0][10].ToString();
        int priceIndex = price.LastIndexOf(".");
        this.lblPrice.Text = price.Substring(0, priceIndex + 3);
        this.lblQuantity.Text = ds.Tables[0].Rows[0][14].ToString();
        this.lblSold.Text = ds.Tables[0].Rows[0][15].ToString();
        this.coverImg.Src = ds.Tables[0].Rows[0][13].ToString();
        this.coverImgP.Src = ds.Tables[0].Rows[0][13].ToString();
        this.ltlScript.Text = ds.Tables[0].Rows[0][9].ToString();
    }
    protected void AddtoCartBt_Click(object sender, ImageClickEventArgs e)
    {
        Stat_Class order = new Stat_Class(Request.QueryString["bookID"]);

        ShoppingCart cart = (ShoppingCart)Session["MyShoppingCart"]; //创建实例

        if (cart != null)
        {
            cart.AddItem(order);
            Response.Redirect("CartView.aspx");
        }
    }
}
