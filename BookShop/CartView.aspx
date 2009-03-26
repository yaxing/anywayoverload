<%@ Page Language="C#" MasterPageFile="~/mode_index.master" AutoEventWireup="true"
    CodeFile="CartView.aspx.cs" Inherits="CartView" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <center>
        &nbsp;我的购物车<asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" BorderWidth="3px" Width="90%" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="ID" ReadOnly="True" Visible="False" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# "~/ReadImage.aspx?BookID=" + Eval("ID").ToString() %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="BookName" HeaderText="书名" ReadOnly="True" />
                <asp:BoundField DataField="Price" HeaderText="价格" DataFormatString="{0:c}" />
                <asp:BoundField DataField="Quantity" HeaderText="数量" />
                <asp:TemplateField HeaderText="加减">
                    <ItemTemplate>
                        <asp:LinkButton ID="addItemBt" runat="server" CommandName="AddItemOne" CommandArgument='<%# Eval("ID") %>'>+</asp:LinkButton>
                        /<asp:LinkButton ID="delItemBt" runat="server" CommandName="DelItemOne" CommandArgument='<%# Eval("ID") %>'>-</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="删除">
                    <ItemTemplate>
                        <asp:LinkButton ID="DelBt" runat="server" CommandName="DelFromCart" OnClientClick="return confirm('真的要从购物车中删除该商品吗？')"
                          CommandArgument='<%# Eval("ID") %>'>删除</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="Total" runat="server" />
        <asp:Button ID="Button1" Text="继续购物" OnClick="Gonoshopping" runat="server" />
    </center>
</asp:Content>
