Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Namespace AutoScrollTimer
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private autoScrollHelper As AutoScrollHelper
		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			gridControl1.DataSource = GetDataTable()
			autoScrollHelper = New AutoScrollHelper(gridView1)
		End Sub

		Private Function GetDataTable() As DataTable
			Const ColCount As Integer = 40
			Const RowCount As Integer = 100
			Dim table As New DataTable()
			For i As Integer = 0 To ColCount - 1
				table.Columns.Add()
			Next i
			For j As Integer = 0 To RowCount - 1
				Dim row As DataRow = table.NewRow()
				For i As Integer = 0 To ColCount - 1
					row(i) = String.Format("row {0} / col {1}", j, i)
				Next i
				table.Rows.Add(row)
			Next j
			table.AcceptChanges()
			Return table
		End Function

		Private Sub simpleButton1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles simpleButton1.MouseMove
			simpleButton1.DoDragDrop("test", DragDropEffects.Move)
		End Sub

		Private Sub gridControl1_DragOver(ByVal sender As Object, ByVal e As DragEventArgs) Handles gridControl1.DragOver
			e.Effect = DragDropEffects.Move
			autoScrollHelper.ScrollIfNeeded()
		End Sub

		Private Sub gridControl1_DragLeave(ByVal sender As Object, ByVal e As EventArgs) Handles gridControl1.DragLeave

		End Sub
	End Class
End Namespace