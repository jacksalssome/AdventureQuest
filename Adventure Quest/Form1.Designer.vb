<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.but_back = New System.Windows.Forms.Button()
        Me.lblscores = New System.Windows.Forms.Label()
        Me.lblnames = New System.Windows.Forms.Label()
        Me.lbl_yourscore = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'but_back
        '
        Me.but_back.BackColor = System.Drawing.Color.Gainsboro
        Me.but_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.but_back.ForeColor = System.Drawing.Color.White
        Me.but_back.Location = New System.Drawing.Point(100, 161)
        Me.but_back.Margin = New System.Windows.Forms.Padding(2)
        Me.but_back.Name = "but_back"
        Me.but_back.Size = New System.Drawing.Size(75, 23)
        Me.but_back.TabIndex = 5
        Me.but_back.Text = "Back"
        Me.but_back.UseVisualStyleBackColor = False
        '
        'lblscores
        '
        Me.lblscores.AutoSize = True
        Me.lblscores.ForeColor = System.Drawing.Color.White
        Me.lblscores.Location = New System.Drawing.Point(141, 45)
        Me.lblscores.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblscores.Name = "lblscores"
        Me.lblscores.Size = New System.Drawing.Size(35, 13)
        Me.lblscores.TabIndex = 4
        Me.lblscores.Text = "Score"
        '
        'lblnames
        '
        Me.lblnames.AutoSize = True
        Me.lblnames.ForeColor = System.Drawing.Color.White
        Me.lblnames.Location = New System.Drawing.Point(11, 45)
        Me.lblnames.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblnames.Name = "lblnames"
        Me.lblnames.Size = New System.Drawing.Size(40, 13)
        Me.lblnames.TabIndex = 3
        Me.lblnames.Text = "Names"
        '
        'lbl_yourscore
        '
        Me.lbl_yourscore.AutoSize = True
        Me.lbl_yourscore.ForeColor = System.Drawing.Color.White
        Me.lbl_yourscore.Location = New System.Drawing.Point(11, 9)
        Me.lbl_yourscore.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_yourscore.Name = "lbl_yourscore"
        Me.lbl_yourscore.Size = New System.Drawing.Size(88, 13)
        Me.lbl_yourscore.TabIndex = 6
        Me.lbl_yourscore.Text = "Your score: 1000"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(141, 27)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Score:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(11, 27)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Name:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(184, 193)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbl_yourscore)
        Me.Controls.Add(Me.but_back)
        Me.Controls.Add(Me.lblscores)
        Me.Controls.Add(Me.lblnames)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.Text = "High score"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents but_back As System.Windows.Forms.Button
    Friend WithEvents lblscores As System.Windows.Forms.Label
    Friend WithEvents lblnames As System.Windows.Forms.Label
    Friend WithEvents lbl_yourscore As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
