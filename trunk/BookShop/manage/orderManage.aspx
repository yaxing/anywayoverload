<%@ Page Language="C#" MasterPageFile="~/manage/mode_admin.master" AutoEventWireup="true" CodeFile="orderManage.aspx.cs" Inherits="manage_orderManage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <a href="#">≡≡≡link≡≡≡</a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br/>
    <asp:Label ID="lblContent" runat="server" Text=""></asp:Label>
    <p>&nbsp;</p>
    <table style="text-align:center; width:100%;">
        <tr align="center">
            <td align="center">
                <font color='red'><asp:Label ID="lblPageNow" runat="server" Text=""></asp:Label></font>/<asp:Label ID="lblPageAll" runat="server" Text=""></asp:Label>页
                &nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lBtnPriPage" runat="server" OnClick="lBtnPriPage_Click">上一页</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lBtnNextPage" runat="server" OnClick="lBtnNextPage_Click">下一页</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>