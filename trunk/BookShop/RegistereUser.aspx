<%@ Page Language="C#" MasterPageFile="~/mode_index.master" AutoEventWireup="true"
    CodeFile="RegistereUser.aspx.cs" Inherits="RegistereUser" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4 style="margin: 30px 40px; text-align: center">
        用户注册：
    </h4>
    <div style="font-family: @新宋体 Arial; font-size: 12px; margin: 20px 100px; padding: 10px;
        background-color: #e0f5f4">
        <table>
            <tr>
                <td style="text-align: right;" align="left">
                    用户名：</td>
                <td align="left" style="height: 27px">
                    <asp:TextBox ID="txtUserName" runat="server" Width="150px" MaxLength="256" CssClass="textarea"></asp:TextBox>(必填)
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="用户名不能为空"
                        ControlToValidate="txtUserName" Display="Dynamic">*</asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtUserName"
                        ErrorMessage="用户已经存在" OnServerValidate="CustomValidator1_ServerValidate" Display="Dynamic">*</asp:CustomValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtUserName"
                        ErrorMessage="用户名必须5-10位" ValidationExpression="\d{5,10}">*</asp:RegularExpressionValidator><br />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" align="left">
                    密码：
                </td>
                <td align="left" style="height: 27px">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="150px" MaxLength="128"
                        CssClass="textarea"></asp:TextBox>(必填)
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                        ErrorMessage="密码不能为空" Display="Dynamic">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword"
                        ControlToValidate="txtPassword2" Display="Dynamic" ErrorMessage="重复输入密码不匹配">*</asp:CompareValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtPassword"
                        Display="Dynamic" ErrorMessage="密码必须6-12位" ValidationExpression="\d{6,12}">*</asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="text-align: right;" align="left">
                    确认密码：
                </td>
                <td align="left" style="height: 27px">
                    <asp:TextBox ID="txtPassword2" runat="server" TextMode="Password" Width="150px" MaxLength="128"
                        CssClass="textarea"></asp:TextBox>(必填)
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassword2"
                        ErrorMessage="重复密码不能为空">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                </td>
            </tr>
            <tr>
                <td style="text-align: right; height: 21px;" align="left">
                    Email:</td>
                <td align="left" style="height: 21px">
                    <asp:TextBox ID="txtEmail" runat="server" Width="180px" MaxLength="256" CssClass="textarea"></asp:TextBox>(必填)
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="电子邮件不能为空"
                        ControlToValidate="txtEmail" Display="Dynamic">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                            ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                            Display="Dynamic" ErrorMessage="请输入合法的邮件地址" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                </td>
            </tr>
            <tr>
                <td style="text-align: right; height: 20px;" align="left">
                    真实姓名：</td>
                <td align="left">
                    <asp:TextBox ID="txtName" runat="server" Width="150px" MaxLength="10" CssClass="textarea"></asp:TextBox>(必填)
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtName"
                        Display="Dynamic" ErrorMessage="真实姓名不能为空">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="text-align: right;" align="left">
                    地址：</td>
                <td align="left">
                    <asp:TextBox ID="txtAddress" runat="server" Width="200px" MaxLength="50" CssClass="textarea"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align: right;" align="left">
                    邮编：</td>
                <td align="left">
                    <asp:TextBox ID="txtPost" runat="server" Width="180px" MaxLength="50" CssClass="textarea"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPost"
                        Display="Dynamic" ErrorMessage="请输入合法的邮政编码" ValidationExpression="\d{6}">*</asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="text-align: right;" align="left">
                    移动电话：</td>
                <td align="left" style="height: 26px">
                    <asp:TextBox ID="txtMobile" runat="server" Width="180px" MaxLength="50" CssClass="textarea"></asp:TextBox>&nbsp;
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtMobile"
                        Display="Dynamic" ErrorMessage="请输入合法的电话号码" ValidationExpression="\d{11}">*</asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="margin:10px auto; text-align:left">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                    </div>
                </td>
            </tr>
            <tr>
                <td style="text-align: center;" align="left" colspan="2">
                    <input id="Reset1" style="width: 35px; height: 20px" type="reset" value="清空" />&nbsp;
                    <asp:Button ID="Rgbt" runat="server" Text="注册" OnClick="Rgbt_Click" />&nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
