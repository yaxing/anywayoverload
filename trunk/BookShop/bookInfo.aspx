<%@ Page Language="C#" MasterPageFile="~/mode_classify.master" AutoEventWireup="true" CodeFile="bookInfo.aspx.cs" Inherits="_Default" Title="图书信息" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="text-align:left">
    &nbsp;<br />
<table style="width: 100%">
        <tr>
            <td style="width: 30%">
<asp:Label id="lblBookName" runat="server" Font-Size="X-Large" style="font-size: 28px; color: gray; font-family: YouYuan"></asp:Label></td>
            <td style="width: 50%">
            </td>
            <td rowspan="3" valign="top" style="width: 20%">
            <asp:Repeater ID="rpRank" runat="server">
        <HeaderTemplate>
            <table border="0" cellpadding="0" cellspacing="0" height="55" width="100%">  
                <tr>
                    <td align="right">
                        <img height="48" src="Images/index_16.gif" width="161"></td>
                </tr>
                <tr>
                    <td class="tableBorder_B" height="100" valign="top" width="86%">
        </HeaderTemplate>
        <ItemTemplate>
            <table border="0" cellpadding="0" cellspacing="0" height="21" width="100%">
                <tr>
                    <td width="9%">
                        <img height="13" src="Images/greendot.gif" width="11"></td>
                    <td style="padding: 5px;" width="91%">
                        <a href='bookInfo.aspx?bookID=<%#Eval("ID")%>'>
                                    <%#Eval("bookName") %>
                        </a>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
        <FooterTemplate>
            </td> </tr> </table>
        </FooterTemplate>
    </asp:Repeater>
            </td>
        </tr>
        <tr>
            <td style="width: 314px">
                <span style="font-size: 10pt; font-family: 华文隶书">作&nbsp; 者：</span><asp:Label ID="lblAuthor" runat="server" style="color: #0099cc;"></asp:Label>
            </td>
            <td style="width: 300px">
            </td>
        </tr>
        <tr>
            <td style="width: 314px">
            <div>
            <ul class="hoverbox" style="text-align: left">
                <li style="font-size: 9pt">
                <a href="#">
                <img src="" alt="" id="coverImg" runat="server"/>
                <img src="" alt=""  id="coverImgP" class="preview" runat="server"/><br />
                    察看大尺寸封面&nbsp;</a></li></ul>
            </div>
            </td>
            <td valign="top" style="width: 300px">
<table style="width: 282px; height: 75px; font-size: 9pt;">
        <tr>
            <td align="right" style="width: 90px">
                <span style="color: gray">定　价：</span>
            </td>
            <td align="left">
                <span style="color: gray">￥</span><asp:Label ID="lblPrice" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 90px">
                <span style="color: gray">现　价：</span>
            </td>
            <td align="left">
                <span style="color: Red; font-size:20px;">￥</span><asp:Label ID="lblPriceN" style="font-family: YouYuan; font-size: 20px; color: red;" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 90px">
                <span style="color:gray">折　扣：</span>
            </td>
            <td align="left">
                <asp:Label ID="lblDis" runat="server" style="color: gray"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 90px">
                <span style="color:gray">存　量：</span>
            </td>
            <td align="left">
                <asp:Label ID="lblQuantity" runat="server" style="color: gray"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 43px">
                <asp:ImageButton ID="AddtoCartBt" runat="server" OnClick="AddtoCartBt_Click1" />
                <asp:TextBox ID="TxtQuan" runat="server" Width="42px"></asp:TextBox>
                (本)
            </td>
        </tr>
</table>
            </td>
        </tr>
    </table>

</div>
<br /><br />
    &nbsp;<br />
    <br /><br /><br /><br /><br /><br />
<hr style="border-left-color: gray; border-bottom-color: gray; border-top-style: dotted; border-top-color: gray; border-right-style: dotted; border-left-style: dotted; border-right-color: gray; border-bottom-style: dotted">
<br />
<div style ="text-align:left">
<font size="4" face = "幼园" color = "gray">销量与评价</font>
<br /><br /><br />
    <table style="width: 354px">
        <tr>
            <td colspan="2">
                目前本书已售出<asp:Label ID="lblSold" runat="server" style="color: #0033ff"></asp:Label>本</td>
        </tr>
        <tr>
            <td colspan="2">
                共有<asp:Label ID="lblCommentAcount" runat="server" style="color: #0066ff"></asp:Label>用户给与评价</td>
        </tr>
        <tr>
            <td style="width: 169px">
                神卷（好）：</td>
            <td>
                <asp:Label ID="lblGood" runat="server" style="color: #33ff66"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 169px">
                书本（中）：</td>
            <td>
                <asp:Label ID="lblNormal"
                    runat="server" style="color: blue"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 169px">
                废纸（差）：</td>
            <td>
                <asp:Label ID="lblbad" runat="server" style="color: red"></asp:Label></td>
        </tr>
    </table>
    <br />

<br />
<hr style="border-left-color: gray; border-bottom-color: gray; border-top-style: dotted; border-top-color: gray; border-right-style: dotted; border-left-style: dotted; border-right-color: gray; border-bottom-style: dotted">
<br />
<div style ="text-align:left">
<font size="4" face = "幼园" color = "gray">基本信息</font>
<br /><br /><br /><br />
    <table style="width: 80%">
        <tr>
            <td style="width: 25%">
                出版社：</td>
            <td style="width: 25%">
                <asp:Label ID="lblPub" runat="server"></asp:Label></td>
            <td style="width: 25%">
                所属分类：</td>
            <td style="width: 25%">
                <asp:Label ID="lblBookType" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 25%">
                出版日期：</td>
            <td style="width: 25%">
                <asp:Label ID="lblPubDate" runat="server"></asp:Label></td>
            <td style="width: 25%">
            </td>
            <td style="width: 25%">
            </td>
        </tr>
        <tr>
            <td style="width: 25%">
                ISBN号：</td>
            <td style="width: 25%">
                <asp:Label ID="lblISBN" runat="server"></asp:Label></td>
            <td style="width: 25%">
            </td>
            <td style="width: 25%">
            </td>
        </tr>
    </table>
<br />
<hr style="border-left-color: gray; border-bottom-color: gray; border-top-style: dotted; border-top-color: gray; border-right-style: dotted; border-left-style: dotted; border-right-color: gray; border-bottom-style: dotted">
<br />
<div style ="text-align:left">
<font size="4" face = "幼园" color = "gray">内容简介</font>
<br />
    <br />
    <br />
    <br />
                <asp:Literal ID="ltlScript" runat="server"></asp:Literal><br />
    <br />
<hr style="border-left-color: gray; border-bottom-color: gray; border-top-style: dotted; border-top-color: gray; border-right-style: dotted; border-left-style: dotted; border-right-color: gray; border-bottom-style: dotted">
<br />
<div style ="text-align:left">
<font size="4" face = "幼园" color = "gray">用户评论</font>
<br />    
    <br />
    <br />
    <br />
</div>
</asp:Content>

