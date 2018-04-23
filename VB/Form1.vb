Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports DevExpress.XtraTreeList

Namespace WindowsApplication1
	''' <summary>
	''' Summary description for Form1.
	''' </summary>
	Public Class Form1
		Inherits System.Windows.Forms.Form
		Private WithEvents treeList1 As DevExpress.XtraTreeList.TreeList
		Private WithEvents textBox1 As System.Windows.Forms.TextBox
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()

			'
			' TODO: Add any constructor code after InitializeComponent call
			'
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.treeList1 = New DevExpress.XtraTreeList.TreeList()
			Me.textBox1 = New System.Windows.Forms.TextBox()
			CType(Me.treeList1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' treeList1
			' 
			Me.treeList1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.treeList1.Location = New System.Drawing.Point(0, 0)
			Me.treeList1.Name = "treeList1"
			Me.treeList1.Size = New System.Drawing.Size(498, 375)
			Me.treeList1.TabIndex = 0
'			Me.treeList1.MouseDown += New System.Windows.Forms.MouseEventHandler(Me.treeList1_MouseDown);
'			Me.treeList1.MouseMove += New System.Windows.Forms.MouseEventHandler(Me.treeList1_MouseMove);
			' 
			' textBox1
			' 
			Me.textBox1.AllowDrop = True
			Me.textBox1.Dock = System.Windows.Forms.DockStyle.Right
			Me.textBox1.Location = New System.Drawing.Point(498, 0)
			Me.textBox1.Multiline = True
			Me.textBox1.Name = "textBox1"
			Me.textBox1.Size = New System.Drawing.Size(154, 375)
			Me.textBox1.TabIndex = 1
			Me.textBox1.Text = "Drag-and-drop TreeList cells here"
'			Me.textBox1.DragDrop += New System.Windows.Forms.DragEventHandler(Me.textBox1_DragDrop);
'			Me.textBox1.DragEnter += New System.Windows.Forms.DragEventHandler(Me.textBox1_DragEnter);
			' 
			' Form1
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(652, 375)
			Me.Controls.Add(Me.treeList1)
			Me.Controls.Add(Me.textBox1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.treeList1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread> _
		Shared Sub Main()
			Application.Run(New Form1())
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim TempXViews As DevExpress.XtraTreeList.Design.XViews = New DevExpress.XtraTreeList.Design.XViews(treeList1)
		End Sub

		Private dragStartHitInfo As TreeListHitInfo

		Private Sub treeList1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles treeList1.MouseDown
			If e.Button = MouseButtons.Left AndAlso Control.ModifierKeys = Keys.None Then
				dragStartHitInfo = (TryCast(sender, TreeList)).CalcHitInfo(New Point(e.X, e.Y))
			End If
		End Sub
		Private Sub treeList1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles treeList1.MouseMove
			If e.Button = MouseButtons.Left AndAlso dragStartHitInfo IsNot Nothing AndAlso dragStartHitInfo.HitInfoType = HitInfoType.Cell Then

				Dim dragSize As Size = SystemInformation.DragSize
				Dim dragRect As New Rectangle(New Point(dragStartHitInfo.MousePoint.X - dragSize.Width \ 2, dragStartHitInfo.MousePoint.Y - dragSize.Height \ 2), dragSize)

				If (Not dragRect.Contains(New Point(e.X, e.Y))) Then
					Dim dragObject As String = dragStartHitInfo.Node.GetDisplayText(dragStartHitInfo.Column)
					TryCast(sender, TreeList).DoDragDrop(dragObject, DragDropEffects.Copy)
				End If
			End If
		End Sub
		Private Sub textBox1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles textBox1.DragEnter
			e.Effect = DragDropEffects.Copy
		End Sub
		Private Sub textBox1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles textBox1.DragDrop
			Dim data As String = TryCast(e.Data.GetData("System.String", True), String)
			If data IsNot Nothing Then
				TryCast(sender, TextBox).Text = data
			End If
		End Sub
	End Class
End Namespace
