<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminEdit.aspx.cs"  MasterPageFile="~/manage/mode_admin.master"  Inherits="manage_adminEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Height="122px" Width="552px">
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:GridView ID="GV1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            AutoGenerateEditButton="True" BackColor="Transparent" BorderColor="Transparent"
            EditCommand="EditRowsCommand" ForeColor="DodgerBlue" Height="61px" HorizontalAlign="Center"
            OnPageIndexChanging="GV1_PageIndexChanging" OnRowCancelingEdit="GV1_CancelEdit"
            OnRowEditing="GV1_RowEdit" OnRowUpdating="GV1_RowUpdating" PageSize="7" Width="552px">
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <EditItemTemplate>
                        <asp:Label ID="Lb_id" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.id") %>'
                            Width="20px"></asp:Label>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle BackColor="#C0C0FF" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <asp:Label ID="Label_id" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.id") %>'
                            Width="20px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="管理员名">
                    <EditItemTemplate>
                        <asp:Label ID="Lb_name" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.userName") %>'
                            Width="50px"></asp:Label>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle BackColor="#C0C0FF" HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemTemplate>
                        <asp:Label ID="Label2_name" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.userName") %>' Width="50px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="密码">
                    <EditItemTemplate>
                        <asp:TextBox ID="TB_pwd" runat="server"
                            Width="60px" Wrap="False" MaxLength="12" ForeColor="#FF8000" Text="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV_pwd" runat="server" Display="Dynamic" ErrorMessage="*" ControlToValidate="TB_pwd"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RV_pwd" runat="server" ControlToValidate="TB_pwd"
                            ErrorMessage="*" ValidationExpression="[a-zA-Z0-9_]{6,12}"></asp:RegularExpressionValidator>
                        <asp:Label ID="Lb_PrePwd" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.password") %>'
                            Visible="False" Width="35px"></asp:Label>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle BackColor="#C0C0FF" HorizontalAlign="Center" VerticalAlign="Bottom"
                        Wrap="False" />
                    <ItemTemplate>
                        &nbsp;<asp:Label ID="Lb_pwd" runat="server" Text='Password'
                            Width="60px" ForeColor="Transparent"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="确认密码">
                    <EditItemTemplate>
                        <asp:TextBox ID="TB_repwd" runat="server" Text='Password'
                            Width="60px" Wrap="False" MaxLength="12" ForeColor="#FF8000"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV_repwd" runat="server" Display="Dynamic" ErrorMessage="*" ControlToValidate="TB_repwd"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RV_repwd" runat="server" ControlToValidate="TB_repwd"
                            ErrorMessage="*" ValidationExpression="[a-zA-Z0-9_]{6,12}"></asp:RegularExpressionValidator>
                        <asp:CompareValidator ID="CV_repwd" runat="server" ControlToCompare="TB_pwd" ControlToValidate="TB_repwd"
                            Display="Dynamic" ErrorMessage="*"></asp:CompareValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Lb_repwd" runat="server" Text='Password'
                            Width="60px" ForeColor="Transparent"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle BackColor="#C0C0FF" HorizontalAlign="Center" VerticalAlign="Bottom" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="电子邮箱">
                    <EditItemTemplate>
                        <asp:TextBox ID="TB_email" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.email") %>'
                            Width="90px" MaxLength="20"></asp:TextBox><asp:RegularExpressionValidator ID="rev4" runat="server" ControlToValidate="TB_email"
                            Display="Dynamic" ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle BackColor="#C0C0FF" HorizontalAlign="Center" VerticalAlign="Bottom"
                        Wrap="False" />
                    <ItemTemplate>
                        &nbsp;
                        <asp:Label ID="Lb_email" runat="server" Font-Size="Small" Text='<%# DataBinder.Eval(Container,"DataItem.email") %>'
                            Width="90px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="等级">
                    <EditItemTemplate>
                        <asp:TextBox ID="TB_level" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.level") %>'
                            Width="15px" MaxLength="1"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rev_level" runat="server" ControlToValidate="TB_level"
                            Display="Dynamic" ErrorMessage="1-4之间" ValidationExpression="[1-4]{1}"></asp:RegularExpressionValidator>
                        <asp:Label ID="Lb_prelevel" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.level") %>'
                            Visible="False" Width="15px"></asp:Label>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle BackColor="#C0C0FF" HorizontalAlign="Center" VerticalAlign="Bottom"
                        Wrap="False" />
                    <ItemTemplate>
                        &nbsp;
                        <asp:Label ID="Lb_level" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.level") %>'
                            Width="15px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="选择">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle BackColor="#C0C0FF" HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemTemplate>
                        <asp:CheckBox ID="CB_del" runat="server" Width="5px" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#FFE0C0" />
        </asp:GridView>
        <table style="width: 558px">
            <tr>
                <td style="width: 143px">
            <asp:Button ID="Bt_all" runat="server" OnClick="Bt_all_Click" Text="全选" />
                </td>
                <td style="width: 38px">
                    <asp:Button ID="Bt_allnot" runat="server" OnClick="Bt_allnot_Click" Text="全不选" /></td>
                <td>
                </td>
                <td style="width: 4518px">
                </td>
                <td style="width: 126px">
                    <asp:Button ID="Bt_del"
                runat="server" OnClick="Bt_del_Click" Text="删除" /></td>
                <td>
                    <asp:Button ID="Bt_search" runat="server" OnClick="Bt_search_Click" Text="返回查询" /></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel_ret" runat="server" Height="50px" HorizontalAlign="Center" Width="549px">
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="Lb_ret" runat="server" ForeColor="Blue"></asp:Label>&nbsp;&nbsp;
        &nbsp;
            <asp:LinkButton
                ID="LB_search" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="#FF8080"
                OnClick="LB_search_Click">返回查询</asp:LinkButton><br />
    </asp:Panel>
    <asp:Panel ID="Panel_quanxian" runat="server" ForeColor="Red" Height="50px" HorizontalAlign="Center"
        Visible="False" Width="550px">
        <br />
        <br />
        <asp:Label ID="Lb_quanxian" runat="server" Text="你的权限不够，无法访问该页面"></asp:Label></asp:Panel>

</asp:Content>