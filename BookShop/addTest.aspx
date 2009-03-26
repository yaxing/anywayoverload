<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addTest.aspx.cs" Inherits="addTest" %>
<%@ Import Namespace="BsCtrl" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<body>
    <form id="Form1" runat="server">
        <table width="100%">
            <tr>
                <td>
                    <asp:Button ID="Button1" Text="查看" OnClick=" View_ShoppingCart " runat="server" /></td>
            </tr>
        </table>
        <br/>
        <center>
            <asp:DataGrid ID="MyDataGrid" AutoGenerateColumns="false" CellPadding="2" BorderWidth="1"
                BorderColor="lightgray" Font-Name="Verdana" Font-Size="10pt" GridLines="vertical"
                Width="90%" OnItemCommand="OnItemCommand" runat="server">
                <Columns>
                    <asp:BoundColumn HeaderText="商品ID" DataField="ID" />
                    <asp:BoundColumn HeaderText="名  称" DataField="bookName" HeaderStyle-HorizontalAlign="center" />
                    <asp:BoundColumn HeaderText="价  格" DataField="Price" DataFormatString="{0:c}" HeaderStyle-HorizontalAlign="center"
                        ItemStyle-HorizontalAlign="right" />
                    <asp:ButtonColumn HeaderText="订  购" Text="加入购物车" HeaderStyle-HorizontalAlign="center"
                        ItemStyle-HorizontalAlign="center" CommandName="AddToCart" />
                </Columns>
                <HeaderStyle BackColor="teal" ForeColor="white" Font-Bold="true" />
                <ItemStyle BackColor="white" ForeColor="darkblue" />
                <AlternatingItemStyle BackColor="beige" ForeColor="darkblue" />
            </asp:DataGrid>
        </center>
    </form>
</body>
</html>
