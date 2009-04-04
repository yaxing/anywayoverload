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

public partial class manage_adminAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel_ins.Visible = true;
        Panel_ret.Visible = false;
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

    //提交信息
    protected void Bt_commit_Click(object sender, EventArgs e)
    {
        //页面验证成功
        if (Page.IsValid)   
        {
            int intSelectedIndex = DDL_level.SelectedIndex; //下拉框选中的index
            int ret;    //记录操作结果

            String strName = TB_name.Text.Trim();
            String strPwd = TB_pwd.Text.Trim();
            String strEmail = TB_email.Text.Trim();
            String strLevel = DDL_level.Items[intSelectedIndex].Value;


            //密码md5加密
            String strMd5Pwd = MD5(strPwd);

            BsUserManager admin = new BsUserManager();
            ret = admin.addAdmin(strName,strMd5Pwd,strEmail,strLevel);  //添加新管理员
            
            if(ret != 0){       //插入操作成功
                Panel_ins.Visible = false;
                Panel_ret.Visible = true;
                Lb_ret.Text = "添加操作成功";
            }

            else{
                Panel_ins.Visible = false;
                Panel_ret.Visible = true;
                Lb_ret.Text = "添加操作失败";
            
            }

        }
    }

    //继续添加
    protected void LB_ins_Click(object sender, EventArgs e)
    {
        Response.Redirect("adminAdd.aspx");
    }

    //返回“用户管理”默认页面
    protected void LB_default_Click(object sender, EventArgs e)
    {
        Response.Redirect("userManage.aspx");
    }
}
