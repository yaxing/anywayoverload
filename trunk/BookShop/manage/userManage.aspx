<%@ Page Language="C#"  MasterPageFile="~/manage/mode_admin.master"  AutoEventWireup="true" CodeFile="userManage.aspx.cs" Inherits="manage_userManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;
    <asp:Panel ID="Panel_content" runat="server" Height="111px" HorizontalAlign="Center"
        Width="555px">
        <br />
        <br />
        <br />
        <br />
        <table style="width: 385px; height: 70px">
            <tr>
                <td style="width: 184px">
                </td>
                <td style="width: 186px">
                </td>
            </tr>
            <tr>
                <td style="width: 184px">
        <asp:Label ID="Lb_member" runat="server" Text="对普通用户的操作：" Font-Bold="True" Font-Size="Large"></asp:Label></td>
                <td style="width: 186px">
        <asp:LinkButton ID="LB_searchMember" runat="server" OnClick="LB_searchMember_Click" Font-Size="Medium" ForeColor="#8080FF">查询或修改用户信息</asp:LinkButton></td>
            </tr>
            <tr>
                <td style="width: 184px; height: 82px">
                </td>
                <td style="width: 186px; height: 82px">
                </td>
            </tr>
            <tr>
                <td style="width: 184px; height: 23px">
        <asp:Label ID="Lb_admin" runat="server" Text="对管理员的操作：" Font-Bold="True" Font-Size="Large"></asp:Label></td>
                <td style="width: 186px; height: 23px">
        <asp:LinkButton ID="LB_addAdmin" runat="server" OnClick="LB_addAdmin_Click" Font-Size="Medium" ForeColor="#8080FF">1. 添加管理员</asp:LinkButton></td>
            </tr>
            <tr>
                <td style="width: 184px">
                </td>
                <td style="width: 186px">
                </td>
            </tr>
            <tr>
                <td style="width: 184px">
                </td>
                <td style="width: 186px">
        <asp:LinkButton ID="LB_searchAdmin" runat="server" OnClick="LB_searchAdmin_Click" Font-Size="Medium" ForeColor="#8080FF">2. 查询或修改管理员信息</asp:LinkButton></td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        &nbsp; &nbsp;
        &nbsp;
        &nbsp; &nbsp;&nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp;<br />
        </asp:Panel>
    &nbsp; &nbsp;&nbsp; &nbsp;<asp:Panel ID="Panel_ret" runat="server" Height="37px" HorizontalAlign="Center"
        Width="554px">
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="Lb_ret" runat="server" ForeColor="Red" Font-Size="Medium"></asp:Label></asp:Panel>


</asp:Content>