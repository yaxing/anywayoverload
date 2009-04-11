<%@ Page Language="C#" MasterPageFile="~/mode_index.master" AutoEventWireup="true"
    CodeFile="OrderDetails.aspx.cs" Inherits="OrderDetails" Title="Untitled Page" %>

<%@ Import Namespace="BsCtrl" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h4>
            订单明细信息</h4>
    </div>
    <h4 style="margin: 30px 40px; background-color: #E0F5F4; text-align: center">
        商品列表：
    </h4>
    <div style="margin: 20px auto; border-bottom:1px dashed #999999">
        <asp:GridView ID="OrderDetailsView" runat="server" AutoGenerateColumns="False" Width="80%"
            BorderWidth="0px">
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
                <asp:TemplateField HeaderText="编号">
                    <ItemTemplate>
                        <div style="margin-left: 0px; margin-top: 5px; width: 50px">
                            <div class="shadow">
                                <div>
                                    <asp:Image ID="Image1" Width="80px" Height="100px" runat="server" BorderWidth="1px"
                                        BorderStyle="Solid" ImageUrl='<%#Eval("coverPath") %>' />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="书名">
                    <ItemTemplate>
                        <asp:Label ID="lblBookName" runat="server" Text='<%# Eval("bookName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="数量">
                    <ItemTemplate>
                        <asp:Label ID="lblQty" runat="server" Text='<%# Eval("number")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="折扣价">
                    <ItemTemplate>
                        <asp:Label ID="lblUnitPrice" runat="server" Text='<%# String.Format("{0:c}",Convert.ToDouble(Eval("discount"))*Convert.ToDouble(Eval("price"))) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="金额">
                    <ItemTemplate>
                        <asp:Label ID="lblAmount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"price","{0:c}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div style="margin:20px auto">
            合计：
            <asp:Label ID="lblAmountFinish" runat="server"></asp:Label>
        </div>
    </div>
    <table>
        <tr>
            <td align="left" style="width: 99px">
                订单配送地址：</td>
            <td align="left" style="width: 356px">
                <asp:Label ID="lblAddress" runat="server" Width="295px"></asp:Label>
                &nbsp;
            </td>
        </tr>
        <tr style="color: #000000">
            <td align="left" style="width: 99px; height: 26px">
                移动电话：</td>
            <td align="left" style="width: 356px; height: 26px">
                <asp:Label ID="lblMobile" runat="server" Width="293px"></asp:Label>
            </td>
        </tr>
        <tr style="color: #000000">
            <td align="left" style="width: 99px; height: 26px">
                状态：</td>
            <td align="left" style="width: 356px; height: 26px">
                <asp:Label ID="lblStatus" runat="server" Width="293px"></asp:Label></td>
        </tr>
        <tr style="color: #000000">
            <td align="left" style="width: 99px; height: 26px">
                订单日期：</td>
            <td align="left" style="width: 356px; height: 26px">
                <asp:Label ID="lblOrderDate" runat="server" Width="293px"></asp:Label></td>
        </tr>
    </table>
</asp:Content>
