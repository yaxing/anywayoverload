<%@ Page Language="C#" MasterPageFile="~/mode_index.master" AutoEventWireup="true" CodeFile="newBooks.aspx.cs" Inherits="newBooks" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" style="text-align:center;">
        <tr><td>�����ϼ�ͼ��</td></tr>
        <tr><td>
            <asp:GridView ID="gvNewBooks" runat="server" AutoGenerateColumns="False" CellPadding="4"
                ForeColor="Black" GridLines="Vertical" AllowPaging="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" Width="90%">
                <FooterStyle BackColor="#CCCC99" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
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

