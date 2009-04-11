<%@ Page Language="C#" MasterPageFile="~/mode_classify.master" AutoEventWireup="true" CodeFile="bookInfo.aspx.cs" Inherits="_Default" Title="ͼ����Ϣ" %>

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
                <span style="font-size: 10pt; font-family: ��������">��&nbsp; �ߣ�</span><asp:Label ID="lblAuthor" runat="server" style="color: #0099cc;"></asp:Label>
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
                    �쿴��ߴ����&nbsp;</a></li></ul>
            </div>
            </td>
            <td valign="top" style="width: 300px">
<table style="width: 282px; height: 75px; font-size: 9pt;">
        <tr>
            <td align="right" style="width: 90px">
                <span style="color: gray">�����ۣ�</span>
            </td>
            <td align="left">
                <span style="color: gray">��</span><asp:Label ID="lblPrice" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 90px">
                <span style="color: gray">�֡��ۣ�</span>
            </td>
            <td align="left">
                <span style="color: Red; font-size:20px;">��</span><asp:Label ID="lblPriceN" style="font-family: YouYuan; font-size: 20px; color: red;" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 90px">
                <span style="color:gray">�ۡ��ۣ�</span>
            </td>
            <td align="left">
                <asp:Label ID="lblDis" runat="server" style="color: gray"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 90px">
                <span style="color:gray">�桡����</span>
            </td>
            <td align="left">
                <asp:Label ID="lblQuantity" runat="server" style="color: gray"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 43px">
                <asp:ImageButton ID="AddtoCartBt" runat="server" OnClick="AddtoCartBt_Click1" />
                <asp:TextBox ID="TxtQuan" runat="server" Width="42px"></asp:TextBox>
                (��)
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
<font size="4" face = "��԰" color = "gray">����������</font>
<br /><br /><br />
    <table style="width: 354px">
        <tr>
            <td colspan="2">
                Ŀǰ�������۳�<asp:Label ID="lblSold" runat="server" style="color: #0033ff"></asp:Label>��</td>
        </tr>
        <tr>
            <td colspan="2">
                ����<asp:Label ID="lblCommentAcount" runat="server" style="color: #0066ff"></asp:Label>�û���������</td>
        </tr>
        <tr>
            <td style="width: 169px">
                ����ã���</td>
            <td>
                <asp:Label ID="lblGood" runat="server" style="color: #33ff66"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 169px">
                �鱾���У���</td>
            <td>
                <asp:Label ID="lblNormal"
                    runat="server" style="color: blue"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 169px">
                ��ֽ�����</td>
            <td>
                <asp:Label ID="lblbad" runat="server" style="color: red"></asp:Label></td>
        </tr>
    </table>
    <br />

<br />
<hr style="border-left-color: gray; border-bottom-color: gray; border-top-style: dotted; border-top-color: gray; border-right-style: dotted; border-left-style: dotted; border-right-color: gray; border-bottom-style: dotted">
<br />
<div style ="text-align:left">
<font size="4" face = "��԰" color = "gray">������Ϣ</font>
<br /><br /><br /><br />
    <table style="width: 80%">
        <tr>
            <td style="width: 25%">
                �����磺</td>
            <td style="width: 25%">
                <asp:Label ID="lblPub" runat="server"></asp:Label></td>
            <td style="width: 25%">
                �������ࣺ</td>
            <td style="width: 25%">
                <asp:Label ID="lblBookType" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 25%">
                �������ڣ�</td>
            <td style="width: 25%">
                <asp:Label ID="lblPubDate" runat="server"></asp:Label></td>
            <td style="width: 25%">
            </td>
            <td style="width: 25%">
            </td>
        </tr>
        <tr>
            <td style="width: 25%">
                ISBN�ţ�</td>
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
<font size="4" face = "��԰" color = "gray">���ݼ��</font>
<br />
    <br />
    <br />
    <br />
                <asp:Literal ID="ltlScript" runat="server"></asp:Literal><br />
    <br />
<hr style="border-left-color: gray; border-bottom-color: gray; border-top-style: dotted; border-top-color: gray; border-right-style: dotted; border-left-style: dotted; border-right-color: gray; border-bottom-style: dotted">
<br />
<div style ="text-align:left">
<font size="4" face = "��԰" color = "gray">�û�����</font>
<br />    
    <br />
    <asp:Label ID="lblNull" runat="server" style="color: #0099ff; font-family: YouYuan" Visible="False"></asp:Label><br />
    
    <asp:GridView ID="CommentGridView" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="CommentGridView_PageIndexChanging" PageSize="5">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <table width = "500">
                        <tr>
                            <td style="width:10%">
                                <img height="13" src="Images/greendot.gif" width="11">�û���</td>
                            <td style="width:20%"><%#Eval("username") %></td>
                            <td style="width:30%">
                                <img height="13" src="Images/greendot.gif" width="11">���֣�<%#Eval("score") %></td>
                            <td style="width:40%">
                                <img height="13" src="Images/greendot.gif" width="11">�����ڣ�<%#Eval("commdatetime") %></td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <img height="13" src="Images/greendot.gif" width="11">���ۣ�</td>
                                <td colspan="3"><%#Eval("comment") %></td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ControlStyle BorderStyle="None" />
                <FooterStyle BorderStyle="None" />
                <HeaderStyle BorderStyle="None" />
                <ItemStyle BackColor="GhostWhite" BorderColor="LightCyan" BorderStyle="Double" BorderWidth="2px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    &nbsp;<br />
    &nbsp;<br />
    <asp:Label ID="lblStates" runat="server" Visible="False" style="color: #0099ff"></asp:Label><br />
    <asp:Panel ID="PanelComment" runat="server" Width="100px" Visible="False">
        <table style="width: 520px; height: 100px">
            <tr>
                <td align="left" style="width: 72px; color: #0099ff; font-family: YouYuan" valign="middle">
                    �ҵ����֣�</td>
                <td colspan="2">
                    <asp:RadioButtonList ID="RBLScore" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1"><font color = "red">��ֽ���</font></asp:ListItem>
                        <asp:ListItem Value="2"><font color = "blue">�鱾���У�</font></asp:ListItem>
                        <asp:ListItem Selected="True" Value="3"><font color = "green">����ã�</font></asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td align="left" style="width: 72px; color: #0099ff; font-family: YouYuan" valign="top">
                    �ҵ����ۣ�</td>
                <td colspan="2">
                    <asp:TextBox ID="TxtComment" runat="server" Height="130px" TextMode="MultiLine" Width="421px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="left" style="width: 72px" valign="middle">
                </td>
                <td style="width: 275px">
                </td>
                <td align="center">
                    <asp:Button ID="BtnComment" runat="server" Text="��Ҫ����" OnClick="BtnComment_Click" /></td>
            </tr>
        </table>
    </asp:Panel>
    
    <br />
    <br />
</div>
</asp:Content>

