Namespace AutoScrollTimer

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
            Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
            Me.simpleButton1 = New DevExpress.XtraEditors.SimpleButton()
            CType((Me.gridControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.gridView1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.panelControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelControl1.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' gridControl1
            ' 
            Me.gridControl1.AllowDrop = True
            Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.gridControl1.Location = New System.Drawing.Point(0, 49)
            Me.gridControl1.MainView = Me.gridView1
            Me.gridControl1.Name = "gridControl1"
            Me.gridControl1.Size = New System.Drawing.Size(517, 317)
            Me.gridControl1.TabIndex = 0
            Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridView1})
            AddHandler Me.gridControl1.DragLeave, New System.EventHandler(AddressOf Me.gridControl1_DragLeave)
            AddHandler Me.gridControl1.DragOver, New System.Windows.Forms.DragEventHandler(AddressOf Me.gridControl1_DragOver)
            ' 
            ' gridView1
            ' 
            Me.gridView1.GridControl = Me.gridControl1
            Me.gridView1.Name = "gridView1"
            Me.gridView1.OptionsView.ColumnAutoWidth = False
            ' 
            ' panelControl1
            ' 
            Me.panelControl1.Controls.Add(Me.simpleButton1)
            Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Top
            Me.panelControl1.Location = New System.Drawing.Point(0, 0)
            Me.panelControl1.Name = "panelControl1"
            Me.panelControl1.Size = New System.Drawing.Size(517, 49)
            Me.panelControl1.TabIndex = 1
            ' 
            ' simpleButton1
            ' 
            Me.simpleButton1.Location = New System.Drawing.Point(6, 6)
            Me.simpleButton1.Name = "simpleButton1"
            Me.simpleButton1.Size = New System.Drawing.Size(75, 23)
            Me.simpleButton1.TabIndex = 0
            Me.simpleButton1.Text = "Drag Me"
            AddHandler Me.simpleButton1.MouseMove, New System.Windows.Forms.MouseEventHandler(AddressOf Me.simpleButton1_MouseMove)
            ' 
            ' Form1
            ' 
            Me.ClientSize = New System.Drawing.Size(517, 366)
            Me.Controls.Add(Me.gridControl1)
            Me.Controls.Add(Me.panelControl1)
            Me.Name = "Form1"
            AddHandler Me.Load, New System.EventHandler(AddressOf Me.Form1_Load)
            CType((Me.gridControl1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.gridView1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.panelControl1), System.ComponentModel.ISupportInitialize).EndInit()
            Me.panelControl1.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub

#End Region
        Private gridControl1 As DevExpress.XtraGrid.GridControl

        Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView

        Private panelControl1 As DevExpress.XtraEditors.PanelControl

        Private simpleButton1 As DevExpress.XtraEditors.SimpleButton
    End Class
End Namespace
