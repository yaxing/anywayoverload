<%@ Page Language="C#" MasterPageFile="~/mode_index.master" AutoEventWireup="true"
    CodeFile="BuyProduct.aspx.cs" Inherits="BuyProduct" Title="Untitled Page" %>
    
<%@ Import Namespace = "BsCtrl"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <asp:Panel ID="Panel1" runat="server" Width="80%">
            <h4>
                <span style="color: #6633ff">��һ��������ȷ��</span></h4>
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
                                ���ﳵ�б�Ϊ�ա�<a href="index.aspx">�����Ʒ</a>
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
                    <asp:BoundField DataField="BookName" HeaderText="����" ReadOnly="True" />
                    <asp:BoundField DataField="Price" HeaderText="�۸�" DataFormatString="{0:c}" />
                    <asp:BoundField DataField="Discount" HeaderText="�ۿ�" />
                    <asp:BoundField DataField="Quantity" HeaderText="����" />
                </Columns>
            </asp:GridView>
            �ϼƣ���
            <asp:Label ID="Total" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="��һ��" /><br />
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Width="80%" Visible="False">
            <span style="color: #6633ff"></span>
            <h3>
                <span style="color: #6633ff">�ڶ�������д�����ջ��ַ</span></h3>
            <p>
                <span style="color: #6633ff"></span>&nbsp;</p>
            <table>
                <tr>
                    <td align="right" style="width: 99px; height: 26px">
                        ��ʵ������</td>
                    <td align="left" style="width: 356px; height: 26px">
                        <asp:TextBox ID="txtName" runat="server" MaxLength="50" Width="163px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName"
                            ErrorMessage="�������ջ���������">*</asp:RequiredFieldValidator>(����)</td>
                </tr>
                <tr>
                    <td align="right" style="width: 99px; height: 26px;">
                        ��ַ��</td>
                    <td align="left" style="width: 356px; height: 26px;">
                        <asp:TextBox ID="txtAddress" MaxLength="200" runat="server" Width="255px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAddress"
                            ErrorMessage="�������͵�ַ����Ϊ��">*</asp:RequiredFieldValidator>(����)</td>
                </tr>
                <tr>
                    <td align="right" style="width: 99px; height: 20px;">
                        Email��</td>
                    <td align="left" style="width: 356px; height: 20px;">
                        <asp:TextBox ID="txtEmail" runat="server" Width="180px"></asp:TextBox><asp:RegularExpressionValidator
                            ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="�����ʽ����ȷ��" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Email��ַ����Ϊ��" ControlToValidate="txtEmail">*</asp:RequiredFieldValidator>(����)</td>
                </tr>
                <tr style="color: #000000">
                    <td align="right" style="width: 99px; height: 26px;">
                        �绰��</td>
                    <td align="left" style="height: 26px; width: 356px;">
                        <asp:TextBox ID="txtMobile" runat="server" Width="180px"></asp:TextBox><asp:RegularExpressionValidator
                            ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMobile"
                            ErrorMessage="�ƶ��绰��ʽ����ȷ��" ValidationExpression="\d{11}">*</asp:RegularExpressionValidator></td>
                </tr>
                <tr style="color: #000000">
                    <td align="right" style="width: 99px; height: 26px;">
                        �ʱࣺ</td>
                    <td align="left" style="height: 26px; width: 356px;">
                        <asp:TextBox ID="txtPost" runat="server" Width="180px"></asp:TextBox><asp:RegularExpressionValidator
                            ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtPost"
                            ErrorMessage="�ʱ��ʽ����ȷ��" ValidationExpression="\d{6}">*</asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td align="right" style="width: 99px; height: 26px;">
                        ֧����ʽ��</td>
                    <td align="left" style="width: 356px; height: 26px;">
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem Value="��������">��������</asp:ListItem>
                            <asp:ListItem Value="����֧��">����֧��</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr style="color: #000000">
                    <td align="left" colspan="2">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" Width="241px" />
                    </td>
                </tr>
                <tr style="color: #000000">
                    <td align="center" colspan="2" height="30" valign="middle">
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="��һ��" />
                        <asp:Button ID="btnSubmit" runat="server" Text="ȷ��" OnClick="btnSubmit_Click" /></td>
                </tr>
            </table>
        </asp:Panel>
    </center>
</asp:Content>
