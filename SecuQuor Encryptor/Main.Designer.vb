<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Secuquor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Secuquor))
        Me.EncodedTXB = New System.Windows.Forms.TextBox()
        Me.DecodedTXB = New System.Windows.Forms.TextBox()
        Me.ModeBox = New System.Windows.Forms.GroupBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.ModeBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'EncodedTXB
        '
        Me.EncodedTXB.Enabled = False
        Me.EncodedTXB.ForeColor = System.Drawing.Color.DarkGray
        Me.EncodedTXB.Location = New System.Drawing.Point(12, 64)
        Me.EncodedTXB.Multiline = True
        Me.EncodedTXB.Name = "EncodedTXB"
        Me.EncodedTXB.Size = New System.Drawing.Size(385, 352)
        Me.EncodedTXB.TabIndex = 0
        Me.EncodedTXB.Text = "Encrypted text goes here"
        '
        'DecodedTXB
        '
        Me.DecodedTXB.Enabled = False
        Me.DecodedTXB.ForeColor = System.Drawing.Color.DarkGray
        Me.DecodedTXB.Location = New System.Drawing.Point(12, 422)
        Me.DecodedTXB.Name = "DecodedTXB"
        Me.DecodedTXB.Size = New System.Drawing.Size(385, 20)
        Me.DecodedTXB.TabIndex = 1
        Me.DecodedTXB.Text = "Decrypted text goes here"
        '
        'ModeBox
        '
        Me.ModeBox.Controls.Add(Me.LinkLabel2)
        Me.ModeBox.Controls.Add(Me.ComboBox1)
        Me.ModeBox.Location = New System.Drawing.Point(12, 12)
        Me.ModeBox.Name = "ModeBox"
        Me.ModeBox.Size = New System.Drawing.Size(390, 46)
        Me.ModeBox.TabIndex = 6
        Me.ModeBox.TabStop = False
        Me.ModeBox.Text = "Select Mode"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Enabled = False
        Me.LinkLabel2.Location = New System.Drawing.Point(341, 21)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(43, 13)
        Me.LinkLabel2.TabIndex = 9
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Options"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(10, 18)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(325, 21)
        Me.ComboBox1.TabIndex = 8
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(334, 445)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(63, 13)
        Me.LinkLabel1.TabIndex = 7
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "What's new"
        '
        'Secuquor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(409, 467)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.ModeBox)
        Me.Controls.Add(Me.DecodedTXB)
        Me.Controls.Add(Me.EncodedTXB)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Secuquor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SecuQuor [Version 2.0]"
        Me.ModeBox.ResumeLayout(False)
        Me.ModeBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents EncodedTXB As TextBox
    Friend WithEvents DecodedTXB As TextBox
    Friend WithEvents ModeBox As GroupBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents LinkLabel2 As LinkLabel
End Class
