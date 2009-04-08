<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bookManage.aspx.cs" Inherits="manage_bookManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>书籍管理</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312"/>
    <link href="../CSS/style.css" rel="stylesheet"/>
    <style type="text/css">
    #newPreview {
         FILTER: progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale)
    }
    </style> 
    <script language="javascript" type="text/javascript">
     function Preview(imgFile)
     {
        if(imgFile != "")
        {
        var newPreview = document.getElementById("newPreview");
        newPreview.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = imgFile;
        newPreview.style.width = "128px";
        newPreview.style.height = "165px";
        }
     } 
    </script>
</head>
<body>
<table width="100%"  border="0" cellspacing="0" cellpadding="0" background="../Images/bg.gif">
  <tr>
    <td>
<table width="777" height="609"  border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
  <tr>
    <td valign="top" style="width: 778px">
	
<!-- ------------------------------------------------head stats here--------------------------------------------------------- -->
<table width="100%"  border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="6" colspan="2" bgcolor="#81CF00"></td>
      </tr>
      <tr>
        <td width="28%" height="70"><img src="../Images/index_ht.gif" width="221" height="58"></td>
        <td width="72%" valign="top"><table width="100%" height="35"  border="0" cellpadding="0" cellspacing="0">
          <tr align="center">
            <td rowspan="2" valign="bottom">&nbsp;</td>
            <td height="22" valign="bottom"><a href="bookManage.aspx">图书管理</a></td>
            <td width="1" rowspan="2" valign="top"><img src="../Images/Nav_separate.gif" width="1" height="36"></td>
            <td valign="bottom"><a href="userManage.aspx">用户管理</a></td>
            <td width="1" rowspan="2" valign="top"><img src="../Images/Nav_separate.gif" width="1" height="36"></td>
            <td valign="bottom"><a href="orderManage.aspx">订单管理</a></td>
            <td width="1" rowspan="2" valign="top"><img src="../Images/Nav_separate.gif" width="1" height="36"></td>
            <td valign="bottom"><a href="BBS.aspx">公告管理</a></td>
            <td width="1" rowspan="2" valign="top"><img src="../Images/Nav_separate.gif" width="1" height="36"></td>
            <td valign="bottom"><a href="Poll.aspx">投票管理</a></td>
            <td width="1" rowspan="2" valign="top"><img src="../Images/Nav_separate.gif" width="1" height="36"></td>
            <td valign="bottom">&nbsp;<a href="Logout.aspx">退出</a>&nbsp;</td>
          </tr>
          <tr align="center">
            <td height="13"><a href="bookManage.aspx">Books Manage</a></td>
            <td><a href="userManage.aspx">Member Manage</a></td>
            <td><a href="orderManage.aspx">Order Manage</a></td>
            <td><a href="BBS.aspx">BBS Manage </a></td>
            <td><a href="Poll.aspx">Poll manage </a></td>
            <td>&nbsp;<a href="Logout.aspx">Quit</a>&nbsp;</td>
          </tr>
        </table></td>
      </tr>
    </table>
<!-- ----------------------------------------------添加XX starts here--------------------------------------------------------- -->
	<table width="100%"  border="0" cellspacing="0" cellpadding="0" class="tableBorder_LTR">
      <tr>
        <td height="30" align="center" bgcolor="#eeeeee">
           
        </td>
      </tr>
    </table>
<!-- ---------------------------------------------body starts here------------------------------------------------------------ -->
<form id="form1" runat="server">
	<table width="100%" height="396"  border="0" cellpadding="0" cellspacing="0" class="tableBorder_LBR">
        <tr>
		<!-- 左板块starts -->
          <td width="26%" height="395" valign="top"><table width="100%"  border="0" cellspacing="-2" cellpadding="-2">
            <tr>
              <td width="55%" height="82" align="center" class="word_grey">&nbsp;<img src="../Images/reg.gif" width="84" height="54"></td>
              <td width="45%" align="left" class="word_grey">图书管理</td>
            </tr>
            <tr>
              <td height="112" colspan="2" valign="top" class="word_grey"><ul>
                <li><asp:ImageButton ID="NewBook" runat="server" OnClick="NewBook_Click"/></li>
                <li><asp:ImageButton ID="NewType" runat="server" OnClick="NewType_Click"/></li>
                <li><asp:ImageButton ID="BookList" runat="server" OnClick="BookList_Click"/></li>
                <li><asp:ImageButton ID="BookUpdate" runat="server" OnClick="BookUpdate_Click"/></li>
              </ul></td>
            </tr>
            <tr align="center">
              <td colspan="2" valign="middle" class="word_grey"></td>
            </tr>
          </table></td><!-- 左板块ends -->
		  
          <td width="5" valign="top" background="Images/Cen_separate.gif"></td><!-- 分割线 -->
		  
		  <!-- 右板块starts -->
          <td valign="top" style="width: 73%">
		  	<div>
                  <asp:Panel ID="NewBookPanel" runat="server" Height="400px" Width="520px" Visible="False">
                  <table style="width: 520px; height: 390px">
                      <tr>
                          <td align="left" style="width: 83px">
                              书&nbsp; 名<span style="color: #ff0033">*</span>：</td>
                          <td colspan="1" style="width: 260px">
                              <asp:TextBox ID="TxtBookName" runat="server" MaxLength="128"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RvalBookName" runat="server" ControlToValidate="TxtBookName"
                                  Display="Dynamic" ErrorMessage="*书名不能为空" ValidationGroup="AddNewBook"></asp:RequiredFieldValidator></td>
                          <td colspan="4" style="width: 166px" align="center" rowspan="9"><div id="newPreview"></div></td>
                      </tr>
                      <tr>
                          <td align="left" style="width: 83px">
                              图书分类<span style="color: #ff0033">*</span>：</td>
                          <td colspan="1" style="width: 260px">
                              <asp:DropDownList ID="DDDLType" runat="server">
                              </asp:DropDownList></td>
                      </tr>
                      <tr>
                          <td align="left" style="width: 83px">
                              作&nbsp; 者<span style="color: #ff0033">*</span>：</td>
                          <td colspan="1" style="width: 260px">
                              <asp:TextBox ID="TxtAuthor" runat="server" MaxLength="128"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RvalAuthor" runat="server" ControlToValidate="TxtAuthor"
                                  Display="Dynamic" ErrorMessage="*请填写作者" ValidationGroup="AddNewBook"></asp:RequiredFieldValidator></td>
                      </tr>
                      <tr>
                          <td align="left" style="width: 83px">
                              出版社<span style="color: #ff0033">*</span>：</td>
                          <td colspan="1" style="width: 260px">
                              <asp:TextBox ID="TxtPub" runat="server" MaxLength="128"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RvalPrint" runat="server" ControlToValidate="TxtPub"
                                  Display="Dynamic" ErrorMessage="*请填写出版社" ValidationGroup="AddNewBook"></asp:RequiredFieldValidator></td>
                      </tr>
                      <tr>
                          <td align="left" style="width: 83px">
                              出版日期<span style="color: #ff0033">*</span>：</td>
                          <td colspan="1" style="width: 260px">
                              <asp:TextBox ID="TxtPubTime" runat="server" MaxLength="10"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RvalPubT" runat="server" ControlToValidate="TxtPubTime"
                                  Display="Dynamic" ErrorMessage="*请填写出版日期" ValidationGroup="AddNewBook"></asp:RequiredFieldValidator></td>
                      </tr>
                      <tr>
                          <td align="left" style="width: 83px">
                              ISBN号<span style="color: #ff0033">*</span>：</td>
                          <td colspan="1" style="width: 260px">
                              <asp:TextBox ID="TxtISBN" runat="server" MaxLength="32"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RvalISBN" runat="server" ControlToValidate="TxtISBN"
                                  Display="Dynamic" ErrorMessage="*请填写ISBN" ValidationGroup="AddNewBook"></asp:RequiredFieldValidator></td>
                      </tr>
                      <tr>
                          <td align="left" style="width: 83px">
                              定&nbsp; 价<span style="color: #ff0033">*</span>：</td>
                          <td colspan="1" style="width: 260px">
                              <asp:TextBox ID="TxtPrice" runat="server" MaxLength="20"></asp:TextBox>(元)<asp:RequiredFieldValidator
                                  ID="RvalPrice" runat="server" ControlToValidate="TxtPrice" Display="Dynamic"
                                  ErrorMessage="*请给书籍定价" ValidationGroup="AddNewBook"></asp:RequiredFieldValidator></td>
                      </tr>
                      <tr>
                          <td align="left" style="width: 83px">
                              存&nbsp; 量<span style="color: #ff0033">*</span>：</td>
                          <td colspan="1" style="width: 260px">
                              <asp:TextBox ID="TxtQuantity" runat="server" MaxLength="20"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtQuantity"
                                  Display="Dynamic" ErrorMessage="*请填写书籍存量" ValidationGroup="AddNewBook"></asp:RequiredFieldValidator></td>
                      </tr>
                      <tr>
                          <td align="left" style="width: 83px">
                              封面图片：</td>
                          <td colspan="1" style="width: 260px">
                              <asp:FileUpload ID="CoverUpload" runat="server" onpropertychange="Preview(this.value);" />&nbsp;
                          </td>
                      </tr>
                      <tr>
                          <td align="left" style="width: 83px">
                              内容描述：</td>
                          <td colspan="5" rowspan="3">
                              <asp:TextBox ID="TxtScript" runat="server" Height="75px" TextMode="MultiLine" Width="400px"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td align="left" style="width: 83px">
                          </td>
                      </tr>
                      <tr>
                          <td align="left" style="width: 83px">
                          </td>
                      </tr>
                      <tr>
                          <td align="center" colspan="6" rowspan="1">
                              <asp:Button ID="BtnSub" runat="server" Text="提交" OnClick="BtnSub_Click" ValidationGroup="AddNewBook" />
                              &nbsp; &nbsp; &nbsp;<input id="BtnReset" type="reset" value="重置" /></td>
                      </tr>
                  </table>
                  </asp:Panel>
           
         </div>
              <asp:Panel ID="TypePanel" runat="server" Height="400px" Visible="False" Width="520px">
                  <br />
                  <br />
                  <asp:Label ID="lblQuick" runat="server" BackColor="White" Style="margin-left: 100px"
                      Text="快速变更分类："></asp:Label>
                  <br />
                  <br />
                  <asp:Label ID="Label1" runat="server" Style="margin-left: 100px" Text="未添加分类："></asp:Label>
                  <asp:Label ID="Label2" runat="server" Style="margin-left: 125px" Text="已添加分类："></asp:Label><br />
                  <asp:ListBox ID="LBNew" runat="server" Style="left: 20%; width: 100px;
                      top: 20%; height: 200px; margin-left: 100px;" SelectionMode="Multiple"></asp:ListBox>
                  <asp:ListBox ID="LBEx" runat="server" Style="left: 40%; width: 100px;
                      top: 20%; height: 200px; margin-left: 100px;" SelectionMode="Multiple"></asp:ListBox>
                  <asp:Button ID="BtnAdd" runat="server" Style="left: 22px; top: -52px; margin-top: -130px; margin-left: -180px;"
                      Text=">" Width="47px" OnClick="BtnAdd_Click"/>&nbsp;<asp:Button ID="BtnDel" runat="server"
                          Style="margin-top: -100px; margin-left: -185px" Text="<" Width="47px" OnClick="BtnDel_Click" /><br />
                  <br />
                  <asp:Label ID="lblSelf" runat="server" BackColor="White" Style="margin-top: 20px;
                      margin-left: 100px" Text="自定义分类："></asp:Label>
                  <br />
                  <asp:TextBox ID="TxtTypeP" runat="server" Style="left: -211px; top: 142px; margin-top: 20px; margin-left: 100px;"></asp:TextBox>
                  <asp:Button ID="BtnAddP" runat="server" Style="left: 264px; top: 123px" Text="添加分类" OnClick="BtnAddP_Click" ValidationGroup="bookTypeIn" />
                  <asp:Button ID="BtnDelP" runat="server" Style="left: 264px; top: 123px" Text="删除分类" OnClick="BtnDelP_Click" ValidationGroup="bookTypeIn" /><br />
                  <asp:RequiredFieldValidator ID="RvalTypeIn" runat="server" Display="Dynamic" ErrorMessage="*请输入分类名"
                      Style="margin-left: 100px" ValidationGroup="bookTypeIn" ControlToValidate="TxtTypeP"></asp:RequiredFieldValidator><br />
                  <asp:Label ID="lblStat" runat="server" ForeColor="Red" Style="margin-left: 100px"></asp:Label></asp:Panel>
              <asp:Panel ID="BookListPanel" runat="server" Height="400px" Width="520px">
                  <asp:GridView ID="BookGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                      BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"
                      CellPadding="4" ForeColor="Black" GridLines="Vertical" OnRowDeleting="BookGridView_RowDeleting" OnRowEditing="BookGridView_RowEditing" Width="510px" DataKeyNames="ID" OnPageIndexChanging="BookGridView_PageIndexChanging" PageSize="6">
                      <FooterStyle BackColor="#CCCC99" />
                      <RowStyle BackColor="#F7F7DE" />
                      <Columns>
                          <asp:BoundField DataField="ISBN" HeaderText="书号" />
                          <asp:BoundField DataField="bookName" HeaderText="书名" />
                          <asp:BoundField DataField="className" HeaderText="类型" />
                          <asp:BoundField DataField="author" HeaderText="作者" />
                          <asp:BoundField DataField="publisher" HeaderText="出版社" />
                          <asp:ButtonField ButtonType="Button" HeaderText="修改信息" Text="编辑" CommandName="Edit" />
                          <asp:ButtonField ButtonType="Button" HeaderText="删除书籍" Text="删除" CommandName="Delete" />
                      </Columns>
                      <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                      <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                      <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                      <AlternatingRowStyle BackColor="White" />
                  </asp:GridView>
              </asp:Panel>
              <asp:Panel ID="BookUpdatePanel" runat="server" Height="400px" Visible="False" Width="520px"><table style="width: 520px; height: 390px">
                  <tr>
                      <td align="left" style="width: 83px">
                          书&nbsp; 名<span style="color: #ff0033">*</span>：</td>
                      <td colspan="1" style="width: 260px">
                          <asp:TextBox ID="TxtBookNameU" runat="server" MaxLength="128"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtBookNameU"
                              Display="Dynamic" ErrorMessage="*书名不能为空" ValidationGroup="UpdateBook"></asp:RequiredFieldValidator>
                          <asp:HiddenField ID="HFBookID" runat="server" />
                      </td>
                      <td colspan="4" style="width: 166px; color: #000000;" align="center" rowspan="9">
                          <asp:Image ID="ImgEx" runat="server" Height="165px" Width="128px" /></td>
                  </tr>
                  <tr style="color: #000000">
                      <td align="left" style="width: 83px">
                          图书分类<span style="color: #ff0033">*</span>：</td>
                      <td colspan="1" style="width: 260px">
                          <asp:DropDownList ID="DDLTypeU" runat="server">
                          </asp:DropDownList>
                          <asp:HiddenField ID="HFOldType" runat="server" />
                      </td>
                  </tr>
                  <tr>
                      <td align="left" style="width: 83px">
                          作&nbsp; 者<span style="color: #ff0033">*</span>：</td>
                      <td colspan="1" style="width: 260px">
                          <asp:TextBox ID="TxtAuthorU" runat="server" MaxLength="128"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtAuthorU"
                              Display="Dynamic" ErrorMessage="*请填写作者" ValidationGroup="UpdateBook"></asp:RequiredFieldValidator></td>
                  </tr>
                  <tr style="color: #000000">
                      <td align="left" style="width: 83px">
                          出版社<span style="color: #ff0033">*</span>：</td>
                      <td colspan="1" style="width: 260px">
                          <asp:TextBox ID="TxtPubU" runat="server" MaxLength="128"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtPubU"
                              Display="Dynamic" ErrorMessage="*请填写出版社" ValidationGroup="UpdateBook"></asp:RequiredFieldValidator></td>
                  </tr>
                  <tr style="color: #000000">
                      <td align="left" style="width: 83px">
                          出版日期<span style="color: #ff0033">*</span>：</td>
                      <td colspan="1" style="width: 260px">
                          <asp:TextBox ID="TxtPubDateU" runat="server" MaxLength="10"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtPubDateU"
                              Display="Dynamic" ErrorMessage="*请填写出版日期" ValidationGroup="UpdateBook"></asp:RequiredFieldValidator></td>
                  </tr>
                  <tr style="color: #000000">
                      <td align="left" style="width: 83px">
                          ISBN号<span style="color: #ff0033">*</span>：</td>
                      <td colspan="1" style="width: 260px">
                          <asp:TextBox ID="TxtISBNU" runat="server" MaxLength="32"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtISBNU"
                              Display="Dynamic" ErrorMessage="*请填写ISBN" ValidationGroup="UpdateBook"></asp:RequiredFieldValidator></td>
                  </tr>
                  <tr>
                      <td align="left" style="width: 83px">
                          定&nbsp; 价<span style="color: #ff0033">*</span>：</td>
                      <td colspan="1" style="width: 260px">
                          <asp:TextBox ID="TxtPriceU" runat="server" MaxLength="20"></asp:TextBox>(元)<asp:RequiredFieldValidator
                              ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtPriceU" Display="Dynamic"
                              ErrorMessage="*请给书籍定价" ValidationGroup="UpdateBook"></asp:RequiredFieldValidator></td>
                  </tr>
                  <tr>
                      <td align="left" style="width: 83px">
                          存&nbsp; 量<span style="color: #ff0033">*</span>：</td>
                      <td colspan="1" style="width: 260px">
                          <asp:TextBox ID="TxtAvailableU" runat="server" MaxLength="20"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TxtAvailableU"
                              Display="Dynamic" ErrorMessage="*请填写书籍存量" ValidationGroup="UpdateBook"></asp:RequiredFieldValidator></td>
                  </tr>
                  <tr>
                      <td align="left" style="width: 83px">
                          封面图片：</td>
                      <td colspan="1" style="width: 260px">
                          <asp:FileUpload ID="CoverUploadU" runat="server" />&nbsp;
                          </td>
                  </tr>
                  <tr>
                      <td align="left" style="width: 83px">
                          内容描述：</td>
                      <td colspan="5" rowspan="3">
                          <asp:TextBox ID="TxtScriptU" runat="server" Height="75px" TextMode="MultiLine" Width="400px"></asp:TextBox></td>
                  </tr>
                  <tr>
                      <td align="left" style="width: 83px">
                      </td>
                  </tr>
                  <tr>
                      <td align="left" style="width: 83px">
                      </td>
                  </tr>
                  <tr>
                      <td align="center" colspan="6" rowspan="1">
                          <asp:Button ID="BtnUpdate" runat="server" Text="提交" OnClick="BtnUpdate_Click" ValidationGroup="UpdateBook" />
                          &nbsp; &nbsp; &nbsp;<input id="BtnResetU" type="reset" value="重置" /></td>
                  </tr>
              </table>
              </asp:Panel>
              <asp:Panel ID="BookSearchPanel" runat="server" Height="400px" Visible="False" Width="520px">
                  <br />
                  <br />
                  <br />
                  <br />
                  <br />
                  <br />
                  <br />
                  <asp:Label ID="lblBookSearch" runat="server" Style="margin-left: 100px" Text="请指定你要修改的书籍："></asp:Label><br />
                  <br />
                  <br />
                  <asp:TextBox ID="TxtBookSearch" runat="server" Style="margin-left: 100px"></asp:TextBox>
                  <asp:Button ID="BtnSearch" runat="server" OnClick="BtnSearch_Click" Text="指定书籍" /></asp:Panel>
		  </td>
        </tr>
      </table>
</form>
<!-- ----------------------------bottom starts here------------------------------------------------------------ -->  
<table width="100%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td height="5" bgcolor="#83CC10"></td>
        </tr>
        <tr>
          <td align="center"><table width="100%" height="78"  border="0" align="center" cellpadding="-2" cellspacing="-2">
            <tr>
              <td width="124" height="13">&nbsp;</td>
              <td height="13" colspan="3"><div align="center">制作：AnywayOverload小组</div></td>
              <td width="141">&nbsp;</td>
            </tr>
            <tr>
              <td width="124" height="13">&nbsp;</td>
              <td height="13" colspan="3" align="center"><a href="#">图书山寨</a>客户服务热线：010-6891xxx&nbsp;&nbsp;&nbsp;&nbsp;联系人:AnywayOverload小组</td>
              <td width="141">&nbsp;</td>
            </tr>
            <tr>
              <td height="15" colspan="2">&nbsp;</td>
              <td width="464" valign="bottom"><div align="center"> CopyRight &copy; 2008.3.17 AnywayOverload小组</div></td>
              <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
              <td colspan="2">&nbsp;</td>
              <td align="center">本站请使用IE6.0或以上版本 1024*768为最佳显示效果</td>
              <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
              <td height="15" colspan="2">&nbsp;</td>
              <td align="center">&nbsp;</td>
              <td colspan="2">&nbsp;</td>
            </tr>
          </table></td>
        </tr>
      </table>
<!-- -------------------------------------------------------------------------------------------------------------------------- -->
</td></tr></table>
</td></tr></table>
</body>
</html>
