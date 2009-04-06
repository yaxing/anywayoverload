<%@ Page Language="C#" MasterPageFile="~/manage/mode_admin.master" AutoEventWireup="true" CodeFile="PollDetail.aspx.cs" Inherits="manage_PollDetail" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="PollDetailTitle" runat="server"></asp:Label>
    <asp:GridView ID="PollDetail" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" 
        BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
        DataKeyNames="ID" ForeColor="Black" 
        onpageindexchanging="PollDetail_PageIndexChanging" 
        onrowcancelingedit="PollDetail_RowCancelingEdit" 
        onrowdeleting="PollDetail_RowDeleting" onrowediting="PollDetail_RowEditing" 
        onrowupdating="PollDetail_RowUpdating" PageSize="5">
        <FooterStyle BackColor="#CCCCCC" />
        <RowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="序号" />
            <asp:BoundField DataField="pollID" HeaderText="所属主题序号" />
            <asp:BoundField DataField="optionName" HeaderText="投票选项" />
            <asp:BoundField DataField="counts" HeaderText="计数" />
            <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
        </Columns>
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:Button ID="DelAll" runat="server" CausesValidation="False" 
        onclick="DelAll_Click" Text="删除所有" />
&nbsp;<asp:Label ID="flag1" runat="server"></asp:Label>
    <br />
    <asp:Label ID="PollTheme" runat="server" Text="投票主题"></asp:Label>
    <asp:TextBox ID="PollThemeText" runat="server" Enabled="False"></asp:TextBox>
    <br />
    <asp:Label ID="PollOption" runat="server" Text="投票选项"></asp:Label>
    <asp:TextBox ID="PollOptionText" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="PollOptionText" ErrorMessage="投票选项的内容不能为空！"></asp:RequiredFieldValidator>
    <br />
    <asp:Button ID="Save" runat="server" onclick="Save_Click" Text="保存" />
&nbsp;<asp:Button ID="Reset" runat="server" CausesValidation="False" 
        onclick="Reset_Click" Text="重置" />
&nbsp;
    <asp:Label ID="flag2" runat="server"></asp:Label>
</asp:Content>

