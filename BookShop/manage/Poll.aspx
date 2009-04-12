﻿<%@ Page Language="C#" MasterPageFile="~/manage/mode_admin.master" EnableEventValidation ="false" AutoEventWireup="true" CodeFile="Poll.aspx.cs" Inherits="manage_Poll" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="PollTitle" runat="server"></asp:Label>
    <asp:GridView ID="Poll" runat="server" AutoGenerateColumns="False" 
        BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" CellSpacing="2" Width="568px" 
        AllowPaging="True" DataKeyNames="ID" 
        onpageindexchanging="Poll_PageIndexChanging" 
        onrowcancelingedit="Poll_RowCancelingEdit" onrowdeleting="Poll_RowDeleting" 
        onrowediting="Poll_RowEditing" onrowupdating="Poll_RowUpdating" PageSize="5" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" EnableViewState="False">
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <Columns>
            <asp:TemplateField HeaderText="序号">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Enabled="False" Text='<%# Bind("ID") %>' Width="80%"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="主题">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("theme") %>' TextMode="MultiLine" Width="80%" Enabled="False"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("theme") %>' Width="80%"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="20%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="简介">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("introduce") %>' TextMode="MultiLine" Width="80%" CausesValidation="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3"
                        ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("introduce") %>' Width="80%"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="40%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="状态">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("available") %>' Width="80%"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox4"
                        ErrorMessage="RangeValidator" MaximumValue="1" MinimumValue="0">（0-不可用；1-可用）</asp:RangeValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("available") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="5%" />
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="ID" 
                DataNavigateUrlFormatString="pollDetail.aspx?ID={0}" HeaderText="查看详细" 
                Text="详细信息" >
                <ItemStyle Width="15%" />
            </asp:HyperLinkField>
        </Columns>
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:Button ID="DeleteAll" runat="server" Text="删除全部" CausesValidation="False" 
        onclick="DeleteAll_Click" />
    &nbsp;&nbsp;
    <asp:Button ID="OutWord" runat="server" OnClick="OutWord_Click" Text="导出到Word" />
    &nbsp;
    <asp:Label ID="availableFlags" runat="server"></asp:Label>
    <br />
    <br />
    添加投票主题：<br />
    <br />
    <asp:Label ID="Theme" runat="server" Text="投票主题"></asp:Label>
    <asp:TextBox ID="ThemeText" runat="server" ValidationGroup="a" CausesValidation="True"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="ThemeText" ErrorMessage="主题不能为空" ValidationGroup="a"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="PollContent" runat="server" Text="投票简介"></asp:Label>
    <asp:TextBox ID="introText" runat="server" ValidationGroup="a" CausesValidation="True"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="introText" ErrorMessage="简介不能为空" ValidationGroup="a"></asp:RequiredFieldValidator>
    <br />
    <asp:RadioButton ID="Able" runat="server" GroupName="State" Text="可用" />
    <asp:RadioButton ID="unAble" runat="server" Checked="True" GroupName="State" 
        Text="不可用" />
    <br />
    <asp:Button ID="Save" runat="server" Text="保存" onclick="Save_Click" ValidationGroup="a" />
    &nbsp;
    <asp:Button ID="Reset" runat="server" Text="重置" CausesValidation="False" 
        onclick="Reset_Click" />
    <asp:Label ID="availablenum" runat="server"></asp:Label>
</asp:Content>

