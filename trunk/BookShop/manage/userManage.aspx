<%@ Page Language="C#" MasterPageFile="~/manage/mode_admin.master"  CodeFile="UserManage.aspx.cs" AutoEventWireup="true" Inherits="manage_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
        <br />
        <asp:Label ID="Label_Error" runat="server" ForeColor="Red" Width="194px"></asp:Label><br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Size="12pt" ForeColor="#0066FF" Text="请输入查询条件"></asp:Label><br />
        <br />
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label_ID" runat="server" Font-Bold="True" Text="用户ID" Width="65px"></asp:Label>
        &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:TextBox ID="TB_ID" runat="server" ForeColor="Black" ></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:RegularExpressionValidator ID="rev1" runat="server" ControlToValidate="TB_ID"
            ErrorMessage="用户ID格式错误" ValidationExpression="[1-9]{1}\d{0,9}"></asp:RegularExpressionValidator><br />
        &nbsp;<br />
        &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:Label ID="Label_Name" runat="server" Font-Bold="True" Text="用户名" Width="61px"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; <asp:TextBox ID="TB_Name" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
        &nbsp; &nbsp;
        <asp:RegularExpressionValidator ID="rev2" runat="server" ControlToValidate="TB_Name"
            ErrorMessage="用户名格式错误" ValidationExpression="[a-zA-Z]{1}\w{0,9}"></asp:RegularExpressionValidator><br />
        <br />
        &nbsp; &nbsp;&nbsp; &nbsp;
        <asp:Label ID="Label_TEL" runat="server" Font-Bold="True" Text="TEL" Width="48px"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TB_TEL" runat="server" CausesValidation="True"></asp:TextBox><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp;
        &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:RegularExpressionValidator runat="server" ID="rev3" ControlToValidate="TB_TEL" ValidationExpression="(\d{3,4}-?\d{7,8})|(1{1]\d{10})" ErrorMessage="TEL格式错误" />
        &nbsp; &nbsp;&nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
        &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label_Email" runat="server" Font-Bold="True" Text="Email" Width="57px"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TB_Email" runat="server"  ></asp:TextBox>&nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:RegularExpressionValidator runat="server" ID="rev4" ControlToValidate="TB_Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Email地址格式错误"  />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
        &nbsp;&nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp;&nbsp; 
        <asp:Label ID="Label_Rank" runat="server" Font-Bold="True" Text="用户等级" Width="72px"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; 
        <asp:DropDownList ID="DPD_Grade" runat="server" >
            <asp:ListItem Selected="True">不选</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
        </asp:DropDownList>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        &nbsp; &nbsp;
        <br />
        <br />
        <asp:Button ID="Bt_search" runat="server" Font-Bold="True"  Text="查询" Width="55px" OnClick="Bt_search_Click" /><br />
        &nbsp;<br />
        
        <asp:ValidationSummary ID="vs1" runat="server" DisplayMode="BulletList" HeaderText="错误" Visible="False" />
        </asp:Panel>

</asp:Content>
