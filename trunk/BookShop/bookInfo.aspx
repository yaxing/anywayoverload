<%@ Page Language="C#" MasterPageFile="~/mode_classify.master" AutoEventWireup="true" CodeFile="bookInfo.aspx.cs" Inherits="_Default" Title="图书信息" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 620px; height: 420px; margin-top: 0px; margin-left: 80px;">
        <tr>
            <td align="left" style="width: 83px">
                书&nbsp; 名：</td>
            <td colspan="1" style="width: 260px" align="left">
                <asp:Label ID="lblBookName" runat="server"></asp:Label></td>
            <td align="left" colspan="4" rowspan="9" style="width: 166px; color: #000000">
            <ul class="hoverbox">
                <li>
                <a href="#">
                <img src="" alt="" id="coverImg" runat="server"/>
                <img src="" alt=""  id="coverImgP" class="preview" runat="server"/>
                </a>
                </li>
            </ul>
            </td>
        </tr>
        <tr style="color: #000000">
            <td align="left" style="width: 83px">
                所属分类：</td>
            <td colspan="1" style="width: 260px" align="left">
                <asp:Label ID="lblBookType" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" style="width: 83px">
                作&nbsp; 者：</td>
            <td colspan="1" style="width: 260px" align="left">
                <asp:Label ID="lblAuthor" runat="server"></asp:Label></td>
        </tr>
        <tr style="color: #000000">
            <td align="left" style="width: 83px">
                出版社：</td>
            <td colspan="1" style="width: 260px" align="left">
                <asp:Label ID="lblPub" runat="server"></asp:Label></td>
        </tr>
        <tr style="color: #000000">
            <td align="left" style="width: 83px">
                出版日期：</td>
            <td colspan="1" style="width: 260px" align="left">
                <asp:Label ID="lblPubDate" runat="server"></asp:Label></td>
        </tr>
        <tr style="color: #000000">
            <td align="left" style="width: 83px">
                ISBN号：</td>
            <td colspan="1" style="width: 260px" align="left">
                <asp:Label ID="lblISBN" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" style="width: 83px">
                定&nbsp; 价：</td>
            <td colspan="1" style="width: 260px" align="left">
                <asp:Label ID="lblPrice" runat="server"></asp:Label>(元)</td>
        </tr>
        <tr>
            <td align="left" style="width: 83px">
                存&nbsp; 量：</td>
            <td colspan="1" style="width: 260px" align="left">
                <asp:Label ID="lblQuantity" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" style="width: 83px">
                销&nbsp; 量：</td>
            <td colspan="1" style="width: 260px" align="left">
                <asp:Label ID="lblSold" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" style="width: 83px">
                评&nbsp; 价：</td>
            <td align="left" colspan="1" style="width: 260px">
                好：<asp:Label ID="lblGood" runat="server"></asp:Label>一般：<asp:Label ID="lblNormal"
                    runat="server"></asp:Label>差：<asp:Label ID="lblbad" runat="server"></asp:Label></td>
            <td align="center" colspan="4" rowspan="1" style="width: 166px; color: #000000">
                <asp:TextBox ID="TxtQuan" runat="server" Width="42px"></asp:TextBox>
                (件)<asp:ImageButton ID="IBtnAdd" runat="server" /></td>
        </tr>
        <tr>
            <td align="left" style="width: 83px">
                内容描述：</td>
            <td colspan="5" rowspan="3" align="left">
                <asp:Literal ID="ltlScript" runat="server"></asp:Literal></td>
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
    <br />
    <br />
</asp:Content>

