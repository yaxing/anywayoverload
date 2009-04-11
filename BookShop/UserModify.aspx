<%@ Page Language="C#" MasterPageFile="~/mode_index.master" AutoEventWireup="true" CodeFile="UserModify.aspx.cs" Inherits="UserModify" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h4 style="margin: 30px 40px; text-align: center">
        �û���Ϣ�޸ģ�
    </h4>
    <div style="font-family: @������ Arial; font-size: 12px; margin: 20px 100px; padding: 10px;
        background-color: #e0f5f4">
        <table>
            <tr>
                <td style="text-align: left; height: 17px;" align="left" colspan="2">
                    �����޸������û���Ϣ��&nbsp;
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
                    Email��</td>
                <td align="left" style="height: 21px">
                    <asp:TextBox ID="txtEmail" runat="server" Width="180px" MaxLength="256" CssClass="textarea"></asp:TextBox>
                    (����)<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="���䲻�ܸ���Ϊ��" ControlToValidate="txtEmail" Display="Dynamic" ValidationGroup="UserModifyGp"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                        Display="Dynamic" ErrorMessage="�����ʽ����ȷ" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="UserModifyGp"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                </td>
            </tr>
            <tr>
                <td style="text-align: right; height: 22px;" align="left">
                    ��ʵ������</td>
                <td align="left" style="height: 22px">
                    <asp:TextBox ID="txtName" runat="server" Width="150px" MaxLength="10" CssClass="textarea"></asp:TextBox>
                    (����)<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="��ʵ�������ܸ���Ϊ��" ControlToValidate="txtName" Display="Dynamic" ValidationGroup="UserModifyGp"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="text-align: right;" align="left">
                    ��ַ��</td>
                <td align="left">
                    <asp:TextBox ID="txtAddress" runat="server" Width="200px" MaxLength="50" CssClass="textarea"></asp:TextBox>
                    (����)<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="��ַ���ܸ���Ϊ��" ControlToValidate="txtAddress" Display="Dynamic" ValidationGroup="UserModifyGp"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="text-align: right; height: 20px;" align="left">
                    �ʱࣺ</td>
                <td align="left" style="height: 20px">
                    <asp:TextBox ID="txtPost" runat="server" Width="180px" MaxLength="50" CssClass="textarea"></asp:TextBox>
                    (����)<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="�ʱ಻�ܸ���Ϊ��" ControlToValidate="txtPost" Display="Dynamic" ValidationGroup="UserModifyGp"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPost"
                        Display="Dynamic" ErrorMessage="�ʱ��ʽ����ȷ" ValidationExpression="\d{6}" ValidationGroup="UserModifyGp"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="text-align: right;" align="left">
                    �ƶ��绰��</td>
                <td align="left" style="height: 26px">
                    <asp:TextBox ID="txtMobile" runat="server" Width="180px" MaxLength="50" CssClass="textarea"></asp:TextBox>&nbsp;(����)
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtMobile" Display="Dynamic"
                        ErrorMessage="�绰���ܸ���Ϊ��" ValidationGroup="UserModifyGp"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtMobile"
                        Display="Dynamic" ErrorMessage="�ֻ������ʽ����ȷ" ValidationExpression="\d{11}" ValidationGroup="UserModifyGp"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="text-align: center; height: 20px;" align="left" colspan="2">
                    <asp:Button ID="SaveBt1" runat="server" Text="����" OnClick="SaveBt1_Click" ValidationGroup="UserModifyGp" /><br />
                    <asp:Label ID="SaveLb1" runat="server" ForeColor="Red" Text="�û���Ϣ���³ɹ���" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td style="text-align: right;" align="left">
                    ��������룺
                </td>
                <td align="left" style="height: 27px">
                    <asp:TextBox ID="txtOldPass" runat="server" TextMode="Password" Width="150px" MaxLength="128"
                        CssClass="textarea"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtOldPass"
                        Display="Dynamic" ErrorMessage="�����������" ValidationGroup="UserPassGp"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtOldPass"
                        Display="Dynamic" ErrorMessage="���������벻��ȷ" OnServerValidate="CustomValidator1_ServerValidate"
                        ValidationGroup="UserPassGp"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td style="text-align: right;" align="left">
                    �����룺
                </td>
                <td align="left" style="height: 27px">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="150px" MaxLength="128"
                        CssClass="textarea"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPassword"
                        Display="Dynamic" ErrorMessage="������������" ValidationGroup="UserPassGp"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtPassword"
                        Display="Dynamic" ErrorMessage="�������6-12λ" ValidationExpression="[A-Za-z0-9]{6,12}"
                        ValidationGroup="UserPassGp"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="text-align: right;" align="left">
                    ȷ�����룺
                </td>
                <td align="left" style="height: 27px">
                    <asp:TextBox ID="txtPassword2" runat="server" TextMode="Password" Width="150px" MaxLength="128"
                        CssClass="textarea"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPassword2"
                        Display="Dynamic" ErrorMessage="�ظ�����������" ValidationGroup="UserPassGp"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword"
                        ControlToValidate="txtPassword2" Display="Dynamic" ErrorMessage="�������벻һ��" ValidationGroup="UserPassGp"></asp:CompareValidator></td>
            </tr>
            <tr>
                <td style="text-align: center; height: 21px;" align="left" colspan="2">
                    <asp:Button ID="SaveBt2" runat="server" Text="����" ValidationGroup="UserPassGp" OnClick="SaveBt2_Click" />
                    <br />
                    <asp:Label ID="SaveLb2" runat="server" ForeColor="Red" Text="�����޸ĳɹ���" Visible="False"></asp:Label></td>
            </tr>
        </table>
    </div>
</asp:Content>

