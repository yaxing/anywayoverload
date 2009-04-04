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

public partial class ShowOrder : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        BindToGridView();
    }

    protected void BindToGridView()
    {
        BsOrder bs = new BsOrder();

        BsUserManager bm = new BsUserManager();

        if (Session["userName"] != null)
        {
            String uN = Session["userName"].ToString();

            int userID = bm.findUser(uN);

            this.GridView1.DataSource = bs.SelectOrders(userID);

            this.GridView1.DataBind();
        }
        else
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert(\"ÇëÏÈµÇÂ½£¡\");this.location.href='index.aspx'</script>");
        }
        ResetKey();
        ShowPageIndex();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        
        if(e.CommandName=="CancelOrder")
        {
            BsOrder bs = new BsOrder();
            BsUserManager bm = new BsUserManager();
            bs.CancelOrder(index);
            if (Session["userName"] != null)
            {
                String uN = Session["userName"].ToString();

                int userID = bm.findUser(uN);

                this.GridView1.DataSource = bs.SelectOrders(userID);

                this.GridView1.DataBind();
            }
            else
            {
                Response.Redirect("index.aspx");
                Response.Write("<script>alert('ÇëÏÈµÇÂ½!');</script>");
            }
        }
    }

    protected void ShowPageIndex()
    {
        Label lb = new Label();
        lb = (Label)this.GridView1.BottomPagerRow.Cells[0].FindControl("ShowPageLb");
        lb.Text = "µÚ" + Convert.ToString(this.GridView1.PageIndex + 1) + "/" + this.GridView1.PageCount + "Ò³";
    }

    protected void ResetKey()
    {
        LinkButton lk = new LinkButton();
        if (GridView1.PageIndex == 0)
        {
            lk = (LinkButton)this.GridView1.BottomPagerRow.Cells[0].FindControl("PreviousBt");
            lk.Enabled = false;
        }
        if (GridView1.PageIndex == GridView1.PageCount- 1)
        {
            lk = (LinkButton)this.GridView1.BottomPagerRow.Cells[0].FindControl("NextBt");
            lk.Enabled = false;
        }
    }

    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {
        string direction = ((LinkButton)sender).CommandName.ToString();

        switch(direction)
        {
            case "First":
                this.GridView1.PageIndex = 0;
                break;
            case "Previous":
                if(this.GridView1.PageIndex>0)
                {
                    GridView1.PageIndex -= 1;
                }
                break;
            case "Next":
                if(this.GridView1.PageIndex<this.GridView1.PageCount-1)
                {
                    GridView1.PageIndex += 1;
                }
                break;
            case "End":
                this.GridView1.PageIndex = this.GridView1.PageCount - 1;
                break;
            default:
                break;
        }
        BindToGridView();
    }
}
