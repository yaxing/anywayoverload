<%@ Page Language="C#" MasterPageFile="~/manage/mode_admin.master" AutoEventWireup="true" CodeFile="orderManage.aspx.cs" Inherits="manage_orderManage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    ====<asp:LinkButton ID="lBtnPageType" runat="server" Text="" OnClick="lBtnPageType_Click"></asp:LinkButton>====
    <asp:HiddenField ID="hfPageType" runat="server" Value="" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br/>
    <p style="text-align:center">�û�����<asp:TextBox ID="tBoxUserName" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lBtnSearch" runat="server" OnClick="lBtnSearch_Click">��������</asp:LinkButton></p>
    <asp:HiddenField ID="hfUserName" runat="server" Value="" />
    <asp:Label ID="lblContent" runat="server" Text=""></asp:Label>
    <br />
    <table style="text-align:center; width:100%;">
        <tr align="center">
            <td align="center">
                <font color='red'><asp:Label ID="lblPageNow" runat="server" Text=""></asp:Label></font>/<asp:Label ID="lblPageAll" runat="server" Text=""></asp:Label>ҳ
                &nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lBtnPriPage" runat="server" OnClick="lBtnPriPage_Click">��һҳ</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lBtnNextPage" runat="server" OnClick="lBtnNextPage_Click">��һҳ</asp:LinkButton>
            </td>
        </tr>
    </table>
    <p style="text-align:right">
        <asp:LinkButton ID="lBtnTran" runat="server" OnClick="lBtnTran_Click" OnClientClick="confirm('��ȷ��Ҫִ�д˲�����')">
            ��ֹ����--����ʷ����&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
   </p>
</asp:Content>