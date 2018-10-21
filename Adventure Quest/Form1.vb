Public Class Form1

    Private Sub cmdback_Click(sender As Object, e As EventArgs) Handles but_back.Click
        If hsgoto = "MM" Then
            Me.Close()
            Form2.Show()
        ElseIf hsgoto = "GW" Then
            Me.Close()
            Form3.Show()
            Form2.Show()
        Else 'just incase
            Me.Close()
            Form2.Show()
        End If
    End Sub

    Private Sub Form1_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        If hsgoto = "MM" Then
            Me.Close()
            Form2.Show()
        ElseIf hsgoto = "GW" Then
            Me.Close()
            Form3.Show()
            Form2.Show()
        Else 'just incase
            Me.Close()
            Form2.Show()
        End If
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        but_back.BackColor = form3backcolor
        lbl_yourscore.BackColor = form3backcolor
        lblnames.BackColor = form3backcolor
        lblscores.BackColor = form3backcolor
        Label2.BackColor = form3backcolor
        Label3.BackColor = form3backcolor

        Me.BackColor = form3backcolor

        but_back.ForeColor = form3forecolor
        lbl_yourscore.ForeColor = form3forecolor
        lblnames.ForeColor = form3forecolor
        lblscores.ForeColor = form3forecolor
        Label2.ForeColor = form3forecolor
        Label3.ForeColor = form3forecolor

        Dim nme(7) As String
        Dim score(7) As Integer
        Dim pname As String = ""
        Dim con As Boolean = True
        Dim tempnames As String
        Dim tempscores As String
        Dim time_score As Integer
        Dim Playerscore As Integer

        'Score calculation

        '10 seconds = -1 point
        '1 boss = 300 points
        time_score = time / 10
        Playerscore = bosspoints - time_score

        lblnames.Text = ""
        lblscores.Text = ""
        lbl_yourscore.Text = "Your Score:" & Playerscore

        'access stored highscores
        Dim objname As New System.IO.StreamReader(System.AppDomain.CurrentDomain.BaseDirectory & "names.txt")
        Dim objscore As New System.IO.StreamReader(System.AppDomain.CurrentDomain.BaseDirectory & "scores.txt")

        'Read stored highscores
        For count As Integer = 0 To 7
            score(count) = CType(objscore.ReadLine, Integer)
            nme(count) = objname.ReadLine
        Next

        'Close text file
        objname.Close()
        objscore.Close()

        'Check if player is viewing or creating a high score
        If enterhs = True Then
            'If score is high enoth add it
            If Playerscore > score(7) Then
                score(7) = Playerscore
                nme(7) = InputBox("Please Enter a Username", "Enter A Username", pname)
                If pname Is "" Then
                    Name = "Mr. No Name"
                End If
            End If
            Do While con = True
                con = False
                For count = 0 To 6
                    If score(count) < score(count + 1) Then
                        tempscores = score(count)
                        tempnames = nme(count)
                        score(count) = score(count + 1)
                        nme(count) = nme(count + 1)
                        score(count + 1) = tempscores
                        nme(count + 1) = tempnames
                        con = True
                    End If
                Next
            Loop

            For count = 0 To 7
                lblnames.Text = lblnames.Text & nme(count) & vbCrLf
                lblscores.Text = lblscores.Text & score(count) & vbCrLf
            Next

            My.Computer.FileSystem.WriteAllText("names.txt", lblnames.Text, False)
            My.Computer.FileSystem.WriteAllText("scores.txt", lblscores.Text, False)
        Else
            For count = 0 To 7
                lblnames.Text = lblnames.Text & nme(count) & vbCrLf
                lblscores.Text = lblscores.Text & score(count) & vbCrLf
            Next
        End If

    End Sub
End Class
