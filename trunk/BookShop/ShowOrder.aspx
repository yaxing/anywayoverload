<%@ Page Language="C#" MasterPageFile="~/mode_index.master" AutoEventWireup="true"
    CodeFile="ShowOrder.aspx.cs" Inherits="ShowOrder" Title="Untitled Page" %>

<%@ Import Namespace="BsCtrl" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h4 style="margin:30px 40px; background-color:#E0F5F4; text-align:center">
            订单列表
        </h4>
    </div>
    <div>
        <center>
            <table style="width: 100%">
                <tr>
                    <td colspan="3">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand" AllowSorting="True" AllowPaging="True"
                            OnPageIndexChanged="GridView1_PageIndexChanged"
                            PageSize="10" Width="90%" OnSorting="GridView1_Sorting">
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
                                <asp:BoundField DataField="ID" HeaderText="订单编号" SortExpression="ID" ReadOnly="True" />
                                <asp:TemplateField HeaderText="订单日期" SortExpression="orderdatetime">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# String.Format("{0:D}",Eval("orderdatetime"))%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="总金额" SortExpression="amount">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# String.Format("{0:c}",Eval("amount")) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="订单状态" SortExpression="pay">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# BsOrder.ShowOrderStatus(Convert.ToInt32(Eval("pay"))) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl='<%#"OrderDetails.aspx?OrderID="+Eval("ID").ToString() %>'>查看</asp:LinkButton>
                                        <asp:LinkButton ID="lbtnCancel" runat="server" CommandArgument='<%#Eval("ID") %>'
                                            CommandName="CancelOrder" Visible='<%# Convert.ToBoolean((Convert.ToInt32(Eval("pay"))) == 0) %>'
                                            OnClientClick="return confirm('真的要取消该订单吗？')">取消</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle BackColor="#5D7B9D" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <PagerTemplate>
                                <asp:Label ID="ShowPageLb" runat="server"></asp:Label>
                                <asp:LinkButton ID="FirstBt" runat="server" CommandName="First" OnClick="GridView1_PageIndexChanged">首页</asp:LinkButton>
                                <asp:LinkButton ID="PreviousBt" runat="server" CommandName="Previous" OnClick="GridView1_PageIndexChanged">上一页</asp:LinkButton>
                                <asp:LinkButton ID="NextBt" runat="server" CommandName="Next" OnClick="GridView1_PageIndexChanged">下一页</asp:LinkButton>
                                <asp:LinkButton ID="EndBt" runat="server" CommandName="End" OnClick="GridView1_PageIndexChanged">尾页</asp:LinkButton>
                            </PagerTemplate>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </center>
    </div>
</asp:Content>
