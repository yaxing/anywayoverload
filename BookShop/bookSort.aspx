<%@ Page Language="C#" MasterPageFile="~/mode_classify.master" AutoEventWireup="true" CodeFile="bookSort.aspx.cs" Inherits="bookSort" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="width:100%;text-align:center">
  <table style="width:100%">
  <tr><td style="height: 18px">
      </td></tr>
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
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblClassName" runat="server" Text="Label"></asp:Label>
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
                                            <asp:Label ID="Label4" runat="server" Font-Size="12px" ForeColor="#878787" Text='<%# "剩余数量: "+ Eval("available") %>'></asp:Label></td>
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
    </asp:GridView>
    </td></tr>
  </table>
    </div>
</asp:Content>

