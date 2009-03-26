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

public partial class RegistereUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        string userName = args.Value;
        BsUserManager bs = new BsUserManager();
        if (bs.IsUserExist(userName))
        {
            args.IsValid = false;
        }
        else args.IsValid = true;
    }
    protected void Rgbt_Click(object sender, EventArgs e)
    {
        if (this.IsValid)
        {
            string user_Name = txtUserName.Text.Trim();
            string user_Password = txtPassword.Text.Trim();
            string true_Name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string address = txtAddress.Text.Trim();
            string post = txtPost.Text.Trim();
            string tel = txtMobile.Text.Trim();

            BsUserManager bs = new BsUserManager();
            int userId = 0;
            if (bs.InsertUser(user_Name, user_Password, true_Name, email, address, post, tel) == true)
            {
                Response.Write("注册成功！");
            }
            else { Response.Write("注册不成功！"); }
        }
        else
        {
            Response.Write("注册不成功，请重新注册！");
        }
    }
}
