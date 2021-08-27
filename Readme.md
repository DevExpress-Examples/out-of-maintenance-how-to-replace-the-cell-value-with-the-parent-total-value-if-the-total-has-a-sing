<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128577746/14.1.7%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T160905)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [RowFieldValueItem.cs](./CS/App_Code/RowFieldValueItem.cs) (VB: [RowFieldValueItem.vb](./VB/App_Code/RowFieldValueItem.vb))
* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
<!-- default file list end -->
# How to replace the cell value with the parent total value if the total has a single child
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t160905/)**
<!-- run online end -->


<p>If you use the <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressDataPivotGridPivotSummaryDisplayTypeEnumtopic">PercentOfColumn</a> <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraPivotGridPivotGridFieldBase_SummaryDisplayTypetopic">SummaryDisplayType</a>, it is sometimes necessary to show total values in the last level cells. Refer to the attached screenshot. Red cells show a percent of the corresponding total value, but since the total has a single nested cell, 100% is always shown. In this case, the only way to see the total value (a green cell ) is to collapse the corresponding row:</p>
<img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-replace-the-cell-value-with-the-parent-total-value-if-the-total-has-a-single-child-t160905/14.1.7+/media/619192ea-5465-11e4-80ba-00155d624807.png"><br />
<p>f you wish to always see total values, simply enable the <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraPivotGridPivotGridOptionsViewBase_ShowTotalsForSingleValuestopic">PivotGrid.OptionsView.ShowTotalsForSingleValues Property</a>. In this case, total rows will be always shown:</p>
<img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-replace-the-cell-value-with-the-parent-total-value-if-the-total-has-a-single-child-t160905/14.1.7+/media/1c16d5d6-5466-11e4-80ba-00155d624807.png"><br /><br />
<p>However, these extra total rows take additional space. Sometimes it is better to show corresponding total values instead of the default cell value. This example demonstrates how to accomplish this task. <br /><img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-replace-the-cell-value-with-the-parent-total-value-if-the-total-has-a-single-child-t160905/14.1.7+/media/5b0aa2d9-5469-11e4-80ba-00155d624807.png"><br /><br />Note that this example uses our internal API to access all required information about the processed row. We do not update this API frequently but since these are our internal methods, we can change them without any notifications. It is necessary to test this functionality carefully on each version update.</p>
<br /><br />

<br/>


