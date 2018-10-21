Public Class Form4

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        Dim tempy As Color

        If ComboBox1.SelectedItem = "Red" Then
            tempy = Color.Red
        ElseIf ComboBox1.SelectedItem = "Blue" Then
            tempy = Color.Blue
        ElseIf ComboBox1.SelectedItem = "Default" Then
            tempy = Color.Gainsboro
        End If

        TextBox1.BackColor = tempy
        TextBox2.BackColor = tempy
        TextBox3.BackColor = tempy
        TextBox4.BackColor = tempy
        TextBox5.BackColor = tempy
        TextBox6.BackColor = tempy
        TextBox7.BackColor = tempy
        TextBox8.BackColor = tempy
        TextBox9.BackColor = tempy
        Me.BackColor = tempy

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Me.Close()
    End Sub
End Class