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

public partial class manage_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        /*
        if (Session["AdminN"] == null) {    //如果不是管理员身份
            Response.Redirect("adminLogin.html");
        }
        
         */ 
    }

    protected void Bt_search_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            int intSelectedIndex = DPD_Grade.SelectedIndex; //下拉框选中的index

            String strID = TB_ID.Text.Trim();
            String strName = TB_Name.Text.Trim();
            String strTEL = TB_TEL.Text.Trim();
            String strEmail = TB_Email.Text.Trim();
            String strGrade = DPD_Grade.Items[intSelectedIndex].Value;

           //查询条件>=1项
           if (strID != "" || strName != "" || strTEL != "" || strEmail != "" || strGrade != "不选")
           {  
             //转向memberEdit页面，并将查询条件以参数str的形式传递给它
               Response.Redirect("memberEdit.aspx?id=" + strID  + "&name=" + strName + "&tel=" + strTEL + "&email=" + strEmail +"&grade=" + strGrade);
            }

            else
            {  //查询条件为0项

                Label_Error.Text = "你没有输入任何查询条件";
            }
        }
    }


    protected void Bt_return_Click(object sender, EventArgs e)
    {
        Response.Redirect("userManage.aspx");
    }
}
