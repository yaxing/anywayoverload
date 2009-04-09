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
using BsCtrl;


public partial class manage_userSearchResultaspx : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //判断权限

        //若不是管理员，回到管理员登录页面
        if(Session["AdminN"] == null)
        {
            Response.Redirect("adminLogin.html");
        }
        
        //判断是否为4级管理员，只有4级管理员能访问该页面
        //不是4级管理员
        if(Session["AdminLv"].ToString() !=  "4")
        {
            Response.Redirect("adminLogin.html");          
        }
        
        if (this.IsPostBack == false)
            LoadData();
        Panel_ret.Visible = false;

        //如果当前没有数据，则“全选”“全不选”“删除”按钮消失
        if (GV1.Rows.Count == 0)
        {   //查询结果为空

            Panel1.Visible = false;
            Panel_ret.Visible = true;
            Lb_ret.Text = "没有符合条件的用户信息";
        }

    }
    protected void LoadData()
    {

        //获得memberSearch页面传递过来的参数
        String strID = Request.QueryString["id"];
        String strName = Request.QueryString["name"];
        String strTEL = Request.QueryString["tel"];
        String strEmail = Request.QueryString["email"];

        //实例化BsUserManager
        BsUserManager admin = new BsUserManager();
        DataSet ds = admin.searchMember(strID,strName,strTEL,strEmail);

        //绑定数据源
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
        Response.Redirect("memberSearch.aspx");
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
        String strMd5Pwd;   //写回数据库的密码

        int RowEditIndex = GV1.EditIndex;
        //判断当前是否为数据行
        if (GV1.Rows[RowEditIndex].RowType == DataControlRowType.DataRow)
        {    
            //获取管理员更改的用户信息
            string strID = ((Label)GV1.Rows[RowEditIndex].FindControl("Lb_id")).Text;     //用户ID
            String strName = ((Label)GV1.Rows[RowEditIndex].FindControl("Lb_name")).Text;       //用户名
            String strPwd = ((TextBox)GV1.Rows[RowEditIndex].FindControl("TB_pwd")).Text.Trim();  //用户密码
            String strTEL = ((TextBox)GV1.Rows[RowEditIndex].FindControl("TB_tel")).Text.Trim();    //tel
            String strEmail = ((TextBox)GV1.Rows[RowEditIndex].FindControl("TB_email")).Text.Trim();    //email
          
            if (strPwd != "Password")    //输入了新密码
            {    //密码md5加密
                strMd5Pwd = MD5(strPwd);
            }
            else    //将原密码写回数据库
            {
                strMd5Pwd = ((Label)GV1.Rows[RowEditIndex].FindControl("Lb_PrePwd")).Text;         
            }

            //执行更新操作
            admin.updateMember(strID, strName, strMd5Pwd, strTEL, strEmail);       //更新用户

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
                Panel_ret.Visible = true;
            }

            Lb_ret.Text = "操作成功";   //提示成功
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
            
            if (del.Checked)   //如果删除复选框被选中
                {

                    admin.deleteMember(intID);  //删除用户
                    del_no = false; 
                }
        }

        //显示更新后的页面
        LoadData();

        if (del_no == false)
        {
            Lb_ret.Text = "删除操作成功";   //选择1个以上用户删除，提示成功

            //如果当前没有数据，则“全选”“全不选”“删除”按钮消失
            if (GV1.Rows.Count == 0)
            {   //查询结果为空

                Panel1.Visible = false;
                Panel_ret.Visible = true;
            }

        }
        else
        {
            Panel_ret.Visible = true;
            LB_search.Visible = false;
            Lb_ret.Text = "你没有选择任何用户，删除操作失败";   //选择0个用户删除，提示错误
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
        Response.Redirect("memberSearch.aspx");
    }
 
}
