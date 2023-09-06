Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Drawing

Namespace AutoScrollTimer

    Public Class AutoScrollHelper

        Public Sub New(ByVal view As GridView)
            fGrid = view.GridControl
            fView = view
            fScrollInfo = New ScrollInfo(Me, view)
        End Sub

        Private fGrid As GridControl

        Private fView As GridView

        Private fScrollInfo As ScrollInfo

        Public ThresholdInner As Integer = 20

        Public ThresholdOutter As Integer = 100

        Public HorizontalScrollStep As Integer = 10

        Public Property ScrollTimerInterval As Integer
            Get
                Return fScrollInfo.scrollTimer.Interval
            End Get

            Set(ByVal value As Integer)
                fScrollInfo.scrollTimer.Interval = value
            End Set
        End Property

        Public Sub ScrollIfNeeded()
            Dim pt As Point = fGrid.PointToClient(Control.MousePosition)
            Dim rect As Rectangle = fView.ViewRect
            fScrollInfo.GoLeft = pt.X > rect.Left - ThresholdOutter AndAlso pt.X < rect.Left + ThresholdInner
            fScrollInfo.GoRight = pt.X > rect.Right - ThresholdInner AndAlso pt.X < rect.Right + ThresholdOutter
            fScrollInfo.GoUp = pt.Y < rect.Top + ThresholdInner AndAlso pt.Y > rect.Top - ThresholdOutter
            fScrollInfo.GoDown = pt.Y > rect.Bottom - ThresholdInner AndAlso pt.Y < rect.Bottom + ThresholdOutter
            Console.WriteLine("{0} {1} {2} {3} {4}", pt, fScrollInfo.GoLeft, fScrollInfo.GoRight, fScrollInfo.GoUp, fScrollInfo.GoDown)
        End Sub

        Friend Class ScrollInfo

            Friend scrollTimer As Timer

            Private view As GridView = Nothing

            Private left, right, up, down As Boolean

            Private owner As AutoScrollHelper

            Public Sub New(ByVal owner As AutoScrollHelper, ByVal view As GridView)
                Me.owner = owner
                Me.view = view
                scrollTimer = New Timer()
                AddHandler scrollTimer.Tick, New EventHandler(AddressOf scrollTimer_Tick)
            End Sub

            Public Property GoLeft As Boolean
                Get
                    Return left
                End Get

                Set(ByVal value As Boolean)
                    If left <> value Then
                        left = value
                        CalcInfo()
                    End If
                End Set
            End Property

            Public Property GoRight As Boolean
                Get
                    Return right
                End Get

                Set(ByVal value As Boolean)
                    If right <> value Then
                        right = value
                        CalcInfo()
                    End If
                End Set
            End Property

            Public Property GoUp As Boolean
                Get
                    Return up
                End Get

                Set(ByVal value As Boolean)
                    If up <> value Then
                        up = value
                        CalcInfo()
                    End If
                End Set
            End Property

            Public Property GoDown As Boolean
                Get
                    Return down
                End Get

                Set(ByVal value As Boolean)
                    If down <> value Then
                        down = value
                        CalcInfo()
                    End If
                End Set
            End Property

            Private Sub scrollTimer_Tick(ByVal sender As Object, ByVal e As EventArgs)
                owner.ScrollIfNeeded()
                If GoDown Then view.TopRowIndex += 1
                If GoUp Then view.TopRowIndex -= 1
                If GoLeft Then view.LeftCoord -= owner.HorizontalScrollStep
                If GoRight Then view.LeftCoord += owner.HorizontalScrollStep
                If(Control.MouseButtons And MouseButtons.Left) = MouseButtons.None Then scrollTimer.Stop()
            End Sub

            Private Sub CalcInfo()
                If Not(GoDown AndAlso GoLeft AndAlso GoRight AndAlso GoUp) Then scrollTimer.Stop()
                If GoDown OrElse GoLeft OrElse GoRight OrElse GoUp Then scrollTimer.Start()
            End Sub
        End Class
    End Class
End Namespace
