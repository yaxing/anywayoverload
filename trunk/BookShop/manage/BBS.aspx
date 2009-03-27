<%@ Page Language="C#" MasterPageFile="~/manage/mode_admin.master" AutoEventWireup="true" CodeFile="BBS.aspx.cs" Inherits="manage_BBS" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 862px">
            </td>
            <td colspan="4">
                公告管理</td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 862px">
                <asp:Label ID="Label1" runat="server" Text="公告内容："></asp:Label></td>
            <td colspan="3">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                    ErrorMessage="内容不能为空"></asp:RequiredFieldValidator></td>
            <td style="width: 113px">
                <asp:Button ID="Button3" runat="server" Text="显示所有公告" CausesValidation="False" OnClick="Button3_Click" /></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 862px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
                <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" /></td>
            <td style="width: 100px; height: 21px">
                <asp:Button ID="Button2" runat="server" Text="重置" CausesValidation="False" OnClick="Button2_Click" /></td>
            <td style="width: 164px; height: 21px">
            </td>
            <td style="width: 113px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 862px">
            </td>
            <td style="width: 100px">
                <asp:Label ID="Label2" runat="server"></asp:Label></td>
            <td style="width: 100px">
            </td>
            <td style="width: 164px">
            </td>
            <td style="width: 113px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 862px">
            </td>
            <td colspan="2" rowspan="2">
                &nbsp;
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
                    PageSize="5" DataKeyNames="ID" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" AutoGenerateColumns="False" ForeColor="Black" GridLines="None">
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowEditButton="True" />
                        <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                        <asp:BoundField DataField="ID" HeaderText="序号" />
                        <asp:BoundField DataField="content" HeaderText="内容" />
                        <asp:BoundField DataField="postTime" HeaderText="发布时间" />
                    </Columns>
                </asp:GridView>
            </td>
            <td style="width: 164px">
                &nbsp;<br />
                </td>
            <td style="width: 113px">
                &nbsp;</td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 33px;">
            </td>
            <td style="width: 862px; height: 33px;">
            </td>
            <td style="width: 164px; height: 33px;">
            </td>
            <td style="width: 113px; height: 33px;">
                &nbsp; &nbsp;&nbsp;
            </td>
            <td style="width: 100px; height: 33px;">
            </td>
            <td style="width: 100px; height: 33px;">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 862px">
            </td>
            <td style="width: 100px">
                <asp:Label ID="Label5" runat="server"></asp:Label></td>
            <td style="width: 100px">
            </td>
            <td style="width: 164px">
            </td>
            <td style="width: 113px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 862px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 164px">
            </td>
            <td style="width: 113px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</asp:Content>

