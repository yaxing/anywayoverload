<%@ Page Language="C#" MasterPageFile="~/mode_index.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width:520px; min-height:300px; float:left; border-color:#FFFFFF">
        <asp:Repeater ID="rpBookInfo" runat="server">
            <ItemTemplate>
				  	<%-- 图书信息 --%>
				  	<div style="width:250px;float:left;">
				  	<table width="100%" height="123"  border="0" cellpadding="0" cellspacing="0">
                    <tr>
                      <td width="43%" align="center"><img src='<%#Eval("coverPath") %>' width="76" height="110"></td>
                      <td width="57%" align="center"><table width="100%" height="119"  border="0" cellpadding="0" cellspacing="0">
                        <tr>
                          <td><%#Eval("bookName") %></td>
                        </tr>
                        <tr>
                          <td><%#Eval("publisher") %></td>
                        </tr>
                        <tr>
                          <td>作者：<%#Eval("author") %></td>
                        </tr>
                          <td>定价：<%#Eval("price") %>（元）</td>
                      </table></td>
                    </tr>
                  </table>
                  </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div style="float:right;width:220px">
        <div>
            <asp:Repeater ID="rpNewBook" runat="server">
                <HeaderTemplate>
                    <table width="100%" height="55"  border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="right"><img src="Images/index_12.gif" width="161" height="46" /></td>
                        </tr>
                        <tr>
                            <td width="86%" height="100" valign="top" class="tableBorder_B">
                </HeaderTemplate>
                <ItemTemplate>
                    <table width="100%" height="21"  border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="9%"><img src="Images/greendot.gif" width="11" height="13"></td>
                            <td width="91%" style="padding:5px;"><a href="#">射雕英雄传</a></td>
                        </tr>
                    </table>
                </ItemTemplate>
                <FooterTemplate>
                    </td>
                    </tr>
                     </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div>
            <asp:Repeater ID="rpRank" runat="server">
                <HeaderTemplate>
                                <table width="100%" height="55"  border="0" cellpadding="0" cellspacing="0">
                  <tr>
                    <td align="right"><img src="Images/index_16.gif" width="161" height="48"></td>
                  </tr>
                  <tr>
                                  <td width="86%" height="100" valign="top" class="tableBorder_B">
                </HeaderTemplate>
                <ItemTemplate>
                			  <table width="100%" height="21"  border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td width="9%"><img src="Images/greendot.gif" width="11" height="13"></td>
                  <td width="91%" style="padding:5px;"><a href="#">白雪公主和七个小矮人</a></td>
                </tr>
              </table>
                </ItemTemplate>
                <FooterTemplate>
                			  </td>
                  </tr>
                </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>

