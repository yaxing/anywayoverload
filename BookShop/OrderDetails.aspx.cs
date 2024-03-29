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
using System.Configuration;
using BsCtrl;

public partial class OrderDetails : System.Web.UI.Page
{
    string Order_ID = "";
    String strDbConn = ConfigurationManager.ConnectionStrings["shanzhaiConnectionString"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        BsOrder bs = new BsOrder(strDbConn);
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        Double total = 0;
        String Book_Name;
        
        Order_ID = Request.QueryString["OrderID"].ToString();
        dt = bs.ShowOrderDetails(Convert.ToInt32(Order_ID));
        dt2 = bs.ShowOrderInfo(Convert.ToInt32(Order_ID));
        this.OrderDetailsView.DataSource = dt;

        foreach(DataRow dr in dt.Rows)
        {
            total += Convert.ToDouble(dr["price"])*Convert.ToDouble(dr["discount"])*Convert.ToInt32(dr["number"]);
        }

        this.lblAmountFinish.Text = String.Format("��{0:c}", Convert.ToString(total));
        this.OrderDetailsView.DataBind();

        this.lblAddress.Text = dt2.Rows[0]["address"].ToString();
        this.lblMobile.Text = dt2.Rows[0]["tel"].ToString();
        this.lblOrderDate.Text = dt2.Rows[0]["orderdatetime"].ToString();
        String Status = BsOrder.ShowOrderStatus(Convert.ToInt32(dt2.Rows[0]["pay"].ToString()));
        this.lblStatus.Text = Status;
    }
}
