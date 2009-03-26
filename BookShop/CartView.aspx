<%@ Page Language="C#" MasterPageFile="~/mode_index.master" AutoEventWireup="true"
    CodeFile="CartView.aspx.cs" Inherits="CartView" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td>
                <asp:Button ID="Button1" Text="继续购物" OnClick="Gonoshopping" runat="server" />
            </td>
        </tr>
    </table>
    <br />
    <center>
        <asp:DataGrid ID="MyDataGrid" AutoGenerateColumns="false" CellPadding="2" BorderWidth="1"
            BorderColor="lightgray" Font-Name="Verdana" Font-Size="10pt" GridLines="Vertical"
            Width="90%" OnItemCommand="OnItemCommand" runat="server">
            <Columns>
                <asp:BoundColumn HeaderText="图书ID" DataField="ID" />
                <asp:BoundColumn HeaderText="书  名" DataField="BookName" />
                <asp:BoundColumn HeaderText="价  格" DataField="Price" DataFormatString="{0:c}" HeaderStyle-HorizontalAlign="center"
                    ItemStyle-HorizontalAlign="right" />
                <asp:BoundColumn HeaderText="数量" DataField="Quantity" HeaderStyle-HorizontalAlign="center"
                    ItemStyle-HorizontalAlign="center" />
                <asp:ButtonColumn HeaderText="删除" Text="删除" HeaderStyle-HorizontalAlign="center"
                    ItemStyle-HorizontalAlign="center" CommandName="DelFromCart" />
            </Columns>
            <HeaderStyle BackColor="teal" ForeColor="white" Font-Bold="true" />
            <ItemStyle BackColor="white" ForeColor="darkblue" />
            <AlternatingItemStyle BackColor="beige" ForeColor="darkblue" />
        </asp:DataGrid>
    </center>
    <h3>
        <asp:Label ID="Total" runat="server" /></h3>
</asp:Content>
