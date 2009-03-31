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
        TB_ID.Attributes.Add("OnClick", "this.value = '';");
        TB_Name.Attributes.Add("OnClick", "this.value = '';");
        TB_TEL.Attributes.Add("OnClick", "this.value = '';");
        TB_Email.Attributes.Add("OnClick", "this.value = '';");
      */

        if (Session["AdminN"] == null) {    //如果不是管理员身份
            Response.Redirect("adminLogin.html");
        }
        
    }

    protected void Bt_search_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            int intSelectedIndex = DPD_Grade.SelectedIndex; //下拉框选中的index

            String strUserID = TB_ID.Text.Trim();
            String strUserName = TB_Name.Text.Trim();
            String strTEL = TB_TEL.Text.Trim();
            String strEmail = TB_Email.Text.Trim();
            String strGrade = DPD_Grade.Items[intSelectedIndex].Value;  //////////////
            String str = "Select id,userName,password,tel,email,grade from users where 1=1 ";


                if (strUserID != "" || strUserName != "" || strTEL != "" || strEmail != "" || strGrade != "不选")
                {   //查询条件>=1项

                    
                if (strGrade != "不选")
                {
                    str += "And grade = " + strGrade;
                }

                if (strUserID.Length > 0)
                {
                    str += "And ID = " +  "'" + strUserID + "'";

                }

              
                if (strUserName.Length > 0)
                {
                    str += "And userName=" + "'" + strUserName + "'" ;

                }
                
               
                if (strTEL.Length > 0)
                {
                    str += "And tel = " +  "'" + strTEL + "'";

                }
                if (strEmail.Length > 0)
                {
                    str += "And email = " + "'" + strEmail + "'";

                }

                
                Response.Redirect("userSearchResult.aspx?str=" + str);     //转向userSearchResult页面，并将查询条件以参数str的形式传递给它

            }


            else
            {  //查询条件为0项

                Label_Error.Text = "你没有输入任何查询条件";
            }
        }
    }

      
}