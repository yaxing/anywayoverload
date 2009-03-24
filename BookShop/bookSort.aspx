<%@ Page Language="C#" MasterPageFile="~/mode_classify.master" AutoEventWireup="true" CodeFile="bookSort.aspx.cs" Inherits="bookSort" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="gvBookList" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333"
        GridLines="None" AutoGenerateColumns="False">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
        <EditRowStyle BackColor="#2461BF" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="bookName" HeaderText="书籍名称" />
            <asp:BoundField DataField="author" HeaderText="作者" />
            <asp:BoundField DataField="publisher" HeaderText="出版社" />
            <asp:BoundField DataField="price" HeaderText="价格" />
            <asp:BoundField DataField="available" HeaderText="剩余数量" />
        </Columns>
    </asp:GridView>
</asp:Content>

