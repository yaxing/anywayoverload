<%@ Page Language="C#" MasterPageFile="~/mode_classify.master" AutoEventWireup="true" CodeFile="bookInfo.aspx.cs" Inherits="_Default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 620px; height: 420px; margin-top: 0px; margin-left: 80px;">
        <tr>
            <td align="left" style="width: 83px">
                �� �ۣ�</td>
            <td colspan="1" style="width: 260px">
                �ã�<asp:Label ID="lblGood" runat="server"></asp:Label>һ�㣺<asp:Label ID="lblNormal"
                    runat="server"></asp:Label>�<asp:Label ID="lblbad" runat="server"></asp:Label></td>
            <td align="center" colspan="4" rowspan="1" style="width: 166px; color: #000000">
                ����ͼƬ</td>
        </tr>
        <tr>
            <td align="left" style="width: 83px">
                ��&nbsp; ����</td>
            <td colspan="1" style="width: 260px">
                <asp:Label ID="lblBookName" runat="server"></asp:Label></td>
            <td align="center" colspan="4" rowspan="9" style="width: 166px; color: #000000">
                
            </td>
        </tr>
        <tr style="color: #000000">
            <td align="left" style="width: 83px">
                �������ࣺ</td>
            <td colspan="1" style="width: 260px">
                <asp:Label ID="lblBookType" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" style="width: 83px">
                ��&nbsp; �ߣ�</td>
            <td colspan="1" style="width: 260px">
                <asp:Label ID="lblAuthor" runat="server"></asp:Label></td>
        </tr>
        <tr style="color: #000000">
            <td align="left" style="width: 83px">
                �����磺</td>
            <td colspan="1" style="width: 260px">
                <asp:Label ID="lblPub" runat="server"></asp:Label></td>
        </tr>
        <tr style="color: #000000">
            <td align="left" style="width: 83px">
                �������ڣ�</td>
            <td colspan="1" style="width: 260px">
                <asp:Label ID="lblPubDate" runat="server"></asp:Label></td>
        </tr>
        <tr style="color: #000000">
            <td align="left" style="width: 83px">
                ISBN�ţ�</td>
            <td colspan="1" style="width: 260px">
                <asp:Label ID="lblISBN" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" style="width: 83px">
                ��&nbsp; �ۣ�</td>
            <td colspan="1" style="width: 260px">
                <asp:Label ID="lblPrice" runat="server"></asp:Label>(Ԫ)</td>
        </tr>
        <tr>
            <td align="left" style="width: 83px">
                ��&nbsp; ����</td>
            <td colspan="1" style="width: 260px">
                <asp:Label ID="lblQuantity" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" style="width: 83px">
                �� ����</td>
            <td colspan="1" style="width: 260px">
                <asp:Label ID="lblSold" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" style="width: 83px">
                ����������</td>
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

