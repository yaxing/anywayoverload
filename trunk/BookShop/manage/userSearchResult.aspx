<%@ Page Language="C#" MasterPageFile="~/manage/mode_admin.master"  CodeFile="userSearchResult.aspx.cs" AutoEventWireup="true" Inherits="manage_userSearchResultaspx" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Height="122px" Width="552px">
        &nbsp;&nbsp;
        
        <asp:GridView ID="GV1" runat="server" AllowPaging="True" AutoGenerateColumns="False" HorizontalAlign="Center" AutoGenerateEditButton="True"
        EditCommand ="EditRowsCommand" PageSize="2" OnRowCancelingEdit="GV1_CancelEdit" OnRowEditing="GV1_RowEdit" Height="61px" OnRowUpdating="GV1_RowUpdating" Width="552px" BackColor="Transparent" BorderColor="Transparent" ForeColor="DodgerBlue" OnPageIndexChanging="GV1_PageIndexChanging" >
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
                        <asp:Label ID="Label2_name" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.userName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="密码">
                    <ItemTemplate>
                        &nbsp;<asp:Label ID="Lb_pwd" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.password") %>' Width="70px"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BackColor="#C0C0FF" HorizontalAlign="Center" VerticalAlign="Bottom"
                        Wrap="False" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TB_pwd" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.password") %>' Width="70px" Wrap="False"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="联系电话">
                    <ItemTemplate>
                        &nbsp;
                        <asp:Label ID="Lb_tel" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.tel") %>' Width="95px" Font-Size="Small"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BackColor="#C0C0FF" HorizontalAlign="Center" VerticalAlign="Bottom"
                        Wrap="False" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TB_tel" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.tel") %>' Width="95px"></asp:TextBox>
                        <br />
                        <asp:RegularExpressionValidator ID="rev3" runat="server" ControlToValidate="TB_tel"
                            Display="Dynamic" ErrorMessage="TEL格式错误" ValidationExpression="(\d{3,4}-?\d{7,8})|(1{1]\d{10})"></asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="电子邮箱">
                    <ItemTemplate>
                        &nbsp;
                        <asp:Label ID="Lb_email" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.email") %>' Width="110px" Font-Size="Small"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle BackColor="#C0C0FF" HorizontalAlign="Center" VerticalAlign="Bottom"
                        Wrap="False" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TB_email" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.email") %>' Width="110px"></asp:TextBox><br />
                        <asp:RegularExpressionValidator ID="rev4" runat="server" ControlToValidate="TB_email"
                            Display="Dynamic" ErrorMessage="Email地址格式错误" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="等级">
                    <ItemTemplate>
                        &nbsp;
                        <asp:Label ID="Lb_grade" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.grade") %>' Width="15px"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BackColor="#C0C0FF" HorizontalAlign="Center" VerticalAlign="Bottom"
                        Wrap="False" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TB_grade" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.grade") %>' Width="15px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rev_grade" runat="server" ControlToValidate="TB_grade"
                            Display="Dynamic" ErrorMessage="等级范围在1-5之间" ValidationExpression="[1-5]{1}"></asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
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
      
        &nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center">
            <br />
            <asp:Button ID="Bt_all" runat="server" OnClick="Bt_all_Click"
            Text="全选" />&nbsp; &nbsp;<asp:Button ID="Bt_allnot" runat="server" OnClick="Bt_allnot_Click"
            Text="全不选" />&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="Bt_del" runat="server" OnClick="Bt_del_Click"
                Text="删除" />
            &nbsp;<asp:Button ID="Bt_search" runat="server" OnClick="Bt_search_Click" Text="返回查询" /><br />
            <br />
            <br />
        <asp:Label ID="Lb_ret" runat="server" ForeColor="Blue"></asp:Label>&nbsp;
            <asp:LinkButton ID="LB_search" runat="server" Font-Bold="True" Font-Underline="True"
                ForeColor="#FF8080" OnClick="LB_search_Click">返回查询</asp:LinkButton><br />
            <br />
            <br />
            <br />
        <asp:ValidationSummary ID="vs1" runat="server" DisplayMode="BulletList" HeaderText="错误" Visible="False" />
            <br />
        </asp:Panel>
        &nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        </asp:Panel>
    &nbsp; &nbsp; &nbsp;
</asp:Content>
