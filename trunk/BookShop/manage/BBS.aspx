<%@ Page Language="C#" MasterPageFile="~/manage/mode_admin.master" AutoEventWireup="true" CodeFile="BBS.aspx.cs" Inherits="manage_BBS" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Tittle" runat="server"></asp:Label>
    <asp:GridView ID="BBS" runat="server" CellPadding="4" ForeColor="Black" 
        Width="318px" AutoGenerateColumns="False" BackColor="#CCCCCC" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2" 
        DataKeyNames="ID" onrowdeleting="BBS_RowDeleting" AllowPaging="True" 
        onpageindexchanging="BBS_PageIndexChanging" 
        onrowcancelingedit="BBS_RowCancelingEdit" onrowediting="BBS_RowEditing" 
        onrowupdating="BBS_RowUpdating" PageSize="5" >
        <FooterStyle BackColor="#CCCCCC" />
        <RowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="序号" />
            <asp:BoundField DataField="content" HeaderText="内容" />
            <asp:BoundField DataField="postTime" HeaderText="发布时间" />
            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" 
                CausesValidation="False" />
            <asp:CommandField HeaderText="编辑" ShowEditButton="True" 
                CausesValidation="False" />
        </Columns>
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:Button ID="DeleteAll" runat="server" Text="删除所有" CausesValidation="False" 
        onclick="DeleteAll_Click" />
    &nbsp;
    <asp:Label ID="Updates" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Label ID="BBSContentTitle" runat="server" Text="公告内容"></asp:Label>
    <asp:TextBox ID="BBSContent" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ErrorMessage="RequiredFieldValidator" ControlToValidate="BBSContent">公告的内容不能为空！</asp:RequiredFieldValidator>
    <br />
    <br />
    <br />
    <asp:Button ID="Save" runat="server" Text="保存" onclick="Save_Click" />
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="Reset" runat="server" Text="重置" CausesValidation="False" 
        onclick="Reset_Click" />
    &nbsp;&nbsp;<asp:Label ID="InsertFlags" runat="server"></asp:Label>
    &nbsp;
    <asp:Label ID="UpdateFlags" runat="server"></asp:Label>
    <br />
</asp:Content>

