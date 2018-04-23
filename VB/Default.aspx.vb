Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.XtraPivotGrid.Data
Imports DevExpress.Web.ASPxPivotGrid
Imports DevExpress.Web.ASPxPivotGrid.Data

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    End Sub
    Protected Sub ASPxPivotGrid1_CustomCellValue(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxPivotGrid.PivotCellValueEventArgs)
        If e.DataField.ID = "fieldAmountCustomPercent" AndAlso e.RowField IsNot Nothing Then
            Dim data As PivotGridData = DirectCast(sender, ASPxPivotGrid).Data
            Dim parentValueItem As PivotFieldValueItem = Nothing
            If GetParentItem(data, e.RowIndex, e.RowField.AreaIndex, parentValueItem) Then
                Dim columnFields() As PivotGridField = If(e.GetColumnFields(), New PivotGridField(){})
                Dim rowFields() As PivotGridField = If(e.GetRowFields(), New PivotGridField(){})
                e.Value = e.GetCellValue(columnFields.Select(Function(cf) e.GetFieldValue(cf)).ToArray(), rowFields.Where(Function(rf) rf.AreaIndex <= parentValueItem.Field.AreaIndex).Select(Function(rf) e.GetFieldValue(rf)).ToArray(), e.DataField)
            End If
        End If
    End Sub

    Private Function GetParentItem(ByVal data As PivotGridData, ByVal rowIndex As Integer, ByVal level As Integer, ByRef parentValueItem As PivotFieldValueItem) As Boolean
        parentValueItem = Nothing
        If level < 1 Then
            Return False
        End If
        Dim valueItem As PivotFieldValueItem = data.VisualItems.GetItem(False, rowIndex, level - 1)
        If valueItem IsNot Nothing AndAlso valueItem.Field IsNot Nothing AndAlso HaveSingleChild(data, valueItem) Then
            parentValueItem = valueItem
            If level > 1 AndAlso GetParentItem(data, rowIndex, level - 1, valueItem) Then
                parentValueItem = valueItem
            End If
            Return True
        Else
            Return False
        End If
    End Function

    Private Function HaveSingleChild(ByVal data As PivotGridData, ByVal valueItem As PivotFieldValueItem) As Boolean
        If valueItem.MinLastLevelIndex = valueItem.MaxLastLevelIndex Then
            Return True
        Else
            Dim nestedField = data.GetFieldByArea(valueItem.Area, valueItem.Field.AreaIndex + 1)
            Dim rows As IEnumerable(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow) = valueItem.CreateDrillDownDataSource().Cast(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)()
            Return rows.Select(Function(row) row(nestedField)).Distinct().Count() = 1
        End If
    End Function
End Class
