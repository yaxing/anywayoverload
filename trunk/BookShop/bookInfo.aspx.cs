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
            if (Request["bookID"] != null)
            {
                this.PageInfo_Load();
            }
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
        BsBookInfo bookInfo = new BsBookInfo(strDbConn);
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
        Double priceM = Convert.ToDouble(price);
        Double discount = Convert.ToDouble(ds.Tables[0].Rows[0][19]);
        Double priceN = priceM * discount;
        discount = discount * 10;
        String priceNow = priceN.ToString();
        int priceIndex = price.LastIndexOf(".");

        this.lblPrice.Text = price.Substring(0, priceIndex + 3);

        priceIndex = priceNow.LastIndexOf(".");
        if (discount < 10.0)
            this.lblDis.Text = discount.ToString() + "折";
        else
            this.lblDis.Text = "无折扣";
        if(priceIndex > 0)
        {
            if (priceNow.Length >= priceIndex + 3)
            {
                this.lblPriceN.Text = priceNow.Substring(0, priceIndex + 3);
            }
            else
                this.lblPriceN.Text = priceNow + "0";
        }
        else
        {
            this.lblPriceN.Text = priceNow + ".00";
        }
        this.lblQuantity.Text = ds.Tables[0].Rows[0][14].ToString();
        this.lblSold.Text = ds.Tables[0].Rows[0][15].ToString();

        Double Goods = Convert.ToDouble(ds.Tables[0].Rows[0][16]);
        Double Normals = Convert.ToDouble(ds.Tables[0].Rows[0][17]);
        Double Bads = Convert.ToDouble(ds.Tables[0].Rows[0][18]);

        int GoodsP = 0;
        int NormalsP = 0;
        int BadsP = 0;
        if ((Goods + Normals + Bads) > 0)
        {
            GoodsP = Convert.ToInt32(Goods / (Goods + Normals + Bads) * 100);
            NormalsP = Convert.ToInt32(Normals / (Goods + Normals + Bads) * 100);
            BadsP = Convert.ToInt32(Bads / (Goods + Normals + Bads) * 100);
        }

        this.lblCommentAcount.Text = Convert.ToString(Convert.ToInt32(Goods+Normals+Bads));

        this.lblGood.Text = ds.Tables[0].Rows[0][16].ToString() + "(" + GoodsP.ToString() + "%)";
        this.lblNormal.Text = ds.Tables[0].Rows[0][17].ToString() + "(" + NormalsP.ToString() + "%)";
        this.lblbad.Text = ds.Tables[0].Rows[0][18].ToString() + "(" + BadsP.ToString() + "%)";

        this.ImageGood.Width = GoodsP;
        this.ImageMid.Width = NormalsP;
        this.ImageBad.Width = BadsP;

        this.coverImg.Src = ds.Tables[0].Rows[0][13].ToString();
        this.coverImgP.Src = ds.Tables[0].Rows[0][13].ToString();
        this.ltlScript.Text = ds.Tables[0].Rows[0][9].ToString();
        this.rpRank.DataSource = bookInfo.GetHotBooks(5);
        this.rpRank.DataBind();
        this.CommentGridView_Load(bookID);
        if (Session["userName"] != null)
        {
            this.PanelComment.Visible = true;
        }
        else this.PanelComment.Visible = false;
    }

    protected void CommentGridView_Load(int bookID)
    {
        BsBookInfo comment = new BsBookInfo(strDbConn);
        DataSet ds = new DataSet();
        ds = comment.GetOneComment(bookID);
        if (ds == null)
        {
            return;
        }
        if (ds.Tables[0].Rows.Count == 0)
        {
            this.lblNull.Text = "目前尚无用户对本书进行评论";
            this.lblNull.Visible = true;
        }
        this.CommentGridView.DataSource = ds;
        this.CommentGridView.DataBind();
    }
    
    protected void AddtoCartBt_Click1(object sender, ImageClickEventArgs e)
    {
        Stat_Class order = new Stat_Class(Request.QueryString["bookID"],strDbConn);

        ShoppingCart cart = (ShoppingCart)Session["MyShoppingCart"]; //创建实例

        if (cart != null)
        {
            if (this.TxtQuan.Text != null && this.TxtQuan.Text != "")
            {
                int iQuan = 0;
                try
                {
                    iQuan = Convert.ToInt32(this.TxtQuan.Text);
                }catch(FormatException ex)
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert(\"数量不正确！\");</script>");
                }
                if(iQuan > 0)
                  order.Quantity = iQuan;
              else { ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert(\"数量不正确！\");</script>"); }
            }
            else order.Quantity = 1;
            if(cart.AddItem(order) == false)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert(\"库存量不够！\");</script>");
                return;
            }
            Response.Redirect("CartView.aspx");
        }
    }
    protected void BtnComment_Click(object sender, EventArgs e)
    {
        int Score = Convert.ToInt32(this.RBLScore.SelectedValue);
        String CommentText = this.TxtComment.Text;

        CommentText = CommentText.Replace("\r\n", "<br/>");

        String userName = Session["userName"].ToString();
        int bookID = Convert.ToInt32(Request.QueryString["bookID"]);

        BsBookInfo commentContrl = new BsBookInfo(strDbConn);
        if (commentContrl.AddOneComment(bookID, userName, CommentText, Score))
        {
            this.PageInfo_Load();
            this.lblStates.Text = "评论成功！";
            this.lblStates.Visible = true;
        }
        else
        {
            this.lblStates.Text = "评论添加失败！请稍候再试。";
            this.lblStates.Visible = true;
        }
    }
    protected void CommentGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.CommentGridView.PageIndex = e.NewPageIndex;
        int bookID = Convert.ToInt32(Request.QueryString["bookID"]);
        this.CommentGridView_Load(bookID);
    }
}
