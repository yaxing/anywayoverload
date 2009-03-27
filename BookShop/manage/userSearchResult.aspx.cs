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


public partial class manage_userSearchResultaspx : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
            LoadData();

            //位置在下的“返回查询”按钮可见
            LinkButton LB_search = (LinkButton)Panel2.FindControl("LB_search");
            LB_search.Visible = false;

        //如果当前没有数据，则“全选”“全不选”“删除”按钮消失
        if (GV1.Rows.Count == 0)
        {   //查询结果为空

            //“全选”按钮不可见
            Button Bt_all = (Button)Panel2.FindControl("Bt_all");
            Bt_all.Visible = false;

            //“全不选”按钮不可见
            Button Bt_allnot = (Button)Panel2.FindControl("Bt_allnot");
            Bt_allnot.Visible = false;

            //“修改”按钮不可见
            Button Bt_del = (Button)Panel2.FindControl("Bt_del");
            Bt_del.Visible = false;
            //位置在上的“返回查询”按钮不可见
            Button Bt_search = (Button)Panel2.FindControl("Bt_search");
            Bt_search.Visible = false;

            //位置在下的“返回查询”按钮可见
            LB_search.Visible = true;



            Lb_ret.Text = "没有符合条件的用户信息";

        }

    }
    protected void LoadData()
    {

        //获得userManage页面传递过来的参数
        String str = Request.QueryString["str"];

        //运用全局变量dbServer、dbUserName、dbPassWord，要链接数据库就按照这个来-------------
        //如果要修改全局变量值的话就在Web.Config里面的<appSettings>改
        string server = ConfigurationSettings.AppSettings["dbServer"];
        string userName = ConfigurationSettings.AppSettings["dbUserName"];
        string passWord = ConfigurationSettings.AppSettings["dbPassWord"];

        //实例化BsUserManager
        BsUserManager Admin = new BsUserManager(server, userName, passWord);
        DataSet ds = Admin.searchUser(str);

        //绑定数据源s
        GV1.DataSource = ds;
        GV1.DataBind();
    }


    /*
    //当改变页次时，将启动ChangePage事件程序
    public void ChangePage(object sender, DataGridPageChangedEventArgs e)
    {
        int test;

    }
     */



    //当点击“返回查询” 时，返回查询页面userManage.aspx
    protected void Bt_search_Click(object sender, EventArgs e)
    {
        Response.Redirect("userManage.aspx");
    }


     /*全选
      功能：选中所有用户
      */
    protected void Bt_all_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GV1.Rows.Count; i++)
        {

            if (GV1.Rows[i].RowType == DataControlRowType.DataRow)
            {    //判断当前是否为数据行
                CheckBox cb;
                cb = (CheckBox)GV1.Rows[i].FindControl("CB_del");
                cb.Checked = true;
            }
        }
    }



    /*全不选
   功能：不选所用户  */
    protected void Bt_allnot_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GV1.Rows.Count; i++)
        {
            if (GV1.Rows[i].RowType == DataControlRowType.DataRow)
            {    //判断当前是否为数据行
                CheckBox cb;
                cb = (CheckBox)GV1.Rows[i].FindControl("CB_del");
                cb.Checked = false;
            }
        }

    }

    //编辑某一行
    protected void GV1_RowEdit(object sender, GridViewEditEventArgs e)
    {
        GV1.EditIndex = e.NewEditIndex;
        LoadData();
    }

    //取消编辑  
    protected void GV1_CancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GV1.EditIndex = -1;         //退出编辑模式
        LoadData();
    }

   
    //提交编辑数据，更新
    protected void GV1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BsUserManager admin1 = new BsUserManager("localhost", "sa", ".");     //实例化BsUserManager

        int RowEditIndex = GV1.EditIndex;
        if (GV1.Rows[RowEditIndex].RowType == DataControlRowType.DataRow)
        {    //判断当前是否为数据行

            //获取管理员更改的用户信息
            string strID = ((Label)GV1.Rows[RowEditIndex].FindControl("Lb_id")).Text;     //用户ID
            int id = Convert.ToInt32(strID);    //将ID转换成int型
            String userName = ((Label)GV1.Rows[RowEditIndex].FindControl("Lb_name")).Text;       //用户名
            String password = ((TextBox)GV1.Rows[RowEditIndex].FindControl("TB_pwd")).Text.Trim();  //用户密码
            String tel = ((TextBox)GV1.Rows[RowEditIndex].FindControl("TB_tel")).Text.Trim();    //tel
            String email = ((TextBox)GV1.Rows[RowEditIndex].FindControl("TB_email")).Text.Trim();    //email
            String strgrade = ((TextBox)GV1.Rows[RowEditIndex].FindControl("TB_grade")).Text.Trim();  //用户等级grade
            int grade = Convert.ToInt32(strgrade);

            //执行更新操作
            admin1.updateUser(id, userName, password, tel, email, grade);       //更新用户

            //退出编辑模式，显示更新后的页面
            GV1.EditIndex = -1;
            LoadData();
            Lb_ret.Text = "操作成功";   //提示成功
        }
    }

    //执行删除操作
    protected void Bt_del_Click(object sender, EventArgs e)
    {
        BsUserManager admin1 = new BsUserManager("localhost", "sa", ".");     //实例化BsUserManager
        bool del_no = true; // 标记执行删除前是否选择了1个以上用户。为true说明没有选择用户，提示错误 

        for (int i = 0; i < GV1.Rows.Count; i++) {      //删除选中的用户
            string strID = ((Label)GV1.Rows[i].FindControl("Label_id")).Text;     //用户ID
            int id = Convert.ToInt32(strID);    //将ID转换成int型
            CheckBox del = ((CheckBox)GV1.Rows[i].FindControl("CB_del"));    //del记录是否被选中要删除
            
            if (del.Checked)   //如果删除复选框被选中
                {

                    admin1.deleteUser(id);  //删除用户
                    del_no = false; 
                }
        }

        LoadData(); //显示更新后的页面
        if (del_no == false)
        {
            Lb_ret.Text = "删除操作成功";   //选择1个以上用户删除，提示成功

            //如果当前没有数据，则“全选”“全不选”“删除”按钮消失
            if (GV1.Rows.Count == 0)
            {   //查询结果为空

                //“全选”按钮不可见
                Button Bt_all = (Button)Panel2.FindControl("Bt_all");
                Bt_all.Visible = false;

                //“全不选”按钮不可见
                Button Bt_allnot = (Button)Panel2.FindControl("Bt_allnot");
                Bt_allnot.Visible = false;

                //“修改”按钮不可见
                Button Bt_del = (Button)Panel2.FindControl("Bt_del");
                Bt_del.Visible = false;

                //位置在上的“返回查询”按钮不可见
                Button Bt_search = (Button)Panel2.FindControl("Bt_search");
                Bt_search.Visible = false;

                //位置在下的“返回查询”按钮可见
                LinkButton LB_search = (LinkButton)Panel2.FindControl("LB_search");
                LB_search.Visible = true;

            }

        }
        else
            Lb_ret.Text = "你没有选择任何用户，删除操作失败";   //选择0个用户删除，提示错误

    }
    protected void GV1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GV1.PageIndex = e.NewPageIndex;
        LoadData(); //重新绑定GridView数据的函数

    }
    protected void LB_search_Click(object sender, EventArgs e)
    {
        Response.Redirect("userManage.aspx");
    }
}
