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
        //loginChk();                        //��½�ж�
        if (!IsPostBack)
        {
            hfPageType.Value = "1";          //ֵΪ1����ʾ����ʷ����
            lBtnPageType.Text = "��ʷ����";
            lBtnTran.Visible = true;
            hfUserName.Value = "";           //��һ�μ���ҳ�棬�����ؼ����ֶ�Ϊ��
            showContent(1);
        }
        
    }


    /*
     ��ʾ������Ϣ
     * ������flag��1��ʾ��һ����ʾ�����ݣ�0����ʾ��ҳ
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
        orderManObj.initPages();            //����ҳ��
        lblPageAll.Text = orderManObj.getPageAmount() + "";     //��ʾ��ҳ��
        if (flag == 1)
        {
            lblPageNow.Text = orderManObj.getCurrentPage() + "";    //��ʾ��ǰҳ��
        }
        else
        {
            orderManObj.setCurrentPage(Convert.ToInt32(lblPageNow.Text));   //��ȡҳ��������Ҫ��ʾ��ҳ��
        }

        if (lblPageAll.Text.Equals("0"))                            //���÷�ҳ��ť�Ŀɼ���
        {
            lBtnNextPage.Visible = false;
            lBtnPriPage.Visible = false;
        }
        else
        {
            lBtnNextPage.Visible = true;
            lBtnPriPage.Visible = true;
        }
        
        if (hfPageType.Value.Equals("1"))                       //��ʾ������¼
        {
            lblContent.Text = orderManObj.recordToShow(1);
        }
        else
        {
            lblContent.Text = orderManObj.recordToShow(0);
        }
    }

    /*
     �����һҳ
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
     �����һҳ
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
     ������ť����¼�
     */
    protected void lBtnSearch_Click(object sender, EventArgs e)
    {
        String userName = tBoxUserName.Text;
        userName=userName.Replace("'", "��");
        userName=userName.Replace("\\", "��");
        hfUserName.Value = userName;
        showContent(1);
    }

    /*
     *��½�ж�
     */
    public void loginChk()
    {
        if (Session["AdminN"] == null || Session["AdminLv"] == null)
        {
            Response.Redirect("adminLogin.html");
        }
    }

    /*
     ������Ӱ�ť
     */
    protected void lBtnPageType_Click(object sender, EventArgs e)
    {
        if (hfPageType.Value.Equals("1"))   //
        {
            hfPageType.Value = "0";
            lBtnPageType.Text = "��������";
            lBtnTran.Visible = false;
        }
        else
        {
            hfPageType.Value = "1";
            lBtnPageType.Text = "��ʷ����";
            lBtnTran.Visible = true;
        }

        showContent(1);
    }

    /*
     һ��ɽ��״���
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
