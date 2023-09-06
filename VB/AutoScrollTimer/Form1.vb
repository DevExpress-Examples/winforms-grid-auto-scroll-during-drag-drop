Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Namespace AutoScrollTimer

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private autoScrollHelper As AutoScrollHelper

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            gridControl1.DataSource = GetDataTable()
            autoScrollHelper = New AutoScrollHelper(gridView1)
        End Sub

        Private Function GetDataTable() As DataTable
            Const ColCount As Integer = 40
            Const RowCount As Integer = 100
            Dim table As DataTable = New DataTable()
            For i As Integer = 0 To ColCount - 1
                table.Columns.Add()
            Next

            For j As Integer = 0 To RowCount - 1
                Dim row As DataRow = table.NewRow()
                For i As Integer = 0 To ColCount - 1
                    row(i) = String.Format("row {0} / col {1}", j, i)
                Next

                table.Rows.Add(row)
            Next

            table.AcceptChanges()
            Return table
        End Function

        Private Sub simpleButton1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            simpleButton1.DoDragDrop("test", DragDropEffects.Move)
        End Sub

        Private Sub gridControl1_DragOver(ByVal sender As Object, ByVal e As DragEventArgs)
            e.Effect = DragDropEffects.Move
            autoScrollHelper.ScrollIfNeeded()
        End Sub

        Private Sub gridControl1_DragLeave(ByVal sender As Object, ByVal e As EventArgs)
        End Sub
    End Class
End Namespace
