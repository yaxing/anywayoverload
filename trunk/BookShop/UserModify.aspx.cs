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
using DbConnect;

public partial class UserModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        BsUserManager bm = new BsUserManager();
        this.SaveLb1.Visible = false;
        this.SaveLb2.Visible = false;

        if(!IsPostBack)
        {
            if (Session["userName"] != null)
            {
                String user_Name = Session["userName"].ToString();
                int userID = bm.findUser(user_Name);
                dt = bm.ShowUserInfo(userID);

                this.UserNameLb.Text = dt.Rows[0]["userName"].ToString();
                this.txtAddress.Text = dt.Rows[0]["address"].ToString();
                this.txtEmail.Text = dt.Rows[0]["email"].ToString();
                this.txtMobile.Text = dt.Rows[0]["tel"].ToString();
                this.txtName.Text = dt.Rows[0]["trueName"].ToString();
                this.txtPost.Text = dt.Rows[0]["postcode"].ToString();
            }
            else ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert(\"请先登陆！\");this.location.href='index.aspx'</script>");
        }
    }
    
    protected void SaveBt1_Click(object sender, EventArgs e)
    {
        BsUserManager bm = new BsUserManager();

        if (this.IsValid)
        {
            string true_Name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string address = txtAddress.Text.Trim();
            string post = txtPost.Text.Trim();
            string tel = txtMobile.Text.Trim();

            String user_Name = Session["userName"].ToString();
            int userID = bm.findUser(user_Name);
            
            if(bm.UpdateUserInfo(userID,true_Name,email,address,tel,post) == true)
            {
                this.SaveLb1.Visible = true;
            }
            else 
            {
                this.SaveLb1.Text = "更新失败！";
                this.SaveLb1.Visible = true;
            }
        }
        
    }

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        String user_Pass = args.Value;
        String user_Name = this.UserNameLb.Text.ToString();
        DataSet loginInfo;
        string dbConnStr = ConfigurationManager.ConnectionStrings["shanzhaiConnectionString"].ToString();//初始化数据库连接信息
        modeIndex indexCtrl = new modeIndex();  //建立控制类对象
        indexCtrl.initial(dbConnStr);  //数据库连接初始化

        user_Pass = BsUserManager.MD5(user_Pass);
        loginInfo = indexCtrl.VerifyUserInfo(user_Name, user_Pass);

        if (loginInfo.Tables[0].Rows.Count > 0)
        {
            args.IsValid = true;
        }
        else args.IsValid = false;
    }
    protected void SaveBt2_Click(object sender, EventArgs e)
    {
        if (this.IsValid)
        {
            String user_Pass = this.txtPassword.Text.Trim();

            BsUserManager bs = new BsUserManager();
            String user_Name = Session["userName"].ToString();
            int userID = bs.findUser(user_Name);
            user_Pass = BsUserManager.MD5(user_Pass);

            if (bs.UpdateUserPass(userID,user_Pass))
            {
                this.SaveLb2.Visible = true;
            }
            else
            {
                this.SaveLb2.Text = "修改失败！";
                this.SaveLb2.Visible = true;
            }
        }
    }
}
