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
    
    protected void Page_Load(object sender, EventArgs e)
    {
        BsOrder bs = new BsOrder();
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
            total += Convert.ToDouble(dr["price"])*Convert.ToDouble(dr["discount"]);
        }

        this.lblAmountFinish.Text = String.Format("гд{0:c}", Convert.ToString(total));
        this.OrderDetailsView.DataBind();

        this.lblMobile.Text = dt2.Rows[0]["tel"].ToString();
        this.lblOrderDate.Text = dt2.Rows[0]["orderdatetime"].ToString();
        this.lblStatus.Text = dt2.Rows[0]["pay"].ToString();
    }
}
