<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel_Res = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_Next = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TextBox_Log = New System.Windows.Forms.TextBox()
        Me.RichTextBox_Info = New System.Windows.Forms.RichTextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.立即查询ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.立即标识ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.强制发布ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel_Res, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel_Next})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 512)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(2, 0, 21, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1176, 30)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel_Res
        '
        Me.ToolStripStatusLabel_Res.Name = "ToolStripStatusLabel_Res"
        Me.ToolStripStatusLabel_Res.Size = New System.Drawing.Size(40, 23)
        Me.ToolStripStatusLabel_Res.Text = "Res"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(1062, 23)
        Me.ToolStripStatusLabel2.Spring = True
        Me.ToolStripStatusLabel2.Text = "."
        '
        'ToolStripStatusLabel_Next
        '
        Me.ToolStripStatusLabel_Next.Name = "ToolStripStatusLabel_Next"
        Me.ToolStripStatusLabel_Next.Size = New System.Drawing.Size(51, 23)
        Me.ToolStripStatusLabel_Next.Text = "Next"
        '
        'TextBox_Log
        '
        Me.TextBox_Log.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox_Log.Dock = System.Windows.Forms.DockStyle.Right
        Me.TextBox_Log.Location = New System.Drawing.Point(660, 34)
        Me.TextBox_Log.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox_Log.Multiline = True
        Me.TextBox_Log.Name = "TextBox_Log"
        Me.TextBox_Log.Size = New System.Drawing.Size(516, 478)
        Me.TextBox_Log.TabIndex = 3
        '
        'RichTextBox_Info
        '
        Me.RichTextBox_Info.BackColor = System.Drawing.SystemColors.Control
        Me.RichTextBox_Info.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox_Info.Location = New System.Drawing.Point(0, 34)
        Me.RichTextBox_Info.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RichTextBox_Info.Name = "RichTextBox_Info"
        Me.RichTextBox_Info.Size = New System.Drawing.Size(660, 478)
        Me.RichTextBox_Info.TabIndex = 4
        Me.RichTextBox_Info.Text = ""
        '
        'MenuStrip1
        '
        Me.MenuStrip1.GripMargin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.立即查询ToolStripMenuItem, Me.立即标识ToolStripMenuItem, Me.强制发布ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1176, 34)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '立即查询ToolStripMenuItem
        '
        Me.立即查询ToolStripMenuItem.Name = "立即查询ToolStripMenuItem"
        Me.立即查询ToolStripMenuItem.Size = New System.Drawing.Size(98, 28)
        Me.立即查询ToolStripMenuItem.Text = "立即查询"
        '
        '立即标识ToolStripMenuItem
        '
        Me.立即标识ToolStripMenuItem.Name = "立即标识ToolStripMenuItem"
        Me.立即标识ToolStripMenuItem.Size = New System.Drawing.Size(98, 28)
        Me.立即标识ToolStripMenuItem.Text = "立即发布"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "InfoReporter"
        Me.NotifyIcon1.Visible = True
        '
        '强制发布ToolStripMenuItem
        '
        Me.强制发布ToolStripMenuItem.Name = "强制发布ToolStripMenuItem"
        Me.强制发布ToolStripMenuItem.Size = New System.Drawing.Size(98, 28)
        Me.强制发布ToolStripMenuItem.Text = "强制发布"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1176, 542)
        Me.Controls.Add(Me.RichTextBox_Info)
        Me.Controls.Add(Me.TextBox_Log)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MinimumSize = New System.Drawing.Size(1189, 572)
        Me.Name = "MainForm"
        Me.Text = "InfoReporter"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents TextBox_Log As TextBox
    Friend WithEvents RichTextBox_Info As RichTextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 立即查询ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 立即标识ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel_Next As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_Res As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents 强制发布ToolStripMenuItem As ToolStripMenuItem
End Class
