<%@ Page Language="C#" MasterPageFile="~/mode_index.master" AutoEventWireup="true"
    CodeFile="BuyProduct.aspx.cs" Inherits="BuyProduct" Title="Untitled Page" %>
    
<%@ Import Namespace = "BsCtrl"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <asp:Panel ID="Panel1" runat="server" Width="80%">
            <h4>
                <span style="color: #6633ff">第一步：订单确认</span></h4>
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <br />
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                BorderWidth="3px" Width="90%" AutoGenerateColumns="False">
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
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%#Eval("Cover") %>' PostBackUrl='<%# "bookInfo.aspx?bookID="+Eval("ID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="BookName" HeaderText="书名" ReadOnly="True" />
                    <asp:BoundField DataField="Price" HeaderText="价格" DataFormatString="{0:c}" />
                    <asp:BoundField DataField="Discount" HeaderText="折扣" />
                    <asp:BoundField DataField="Quantity" HeaderText="数量" />
                </Columns>
            </asp:GridView>
            合计：￥
            <asp:Label ID="Total" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="下一步" /><br />
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Width="80%" Visible="False">
            <span style="color: #6633ff"></span>
            <h3>
                <span style="color: #6633ff">第二步：填写您的收获地址</span></h3>
            <p>
                <span style="color: #6633ff"></span>&nbsp;</p>
            <table>
                <tr>
                    <td align="right" style="width: 99px; height: 26px">
                        真实姓名：</td>
                    <td align="left" style="width: 356px; height: 26px">
                        <asp:TextBox ID="txtName" runat="server" MaxLength="50" Width="163px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName"
                            ErrorMessage="请输入收货人姓名。">*</asp:RequiredFieldValidator>(必填)</td>
                </tr>
                <tr>
                    <td align="right" style="width: 99px; height: 26px;">
                        地址：</td>
                    <td align="left" style="width: 356px; height: 26px;">
                        <asp:TextBox ID="txtAddress" MaxLength="200" runat="server" Width="255px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAddress"
                            ErrorMessage="订单配送地址不能为空">*</asp:RequiredFieldValidator>(必填)</td>
                </tr>
                <tr>
                    <td align="right" style="width: 99px; height: 20px;">
                        Email：</td>
                    <td align="left" style="width: 356px; height: 20px;">
                        <asp:TextBox ID="txtEmail" runat="server" Width="180px"></asp:TextBox><asp:RegularExpressionValidator
                            ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="邮箱格式不正确。" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Email地址不能为空" ControlToValidate="txtEmail">*</asp:RequiredFieldValidator>(必填)</td>
                </tr>
                <tr style="color: #000000">
                    <td align="right" style="width: 99px; height: 26px;">
                        电话：</td>
                    <td align="left" style="height: 26px; width: 356px;">
                        <asp:TextBox ID="txtMobile" runat="server" Width="180px"></asp:TextBox><asp:RegularExpressionValidator
                            ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMobile"
                            ErrorMessage="移动电话格式不正确。" ValidationExpression="\d{11}">*</asp:RegularExpressionValidator></td>
                </tr>
                <tr style="color: #000000">
                    <td align="right" style="width: 99px; height: 26px;">
                        邮编：</td>
                    <td align="left" style="height: 26px; width: 356px;">
                        <asp:TextBox ID="txtPost" runat="server" Width="180px"></asp:TextBox><asp:RegularExpressionValidator
                            ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtPost"
                            ErrorMessage="邮编格式不正确。" ValidationExpression="\d{6}">*</asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td align="right" style="width: 99px; height: 26px;">
                        支付方式：</td>
                    <td align="left" style="width: 356px; height: 26px;">
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem Value="货到付款">货到付款</asp:ListItem>
                            <asp:ListItem Value="在线支付">在线支付</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr style="color: #000000">
                    <td align="left" colspan="2">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" Width="241px" />
                    </td>
                </tr>
                <tr style="color: #000000">
                    <td align="center" colspan="2" height="30" valign="middle">
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="上一步" />
                        <asp:Button ID="btnSubmit" runat="server" Text="确认" OnClick="btnSubmit_Click" /></td>
                </tr>
            </table>
        </asp:Panel>
    </center>
</asp:Content>
