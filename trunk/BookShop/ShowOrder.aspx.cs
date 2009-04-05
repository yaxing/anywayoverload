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
        if(!IsPostBack)
        {
            this.GridView1.Attributes.Add("SortExpression", "ID");
            this.GridView1.Attributes.Add("SortDirection", "ASC");
            BindToGridView();
        }
    }

    protected void BindToGridView()
    {
        BsOrder bs = new BsOrder();

        BsUserManager bm = new BsUserManager();

        if (Session["userName"] != null)
        {
            DataTable dt = new DataTable();
            String uN = Session["userName"].ToString();

            int userID = bm.findUser(uN);
            dt = bs.SelectOrders(userID);
            string SortDirection = this.GridView1.Attributes["SortDirection"].ToString();
            string SortExpression = this.GridView1.Attributes["SortExpression"].ToString();
            dt.DefaultView.Sort = string.Format("{0} {1}", SortExpression, SortDirection);
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
        }
        else
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert(\"请先登陆！\");this.location.href='index.aspx'</script>");
        }
        ResetKey();
        ShowPageIndex();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {   
        if(e.CommandName=="CancelOrder")
        {
            int index = Convert.ToInt32(e.CommandArgument);
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
                Response.Write("<script>alert('请先登陆!');</script>");
            }
        }
    }

    protected void ShowPageIndex()
    {
        Label lb = new Label();
        lb = (Label)this.GridView1.BottomPagerRow.Cells[0].FindControl("ShowPageLb");
        lb.Text = "第" + Convert.ToString(this.GridView1.PageIndex + 1) + "/" + this.GridView1.PageCount + "页";
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
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression != "")
        {
            if (GridView1.PageCount > 0)
            {
                //设定排序方向
                string SortDirection = "ASC";
                SortDirection = (this.GridView1.Attributes["SortDirection"].ToString() == SortDirection ? "DESC" : "ASC");
                this.GridView1.Attributes["SortExpression"] = e.SortExpression;
                this.GridView1.Attributes["SortDirection"] = SortDirection;
                //重新绑定数据
                BindToGridView();
            }
        }

    }
}
