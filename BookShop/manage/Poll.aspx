<%@ Page Language="C#" MasterPageFile="~/manage/mode_admin.master" AutoEventWireup="true" CodeFile="Poll.aspx.cs" Inherits="manage_Poll" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="PollTitle" runat="server"></asp:Label>
    <asp:GridView ID="Poll" runat="server" AutoGenerateColumns="False" 
        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
        CellPadding="4" CellSpacing="2" ForeColor="Black" Width="438px" 
        AllowPaging="True" DataKeyNames="ID" 
        onpageindexchanging="Poll_PageIndexChanging" 
        onrowcancelingedit="Poll_RowCancelingEdit" onrowdeleting="Poll_RowDeleting" 
        onrowediting="Poll_RowEditing" onrowupdating="Poll_RowUpdating" PageSize="5">
        <FooterStyle BackColor="#CCCCCC" />
        <RowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="序号" />
            <asp:BoundField DataField="theme" HeaderText="主题" />
            <asp:BoundField DataField="introduce" HeaderText="简介" />
            <asp:BoundField DataField="available" HeaderText="状态" />
            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
            <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" 
                DataNavigateUrlFormatString="pollDetail.aspx?ID={0}" HeaderText="查看详细" 
                Text="详细信息" />
        </Columns>
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:Button ID="DeleteAll" runat="server" Text="删除全部" CausesValidation="False" 
        onclick="DeleteAll_Click" />
    <asp:Label ID="availableFlags" runat="server"></asp:Label>
    <br />
    <asp:Label ID="Theme" runat="server" Text="投票主题"></asp:Label>
    <asp:TextBox ID="ThemeText" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="ThemeText" ErrorMessage="主题不能为空"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="PollContent" runat="server" Text="投票简介"></asp:Label>
    <asp:TextBox ID="introText" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="introText" ErrorMessage="简介不能为空"></asp:RequiredFieldValidator>
    <br />
    <asp:RadioButton ID="Able" runat="server" GroupName="State" Text="可用" />
    <asp:RadioButton ID="unAble" runat="server" Checked="True" GroupName="State" 
        Text="不可用" />
    <br />
    <asp:Button ID="Save" runat="server" Text="保存" onclick="Save_Click" />
    &nbsp;
    <asp:Button ID="Reset" runat="server" Text="重置" CausesValidation="False" 
        onclick="Reset_Click" />
    <asp:Label ID="availablenum" runat="server"></asp:Label>
</asp:Content>

