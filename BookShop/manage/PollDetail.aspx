﻿<%@ Page Language="C#" MasterPageFile="~/manage/mode_admin.master" EnableEventValidation ="false" AutoEventWireup="true" CodeFile="PollDetail.aspx.cs" Inherits="manage_PollDetail" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="PollDetailTitle" runat="server"></asp:Label>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:HyperLink ID="HyperLink1" runat="server" BackColor="#FFC0C0" NavigateUrl="~/manage/Poll.aspx"
        Target="_parent">返回投票主题</asp:HyperLink>
    <asp:GridView ID="PollDetail" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" 
        BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" 
        DataKeyNames="ID" 
        onpageindexchanging="PollDetail_PageIndexChanging" 
        onrowcancelingedit="PollDetail_RowCancelingEdit" 
        onrowdeleting="PollDetail_RowDeleting" onrowediting="PollDetail_RowEditing" 
        onrowupdating="PollDetail_RowUpdating" PageSize="8" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" EnableViewState="False" Width="548px">
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <Columns>
            <asp:TemplateField HeaderText="序号">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Enabled="False" Text='<%# Bind("ID") %>' Width="80%"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("ID") %>' Width="80%"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="所属主题">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Enabled="False" Text='<%# Bind("theme") %>' Width="80%"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("theme") %>' Width="80%"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="30%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="投票选项">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("optionName") %>' TextMode="MultiLine" Width="80%" CausesValidation="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3"
                        ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("optionName") %>' Width="80%"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="30%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="计数">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Enabled="False" Text='<%# Bind("counts") %>' Width="80%"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("counts") %>' Width="80%"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
        </Columns>
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:Button ID="DelAll" runat="server" CausesValidation="False" 
        onclick="DelAll_Click" Text="删除所有" />
&nbsp;&nbsp;<asp:Button ID="OutWord" runat="server" OnClick="OutWord_Click" Text="导出Word" />&nbsp;
    <asp:Label ID="flag1" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Label ID="AddTitle" runat="server" Text="添加投票项：" Width="98px"></asp:Label><br />
    <asp:Label ID="PollTheme" runat="server" Text="投票主题"></asp:Label>
    <asp:TextBox ID="PollThemeText" runat="server" Enabled="False"></asp:TextBox>
    <br />
    <asp:Label ID="PollOption" runat="server" Text="投票选项"></asp:Label>
    <asp:TextBox ID="PollOptionText" runat="server" ValidationGroup="s1" CausesValidation="True"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="PollOptionText" ErrorMessage="投票选项的内容不能为空！" ValidationGroup="s1"></asp:RequiredFieldValidator>
    <br />
    <asp:Button ID="Save" runat="server" onclick="Save_Click" Text="保存" ValidationGroup="s1" />
&nbsp;<asp:Button ID="Reset" runat="server" CausesValidation="False" 
        onclick="Reset_Click" Text="重置" />
&nbsp;
    <asp:Label ID="flag2" runat="server"></asp:Label>
</asp:Content>

