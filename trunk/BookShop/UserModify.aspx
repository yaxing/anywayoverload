<%@ Page Language="C#" MasterPageFile="~/mode_index.master" AutoEventWireup="true" CodeFile="UserModify.aspx.cs" Inherits="UserModify" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h4 style="margin: 30px 40px; text-align: center">
        用户信息修改：
    </h4>
    <div style="font-family: @新宋体 Arial; font-size: 12px; margin: 20px 100px; padding: 10px;
        background-color: #e0f5f4">
        <table>
            <tr>
                <td style="text-align: left; height: 17px;" align="left" colspan="2">
                    请您修改您的用户信息：&nbsp;
                    <asp:Label ID="UserNameLb" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2" align="left" rowspan="2">
                </td>
            </tr>
            <tr>
            </tr>
            <tr>
                <td style="text-align: right; height: 21px;" align="left">
                    Email：</td>
                <td align="left" style="height: 21px">
                    <asp:TextBox ID="txtEmail" runat="server" Width="180px" MaxLength="256" CssClass="textarea"></asp:TextBox>
                    (必填)<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="邮箱不能更新为空" ControlToValidate="txtEmail" Display="Dynamic" ValidationGroup="UserModifyGp"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                        Display="Dynamic" ErrorMessage="邮箱格式不正确" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="UserModifyGp"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                </td>
            </tr>
            <tr>
                <td style="text-align: right; height: 22px;" align="left">
                    真实姓名：</td>
                <td align="left" style="height: 22px">
                    <asp:TextBox ID="txtName" runat="server" Width="150px" MaxLength="10" CssClass="textarea"></asp:TextBox>
                    (必填)<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="真实姓名不能更新为空" ControlToValidate="txtName" Display="Dynamic" ValidationGroup="UserModifyGp"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="text-align: right;" align="left">
                    地址：</td>
                <td align="left">
                    <asp:TextBox ID="txtAddress" runat="server" Width="200px" MaxLength="50" CssClass="textarea"></asp:TextBox>
                    (必填)<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="地址不能更新为空" ControlToValidate="txtAddress" Display="Dynamic" ValidationGroup="UserModifyGp"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="text-align: right; height: 20px;" align="left">
                    邮编：</td>
                <td align="left" style="height: 20px">
                    <asp:TextBox ID="txtPost" runat="server" Width="180px" MaxLength="50" CssClass="textarea"></asp:TextBox>
                    (必填)<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="邮编不能更新为空" ControlToValidate="txtPost" Display="Dynamic" ValidationGroup="UserModifyGp"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPost"
                        Display="Dynamic" ErrorMessage="邮编格式不正确" ValidationExpression="\d{6}" ValidationGroup="UserModifyGp"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="text-align: right;" align="left">
                    移动电话：</td>
                <td align="left" style="height: 26px">
                    <asp:TextBox ID="txtMobile" runat="server" Width="180px" MaxLength="50" CssClass="textarea"></asp:TextBox>&nbsp;(必填)
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtMobile" Display="Dynamic"
                        ErrorMessage="电话不能更新为空" ValidationGroup="UserModifyGp"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtMobile"
                        Display="Dynamic" ErrorMessage="手机号码格式不正确" ValidationExpression="\d{11}" ValidationGroup="UserModifyGp"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="text-align: center; height: 20px;" align="left" colspan="2">
                    <asp:Button ID="SaveBt1" runat="server" Text="保存" OnClick="SaveBt1_Click" ValidationGroup="UserModifyGp" /><br />
                    <asp:Label ID="SaveLb1" runat="server" ForeColor="Red" Text="用户信息更新成功！" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td style="text-align: right;" align="left">
                    输入旧密码：
                </td>
                <td align="left" style="height: 27px">
                    <asp:TextBox ID="txtOldPass" runat="server" TextMode="Password" Width="150px" MaxLength="128"
                        CssClass="textarea"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtOldPass"
                        Display="Dynamic" ErrorMessage="请输入旧密码" ValidationGroup="UserPassGp"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtOldPass"
                        Display="Dynamic" ErrorMessage="旧密码输入不正确" OnServerValidate="CustomValidator1_ServerValidate"
                        ValidationGroup="UserPassGp"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td style="text-align: right;" align="left">
                    新密码：
                </td>
                <td align="left" style="height: 27px">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="150px" MaxLength="128"
                        CssClass="textarea"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPassword"
                        Display="Dynamic" ErrorMessage="请输入新密码" ValidationGroup="UserPassGp"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtPassword"
                        Display="Dynamic" ErrorMessage="密码必须6-12位" ValidationExpression="[A-Za-z0-9]{6,12}"
                        ValidationGroup="UserPassGp"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="text-align: right;" align="left">
                    确认密码：
                </td>
                <td align="left" style="height: 27px">
                    <asp:TextBox ID="txtPassword2" runat="server" TextMode="Password" Width="150px" MaxLength="128"
                        CssClass="textarea"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPassword2"
                        Display="Dynamic" ErrorMessage="重复输入新密码" ValidationGroup="UserPassGp"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword"
                        ControlToValidate="txtPassword2" Display="Dynamic" ErrorMessage="密码输入不一致" ValidationGroup="UserPassGp"></asp:CompareValidator></td>
            </tr>
            <tr>
                <td style="text-align: center; height: 21px;" align="left" colspan="2">
                    <asp:Button ID="SaveBt2" runat="server" Text="保存" ValidationGroup="UserPassGp" OnClick="SaveBt2_Click" />
                    <br />
                    <asp:Label ID="SaveLb2" runat="server" ForeColor="Red" Text="密码修改成功！" Visible="False"></asp:Label></td>
            </tr>
        </table>
    </div>
</asp:Content>

