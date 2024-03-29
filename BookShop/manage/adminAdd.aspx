﻿<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/manage/mode_admin.master"  CodeFile="adminAdd.aspx.cs" Inherits="manage_adminAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function Bt_reset_onclick() {

}

// ]]>
</script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel_ins" runat="server" HorizontalAlign="Center"
        Width="551px">
        <br />
        <br />
        <table style="width: 343px; height: 113px">
            <tr>
                <td style="width: 678px">
                </td>
                <td style="width: 972px">
        </td>
            </tr>
            <tr>
                <td style="width: 678px">
                </td>
                <td style="width: 972px">
        <asp:Label ID="Lb_head" runat="server" Text="输入新管理员信息" Font-Size="Medium" ForeColor="Blue"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                </td>
                <td style="width: 472px">
                </td>
            </tr>
            <tr>
                <td style="width: 678px; height: 18px;">
                </td>
                <td style="width: 972px; height: 18px;">
                </td>
                <td style="width: 472px; height: 18px;">
                </td>
            </tr>
            <tr>
                <td style="width: 678px; height: 38px">
        <asp:Label ID="Lb_name" runat="server" Text="用户名"></asp:Label></td>
                <td style="width: 972px; height: 38px">
        <asp:TextBox ID="TB_name" runat="server" MaxLength="10" Width="120px"></asp:TextBox>&nbsp;
                    <asp:Label ID="Lable1" runat="server" Text="(必填)"></asp:Label></td>
                <td style="width: 472px; height: 38px">
                    <asp:RequiredFieldValidator ID="RFV_name" runat="server" ControlToValidate="TB_name"
            Display="Dynamic" ErrorMessage="用户名不能为空">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="rev2" runat="server" ControlToValidate="TB_name"
            Display="Dynamic" ErrorMessage="用户名格式：5-10位字母和数字，且必须以字母开头" ValidationExpression="[a-zA-Z]{1}\w{4,9}">*</asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="width: 678px; height: 38px">
        <asp:Label ID="Lb_pwd" runat="server" Text="密码"></asp:Label></td>
                <td style="width: 972px; height: 38px">
        <asp:TextBox ID="TB_pwd" runat="server" MaxLength="12" TextMode="Password" Width="120px"></asp:TextBox>&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="(必填)"></asp:Label></td>
                <td style="width: 472px; height: 38px">
        <asp:RegularExpressionValidator ID="REV_pwd" runat="server" ControlToValidate="TB_pwd"
            Display="Dynamic" ErrorMessage="密码格式：6-12位字母、数字、下划线的组合" ValidationExpression="[a-zA-Z0-9_]{6,12}">*</asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RFV_pwd" runat="server" ControlToValidate="TB_pwd"
            Display="Dynamic" ErrorMessage="密码不能为空">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 678px; height: 38px">
        <asp:Label ID="Lb_repwd" runat="server" Text="确认密码"></asp:Label></td>
                <td style="width: 972px; height: 38px">
        <asp:TextBox ID="TB_repwd" runat="server" MaxLength="12" TextMode="Password" Width="120px"></asp:TextBox>&nbsp;
                    <asp:Label ID="Label3" runat="server" Text="(必填)"></asp:Label></td>
                <td style="width: 472px; height: 38px">
        <asp:RequiredFieldValidator ID="RFV_repwd" runat="server" ControlToValidate="TB_repwd"
            Display="Dynamic" ErrorMessage="确认密码不能为空">*</asp:RequiredFieldValidator><asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TB_pwd"
            ControlToValidate="TB_repwd" Display="Dynamic" ErrorMessage="两次输入的密码不一致">*</asp:CompareValidator></td>
            </tr>
            <tr>
                <td style="width: 678px; height: 38px">
        <asp:Label ID="Lb_email" runat="server" Text="Email"></asp:Label></td>
                <td style="width: 972px; height: 38px">
        <asp:TextBox ID="TB_email" runat="server" MaxLength="20" Width="120px"></asp:TextBox>&nbsp;
                    <asp:Label ID="Label4" runat="server" Text="(必填)"></asp:Label>
                </td>
                <td style="width: 472px; height: 38px">
        <asp:RegularExpressionValidator ID="REV_email" runat="server" ControlToValidate="TB_email"
            Display="Dynamic" ErrorMessage="Email格式不正确" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" EnableViewState="False">*</asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RFV_email" runat="server" ControlToValidate="TB_email"
            Display="Dynamic" ErrorMessage="Email不能为空">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 678px; height: 38px">
        <asp:Label ID="Lb_level" runat="server" Text="等级"></asp:Label></td>
                <td style="width: 972px; height: 38px">
                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                    &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;<asp:DropDownList ID="DDL_level" runat="server" Width="118px">
            <asp:ListItem Value="1">1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
        </asp:DropDownList>&nbsp; &nbsp;<asp:Label ID="Label1" runat="server" Text="(必选)"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp;
                </td>
                <td style="width: 472px; height: 38px">
                </td>
            </tr>
            <tr>
                <td style="width: 678px; height: 38px">
                </td>
                <td style="width: 972px; height: 38px">
                    &nbsp;<asp:Button ID="Bt_commit" runat="server" OnClick="Bt_commit_Click" Text="提交" Width="50px" />&nbsp; &nbsp;&nbsp; <input id="Bt_reset" type="reset" onclick="return Bt_reset_onclick()" style="width: 49px" />
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp;
                </td>
                <td style="width: 472px; height: 38px">
                </td>
            </tr>
        </table>
        <br />
        &nbsp;&nbsp;
        <br />
        <asp:ValidationSummary ID="VS" runat="server" />
        <br />
        <asp:Label ID="Lb_error" runat="server" ForeColor="Red" Text="·  用户名已存在"></asp:Label><br />
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
        &nbsp;<br />
        &nbsp; &nbsp; 
        <br />
        &nbsp; 
        <br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp;
        <br />
        <br />
        <br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp;
    </asp:Panel>
    <asp:Panel ID="Panel_ret" runat="server" Height="52px" HorizontalAlign="Center" Width="550px">
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="Lb_ret" runat="server" Font-Size="Medium" ForeColor="Blue"></asp:Label><br />
        <br />
        <br />
        <asp:LinkButton ID="LB_ins" runat="server" OnClick="LB_ins_Click" Font-Size="Medium" ForeColor="Goldenrod" Font-Underline="True">继续添加</asp:LinkButton>
        &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;<asp:LinkButton ID="LB_default" runat="server" OnClick="LB_default_Click" Font-Size="Medium" ForeColor="Goldenrod" Font-Underline="True">返回“用户管理”</asp:LinkButton></asp:Panel>
    <asp:Panel ID="Panel_quanxian" runat="server" ForeColor="Red" Height="50px" HorizontalAlign="Center"
        Visible="False" Width="550px">
        <br />
        <br />
        <asp:Label ID="Lb_quanxian" runat="server" Text="你的权限不够，无法访问该页面"></asp:Label></asp:Panel>


</asp:Content>