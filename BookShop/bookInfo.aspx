<%@ Page Language="C#" MasterPageFile="~/mode_classify.master" AutoEventWireup="true" CodeFile="bookInfo.aspx.cs" Inherits="_Default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 620px; height: 420px; margin-top: 0px; margin-left: 80px;">
        <tr>
            <td align="left" style="width: 83px">
                评 价：</td>
            <td colspan="1" style="width: 260px">
                好：<asp:Label ID="lblGood" runat="server"></asp:Label>一般：<asp:Label ID="lblNormal"
                    runat="server"></asp:Label>差：<asp:Label ID="lblbad" runat="server"></asp:Label></td>
            <td align="center" colspan="4" rowspan="1" style="width: 166px; color: #000000">
                封面图片</td>
        </tr>
        <tr>
            <td align="left" style="width: 83px">
                书&nbsp; 名：</td>
            <td colspan="1" style="width: 260px">
                <asp:Label ID="lblBookName" runat="server"></asp:Label></td>
            <td align="center" colspan="4" rowspan="9" style="width: 166px; color: #000000">
                
            </td>
        </tr>
        <tr style="color: #000000">
            <td align="left" style="width: 83px">
                所属分类：</td>
            <td colspan="1" style="width: 260px">
                <asp:Label ID="lblBookType" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" style="width: 83px">
                作&nbsp; 者：</td>
            <td colspan="1" style="width: 260px">
                <asp:Label ID="lblAuthor" runat="server"></asp:Label></td>
        </tr>
        <tr style="color: #000000">
            <td align="left" style="width: 83px">
                出版社：</td>
            <td colspan="1" style="width: 260px">
                <asp:Label ID="lblPub" runat="server"></asp:Label></td>
        </tr>
        <tr style="color: #000000">
            <td align="left" style="width: 83px">
                出版日期：</td>
            <td colspan="1" style="width: 260px">
                <asp:Label ID="lblPubDate" runat="server"></asp:Label></td>
        </tr>
        <tr style="color: #000000">
            <td align="left" style="width: 83px">
                ISBN号：</td>
            <td colspan="1" style="width: 260px">
                <asp:Label ID="lblISBN" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" style="width: 83px">
                定&nbsp; 价：</td>
            <td colspan="1" style="width: 260px">
                <asp:Label ID="lblPrice" runat="server"></asp:Label>(元)</td>
        </tr>
        <tr>
            <td align="left" style="width: 83px">
                存&nbsp; 量：</td>
            <td colspan="1" style="width: 260px">
                <asp:Label ID="lblQuantity" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" style="width: 83px">
                销 量：</td>
            <td colspan="1" style="width: 260px">
                <asp:Label ID="lblSold" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" style="width: 83px">
                内容描述：</td>
            <td colspan="5" rowspan="3">
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 83px">
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 83px">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="6" rowspan="1">
                </td>
        </tr>
    </table>
</asp:Content>

