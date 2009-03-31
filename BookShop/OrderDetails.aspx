<%@ Page Language="C#" MasterPageFile="~/mode_index.master" AutoEventWireup="true"
    CodeFile="OrderDetails.aspx.cs" Inherits="OrderDetails" Title="Untitled Page" %>

<%@ Import Namespace="BsCtrl" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h4>
            ������ϸ��Ϣ</h4>
    </div>
    <div>
        <table style="font-size: 12px; font-family: ����" width="100%">
            <tr>
                <td align="left" colspan="2">
                    <table width="100%">
                        <tr>
                            <td>
                                ��Ʒ�б�</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="OrderDetailsView" runat="server" AutoGenerateColumns="False" Width="100%">
                                    <EmptyDataTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td align="center" style="height: 82px">
                                                    �����б�Ϊ�ա�<a href="index.aspx">�����Ʒ</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField HeaderText="���">
                                            <ItemTemplate>
                                                <asp:Image ID="Image1" Width="40px" Height="30px" runat="server" ImageUrl='' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="����">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBookName" runat="server" Text='<%# Eval("bookName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="����">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQty" runat="server" Text='<%# Eval("number")%>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="�ۿۼ�">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUnitPrice" runat="server" Text='<%# String.Format("{0:c}",Convert.ToDouble(Eval("discount"))*Convert.ToDouble(Eval("price"))) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="���">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"price","{0:c}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <table style="width: 410px">
                                    <tr>
                                        <td align="right" colspan="2" style="height: 16px">
                                            �ϼƣ�
                                        <asp:Label ID="lblAmountFinish" runat="server"></asp:Label>&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 99px">
                    �������͵�ַ��</td>
                <td align="left" style="width: 356px">
                    <asp:Label ID="lblAddress" runat="server" Width="295px"></asp:Label>
                    &nbsp;
                </td>
            </tr>
            <tr style="color: #000000">
                <td align="left" style="width: 99px; height: 26px">
                    �ƶ��绰��</td>
                <td align="left" style="width: 356px; height: 26px">
                    <asp:Label ID="lblMobile" runat="server" Width="293px"></asp:Label>
                </td>
            </tr>
            <tr style="color: #000000">
                <td align="left" style="width: 99px; height: 26px">
                    ״̬��</td>
                <td align="left" style="width: 356px; height: 26px">
                    <asp:Label ID="lblStatus" runat="server" Width="293px"></asp:Label></td>
            </tr>
            <tr style="color: #000000">
                <td align="left" style="width: 99px; height: 26px">
                    �������ڣ�</td>
                <td align="left" style="width: 356px; height: 26px">
                    <asp:Label ID="lblOrderDate" runat="server" Width="293px"></asp:Label></td>
            </tr>
            <tr style="color: #000000">
                <td align="left" colspan="2">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
