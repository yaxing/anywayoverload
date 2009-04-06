<%@ Page Language="C#" MasterPageFile="~/mode_index.master" AutoEventWireup="true"
    CodeFile="CartView.aspx.cs" Inherits="CartView" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="JavaScript">

<!--

function makevisible(cur,which){

if (which==0)

cur.filters.alpha.opacity=100

else

cur.filters.alpha.opacity=20

}



-->



    </script>

    <table width="100%">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <center>
        &nbsp;我的购物车
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
            BorderWidth="3px" Width="90%" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EmptyDataTemplate>
                <table width="100%">
                    <tr>
                        <td align="center" style="height: 82px">
                            购物车列表为空。<a href="index.aspx">浏览商品</a>
                        </td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <Columns>
                <asp:BoundField DataField="ID" ReadOnly="True" Visible="False" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%#Eval("Cover") %>'
                            PostBackUrl='<%# "bookInfo.aspx?bookID="+Eval("ID").ToString() %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="BookName" HeaderText="书名" ReadOnly="True" />
                <asp:BoundField DataField="Price" HeaderText="价格" DataFormatString="{0:c}" />
                <asp:BoundField DataField="Discount" HeaderText="折扣" />
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
        <asp:Label ID="Total" runat="server" /></center>
    <center>
        &nbsp;
        <asp:ImageButton ID="ImageButton2" runat="server" style="filter:alpha(opacity=20)" onMouseOver="makevisible(this,0)" onMouseOut="makevisible(this,1)" OnClick="Gonoshopping" ImageUrl="~/Images/goOn.gif"
            Width="100px" />
        <asp:ImageButton ID="ImageButton3" runat="server" style="filter:alpha(opacity=20)" onMouseOver="makevisible(this,0)" onMouseOut="makevisible(this,1)" OnClick="Check_out" ImageUrl="~/Images/confirm.gif"
            Width="100px" />
    </center>
</asp:Content>
