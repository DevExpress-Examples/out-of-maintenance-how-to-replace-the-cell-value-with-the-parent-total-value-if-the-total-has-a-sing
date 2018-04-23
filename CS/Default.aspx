<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v14.1, Version=14.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPivotGrid" tagprefix="dxwpg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <dxwpg:ASPxPivotGrid ID="ASPxPivotGrid1" runat="server" 
        DataSourceID="AccessDataSource1" ClientIDMode="AutoID" 
        oncustomcellvalue="ASPxPivotGrid1_CustomCellValue" Theme="Aqua" >
        <Fields>

            <dxwpg:PivotGridField ID="fieldProductName" Area="RowArea" AreaIndex="1" 
                FieldName="ProductName">
            </dxwpg:PivotGridField>
            <dxwpg:PivotGridField ID="fieldCompanyName" Area="RowArea" AreaIndex="0" 
                FieldName="CompanyName" SortBySummaryInfo-FieldName="ProductAmount" SortOrder="Descending"  >                
            </dxwpg:PivotGridField>
            <dxwpg:PivotGridField ID="fieldOrderYear" Area="RowArea" AreaIndex="2" 
                FieldName="OrderDate" GroupInterval="DateYear" Caption="Year" 
                UnboundFieldName="fieldOrderYear">
            </dxwpg:PivotGridField>
            <dxwpg:PivotGridField ID="fieldOrderMonth" Area="FilterArea" AreaIndex="1" 
                FieldName="OrderDate" GroupInterval="DateMonth" Caption="Month" 
                UnboundFieldName="fieldOrderMonth">
            </dxwpg:PivotGridField>
            <dxwpg:PivotGridField ID="fieldAmountSum" Area="DataArea" AreaIndex="0" 
                FieldName="ProductAmount" Caption="Sum" >
            </dxwpg:PivotGridField>
            <dxwpg:PivotGridField ID="fieldAmountPercent" Area="DataArea" AreaIndex="1" 
                FieldName="ProductAmount" Caption="Percent" SummaryDisplayType="PercentOfColumn" >
            </dxwpg:PivotGridField>
            <dxwpg:PivotGridField ID="fieldAmountCustomPercent" Area="DataArea" AreaIndex="2" Visible="True"
                FieldName="ProductAmount" Caption="Custom Percent" SummaryDisplayType="PercentOfColumn" >
            </dxwpg:PivotGridField>
        </Fields>
        <OptionsView        
            ShowColumnGrandTotalHeader="False" 
            ShowColumnHeaders="False" ShowDataHeaders="False" ShowFilterHeaders="False" />
        <OptionsPager RowsPerPage="20" Position="Bottom" />
    </dxwpg:ASPxPivotGrid>
    <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
        DataFile="~/App_Data/nwind.mdb" 
        SelectCommand="SELECT * FROM [CustomerReports] WHERE [ProductName] < 'C' ">
    </asp:AccessDataSource>
    </form>
</body>
</html>
