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
using System.Security.Cryptography;
using System.Drawing;
using BsCtrl;

public partial class manage_adminEdit : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //判断权限

        //若不是管理员，回到管理员登录页面
        if (Session["AdminN"] == null)
        {
            Response.Redirect("adminLogin.html");
        }

        //判断是否为4级管理员，只有4级管理员能访问该页面
        //不是4级管理员
        if (Session["AdminLv"].ToString() != "4")
        {
            // Response.Redirect("adminLogin.html");
            //提示权限不够信息
            Panel_ret.Visible = false;
            Panel1.Visible = false;
            Panel_quanxian.Visible = true;
        }

        else 
        {
            //不是返回结果，初始化页面
            if (this.IsPostBack == false)
                LoadData();

            Panel_ret.Visible = false;

            //如果当前没有数据，则“全选”“全不选”“删除”按钮消失
            //查询结果为空
            if (GV1.Rows.Count == 0)
            {

                /*
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

                 */
                Panel1.Visible = false;
                Panel_ret.Visible = true;
                Lb_ret.ForeColor = Color.Red;
                Lb_ret.Text = "没有符合条件的用户信息";

            }

        }

       

    }
    protected void LoadData()
    {

        //获得adminSearch页面传递过来的参数
        String strID = Request.QueryString["id"];
        String strName = Request.QueryString["name"];
        String strEmail = Request.QueryString["email"];
        String strLevel = Request.QueryString["level"];
 
        //实例化BsUserManager
        BsUserManager Admin = new BsUserManager();
        DataSet ds = Admin.searchAdmin(strID,strName,strEmail,strLevel);

        //绑定数据源s
        GV1.DataSource = ds;
        GV1.DataBind();

        //“确认密码”栏不可见
        GV1.Columns[3].Visible = false;
    }

    /*功能：密码md5加密
      参数：
     */

    public static string MD5(string strPwd)
    {
        MD5CryptoServiceProvider MD5CSP = new MD5CryptoServiceProvider();
        byte[] MD5Pwd = System.Text.Encoding.UTF8.GetBytes(strPwd);
        byte[] MD5Out = MD5CSP.ComputeHash(MD5Pwd);
        return Convert.ToBase64String(MD5Out);
    } 

    //当点击“返回查询” 时，返回查询页面userManage.aspx
    protected void Bt_search_Click(object sender, EventArgs e)
    {
        Response.Redirect("adminSearch.aspx");
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

        //“确认密码”栏可见
        GV1.Columns[3].Visible = true;
        //复选框不可见——编辑状态不能进行删除操作
        GV1.Columns[6].Visible = false;
        //“删除”按钮不可见
        Button Bt_del = (Button)Panel1.FindControl("Bt_del");
        Bt_del.Visible = false;
       
    }

    //取消编辑  
    protected void GV1_CancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GV1.EditIndex = -1;         //退出编辑模式
        LoadData();

        //复选框可见
        GV1.Columns[6].Visible = true;
        //“删除”按钮可见
        Button Bt_del = (Button)Panel1.FindControl("Bt_del");
        Bt_del.Visible = true;
    }

   
    //提交编辑数据，更新
    protected void GV1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
    
        //实例化BsUserManager
        BsUserManager admin = new BsUserManager();
        String strMd5Pwd;

        int RowEditIndex = GV1.EditIndex;
        if (GV1.Rows[RowEditIndex].RowType == DataControlRowType.DataRow)
        {    //判断当前是否为数据行

            //获取管理员更改的用户信息
            string strID = ((Label)GV1.Rows[RowEditIndex].FindControl("Lb_id")).Text;     //用户ID
            int intID = Convert.ToInt32(strID);    //将ID转换成int型
            String strName = ((Label)GV1.Rows[RowEditIndex].FindControl("Lb_name")).Text;       //用户名
            String strPwd = ((TextBox)GV1.Rows[RowEditIndex].FindControl("TB_pwd")).Text.Trim();  //用户密码
            String strEmail = ((TextBox)GV1.Rows[RowEditIndex].FindControl("TB_email")).Text.Trim();    //email
            String strLevel = ((TextBox)GV1.Rows[RowEditIndex].FindControl("TB_level")).Text.Trim();  //用户等级level
            int intLevel = Convert.ToInt32(strLevel);


            if (strPwd != "Password")    //输入了新密码
            {    //密码md5加密
                strMd5Pwd = MD5(strPwd);
            }
            else    //将原密码写回数据库
            {
                strMd5Pwd = ((Label)GV1.Rows[RowEditIndex].FindControl("Lb_PrePwd")).Text;

            }


            //判断管理员等级变更是否合法
            //管理员原来的等级strPreLevel
            String strPreLevel = ((Label)GV1.Rows[RowEditIndex].FindControl("Lb_prelevel")).Text;
            int intPreLevel = Convert.ToInt32(strPreLevel);

            //不能把等级为4的管理员降级
            if (intLevel != 4 && intPreLevel == 4)
            {
                Panel1.Visible = false;
                Panel_ret.Visible = true;
                Lb_ret.ForeColor = Color.Red;
                Lb_ret.Text = "不能对等级为4的管理员执行降级操作";
                LB_search.Visible = true;
                
            }

            //不能提升等级在3级以下的管理员为4级
            else if (intLevel == 4 && intPreLevel != 4)
            {
                Panel1.Visible = false;
                Panel_ret.Visible = true;
                Lb_ret.ForeColor = Color.Red;
                Lb_ret.Text = "不能提升管理员的等级到4级";
                LB_search.Visible = true;
            }

            else
            {

                //执行更新操作
                admin.updateAdmin(strID, strName, strMd5Pwd, strEmail, strLevel);       //更新用户        /////////

                //退出编辑模式，显示更新后的页面
                GV1.EditIndex = -1;
                LoadData();

                //复选框可见
                GV1.Columns[6].Visible = true;
                //“删除”按钮可见
                Button Bt_del = (Button)Panel1.FindControl("Bt_del");
                Bt_del.Visible = true;

                //如果当前没有数据，则“全选”“全不选”“删除”按钮消失
                if (GV1.Rows.Count == 0)
                {   //查询结果为空
                    Panel1.Visible = false;
                }

                Panel_ret.Visible = true;
                Lb_ret.ForeColor = Color.Blue;
                Lb_ret.Text = "操作成功";   //提示成功
                LB_search.Visible = true;
            }

        }
    }

    //执行删除操作
    protected void Bt_del_Click(object sender, EventArgs e)
    {

        //实例化BsUserManager
        BsUserManager admin = new BsUserManager();
        bool del_no = true; // 标记执行删除前是否选择了1个以上用户。为true说明没有选择用户，提示错误 

        for (int i = 0; i < GV1.Rows.Count; i++) {      //删除选中的用户
            string strID = ((Label)GV1.Rows[i].FindControl("Label_id")).Text;     //用户ID
            int intID = Convert.ToInt32(strID);    //将ID转换成int型
            CheckBox del = ((CheckBox)GV1.Rows[i].FindControl("CB_del"));    //del记录是否被选中要删除
            
            //如果删除复选框被选中
            if (del.Checked)   
                {
                    //检查待删除的管理员等级是否为4级，若是4级则不能进行删除操作
                    string strLevel = ((Label)GV1.Rows[i].FindControl("Lb_level")).Text;   
                    //不是4级，可以删除
                    if(strLevel != "4")
                    {
                        admin.deleteAdmin(intID);  //删除用户  ///////
                        del_no = false; 
                    }
                }
        }

        //显示更新后的页面
        LoadData();

        if (del_no == false)
        {
            //选择1个以上用户删除，提示成功
            Panel_ret.Visible = true;
            Lb_ret.ForeColor = Color.Blue;
            Lb_ret.Text = "删除操作成功";
            LB_search.Visible = true;

            //如果当前没有数据，则“全选”“全不选”“删除”按钮消失
            //查询结果为空
            if (GV1.Rows.Count == 0)
            {
                Panel1.Visible = false;
            }

        }
        else
        {
            //选择0个用户删除，提示错误
            Panel_ret.Visible = true;
            LB_search.Visible = false;
            Lb_ret.ForeColor = Color.Red;
            // System.Drawing.Color col = Color.Red;
            Lb_ret.Text = "删除操作失败，原因可能是：1.你没有选中任何用户进行删除  2.试图删除等级为4的管理员";
        }

    }
    protected void GV1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GV1.PageIndex = e.NewPageIndex;

        //重新绑定GridView数据的函数
        LoadData(); 

    }
    protected void LB_search_Click(object sender, EventArgs e)
    {
        Response.Redirect("adminSearch.aspx");
    }
}

