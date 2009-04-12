<%@ Page Language="C#" MasterPageFile="~/manage/mode_admin.master"  CodeFile="memberSearch.aspx.cs" AutoEventWireup="true" Inherits="manage_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center" Height="407px" Width="567px">
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<table
            style="width: 141px; height: 36px">
            <tr>
                <td>
        <asp:Label ID="Lb_ret" runat="server" ForeColor="Red" Width="194px" Font-Size="Small"></asp:Label></td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="Label1" runat="server" Font-Size="12pt" ForeColor="#0066FF" Text="请输入查询条件"></asp:Label></td>
            </tr>
        </table>
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<table style="width: 409px; height: 74px">
            <tr>
                <td style="width: 350px; height: 16px">
        <asp:Label ID="Label_ID" runat="server" Font-Bold="True" Text="用户ID" Width="65px"></asp:Label></td>
                <td style="width: 295px; height: 16px">
                    <asp:TextBox ID="TB_ID" runat="server" ForeColor="Black" MaxLength="10" ></asp:TextBox></td>
                <td style="width: 172px; height: 16px">
        <asp:RegularExpressionValidator ID="rev1" runat="server" ControlToValidate="TB_ID"
            ErrorMessage="格式不正确" ValidationExpression="[1-9]{1}\d{0,9}" Display="Dynamic"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="width: 350px">
                    <asp:Label ID="Label_Name" runat="server" Font-Bold="True" Text="用户名" Width="61px"></asp:Label></td>
                <td style="width: 295px">
                    <asp:TextBox ID="TB_Name" runat="server" MaxLength="10"></asp:TextBox></td>
                <td style="width: 172px">
        <asp:RegularExpressionValidator ID="rev2" runat="server" ControlToValidate="TB_Name"
            ErrorMessage="格式不正确" ValidationExpression="[a-zA-Z]{1}\w{0,9}" Display="Dynamic"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="width: 350px; height: 20px">
        <asp:Label ID="Label_TEL" runat="server" Font-Bold="True" Text="TEL" Width="48px"></asp:Label></td>
                <td style="width: 295px; height: 20px">
        <asp:TextBox ID="TB_TEL" runat="server" CausesValidation="True" MaxLength="16"></asp:TextBox></td>
                <td style="width: 172px; height: 20px">
        <asp:RegularExpressionValidator runat="server" ID="rev3" ControlToValidate="TB_TEL" ValidationExpression="(\d{3,4}-?\d{7,8})|(1{1]\d{10})" ErrorMessage="格式不正确" Display="Dynamic" /></td>
            </tr>
            <tr>
                <td style="width: 350px">
        <asp:Label ID="Label_Email" runat="server" Font-Bold="True" Text="Email" Width="57px"></asp:Label></td>
                <td style="width: 295px">
        <asp:TextBox ID="TB_Email" runat="server" MaxLength="20"  ></asp:TextBox></td>
                <td style="width: 172px">
        <asp:RegularExpressionValidator runat="server" ID="rev4" ControlToValidate="TB_Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="格式不正确" Display="Dynamic"  /></td>
            </tr>
        </table>
        <br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        &nbsp; &nbsp;
        <br />
        <br />
        <asp:Button ID="Bt_search" runat="server" Font-Bold="True"  Text="查询" Width="55px" OnClick="Bt_search_Click" />
        &nbsp; &nbsp;<asp:Button ID="Bt_return" runat="server" OnClick="Bt_return_Click"
            Text="返回" Width="55px" Font-Bold="True" /><br />
        &nbsp;<br />
        
        <asp:ValidationSummary ID="vs1" runat="server" DisplayMode="BulletList" HeaderText="错误" Visible="False" ShowSummary="False" />
        </asp:Panel>
    <asp:Panel ID="Panel_quanxian" runat="server" ForeColor="Red" Height="50px" HorizontalAlign="Center"
        Visible="False" Width="550px">
        <br />
        <br />
        <asp:Label ID="Lb_quanxian" runat="server" Text="你的权限不够，无法访问该页面"></asp:Label></asp:Panel>

</asp:Content>
