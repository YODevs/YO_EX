<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class reportunittest
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dtreport = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.passlabelstatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.failedlabelstatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.real_result = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ideal_Result = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Operation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.response = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dtreport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtreport
        '
        Me.dtreport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtreport.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dtreport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtreport.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.real_result, Me.ideal_Result, Me.Operation, Me.response})
        Me.dtreport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtreport.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtreport.Location = New System.Drawing.Point(0, 0)
        Me.dtreport.Name = "dtreport"
        Me.dtreport.Size = New System.Drawing.Size(605, 368)
        Me.dtreport.StandardTab = True
        Me.dtreport.TabIndex = 3
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.passlabelstatus, Me.failedlabelstatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 368)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(605, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'passlabelstatus
        '
        Me.passlabelstatus.BackColor = System.Drawing.Color.DarkGreen
        Me.passlabelstatus.ForeColor = System.Drawing.Color.Snow
        Me.passlabelstatus.Name = "passlabelstatus"
        Me.passlabelstatus.Size = New System.Drawing.Size(52, 17)
        Me.passlabelstatus.Text = "0 Passed"
        '
        'failedlabelstatus
        '
        Me.failedlabelstatus.BackColor = System.Drawing.Color.DarkRed
        Me.failedlabelstatus.ForeColor = System.Drawing.Color.Snow
        Me.failedlabelstatus.Name = "failedlabelstatus"
        Me.failedlabelstatus.Size = New System.Drawing.Size(47, 17)
        Me.failedlabelstatus.Text = "0 Failed"
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        '
        'real_result
        '
        Me.real_result.HeaderText = "Real Result"
        Me.real_result.Name = "real_result"
        '
        'ideal_Result
        '
        Me.ideal_Result.HeaderText = "Ideal Result"
        Me.ideal_Result.Name = "ideal_Result"
        '
        'Operation
        '
        Me.Operation.HeaderText = "Operation"
        Me.Operation.Name = "Operation"
        Me.Operation.ReadOnly = True
        '
        'response
        '
        Me.response.HeaderText = "Response"
        Me.response.Name = "response"
        '
        'reportunittest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(605, 390)
        Me.Controls.Add(Me.dtreport)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "reportunittest"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Report UnitTest"
        CType(Me.dtreport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtreport As Windows.Forms.DataGridView
    Friend WithEvents StatusStrip1 As Windows.Forms.StatusStrip
    Friend WithEvents passlabelstatus As Windows.Forms.ToolStripStatusLabel
    Friend WithEvents failedlabelstatus As Windows.Forms.ToolStripStatusLabel
    Friend WithEvents id As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents real_result As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ideal_Result As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Operation As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents response As Windows.Forms.DataGridViewTextBoxColumn
End Class
