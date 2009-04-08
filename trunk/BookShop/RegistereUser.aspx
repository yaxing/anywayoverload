<%@ Page Language="C#" MasterPageFile="~/mode_index.master" AutoEventWireup="true"
    CodeFile="RegistereUser.aspx.cs" Inherits="RegistereUser" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table style="width: 584px; font-size: 12px; font-family: ����; height: 284px;">
            <tr>
                <td style="height: 40px;" align="left" colspan="2">
                    <h4 style="text-align: center">
                        <span>
                        �û�ע�᣺</span></h4>
                </td>
            </tr>
            <tr>
                <td style="width: 118px; height: 27px; text-align: right;" align="left">
                    �û�����</td>
                <td align="left" style="height: 27px">
                    <asp:TextBox ID="txtUserName" runat="server" Width="150px" MaxLength="256" CssClass="textarea"></asp:TextBox>(����)
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="�û�������Ϊ��"
                        ControlToValidate="txtUserName" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtUserName"
                        ErrorMessage="�û��Ѿ�����" OnServerValidate="CustomValidator1_ServerValidate" Display="Dynamic"></asp:CustomValidator><br />
                    </td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                </td>
            </tr>
            <tr>
                <td style="width: 118px; height: 27px; text-align: right;" align="left">
                    ���룺
                </td>
                <td align="left" style="height: 27px">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="150px" MaxLength="128" CssClass="textarea"></asp:TextBox>(����)
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                        ErrorMessage="���벻��Ϊ��" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword"
                        ControlToValidate="txtPassword2" Display="Dynamic" ErrorMessage="�ظ��������벻ƥ��"></asp:CompareValidator></td>
            </tr>
            <tr>
                <td style="width: 118px; height: 27px; text-align: right;" align="left">
                    ȷ�����룺
                </td>
                <td align="left" style="height: 27px">
                    <asp:TextBox ID="txtPassword2" runat="server" TextMode="Password" Width="150px" MaxLength="128" CssClass="textarea"></asp:TextBox>(����)
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassword2"
                        ErrorMessage="�ظ����벻��Ϊ��"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                </td>
            </tr>
            <tr>
                <td style="width: 118px; height: 26px; text-align: right;" align="left">
                    Email:</td>
                <td align="left" style="height: 26px">
                    <asp:TextBox ID="txtEmail" runat="server" Width="180px" MaxLength="256" CssClass="textarea"></asp:TextBox>(����)
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="�����ʼ�����Ϊ��"
                        ControlToValidate="txtEmail" Display="Dynamic"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                            ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                            Display="Dynamic" ErrorMessage="������Ϸ����ʼ���ַ" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                </td>
            </tr>
            <tr>
                <td style="width: 118px; text-align: right; height: 20px;" align="left">
                    ��ʵ������</td>
                <td align="left" style="height: 20px">
                    <asp:TextBox ID="txtName" runat="server" Width="150px" MaxLength="10" CssClass="textarea"></asp:TextBox>(����)
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtName"
                        Display="Dynamic" ErrorMessage="��ʵ��������Ϊ��"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 118px; text-align: right;" align="left">
                    ��ַ��</td>
                <td style="width: 100px" align="left">
                    <asp:TextBox ID="txtAddress" runat="server" Width="200px" MaxLength="50" CssClass="textarea"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 118px; height: 20px; text-align: right;" align="left">
                    �ʱࣺ</td>
                <td align="left" style="height: 20px">
                    <asp:TextBox ID="txtPost" runat="server" Width="180px" MaxLength="50" CssClass="textarea"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPost"
                        Display="Dynamic" ErrorMessage="������Ϸ�����������" ValidationExpression="\d{6}"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="width: 118px; height: 26px; text-align: right;" align="left">
                    �ƶ��绰��</td>
                <td align="left" style="height: 26px">
                    <asp:TextBox ID="txtMobile" runat="server" Width="180px" MaxLength="50" CssClass="textarea"></asp:TextBox>&nbsp;
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtMobile"
                        Display="Dynamic" ErrorMessage="������Ϸ��ĵ绰����" ValidationExpression="\d{11}"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="height: 26px; text-align: center;" align="left" colspan="2">
                    <input id="Reset1" style="width: 35px; height: 20px" type="reset" value="���" />&nbsp;
                    <asp:Button ID="Rgbt" runat="server" Text="ע��" OnClick="Rgbt_Click" />&nbsp;
                    </td>
            </tr>
        </table>
</asp:Content>
