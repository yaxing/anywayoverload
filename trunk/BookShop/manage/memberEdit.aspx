<%@ Page Language="C#" MasterPageFile="~/manage/mode_admin.master"  CodeFile="memberEdit.aspx.cs" AutoEventWireup="true" Inherits="manage_userSearchResultaspx" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Height="122px" Width="552px">
        &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp;
        &nbsp;&nbsp;<br />
        
        <asp:GridView ID="GV1" runat="server" AllowPaging="True" AutoGenerateColumns="False" HorizontalAlign="Center" AutoGenerateEditButton="True"
        EditCommand ="EditRowsCommand" PageSize="7" OnRowCancelingEdit="GV1_CancelEdit" OnRowEditing="GV1_RowEdit" Height="61px" OnRowUpdating="GV1_RowUpdating" Width="552px" BackColor="Transparent" BorderColor="Transparent" ForeColor="DodgerBlue" OnPageIndexChanging="GV1_PageIndexChanging" >
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <EditItemTemplate>
                        <asp:Label ID="Lb_id" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.id") %>' Width="20px"></asp:Label>
                    </EditItemTemplate>
                    <HeaderStyle BackColor="#C0C0FF" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <asp:Label ID="Label_id" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.id") %>' Width="20px"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="用户名">
                    <EditItemTemplate>
                        <asp:Label ID="Lb_name" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.userName") %>' Width="50px"></asp:Label>
                    </EditItemTemplate>
                    <HeaderStyle BackColor="#C0C0FF" HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemTemplate>
                        <asp:Label ID="Label2_name" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.userName") %>' Width="50px"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="密码">
                    <ItemTemplate>
                        &nbsp;<asp:Label ID="Lb_pwd" runat="server" Width="60px">Password</asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BackColor="#C0C0FF" HorizontalAlign="Center" VerticalAlign="Bottom"
                        Wrap="False" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TB_pwd" runat="server" Text='Password' Width="60px" Wrap="False" MaxLength="12" ForeColor="#FF8000"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV_pwd" runat="server" ControlToValidate="TB_pwd"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RV_pwd" runat="server" ControlToValidate="TB_pwd"
                            ErrorMessage="*" ValidationExpression="[a-zA-Z0-9_]{6,12}"></asp:RegularExpressionValidator>
                        <asp:Label ID="Lb_PrePwd" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.password") %>'
                            Visible="False" Width="35px"></asp:Label>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="确认密码">
                    <EditItemTemplate>
                        <asp:TextBox ID="TB_repwd" runat="server" Text='Password'
                            Width="60px" Wrap="False" MaxLength="12" ForeColor="#FF8000"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV_repwd" runat="server" ControlToValidate="TB_repwd"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="REV_repwd" runat="server" ControlToValidate="TB_repwd"
                            ErrorMessage="*" ValidationExpression="[a-zA-Z0-9_]{6,12}"></asp:RegularExpressionValidator>
                        <asp:CompareValidator ID="CV_repwd" runat="server" ControlToCompare="TB_pwd" ControlToValidate="TB_repwd"
                            ErrorMessage="*"></asp:CompareValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        &nbsp;
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle BackColor="#C0C0FF" HorizontalAlign="Center" VerticalAlign="Bottom"
                        Wrap="True" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="联系电话">
                    <ItemTemplate>
                        &nbsp;
                        <asp:Label ID="Lb_tel" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.tel") %>' Width="70px" Font-Size="Small"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BackColor="#C0C0FF" HorizontalAlign="Center" VerticalAlign="Bottom"
                        Wrap="False" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TB_tel" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.tel") %>' Width="70px" MaxLength="16"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rev3" runat="server" ControlToValidate="TB_tel"
                            Display="Dynamic" ErrorMessage="*" ValidationExpression="(\d{3,4}-?\d{7,8})|(1{1]\d{10})"></asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="电子邮箱">
                    <ItemTemplate>
                        &nbsp;
                        <asp:Label ID="Lb_email" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.email") %>' Width="90px" Font-Size="Small"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle BackColor="#C0C0FF" HorizontalAlign="Center" VerticalAlign="Bottom"
                        Wrap="False" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TB_email" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.email") %>' Width="90px" MaxLength="20"></asp:TextBox><asp:RegularExpressionValidator ID="rev4" runat="server" ControlToValidate="TB_email"
                            Display="Dynamic" ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox ID="CB_del" runat="server" Width="5px" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle BackColor="#C0C0FF" HorizontalAlign="Center" VerticalAlign="Bottom" />
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#FFE0C0" />
        </asp:GridView>
      
        &nbsp;&nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;
        <br />
        <table style="width: 549px">
            <tr>
                <td style="width: 281px">
                </td>
                <td>
                </td>
                <td>
                </td>
                <td style="width: 10446px">
                </td>
                <td style="width: 354px">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 281px">
            <asp:Button ID="Bt_all" runat="server" OnClick="Bt_all_Click"
            Text="全选" /></td>
                <td>
                    <asp:Button ID="Bt_allnot" runat="server" OnClick="Bt_allnot_Click"
            Text="全不选" /></td>
                <td>
                </td>
                <td style="width: 10446px">
                </td>
                <td style="width: 354px">
                    <asp:Button ID="Bt_del" runat="server" OnClick="Bt_del_Click"
                Text="删除" /></td>
                <td>
                    <asp:Button ID="Bt_search" runat="server" OnClick="Bt_search_Click" Text="返回查询" /></td>
            </tr>
        </table>
        <asp:ValidationSummary ID="vs1" runat="server" DisplayMode="BulletList" HeaderText="错误" Visible="False" ShowSummary="False" />
        <br />
        <br />
        &nbsp;&nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        </asp:Panel>
    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<asp:Panel ID="Panel_ret" runat="server" Height="50px"
        HorizontalAlign="Center" Visible="False" Width="553px">
        <br />
        <br />
        <br />
        <asp:Label ID="Lb_ret" runat="server" ForeColor="Blue"></asp:Label>&nbsp;&nbsp;&nbsp;
        &nbsp;<asp:LinkButton ID="LB_search" runat="server" Font-Bold="True" Font-Underline="True"
                ForeColor="#FF8080" OnClick="LB_search_Click">返回查询</asp:LinkButton><br />
    </asp:Panel>
    <asp:Panel ID="Panel_quanxian" runat="server" ForeColor="Red" Height="50px" HorizontalAlign="Center"
        Visible="False" Width="550px">
        <br />
        <br />
        <asp:Label ID="Lb_quanxian" runat="server" Text="你的权限不够，无法访问该页面"></asp:Label></asp:Panel>
</asp:Content>
