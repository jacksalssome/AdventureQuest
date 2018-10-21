Public Class Form3

    ' ! Import from game window !
    Public playersseed As Integer = 0

    'Export over items
    Public itemandcoordlist As ListBox
    Public stairsroomcoords As String
    Public darkroomcoords(5) As String

    'Local variables

    Dim LocX As Integer = 0
    Dim LocY As Integer = 0
    Dim NoOfDarkRooms As Integer = 0
    Dim NoOfStairsRooms As Integer = 0
    Dim ItemRndX As Integer = 0
    Dim ItemRndY As Integer = 0
    Public TPicBox(100) As PictureBox
    Dim stairsroomcoordspicbox As Integer
    Dim darkroomcoordspicbox(5) As Integer

    'Item storage
    Public itemstoragearray(20) As String '(20) Becuse theres 10coords + 10items

    Private Sub Form3_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Form2.But_open_map.Visible = True
        Me.Hide()
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles Me.Load

        '                                               ,  ,
        '                                              / \/ \
        '                                             (/ //_ \_
        '     .-._                                     \||  .  \
        '      \  '-._                           _,:__.-"/---\_ \
        ' ______/___  '.   .--------------------'~-'--.)__( , )\ \
        ' `'--.___  _\  /   |             Here        ,'    \)|\ `\|
        '     /_.-' _\ \ _:,_          Be Dragons           " ||   (
        '   .'__ _.' \'-/,`-~`                                |/
        '       '. ___.> /=,|  Abandon hope all ye who enter  |
        '      / .-'/_ )  '---------------------------------'
        '      )'  ( /(/
        '           \\ "
        '            '=='


        Me.BackColor = form3backcolor

        '  /====================\
        '   Starting map laying
        '  \====================/

        'Everything exept the player 10x10 picturebox is randomly generated

        Dim verytempnumber As Integer = 1

        'Folowing only needs to be run once:
        If playersseed = 0 Then
            Randomize()
        Else
            Randomize(playersseed)
        End If

        For i = 1 To 100

            'Size and location for the picturbox's (generates picturebox's propeties)
            TPicBox(i) = New PictureBox
            TPicBox(i).Location = New Point(LocX * 28, LocY * 28) 'Each picturebox overlays by 2px, so 30-2 = 28
            TPicBox(i).Size = New Size(30, 30)
            TPicBox(i).Visible = False 'REMOVE ME!
            Me.Controls.Add(TPicBox(i)) 'Important, or we wont have control over the picturebox's

            LocX = LocX + 1 'Move to the next picturebox that needs generating

            If LocX = 10 Then 'Fills out a row of picturebox and then move down to the next colum untill it gets to 100
                LocY = LocY + 1
                LocX = 0
            End If

            'If no seed entered generate new map:

            'The following is optimized, but NOT the best solution:
            Dim RoomChooser As Integer = ((100 * Rnd()) + 1) '100 rooms, 100 possible places

            If RoomChooser = 1 Then ' Scales approxemate to how many i want
                If i <> 91 Then 'Dont do anything to bedroom
                    If NoOfStairsRooms >= 1 Then 'inbuilt error checking to reduce generation time.
                        TPicBox(i).BackgroundImage = My.Resources.EmpRoom 'temporty placeholder
                    Else
                        TPicBox(i).BackgroundImage = My.Resources.StairsRoom
                        NoOfStairsRooms = NoOfStairsRooms + 1
                        stairsroomcoords = (TPicBox(i).Location.X / 28) & ", " & -((TPicBox(i).Location.Y / 28) - 9)
                        stairsroomcoordspicbox = i
                    End If
                End If
            ElseIf RoomChooser = 2 Or RoomChooser = 3 Or RoomChooser = 4 Then 'i want 2 or 3 of these
                If i <> 91 Then 'Dont do anything to bedroom
                    If NoOfDarkRooms >= 4 Then
                        TPicBox(i).BackgroundImage = My.Resources.EmpRoom
                    Else
                        TPicBox(i).BackgroundImage = My.Resources.DarkRoom
                        NoOfDarkRooms = NoOfDarkRooms + 1
                        darkroomcoords(verytempnumber) = (TPicBox(i).Location.X.ToString / 28) & ", " & -((TPicBox(i).Location.Y.ToString / 28) - 9)
                        darkroomcoordspicbox(verytempnumber) = i
                        verytempnumber = verytempnumber + 1
                    End If
                End If

            ElseIf RoomChooser >= 5 Then ' >=5 offers room for expansion

                Dim Temptemp As Integer = ((75 * Rnd()) + 1)

                If Temptemp = 1 Then
                    TPicBox(i).BackgroundImage = My.Resources.BodyLineRoom
                ElseIf Temptemp = 2 Then
                    TPicBox(i).BackgroundImage = My.Resources.WasteLeakRoom
                ElseIf Temptemp = 3 Then
                    TPicBox(i).BackgroundImage = My.Resources.WaterLeakRoom
                ElseIf Temptemp = 4 Then
                    TPicBox(i).BackgroundImage = My.Resources.BloodRoom
                ElseIf Temptemp >= 5 Then
                    TPicBox(i).BackgroundImage = My.Resources.EmpRoom
                End If

            End If

            'Check map meets requirments, incase something has gone horably wrong. This sucks yo.
            If i = 100 Then
                'This will get 2 * DarkRooms and 1 * stairs
                If NoOfDarkRooms <= 1 Or NoOfStairsRooms = 0 Or NoOfStairsRooms >= 2 Then
                    'Insted of editing the map to meet the reqirments i just generte a new one and check that one:
                    verytempnumber = 0
                    NoOfDarkRooms = 0
                    NoOfStairsRooms = 0
                    LocX = 0
                    LocY = 0
                    stairsroomcoords = 0
                    stairsroomcoordspicbox = 0
                    For what As Integer = 1 To 5
                        darkroomcoords(what) = 0
                        darkroomcoordspicbox(what) = 0
                    Next
                    'This was a pain to come up with, it removes all the pictureboxes so they can be replaced by the next regeneration:
                    For t As Integer = 1 To 100
                        Me.Controls.Remove(TPicBox(t))
                    Next
                    i = 0 'All PBox's removed, start again
                Else
                    'Map generated and meets requirements, fill it with items:

                    TPicBox(91).Image = My.Resources.BedRoom 'Place the bedroom in the players starting position
                    TPicBox(91).BackgroundImage = Nothing 'Fixes a bug with bedroom transperency
                    TPicBox(91).Visible = True

                    Dim TBoxLocX As Integer = 0
                    Dim TBoxLocY As Integer = 0
                    Dim ItemChooser As Integer = 0
                    Dim RndItem As String = ""

                    If playersseed = 0 Then
                        Randomize()
                    Else
                        Randomize(playersseed)
                    End If

                    Dim Intnumber As Integer = 0

                    For a As Integer = 1 To 10

                        'Generate 10 item coords
                        ItemChooser = ((99 * Rnd()) + 1)

                        TBoxLocX = TPicBox(ItemChooser).Location.X
                        TBoxLocY = TPicBox(ItemChooser).Location.Y

                        'cords saving

                        TBoxLocX = TBoxLocX / 28 'Convert from real cords to 10x10 coords
                        TBoxLocY = TBoxLocY / 28 ' ^^

                        itemstoragearray(Intnumber) = TBoxLocX & ", " & TBoxLocY

                        TextBox9.Text = TextBox9.Text + itemstoragearray(Intnumber) 'Debugging
                        Intnumber = Intnumber + 1 '!Important Don't remove!

                        'Generate from 4 items

                        Dim ARnd As Integer
                        ARnd = ((10 * Rnd()) + 1) '10 items

                        If ARnd <= 1 Then ' Scales approxemate to how many i want

                            RndItem = "sword"

                        ElseIf ARnd = 2 Then 'i want 2 or 3 of these

                            RndItem = "Axe"

                        ElseIf ARnd >= 3 Then ' >=4 offers room for expansion

                            RndItem = "Dagger"

                        End If

                        'Save items
                        itemstoragearray(Intnumber) = RndItem

                        TextBox9.Text = TextBox9.Text + itemstoragearray(Intnumber) 'Debugging
                        Intnumber = Intnumber + 1 '!Important Don't remove

                        'Finish
                    Next
                End If
            End If
        Next

        Label2.Visible = False 'Remove "Generting Map" label becuse map is generated

    End Sub

    Private Sub Map_Updater_Tick(sender As Object, e As EventArgs) Handles Map_Updater.Tick

        PictureBox1.Location = New Point(Form2.room.X * 28 + 10, Form2.room.Y * -28 + 262) '262 is a magic number becuse the pictureboxes have a 2px border 'DO NOT REMOVE

        Dim calcx As Integer = 0
        Dim calcy As Integer = 0
        Dim finalcalc As Integer = 0

        'The Exploation part of the game, small and magnificent
        calcx = Form2.room.X + 1
        calcy = -((Form2.room.Y) * 10) 'One of my finest achivments

        finalcalc = calcx + (calcy + 90) 'This beauty took 30 minutes to work out, i am genius. (It inverts the cardasian plain on the y axis)

        'This reveals the room in compliance with the randomly generated map
        If finalcalc >= 1 And finalcalc <= 100 And finalcalc <> 91 Then 'gotta sanatize dem inputs
            If TPicBox(finalcalc) Is Nothing Then ' Fix's a wird bug if user tryies to close the form
            Else
                TPicBox(finalcalc).Visible = True
            End If
        End If

        calcx = 0
        calcy = 0
        finalcalc = 0

        Map_Updater.Enabled = False

    End Sub
End Class
