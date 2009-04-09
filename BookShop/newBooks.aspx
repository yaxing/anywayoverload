<%@ Page Language="C#" MasterPageFile="~/mode_index.master" AutoEventWireup="true" CodeFile="newBooks.aspx.cs" Inherits="newBooks" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" style="text-align:center;">
        <tr><td style="height: 286px">
            &nbsp;<asp:GridView ID="gvNewBooks" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvNewBooks_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="gvNewBooks_PageIndexChanging1" PageSize="5" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table style="text-align:left; width:100%;">
                                <tr>
                                    <td style="width:120px; text-align:center">
                                        <asp:Image ID="Image1" runat="server" ImageUrl=<%#"cover/" + Eval("coverPath") %> Width="76px" Height="110px"/></td>
                                    <td style="width:500px;">
                                        <table style="width:100%">
                                            <tr><td><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "bookInfo.aspx?bookID="+Eval("ID") %>' Font-Bold="True" Font-Size="14px" ForeColor="#1A66B3"><%#Eval("bookName") %></asp:HyperLink></td></tr>
                                            <tr><td>
                                                 <asp:Label ID="Label2" runat="server" Text='<%# "作者: "+Eval("author") %>' Font-Size="12px" ForeColor="#878787"></asp:Label></td></tr>
                                            <tr><td> <asp:Label ID="Label3" runat="server" Text='<%# "出版社: "+Eval("publisher") %>' Font-Size="12px" ForeColor="#878787"></asp:Label></td></tr>
                                            <tr><td><asp:Label ID="Label4" runat="server" Text='<%# "上架时间: "+ Eval("indatetime", "{0:d}") %>' Font-Size="12px" ForeColor="#878787"></asp:Label></td></tr>
                                            <tr><td><asp:Label ID="Label5" runat="server" Text='<%# "简介: "+Eval("intro") + "..."%>' Font-Size="12px" ForeColor="#404040"></asp:Label></td></tr>
                                            <tr><td><asp:Label ID="Label6" runat="server" Text='<%# "定价: "+Eval("price", "{0:f}") %>' Font-Size="12px" ForeColor="#404040"></asp:Label></td></tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <HeaderTemplate>
                            新书上架
                        </HeaderTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </td></tr>
    </table>
</asp:Content>

