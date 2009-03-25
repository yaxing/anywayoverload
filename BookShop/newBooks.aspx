<%@ Page Language="C#" MasterPageFile="~/mode_index.master" AutoEventWireup="true" CodeFile="newBooks.aspx.cs" Inherits="newBooks" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" style="text-align:center;">
        <tr><td>最新上架图书</td></tr>
        <tr><td>
            <asp:GridView ID="gvNewBooks" runat="server" AutoGenerateColumns="False" CellPadding="4"
                ForeColor="#333333" GridLines="None" AllowPaging="True">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <EditRowStyle BackColor="#2461BF" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="bookName" HeaderText="名称" />
                    <asp:BoundField DataField="author" HeaderText="作者" />
                    <asp:BoundField DataField="publisher" HeaderText="出版社" />
                    <asp:BoundField DataField="indatetime" HeaderText="添加时间" />
                    <asp:BoundField DataField="className" HeaderText="分类" />
                    <asp:BoundField DataField="price" HeaderText="价格" />
                </Columns>
            </asp:GridView>
        </td></tr>
    </table>
</asp:Content>

