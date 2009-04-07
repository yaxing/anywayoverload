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

public partial class manage_orderManage : System.Web.UI.Page
{
    private orderManage orderManObj = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        //loginChk();                        //登陆判断
        if (!IsPostBack)
        {
            hfPageType.Value = "1";          //值为1，显示非历史订单
            lBtnPageType.Text = "历史订单";
            lBtnTran.Visible = true;
            hfUserName.Value = "";           //第一次加载页面，搜索关键字字段为空
            showContent(1);
        }
        
    }


    /*
     显示订单信息
     * 参数：flag，1表示第一次显示该内容；0，表示翻页
     */
    public void showContent(int flag)
    {
        string dbConnStr = ConfigurationManager.ConnectionStrings["shanzhaiConnectionString"].ToString(); // ConfigurationManager.AppSettings["dbConnString"];
        orderManObj = new orderManage(dbConnStr);
        if(hfPageType.Value.Equals("1"))
        {
            orderManObj.setSql("select * from v_orderManage where userName like '%" + hfUserName.Value + "%' order by orderdatetime desc");
        }
        else
        {
            orderManObj.setSql("select * from v_orderManage_done where userName like '%" + hfUserName.Value + "%' order by orderdatetime desc");
        }
        orderManObj.getDsRecord();
        orderManObj.initPages();            //设置页数
        lblPageAll.Text = orderManObj.getPageAmount() + "";     //显示总页数
        if (flag == 1)
        {
            lblPageNow.Text = orderManObj.getCurrentPage() + "";    //显示当前页数
        }
        else
        {
            orderManObj.setCurrentPage(Convert.ToInt32(lblPageNow.Text));   //获取页数，设置要显示的页数
        }

        if (lblPageAll.Text.Equals("0"))                            //设置翻页按钮的可见性
        {
            lBtnNextPage.Visible = false;
            lBtnPriPage.Visible = false;
        }
        else
        {
            lBtnNextPage.Visible = true;
            lBtnPriPage.Visible = true;
        }
        
        if (hfPageType.Value.Equals("1"))                       //显示订单记录
        {
            lblContent.Text = orderManObj.recordToShow(1);
        }
        else
        {
            lblContent.Text = orderManObj.recordToShow(0);
        }
    }

    /*
     点击上一页
     */
    protected void lBtnPriPage_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(lblPageNow.Text) > 1)
        {
            lblPageNow.Text = (Convert.ToInt32(lblPageNow.Text) - 1) + "";
        }
        showContent(0);
    }

    /*
     点击下一页
     */
    protected void lBtnNextPage_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(lblPageNow.Text) < Convert.ToInt32(lblPageAll.Text))
        {
            lblPageNow.Text = (Convert.ToInt32(lblPageNow.Text) + 1) + "";
        }
        showContent(0);
    }

    /*
     搜索按钮点击事件
     */
    protected void lBtnSearch_Click(object sender, EventArgs e)
    {
        String userName = tBoxUserName.Text;
        userName=userName.Replace("'", "‘");
        userName=userName.Replace("\\", "、");
        hfUserName.Value = userName;
        showContent(1);
    }

    /*
     *登陆判断
     */
    public void loginChk()
    {
        if (Session["AdminN"] == null || Session["AdminLv"] == null)
        {
            Response.Redirect("adminLogin.html");
        }
    }

    /*
     点击连接按钮
     */
    protected void lBtnPageType_Click(object sender, EventArgs e)
    {
        if (hfPageType.Value.Equals("1"))   //
        {
            hfPageType.Value = "0";
            lBtnPageType.Text = "订单管理";
            lBtnTran.Visible = false;
        }
        else
        {
            hfPageType.Value = "1";
            lBtnPageType.Text = "历史订单";
            lBtnTran.Visible = true;
        }

        showContent(1);
    }

    /*
     一完成交易处理
     */
    protected void lBtnTran_Click(object sender, EventArgs e)
    {
        string dbConnStr = ConfigurationManager.ConnectionStrings["shanzhaiConnectionString"].ToString();
        orderManObj = new orderManage(dbConnStr);
        orderManObj.setSql("exec pro_deal_orders");
        orderManObj.executeSql();
        showContent(1);
    }
}
