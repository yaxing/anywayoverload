<%@ Page Language="C#" MasterPageFile="~/mode_index.master" AutoEventWireup="true" CodeFile="saleRank.aspx.cs" Inherits="saleRank" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" style="text-align:center">
        <tr><td>销售排行</td></tr>
        <tr><td>
            <asp:GridView ID="gvSaleRank" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" Width="90%">
                <FooterStyle BackColor="#CCCC99" />
                <Columns>
                    <asp:ImageField DataImageUrlField="coverPath" DataImageUrlFormatString="{0}" HeaderText="书籍封面">
                        <ControlStyle Height="100px" Width="76px" />
                    </asp:ImageField>
                    <asp:BoundField DataField="bookName" HeaderText="书籍名称" />
                    <asp:BoundField DataField="publisher" HeaderText="出版社" />
                    <asp:BoundField DataField="author" HeaderText="作者" />
                    <asp:BoundField DataField="sale" HeaderText="销量" />
                    <asp:BoundField DataField="className" HeaderText="分类" />
                    <asp:BoundField DataField="price" HeaderText="价格" SortExpression="price" DataFormatString="{0:f2}" HtmlEncode="False" />
                    <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="bookInfo.aspx?bookID={0}"
                        HeaderText="点击进入" Text="点击进入" />
                </Columns>
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </td></tr>
    </table>
</asp:Content>

