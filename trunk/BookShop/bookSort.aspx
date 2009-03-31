<%@ Page Language="C#" MasterPageFile="~/mode_classify.master" AutoEventWireup="true" CodeFile="bookSort.aspx.cs" Inherits="bookSort" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="width:100%;text-align:center">
  <table style="width:100%">
  <tr><td style="height: 18px">
      <asp:Label ID="lblClassName" runat="server" Text="Label"></asp:Label></td></tr>
  <tr><td>
      <asp:GridView ID="gvBookList" runat="server" AllowPaging="True" CellPadding="4" ForeColor="Black"
        GridLines="Vertical" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" Width="90%" OnPageIndexChanging="gvBookList_PageIndexChanging">
        <FooterStyle BackColor="#CCCC99" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="bookName" HeaderText="书籍名称" />
            <asp:BoundField DataField="author" HeaderText="作者" />
            <asp:BoundField DataField="publisher" HeaderText="出版社" />
            <asp:BoundField DataField="price" HeaderText="价格" />
            <asp:BoundField DataField="available" HeaderText="剩余数量" />
        </Columns>
    </asp:GridView>
    </td></tr>
  </table>
    </div>
</asp:Content>

