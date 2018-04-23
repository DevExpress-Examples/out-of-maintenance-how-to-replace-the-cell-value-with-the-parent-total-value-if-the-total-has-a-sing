using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraPivotGrid.Data;
using DevExpress.Web.ASPxPivotGrid;
using DevExpress.Web.ASPxPivotGrid.Data;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void ASPxPivotGrid1_CustomCellValue(object sender, DevExpress.Web.ASPxPivotGrid.PivotCellValueEventArgs e)
    {
        if( e.DataField.ID == "fieldAmountCustomPercent" && e.RowField != null )
        {
            PivotGridData data = ((ASPxPivotGrid)sender).Data;
            PivotFieldValueItem parentValueItem;
            if ( GetParentItem(data, e.RowIndex, e.RowField.AreaIndex , out parentValueItem) )
            {
                PivotGridField[] columnFields = e.GetColumnFields() ?? new PivotGridField[0];
                PivotGridField[] rowFields = e.GetRowFields() ?? new PivotGridField[0];
                e.Value = e.GetCellValue(columnFields.Select(cf => e.GetFieldValue(cf)).ToArray(),
                    rowFields.Where(rf => rf.AreaIndex <= parentValueItem.Field.AreaIndex).Select(rf => e.GetFieldValue(rf)).ToArray(),
                    e.DataField) ;
            }
        }        
    }

    private bool GetParentItem(PivotGridData data, int rowIndex, int level, out PivotFieldValueItem parentValueItem)
    {
        parentValueItem = null;
        if (level < 1)
            return false;
        PivotFieldValueItem valueItem = data.VisualItems.GetItem(false, rowIndex, level - 1);
        if (valueItem != null && valueItem.Field != null && HaveSingleChild(data, valueItem)) {
            parentValueItem = valueItem;
            if (level > 1 && GetParentItem(data, rowIndex, level - 1, out valueItem))
                parentValueItem = valueItem;
            return true;
        }
        else {            
            return false;
        }
    }

    private bool HaveSingleChild(PivotGridData data, PivotFieldValueItem valueItem)
    {
        if (valueItem.MinLastLevelIndex == valueItem.MaxLastLevelIndex)
            return true;
        else
        {
            var nestedField = data.GetFieldByArea( valueItem.Area, valueItem.Field.AreaIndex + 1);
            IEnumerable<DevExpress.XtraPivotGrid.PivotDrillDownDataRow> rows = valueItem.CreateDrillDownDataSource().Cast<DevExpress.XtraPivotGrid.PivotDrillDownDataRow>();
            return rows.Select(row => row[nestedField]).Distinct().Count() == 1;
        }
    }
}
