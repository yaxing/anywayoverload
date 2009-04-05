<%@ Page Language="C#" MasterPageFile="~/mode_index.master" AutoEventWireup="true" CodeFile="searchDeal.aspx.cs" Inherits="_Default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" style="text-align:center">
        <tr><td>
            <asp:Label ID="lblSearch" runat="server" Text="Label"></asp:Label></td></tr>
        <tr><td>
            <asp:GridView ID="gvSearchResult" runat="server" AutoGenerateColumns="False" BackColor="White"
            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
            GridLines="Vertical" Width="90%" OnPageIndexChanging="gvSearchResult_PageIndexChanging" PageSize="5">
            <FooterStyle BackColor="#CCCC99" />
            <Columns>
                <asp:ImageField DataImageUrlField="coverPath" DataImageUrlFormatString="{0}" HeaderText="书籍封面">
                    <ControlStyle Height="100px" Width="76px" />
                </asp:ImageField>
                <asp:BoundField DataField="bookName" HeaderText="书籍名称" />
                <asp:BoundField DataField="author" HeaderText="作者" />
                <asp:BoundField DataField="publisher" HeaderText="出版社" />
                <asp:BoundField DataField="indatetime" HeaderText="上架时间" DataFormatString="{0:yyyy-M-dd}" HtmlEncode="False" />
                <asp:BoundField DataField="price" HeaderText="价格" DataFormatString="{0:f2}" HtmlEncode="False" />
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
    <asp:HiddenField ID="hfKeyWord" runat="server" />
</asp:Content>

