<%@ Page Language="C#" MasterPageFile="~/manage/mode_admin.master" AutoEventWireup="true" CodeFile="PollDetail.aspx.cs" Inherits="manage_PollDetail" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;<table>
        <tr>
            <td style="width: 100px">
                </td>
            <td style="width: 100px">
                </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label2" runat="server" Text="所属主题"></asp:Label></td>
            <td style="width: 100px">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                <asp:Button ID="Button3" runat="server" Text="显示当前投票主题所有投票选项" OnClick="Button3_Click" /></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label3" runat="server" Text="内容"></asp:Label></td>
            <td style="width: 100px">
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 16px">
                <asp:Label ID="Label4" runat="server" Text="计数"></asp:Label></td>
            <td style="width: 100px; height: 16px">
                <asp:TextBox ID="TextBox4" runat="server" Enabled="False"></asp:TextBox></td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="保存" /></td>
            <td style="width: 100px">
                <asp:Button ID="Button2" runat="server" Text="重置" OnClick="Button2_Click" /></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label1" runat="server" Width="126px"></asp:Label></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" AllowPaging="True" DataKeyNames="ID" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" PageSize="5" OnRowUpdating="GridView1_RowUpdating">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="投票选项序号" />
            <asp:BoundField DataField="pollID" HeaderText="所属投票主题序号" />
            <asp:BoundField DataField="optionName" HeaderText="选项内容" />
            <asp:BoundField DataField="counts" HeaderText="数量" />
            <asp:CommandField ButtonType="Button" ShowEditButton="True" />
            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>

