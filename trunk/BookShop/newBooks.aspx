<%@ Page Language="C#" MasterPageFile="~/mode_index.master" AutoEventWireup="true" CodeFile="newBooks.aspx.cs" Inherits="newBooks" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" style="text-align:center;">
        <tr><td>�����ϼ�ͼ��</td></tr>
        <tr><td>
            <asp:GridView ID="gvNewBooks" runat="server" AutoGenerateColumns="False" CellPadding="4"
                ForeColor="#333333" GridLines="None" AllowPaging="True">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <EditRowStyle BackColor="#2461BF" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="bookName" HeaderText="����" />
                    <asp:BoundField DataField="author" HeaderText="����" />
                    <asp:BoundField DataField="publisher" HeaderText="������" />
                    <asp:BoundField DataField="indatetime" HeaderText="���ʱ��" />
                    <asp:BoundField DataField="className" HeaderText="����" />
                    <asp:BoundField DataField="price" HeaderText="�۸�" />
                </Columns>
            </asp:GridView>
        </td></tr>
    </table>
</asp:Content>

