<%@ Page Language="C#" MasterPageFile="~/manage/mode_admin.master" AutoEventWireup="true" CodeFile="orderManage.aspx.cs" Inherits="manage_orderManage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <a href="#">�ԡԡ�link�ԡԡ�</a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br/>
    <asp:Label ID="lblContent" runat="server" Text=""></asp:Label>
    <form action=""  runat="server">
    <table style="text-align:center; width:100%;">
        <tr align="center">
            <td align="center">
                <asp:Label ID="lblPage" runat="server" Text=""></asp:Label>
                <asp:LinkButton ID="lBtnPriPage" runat="server" OnClick="lBtnPriPage_Click">��һҳ</asp:LinkButton>
                <asp:LinkButton ID="lBtnNextPage" runat="server" OnClick="lBtnNextPage_Click">��һҳ</asp:LinkButton>
            </td>
        </tr>
    </table>
    </form>
</asp:Content>

