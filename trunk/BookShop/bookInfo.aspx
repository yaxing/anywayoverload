<%@ Page Language="C#" MasterPageFile="~/mode_classify.master" AutoEventWireup="true" CodeFile="bookInfo.aspx.cs" Inherits="_Default" Title="ͼ����Ϣ" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 620px; height: 420px; margin-top: 0px; margin-left: 80px;">
        <tr>
            <td align="left" style="width: 83px">
                ��&nbsp; ����</td>
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
                �������ࣺ</td>
            <td colspan="1" style="width: 260px" align="left">
                <asp:Label ID="lblBookType" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" style="width: 83px">
                ��&nbsp; �ߣ�</td>
            <td colspan="1" style="width: 260px" align="left">
                <asp:Label ID="lblAuthor" runat="server"></asp:Label></td>
        </tr>
        <tr style="color: #000000">
            <td align="left" style="width: 83px">
                �����磺</td>
            <td colspan="1" style="width: 260px" align="left">
                <asp:Label ID="lblPub" runat="server"></asp:Label></td>
        </tr>
        <tr style="color: #000000">
            <td align="left" style="width: 83px">
                �������ڣ�</td>
            <td colspan="1" style="width: 260px" align="left">
                <asp:Label ID="lblPubDate" runat="server"></asp:Label></td>
        </tr>
        <tr style="color: #000000">
            <td align="left" style="width: 83px">
                ISBN�ţ�</td>
            <td colspan="1" style="width: 260px" align="left">
                <asp:Label ID="lblISBN" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" style="width: 83px">
                ��&nbsp; �ۣ�</td>
            <td colspan="1" style="width: 260px" align="left">
                <asp:Label ID="lblPrice" runat="server"></asp:Label>(Ԫ)</td>
        </tr>
        <tr>
            <td align="left" style="width: 83px">
                ��&nbsp; ����</td>
            <td colspan="1" style="width: 260px" align="left">
                <asp:Label ID="lblQuantity" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" style="width: 83px">
                ��&nbsp; ����</td>
            <td colspan="1" style="width: 260px" align="left">
                <asp:Label ID="lblSold" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" style="width: 83px">
                ��&nbsp; �ۣ�</td>
            <td align="left" colspan="1" style="width: 260px">
                �ã�<asp:Label ID="lblGood" runat="server"></asp:Label>һ�㣺<asp:Label ID="lblNormal"
                    runat="server"></asp:Label>�<asp:Label ID="lblbad" runat="server"></asp:Label></td>
            <td align="center" colspan="4" rowspan="1" style="width: 166px; color: #000000">
                <asp:TextBox ID="TxtQuan" runat="server" Width="42px"></asp:TextBox>
                (��)<asp:ImageButton ID="IBtnAdd" runat="server" /></td>
        </tr>
        <tr>
            <td align="left" style="width: 83px">
                ����������</td>
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

