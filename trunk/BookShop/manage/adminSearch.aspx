<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminSearch.aspx.cs"  MasterPageFile="~/manage/mode_admin.master"  Inherits="manage_adminSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Height="211px" HorizontalAlign="Center" Width="551px">
        <asp:Label ID="Lb_error" runat="server" ForeColor="Red"></asp:Label><br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="请输入查询信息"></asp:Label><br />
        <br />
        <br />
        <asp:Label ID="Lb_id" runat="server" Text="ID"></asp:Label>
        &nbsp; &nbsp;
        <asp:TextBox ID="TB_id" runat="server" MaxLength="10"></asp:TextBox>
        <asp:RegularExpressionValidator ID="REV_id" runat="server" ControlToValidate="TB_id"
            ErrorMessage="*" ValidationExpression="[1-9]{1}\d{0,9}"></asp:RegularExpressionValidator><br />
        <br />
        <asp:Label ID="Lb_name" runat="server" Text="用户名"></asp:Label>
        &nbsp; &nbsp;
        <asp:TextBox ID="TB_name" runat="server" MaxLength="10"></asp:TextBox>
        <asp:RegularExpressionValidator ID="REV_name" runat="server" ControlToValidate="TB_name"
            ErrorMessage="*" ValidationExpression="[a-zA-Z]{1}\w{0,9}"></asp:RegularExpressionValidator><br />
        <br />
        &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Lb_email" runat="server" Text="Emai"></asp:Label>
        &nbsp; &nbsp;
        <asp:TextBox ID="TB_email" runat="server" MaxLength="20"></asp:TextBox>
        <asp:RegularExpressionValidator ID="REV_email" runat="server" ControlToValidate="TB_email"
            ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><br />
        <br />
        <asp:Label ID="Lb_level" runat="server" Text="等级"></asp:Label>
        &nbsp; &nbsp;&nbsp;
        <asp:DropDownList ID="DDL_level" runat="server">
            <asp:ListItem>不选</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
        </asp:DropDownList><br />
        <br />
        <br />
        <asp:Button ID="Bt_search" runat="server" OnClick="Bt_search_Click" Text="查询" />
        &nbsp; &nbsp;&nbsp;<asp:Button ID="Bt_return" runat="server" OnClick="Bt_return_Click"
            Text="返回" />
        &nbsp;
    </asp:Panel>

</asp:Content>