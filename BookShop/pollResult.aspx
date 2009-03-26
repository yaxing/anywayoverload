<%@ Page Language="C#" MasterPageFile="~/mode_index.master" AutoEventWireup="true" CodeFile="pollResult.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="width:713px; height: 502px;">
 <tr>
  <td style="width:10%">
      </td>
  <td>
      <rsweb:ReportViewer ID="pollR" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="451px" Width="689px">
          <LocalReport ReportPath="Report.rdlc">
              <DataSources>
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1_pollDetail" />
              </DataSources>
          </LocalReport>
      </rsweb:ReportViewer>
      <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData"
          TypeName="DataSet1TableAdapters.pollDetailTableAdapter"></asp:ObjectDataSource>
  
  </td>
  <td style="width:10%">
  </td>
 </tr>
</table>
</asp:Content>

