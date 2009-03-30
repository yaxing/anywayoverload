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
    String server = ConfigurationSettings.AppSettings["dbServer"];
    String userName = ConfigurationSettings.AppSettings["dbUserName"];
    String passWord = ConfigurationSettings.AppSettings["dbPassWord"];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.PageInfo_Load();
        }
    }
    protected void PageInfo_Load()
    {
        String bookNum = "1";
        BsBookInfo bookInfo = new BsBookInfo(server,userName,passWord);
        int bookID = Convert.ToInt32(bookNum);
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
    }
}
