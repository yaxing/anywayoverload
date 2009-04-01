<%@ Page Language="C#" MasterPageFile="~/mode_index.master" AutoEventWireup="true"
    CodeFile="ShowOrder.aspx.cs" Inherits="ShowOrder" Title="Untitled Page" %>

<%@ Import Namespace="BsCtrl" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h4>
            订单列表
        </h4>
    </div>
    <div>
        <center>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand">
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <EmptyDataTemplate>
                    <table width="100%">
                        <tr>
                            <td align="center" style="height: 82px">
                                订单列表为空。<a href="index.aspx">浏览商品</a>
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="订单编号" ReadOnly="True" />
                    <asp:TemplateField HeaderText="订单日期">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# (Eval("orderdatetime"))%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="总金额">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("amount") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="订单状态">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# BsOrder.ShowOrderStatus(Convert.ToInt32(Eval("pay"))) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl='<%#"OrderDetails.aspx?OrderID="+Eval("ID").ToString() %>'>查看</asp:LinkButton>
                            <asp:LinkButton ID="lbtnCancel" runat="server" CommandArgument='<%#Eval("ID") %>'
                                CommandName="CancelOrder"  Visible = '<%# !Convert.ToBoolean(Eval("pay")) %>' OnClientClick="return confirm('真的要删除该订单吗？')">删除</asp:LinkButton>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
            &nbsp;
        </center>
    </div>
</asp:Content>
