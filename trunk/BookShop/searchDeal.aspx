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
                <asp:TemplateField>
                    <HeaderTemplate>
                        搜索结果
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 100%; text-align: left">
                            <tr>
                                <td style="width: 120px; text-align: center">
                                    <asp:Image ID="Image1" runat="server" Height="110px" ImageUrl='<%#Eval("coverPath") %>'
                                        Width="76px" /></td>
                                <td style="width: 500px">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="14px" ForeColor="#1A66B3"
                                                    NavigateUrl='<%# "bookInfo.aspx?bookID="+Eval("ID") %>'><%#Eval("bookName") %></asp:HyperLink></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Font-Size="12px" ForeColor="#878787" Text='<%# "作者: "+Eval("author") %>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" Font-Size="12px" ForeColor="#878787" Text='<%# "出版社: "+Eval("publisher") %>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Font-Size="12px" ForeColor="#878787" Text='<%# "销量: "+ Eval("sale") %>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label5" runat="server" Font-Size="12px" ForeColor="#404040" Text='<%# "简介: "+Eval("intro") + "..."%>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label6" runat="server" Font-Size="12px" ForeColor="#404040" Text='<%# "定价: "+Eval("price", "{0:f}") %>'></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
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

