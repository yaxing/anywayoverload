<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/manage/mode_admin.master"  CodeFile="adminAdd.aspx.cs" Inherits="manage_adminAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel_ins" runat="server" Height="223px" HorizontalAlign="Center"
        Width="550px">
        <br />
        <asp:Label ID="Label1" runat="server" Text="输入新管理员信息"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Lb_name" runat="server" Text="用户名"></asp:Label>
        &nbsp; &nbsp; &nbsp;
        <asp:TextBox ID="TB_name" runat="server" MaxLength="10"></asp:TextBox>
        <asp:RegularExpressionValidator ID="rev2" runat="server" ControlToValidate="TB_name"
            Display="Dynamic" ErrorMessage="*" ValidationExpression="[a-zA-Z]{1}\w{0,9}"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RFV_name" runat="server" ControlToValidate="TB_name"
            Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator><br />
        <br />
        <asp:Label ID="Lb_pwd" runat="server" Text="密码"></asp:Label>
        &nbsp; &nbsp; &nbsp;
        <asp:TextBox ID="TB_pwd" runat="server" MaxLength="32" TextMode="Password"></asp:TextBox>
        <asp:RegularExpressionValidator ID="REV_pwd" runat="server" ControlToValidate="TB_pwd"
            Display="Dynamic" ErrorMessage="*" ValidationExpression="[a-zA-Z0-9_]*"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RFV_pwd" runat="server" ControlToValidate="TB_pwd"
            Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator><br />
        <br />
        <asp:Label ID="Lb_repwd" runat="server" Text="确认密码"></asp:Label>
        &nbsp; &nbsp; &nbsp;
        <asp:TextBox ID="TB_repwd" runat="server" MaxLength="32" TextMode="Password"></asp:TextBox>
        <asp:RegularExpressionValidator ID="REV_repwd" runat="server" ControlToValidate="TB_repwd"
            Display="Dynamic" ErrorMessage="*" ValidationExpression="[a-zA-Z0-9_]*"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RFV_repwd" runat="server" ControlToValidate="TB_repwd"
            Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TB_pwd"
            ControlToValidate="TB_repwd" Display="Dynamic" ErrorMessage="*"></asp:CompareValidator><br />
        <br />
        <asp:Label ID="Lb_email" runat="server" Text="Email"></asp:Label>
        &nbsp; &nbsp; &nbsp;
        <asp:TextBox ID="TB_email" runat="server" MaxLength="20"></asp:TextBox>
        <asp:RegularExpressionValidator ID="REV_email" runat="server" ControlToValidate="TB_email"
            Display="Dynamic" ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RFV_email" runat="server" ControlToValidate="TB_name"
            Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator><br />
        <br />
        <asp:Label ID="Lb_level" runat="server" Text="等级"></asp:Label>
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:DropDownList ID="DDL_level" runat="server">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
        </asp:DropDownList><br />
        <br />
        <br />
        <br />
        <asp:Button ID="Bt_commit" runat="server" OnClick="Bt_commit_Click" Text="提交" />
        &nbsp; &nbsp;<asp:Button ID="Bt_reset" runat="server" Text="重置" /></asp:Panel>
    <asp:Panel ID="Panel_ret" runat="server" Height="52px" HorizontalAlign="Center" Width="550px">
        <br />
        <asp:Label ID="Lb_ret" runat="server"></asp:Label><br />
        <br />
        <br />
        <asp:LinkButton ID="LB_ins" runat="server" OnClick="LB_ins_Click">继续添加</asp:LinkButton>
        &nbsp; &nbsp;&nbsp; &nbsp;<asp:LinkButton ID="LB_default" runat="server" OnClick="LB_default_Click">返回“用户管理”</asp:LinkButton></asp:Panel>


</asp:Content>