<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SecuQuorOptions
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ShiftUpDown = New System.Windows.Forms.NumericUpDown()
        Me.KeycodeStatusLBL = New System.Windows.Forms.Label()
        Me.GenKeyButton = New System.Windows.Forms.Button()
        Me.KeycodeTXB = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CancelBTN = New System.Windows.Forms.Button()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ShiftUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ShiftUpDown)
        Me.GroupBox1.Controls.Add(Me.KeycodeStatusLBL)
        Me.GroupBox1.Controls.Add(Me.GenKeyButton)
        Me.GroupBox1.Controls.Add(Me.KeycodeTXB)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(390, 104)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SecuQuor Options"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Shift"
        '
        'ShiftUpDown
        '
        Me.ShiftUpDown.Location = New System.Drawing.Point(77, 48)
        Me.ShiftUpDown.Maximum = New Decimal(New Integer() {900000, 0, 0, 0})
        Me.ShiftUpDown.Minimum = New Decimal(New Integer() {900000, 0, 0, -2147483648})
        Me.ShiftUpDown.Name = "ShiftUpDown"
        Me.ShiftUpDown.Size = New System.Drawing.Size(113, 20)
        Me.ShiftUpDown.TabIndex = 9
        '
        'KeycodeStatusLBL
        '
        Me.KeycodeStatusLBL.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.KeycodeStatusLBL.Location = New System.Drawing.Point(7, 71)
        Me.KeycodeStatusLBL.Name = "KeycodeStatusLBL"
        Me.KeycodeStatusLBL.Size = New System.Drawing.Size(378, 21)
        Me.KeycodeStatusLBL.TabIndex = 7
        Me.KeycodeStatusLBL.Text = "Status:"
        Me.KeycodeStatusLBL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GenKeyButton
        '
        Me.GenKeyButton.Location = New System.Drawing.Point(196, 45)
        Me.GenKeyButton.Name = "GenKeyButton"
        Me.GenKeyButton.Size = New System.Drawing.Size(188, 23)
        Me.GenKeyButton.TabIndex = 8
        Me.GenKeyButton.Text = "Generate Signed SecuQuor Key"
        Me.GenKeyButton.UseVisualStyleBackColor = True
        '
        'KeycodeTXB
        '
        Me.KeycodeTXB.ForeColor = System.Drawing.Color.DarkGray
        Me.KeycodeTXB.Location = New System.Drawing.Point(77, 19)
        Me.KeycodeTXB.Name = "KeycodeTXB"
        Me.KeycodeTXB.Size = New System.Drawing.Size(307, 20)
        Me.KeycodeTXB.TabIndex = 3
        Me.KeycodeTXB.Text = "(Example: 821-121-2391-ABC)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Keycode"
        '
        'CancelBTN
        '
        Me.CancelBTN.Location = New System.Drawing.Point(246, 124)
        Me.CancelBTN.Name = "CancelBTN"
        Me.CancelBTN.Size = New System.Drawing.Size(75, 23)
        Me.CancelBTN.TabIndex = 8
        Me.CancelBTN.Text = "Cancel"
        Me.CancelBTN.UseVisualStyleBackColor = True
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(327, 124)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 9
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'SecuQuorOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(414, 159)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.CancelBTN)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "SecuQuorOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SecuQuorOptions"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ShiftUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ShiftUpDown As NumericUpDown
    Friend WithEvents KeycodeStatusLBL As Label
    Friend WithEvents GenKeyButton As Button
    Friend WithEvents KeycodeTXB As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CancelBTN As Button
    Friend WithEvents OKButton As Button
End Class
