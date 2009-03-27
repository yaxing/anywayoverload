<%@ Page Language="C#" MasterPageFile="~/manage/mode_admin.master" AutoEventWireup="true" CodeFile="Poll.aspx.cs" Inherits="manage_Poll" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 645px; height: 168px">
        <tr>
            <td style="width: 100px">
            </td>
            <td colspan="4">
                添加投票类型</td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 26px;">
                <asp:Label ID="Label1" runat="server" Text="主题"></asp:Label></td>
            <td colspan="2" style="height: 26px">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                    ErrorMessage="RequiredFieldValidator">主题名不能为空！</asp:RequiredFieldValidator></td>
            <td style="width: 100px; height: 26px;">
                <asp:Button ID="Button1" runat="server" Text="显示所有主题" OnClick="Button1_Click" CausesValidation="False" /></td>
            <td style="width: 100px; height: 26px;">
            </td>
            <td style="width: 100px; height: 26px;">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 26px;">
                <asp:Label ID="Label2" runat="server" Text="简介"></asp:Label></td>
            <td colspan="2" style="height: 26px">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                    ErrorMessage="RequiredFieldValidator">内容不能为空！</asp:RequiredFieldValidator></td>
            <td style="width: 100px; height: 26px;">
            </td>
            <td style="width: 100px; height: 26px;">
            </td>
            <td style="width: 100px; height: 26px;">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label3" runat="server" Text="状态"></asp:Label></td>
            <td style="width: 130px">
                <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" GroupName="Ballot"
                    Text="可用" /></td>
            <td style="width: 157px">
                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="Ballot" Text="不可用" /></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 26px;">
            </td>
            <td style="width: 130px; height: 26px;">
                <asp:Button ID="Button2" runat="server" Text="添加" OnClick="Button2_Click" /></td>
            <td style="width: 157px; height: 26px;">
                <asp:Button ID="Button3" runat="server" Text="重置" OnClick="Button3_Click" CausesValidation="False" /></td>
            <td style="width: 100px; height: 26px;">
                <asp:Label ID="Label4" runat="server"></asp:Label></td>
            <td style="width: 100px; height: 26px;">
            </td>
            <td style="width: 100px; height: 26px;">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 130px">
                &nbsp;&nbsp;
                <asp:Label ID="Label5" runat="server" Width="151px"></asp:Label>
                <asp:GridView ID="GridView1" runat="server" ForeColor="#333333" GridLines="None"
                    Visible="False" AllowPaging="True" PageSize="5" DataKeyNames="ID" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" AutoGenerateColumns="False" >
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <EditRowStyle BackColor="#999999" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#FFFFC0" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField ButtonType="Button" CausesValidation="False" ShowEditButton="True" />
                        <asp:CommandField ButtonType="Button" CausesValidation="False" ShowDeleteButton="True" />
                        <asp:BoundField DataField="ID" HeaderText="序号" />
                        <asp:BoundField DataField="theme" HeaderText="主题" />
                        <asp:BoundField DataField="introduce" HeaderText="简介" />
                        <asp:BoundField DataField="available" HeaderText="状态" />
                        <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="pollDetail.aspx?ID={0}"
                            DataTextFormatString="s" HeaderText="添加选项" Text="添加选项" />
                    </Columns>
                    <PagerSettings Mode="NumericFirstLast" />
                </asp:GridView>
            </td>
            <td style="width: 157px">
                &nbsp;
            </td>
            <td style="width: 100px">
                &nbsp;
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>

</asp:Content>

