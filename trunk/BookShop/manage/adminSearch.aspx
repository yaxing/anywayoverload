<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminSearch.aspx.cs"  MasterPageFile="~/manage/mode_admin.master"  Inherits="manage_adminSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center" Width="551px">
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="请输入查询信息" Font-Size="Medium" ForeColor="Blue"></asp:Label><br />
        <br />
        <br />
        <table style="width: 323px; height: 78px">
            <tr>
                <td style="height: 20px; width: 119px;">
        <asp:Label ID="Lb_id" runat="server" Text="ID"></asp:Label></td>
                <td style="height: 20px">
        <asp:TextBox ID="TB_id" runat="server" MaxLength="10"></asp:TextBox></td>
                <td style="height: 20px">
        <asp:RegularExpressionValidator ID="REV_id" runat="server" ControlToValidate="TB_id"
            ErrorMessage="ID格式：数字" ValidationExpression="[1-9]{1}\d{0,9}" Display="Dynamic">*</asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="width: 119px">
        <asp:Label ID="Lb_name" runat="server" Text="用户名"></asp:Label></td>
                <td>
        <asp:TextBox ID="TB_name" runat="server" MaxLength="10"></asp:TextBox></td>
                <td>
        <asp:RegularExpressionValidator ID="REV_name" runat="server" ControlToValidate="TB_name"
            ErrorMessage="用户名格式：5-10位字母和数字，且必须以字母开头" ValidationExpression="[a-zA-Z]{1}\w{0,9}" Display="Dynamic">*</asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="width: 119px; height: 20px">
        <asp:Label ID="Lb_email" runat="server" Text="Emai"></asp:Label></td>
                <td style="height: 20px">
        <asp:TextBox ID="TB_email" runat="server" MaxLength="20"></asp:TextBox></td>
                <td style="height: 20px">
        <asp:RegularExpressionValidator ID="REV_email" runat="server" ControlToValidate="TB_email"
            ErrorMessage="Email格式不正确" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic">*</asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="width: 119px">
        <asp:Label ID="Lb_level" runat="server" Text="等级"></asp:Label></td>
                <td>
        <asp:DropDownList ID="DDL_level" runat="server">
            <asp:ListItem>不选</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
        </asp:DropDownList>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp;</td>
                <td>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:Button ID="Bt_search" runat="server" OnClick="Bt_search_Click" Text="查询" Width="52px" />
        &nbsp; &nbsp;&nbsp;&nbsp;<input id="Reset1" style="width: 52px" type="reset" value="重置" /><br />
        <br />
        <br />
        <asp:Label ID="Lb_error" runat="server" ForeColor="Red"></asp:Label><br />
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <br />
        <br />
    </asp:Panel>
    <asp:Panel ID="Panel_quanxian" runat="server" ForeColor="Red" Height="50px" HorizontalAlign="Center"
        Visible="False" Width="550px">
        <br />
        <br />
        <asp:Label ID="Lb_quanxian" runat="server" Text="你的权限不够，无法访问该页面"></asp:Label></asp:Panel>

</asp:Content>