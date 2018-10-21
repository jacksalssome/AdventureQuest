Public Class Form2

    'Main form variables:

    Public room As New Point(0, 0)
    Dim dir As String
    Dim TempMenu As String
    Dim Isstairsfound As Boolean
    Dim Isdarkroomfound As Boolean
    Dim WaitTimReason As String
    Dim bosshealth As Integer = 100
    Dim bossbuttons As String = "close"
    Dim health As Integer = 100
    Dim Userinput As String = ""
    Dim playerwin As Boolean = False
    Dim monstermove As String
    Dim ATempNumber As Integer = 0
    Dim counting As Integer = 0
    Dim IsGameStarted As Boolean = False
    Dim bosslevel As Boolean = False
    Dim StartOneTimeRun As Boolean = False
    Dim SettingMisc As String = ""
    Dim Nyan_cat As New PictureBox 'For Nyan Cat gif
    Dim Menutemp As String = False
    Dim miscbuttons As String
    Dim isbossready = False
    Dim Level As Integer = 1
    Dim temp2 As String


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles tim_time.Tick
        'time for highscore
        time = time + 1
    End Sub

    'Start menu:

    Private Sub but_new_Click(sender As Object, e As EventArgs) Handles but_new.Click
        'Sanatising the seed:
        If TxtSeed.Text = "" Then
            Form3.Show()
            'Everything is good to go, start the game:
            TempMenu = "opengamewindow"
            IsGameStarted = True
            StartOneTimeRun = True
            OC_Menus.Enabled = True
        Else
            Dim Value As Integer
            If Integer.TryParse(TxtSeed.Text, Value) Or Value > 0 AndAlso Value < 31 Then
                'Passed the checks, Planting the seed:
                Form3.playersseed = TxtSeed.Text
                Form3.Show()

                'Everything is good to go, start the game:
                TempMenu = "opengamewindow"
                IsGameStarted = True
                StartOneTimeRun = True
                OC_Menus.Enabled = True
            Else
                MsgBox("This isn't a seed, please enter a seed or leave the textbox empty.")
            End If
        End If
    End Sub

    '/========\
    '| Inputs |
    '\========/

    Private Sub but_rig_Click(sender As Object, e As EventArgs) Handles but_rig.Click
        room.X = room.X + 1
        dir = "right"
        Room_Checker.Enabled = True
    End Sub

    Private Sub but_for_Click(sender As Object, e As EventArgs) Handles but_for.Click
        room.Y = room.Y + 1
        dir = "forward"
        Room_Checker.Enabled = True
    End Sub

    Private Sub but_lef_Click(sender As Object, e As EventArgs) Handles but_lef.Click
        room.X = room.X - 1
        dir = "left"
        Room_Checker.Enabled = True
    End Sub

    Private Sub but_bac_Click(sender As Object, e As EventArgs) Handles but_bac.Click
        room.Y = room.Y - 1
        dir = "back"
        Room_Checker.Enabled = True
    End Sub

    Private Sub but_help_Click(sender As Object, e As EventArgs) Handles but_help.Click
        Form4.Show()
        Me.Hide()
    End Sub

    Private Sub Close_Help_Click(sender As Object, e As EventArgs)
        TempMenu = "closehelp"
        OC_Menus.Enabled = True
    End Sub

    Private Sub but_credits_Click(sender As Object, e As EventArgs) Handles but_credits.Click
        TempMenu = "opencredits"
        OC_Menus.Enabled = True
    End Sub

    Private Sub Close_Credits_Click(sender As Object, e As EventArgs) Handles Close_Credits.Click
        TempMenu = "closecredits"
        OC_Menus.Enabled = True
    End Sub

    Private Sub Close_Settings_Click(sender As Object, e As EventArgs) Handles Close_Settings.Click

        If IsGameStarted = True Then
            SettingMisc = "close"
        Else
            TempMenu = "closesettings"
        End If

        OC_Menus.Enabled = True

    End Sub

    Private Sub but_settings_Click(sender As Object, e As EventArgs) Handles but_settings.Click

        If IsGameStarted = True Then
            SettingMisc = "open"
        Else
            TempMenu = "opensettings"
        End If

        OC_Menus.Enabled = True

    End Sub

    Private Sub But_open_map_Click(sender As Object, e As EventArgs) Handles But_open_map.Click
        Form3.Show()
        But_open_map.Visible = False
    End Sub

    Private Sub but_quit_Click(sender As Object, e As EventArgs) Handles but_quit.Click
        Application.Exit() ' Dont delete me
    End Sub

    '/============\
    '| Processing |
    '\============/

    Private Sub Room_Checker_Tick(sender As Object, e As EventArgs) Handles Room_Checker.Tick

        'Extremly compact and complex room positioning checker, checks right, left, down, up.

        Dim WB As Boolean = True
        Dim WF As Boolean = True
        Dim WL As Boolean = True
        Dim WR As Boolean = True

        'First we well do boundry rooms

        ' | <- vertical 0
        If room.Y >= -1 And room.Y <= 10 And room.X = -1 Then
            If dir = "left" Then
                WL = False
                room.X = room.X + 1
            End If
        End If

        ' vetical 9 -> |
        If room.Y >= -1 And room.Y <= 10 And room.X = 10 Then
            If dir = "right" Then
                WR = False
                room.X = room.X - 1
            End If
        End If

        ' - V- horazontal 0
        If room.X >= -1 And room.X <= 10 And room.Y = -1 Then
            If dir = "back" Then
                WB = False
                room.Y = room.Y + 1
            End If
        End If

        ' - ^- horazontal 9
        If room.X >= -1 And room.X <= 10 And room.Y = 10 Then
            If dir = "forward" Then
                WF = False
                room.Y = room.Y - 1
            End If
        End If

        'This block checks if player is walking into a wall

        Randomize()

        Dim TempRND As Integer = ((3 * Rnd()) + 1)

        If WB = True And dir = "back" Then
            If TempRND = 1 Then
                Main.Text = "You walk backwards."
            ElseIf TempRND = 2 Then
                Main.Text = "You go backwards."
            ElseIf TempRND = 3 Then
                Main.Text = "You walk to the room behind you."
            End If
        ElseIf WF = True And dir = "forward" Then
            If TempRND = 1 Then
                Main.Text = "You walk forwards."
            ElseIf TempRND = 2 Then
                Main.Text = "You go forwards."
            ElseIf TempRND = 3 Then
                Main.Text = "You walk to the room in frount of you."
            End If
        ElseIf WL = True And dir = "left" Then
            If TempRND = 1 Then
                Main.Text = "You walk left."
            ElseIf TempRND = 2 Then
                Main.Text = "You go left."
            ElseIf TempRND = 3 Then
                Main.Text = "You walk to the room on your left."
            End If
        ElseIf WR = True And dir = "right" Then
            If TempRND = 1 Then
                Main.Text = "You walk right."
            ElseIf TempRND = 2 Then
                Main.Text = "You go right."
            ElseIf TempRND = 3 Then
                Main.Text = "You walk to the room on your right."
            End If
        ElseIf WB = False Or WF = False Or WR = False Or WL = False Then
            If TempRND = 1 Then
                Main.Text = "There's a wall there."
            ElseIf TempRND = 2 Then
                Main.Text = "You cant walk that way, theres a wall."
            ElseIf TempRND = 3 Then
                Main.Text = "Theres no door that way."
            End If
        End If

        dir = ""

        'All checks complete, update the map
        Form3.Map_Updater.Enabled = True

        'Check for stairs and darkrooms

        If Form3.stairsroomcoords = room.X.ToString & ", " & room.Y.ToString Then
            Isstairsfound = True
            miscbuttons = "openyesno"
            TempMenu = "closedirbuttons"
            OC_Menus.Enabled = True
            but_settings.Visible = False
            but_hs.Visible = False
            player_healthbar.Visible = False
            Label_health.Visible = False
            Main.Text = "Do you want to go to the next level?"
        End If

        For basic As Integer = 0 To 5
            If Form3.darkroomcoords(basic) = room.X.ToString & ", " & room.Y.ToString Then
                Isdarkroomfound = True
                TempMenu = "closedirbuttons"
                OC_Menus.Enabled = True
                ' Start showing boss:
                WaitTimReason = "startshowboss1"
                Wait_tim.Enabled = True
            End If
        Next

        Room_Checker.Enabled = False 'Stop timer

    End Sub

    Private Sub OC_Menus_Tick(sender As Object, e As EventArgs) Handles OC_Menus.Tick

        Dim standedbuttons As String = "" '*keep first

        If TempMenu = "openmainmenu" Then
            Menutemp = "normalopen"
            standedbuttons = "open"
        ElseIf TempMenu = "closemainmenu" Then
            Menutemp = "normalclose"
            standedbuttons = "close"
        End If

        If miscbuttons = "openyesno" Then
            but_yes.Visible = True
            but_no.Visible = True
        ElseIf miscbuttons = "closeyesno" Then
            but_yes.Visible = False
            but_no.Visible = False
        End If

        If Menutemp = "normalopen" Then
            player_healthbar.Visible = False
            Label_health.Visible = False
            but_bac.Visible = False
            but_for.Visible = False
            but_rig.Visible = False
            but_lef.Visible = False
            but_settings.Visible = False
        ElseIf Menutemp = "normalclose" Then
            player_healthbar.Visible = True
            Label_health.Visible = True
            but_bac.Visible = True
            but_for.Visible = True
            but_rig.Visible = True
            but_lef.Visible = True
            but_settings.Visible = True
        ElseIf TempMenu = "opengamewindow" Then
            player_healthbar.Visible = True
            Label_health.Visible = True
            standedbuttons = "close" 'close standed buttons and seed textbox
            TempMenu = "opendirbuttons"
            ADVQ_title.Visible = False
        End If

        'This timer mandages the setting, help and credit menu's

        If SettingMisc = "open" Then
            Combo_backcolor.Visible = True
            Combo_forecolor.Visible = True
            Combo_backimg.Visible = True
            Label_background.Visible = True
            label_text.Visible = True

            player_healthbar.Visible = False
            Label_health.Visible = False

            Main.Visible = False

            Close_Settings.Visible = True
            lbl_time.Visible = True
            but_settings.Visible = False

            but_bac.Visible = False
            but_for.Visible = False
            but_rig.Visible = False
            but_lef.Visible = False
        ElseIf SettingMisc = "close" Then
            Combo_backcolor.Visible = False
            Combo_forecolor.Visible = False
            Combo_backimg.Visible = False
            Label_background.Visible = False
            label_text.Visible = False

            Label_health.Visible = True
            player_healthbar.Visible = True

            Main.Visible = True

            Close_Settings.Visible = False
            lbl_time.Visible = False
            but_settings.Visible = True

            If bosslevel = False Then
                but_bac.Visible = True
                but_for.Visible = True
                but_rig.Visible = True
                but_lef.Visible = True
            End If
        End If

        'other

        If SettingMisc = "open" And bosslevel = True Then

            but_mvf.Visible = False
            but_mvb.Visible = False
            but_swings.Visible = False
            but_rollL.Visible = False
            but_rollR.Visible = False
            but_jump.Visible = False
            but_squat.Visible = False
            but_dodge.Visible = False
            but_fb.Visible = False
            but_melee.Visible = False
            but_hysay.Visible = False

            Pro_bosshealth.Visible = False
            boss_health.Visible = False
            player_healthbar.Visible = False
            Label_health.Visible = False

            Close_Settings.BringToFront()

            bossbuttons = "" 'Or this will be overided
        ElseIf SettingMisc = "close" And bosslevel = True And isbossready = True Then
            but_mvf.Visible = True
            but_mvb.Visible = True
            but_swings.Visible = True
            but_rollL.Visible = True
            but_rollR.Visible = True
            but_jump.Visible = True
            but_squat.Visible = True
            but_dodge.Visible = True
            but_fb.Visible = True
            but_melee.Visible = True
            but_hysay.Visible = True

            Pro_bosshealth.Visible = True
            boss_health.Visible = True
            player_healthbar.Visible = True
            Label_health.Visible = True
        End If

        If TempMenu = "opensettings" Then
            standedbuttons = "close"
            'buttons
            Close_Settings.Visible = True
            lbl_time.Visible = True
            Combo_backcolor.Visible = True
            Combo_forecolor.Visible = True
            Combo_backimg.Visible = True
            'labels
            Label_background.Visible = True
            label_text.Visible = True
        ElseIf TempMenu = "closesettings" Then
            standedbuttons = "open"
            Close_Settings.Visible = False
            lbl_time.Visible = False
            Combo_backcolor.Visible = False
            Combo_forecolor.Visible = False
            Combo_backimg.Visible = False
            'labels
            Label_background.Visible = False
            label_text.Visible = False
            'true
            but_settings.Visible = True
        End If

        If TempMenu = "opencredits" Then
            standedbuttons = "close"
            'Start True
            Close_Credits.Visible = True
            Textbox_Credits.Visible = True
        ElseIf TempMenu = "closecredits" Then
            standedbuttons = "open"
            'Start False
            Textbox_Credits.Visible = False
            Close_Credits.Visible = False
        End If

        'This cuts doown the number of lines so i dont have to repete myself
        If standedbuttons = "close" Then
            label_loadseed.Visible = False
            TxtSeed.Visible = False
            but_new.Visible = False
            but_credits.Visible = False
            but_help.Visible = False
            but_hs.Visible = False
            but_settings.Visible = False
            but_quit.Visible = False
        ElseIf standedbuttons = "open" Then
            'they are in order(of the designer view) so that i dont get confused
            label_loadseed.Visible = True
            TxtSeed.Visible = True
            but_new.Visible = True
            but_settings.Visible = True
            but_credits.Visible = True
            but_help.Visible = True
            but_hs.Visible = True
            but_quit.Visible = True
        End If

        'Direction buttons

        If TempMenu = "closedirbuttons" Or temp2 = "closedirbuttons" Then
            but_bac.Visible = False
            but_for.Visible = False
            but_lef.Visible = False
            but_rig.Visible = False
            Label_health.Location = New Point(16, 116)
            player_healthbar.Location = New Point(94, 113)
        ElseIf TempMenu = "opendirbuttons" Or temp2 = "opendirbuttons" Then
            but_bac.Visible = True
            but_for.Visible = True
            but_lef.Visible = True
            but_rig.Visible = True
            player_healthbar.Visible = True
            Label_health.Visible = True
            Main.Visible = True
            bossbuttons = "close"
            Label_health.Location = New Point(16, 204)
            player_healthbar.Location = New Point(94, 200)
        End If

        If bossbuttons = "open" Then
            but_mvf.Visible = True
            but_mvb.Visible = True
            but_swings.Visible = True
            but_rollL.Visible = True
            but_rollR.Visible = True
            but_jump.Visible = True
            but_squat.Visible = True
            but_dodge.Visible = True
            but_fb.Visible = True
            but_melee.Visible = True
            but_hysay.Visible = True

            Pro_bosshealth.Visible = True
            boss_health.Visible = True
        ElseIf bossbuttons = "enable" Then
            but_mvf.Enabled = True
            but_mvb.Enabled = True
            but_swings.Enabled = True
            but_rollL.Enabled = True
            but_rollR.Enabled = True
            but_jump.Enabled = True
            but_squat.Enabled = True
            but_dodge.Enabled = True
            but_fb.Enabled = True
            but_melee.Enabled = True
            but_hysay.Enabled = True
        ElseIf bossbuttons = "close" Then
            but_mvf.Visible = False
            but_mvb.Visible = False
            but_swings.Visible = False
            but_rollL.Visible = False
            but_rollR.Visible = False
            but_jump.Visible = False
            but_squat.Visible = False
            but_dodge.Visible = False
            but_fb.Visible = False
            but_melee.Visible = False
            but_hysay.Visible = False
            Pro_bosshealth.Visible = False
            boss_health.Visible = False
        ElseIf bossbuttons = "disable" Then
            but_mvf.Enabled = False
            but_mvb.Enabled = False
            but_swings.Enabled = False
            but_rollL.Enabled = False
            but_rollR.Enabled = False
            but_jump.Enabled = False
            but_squat.Enabled = False
            but_dodge.Enabled = False
            but_fb.Enabled = False
            but_melee.Enabled = False
            but_hysay.Enabled = False
        End If

        If StartOneTimeRun = True Then
            'Close_Settings.Location = New Point(180, 114) 'Not needed
            but_settings.Location = New Point(13, 171)
            but_settings.Visible = True
            Close_Settings.Visible = False
            lbl_time.Visible = False
            tim_time.Enabled = True
            StartOneTimeRun = False
        End If

        TempMenu = ""

        OC_Menus.Enabled = False

    End Sub

    Private Sub Test_Tick(sender As Object, e As EventArgs) Handles Test.Tick 'handels health and minamize, maximize.

        ' healthbar

        If health >= 100 Then 'Safty net
            player_healthbar.Value = 100
        Else
            player_healthbar = player_healthbar
        End If

        TextBox6.Text = Form3.playersseed 'Debugging

        'Minamize and maximise map conpanion with main window
        If Me.WindowState = FormWindowState.Minimized Then
            Form3.WindowState = FormWindowState.Minimized
        ElseIf Me.WindowState = FormWindowState.Normal Then
            Form3.WindowState = FormWindowState.Normal
        End If

        Pro_bosshealth.Value = bosshealth

        If bosshealth <= 0 Then
            playerwin = True
        End If

        lbl_time.Text = TimeOfDay

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        health = health + 10
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        health = health - 10
    End Sub

    '/=============\
    ' Combat system   inputs:
    '\=============/

    Private Sub but_mvf_Click(sender As Object, e As EventArgs) Handles but_mvf.Click
        Userinput = "mvf"
        Combat_tim.Enabled = True
    End Sub

    Private Sub but_mvb_Click(sender As Object, e As EventArgs) Handles but_mvb.Click
        Userinput = "mvb"
        Combat_tim.Enabled = True
    End Sub

    Private Sub but_swings_Click(sender As Object, e As EventArgs) Handles but_swings.Click
        Userinput = "swingsword"
        Combat_tim.Enabled = True
    End Sub

    Private Sub but_rollL_Click(sender As Object, e As EventArgs) Handles but_rollL.Click
        Userinput = "rolll"
        Combat_tim.Enabled = True
    End Sub

    Private Sub byt_rollR_Click(sender As Object, e As EventArgs) Handles but_rollR.Click
        Userinput = "rollr"
        Combat_tim.Enabled = True
    End Sub

    Private Sub but_squat_Click(sender As Object, e As EventArgs) Handles but_squat.Click
        Userinput = "squat"
        Combat_tim.Enabled = True
    End Sub

    Private Sub but_jump_Click(sender As Object, e As EventArgs) Handles but_jump.Click
        Userinput = "jump"
        Combat_tim.Enabled = True
    End Sub

    Private Sub but_dodge_Click(sender As Object, e As EventArgs) Handles but_dodge.Click
        Userinput = "dodge"
        Combat_tim.Enabled = True
    End Sub

    Private Sub but_hysay_Click(sender As Object, e As EventArgs) Handles but_hysay.Click
        Userinput = "hysay"
        Combat_tim.Enabled = True
    End Sub

    Private Sub but_fb_Click(sender As Object, e As EventArgs) Handles but_fb.Click
        Userinput = "fb"
        Combat_tim.Enabled = True
    End Sub

    Private Sub but_melee_Click(sender As Object, e As EventArgs) Handles but_melee.Click
        Userinput = "melee"
        Combat_tim.Enabled = True
    End Sub

    Private Sub Combat_tim_Tick(sender As Object, e As EventArgs) Handles Combat_tim.Tick

        ' The combat system is built on random, player actions change the risk.

        bossbuttons = "disable" 'Disable input buttons so player cant cheat
        OC_Menus.Enabled = True

        Randomize()

        Dim CombatMsg As Integer = 0
        Dim CombatMsgString As String = ""
        Dim MoveType As String = ""
        Dim isplayerkilled As Boolean = False
        Dim endmsg As String = ""
        Dim monstermovestring As String = ""

        Dim ARnddNumber As Integer = 0
        ARnddNumber = ((100 * Rnd()) + 1)

        Dim Moveattack As Boolean = False

        If Userinput = "mvf" Then
            MoveType = "move forward"
        ElseIf Userinput = "mvb" Then
            MoveType = "move backward"
        ElseIf Userinput = "swingsword" Then
            MoveType = "swing your sword"
            Moveattack = True
        ElseIf Userinput = "rolll" Then
            MoveType = "roll left"
        ElseIf Userinput = "rollr" Then
            MoveType = "roll right"
        ElseIf Userinput = "squat" Then
            MoveType = "squat down"
        ElseIf Userinput = "jump" Then
            MoveType = "jump up"
        ElseIf Userinput = "dodge" Then
            MoveType = "dodge"
        ElseIf Userinput = "hysay" Then
            MoveType = "hold your sword above you"
            Moveattack = True
        ElseIf Userinput = "fb" Then
            MoveType = "inflict a final blow"
            Moveattack = True
        ElseIf Userinput = "melee" Then
            MoveType = "melee attck"
            Moveattack = True
        End If

        'combatmsgsting

        Dim successmove As Boolean = False

        CombatMsg = ((10 * Rnd()) + 1)

        If CombatMsg <= 1 Then
            CombatMsgString = "luckily you are unharmed."
        ElseIf CombatMsg = 2 Then
            CombatMsgString = "the monster hits you, your head and legs detach from your body as they fly of into the sunset, to say the least, your dead."
            isplayerkilled = True
        ElseIf CombatMsg = 3 Then
            CombatMsgString = "you ded."
            isplayerkilled = True
        ElseIf CombatMsg = 4 Then
            CombatMsgString = "your successful."
            successmove = True
        ElseIf CombatMsg = 5 Then
            CombatMsgString = "you break the air speed record, unfortonatly you dont live to tell the tail."
            isplayerkilled = True
        ElseIf CombatMsg = 6 Then
            CombatMsgString = "you bearly make it. But your move was successful."
            successmove = True
        ElseIf CombatMsg = 7 Then
            CombatMsgString = "your speachless. Successful attack."
            successmove = True
        ElseIf CombatMsg = 8 Then
            CombatMsgString = "the monster does a horific smile."
        ElseIf CombatMsg = 9 Then
            CombatMsgString = "you yell out 'I WILL SURVIVE!'"
        ElseIf CombatMsg = 10 Then
            CombatMsgString = "you bearly make it."
        End If

        If Moveattack = True And successmove = True Then
            bosshealth = bosshealth - 20 'Only awarded to successful agressive attacks.
        End If

        Dim rndnumber As Integer = ((6 * Rnd()) + 1)

        If rndnumber = 2 Or rndnumber = 6 Then
            health = health - 15
        End If

        If monstermove = "leftswing" Then
            monstermovestring = "swing toward you from your left, "
        ElseIf monstermove = "rightswing" Then
            monstermovestring = "swing toward you from your right, "
        ElseIf monstermove = "upswing" Then
            monstermovestring = "swing from below you, "
        ElseIf monstermove = "downswing" Then
            monstermovestring = "swing from above you, "
        ElseIf monstermove = "kick" Then
            monstermovestring = "kick at you, "
        ElseIf monstermove = "punch" Then
            monstermovestring = "punch at you, "
        ElseIf monstermove = "lowleftswing" Then
            monstermovestring = "low level swing from your left, "
        ElseIf monstermove = "lowrightswing" Then
            monstermovestring = "low level swing from your right, "
        ElseIf monstermove = "highleftswing" Then
            monstermovestring = "high level swing from your left, "
        ElseIf monstermove = "highrightswing" Then
            monstermovestring = "high level swing from your right, "
        End If

        Dim themonster As String = ""
        Dim themonsternd As Integer = 0

        themonsternd = ((4 * Rnd()) + 1)

        If themonsternd = 1 Then
            themonster = ", it "
        ElseIf themonsternd = 2 Then
            themonster = ", the monster "
        ElseIf themonsternd = 3 Then
            themonster = ", the thing "
        ElseIf themonsternd >= 4 Then
            themonster = ", the thing in the shadows "
        End If

        Main.Text = "You " & MoveType & themonster & "does a " & monstermovestring & CombatMsgString 'Output

        If isplayerkilled = True Then
            but_play_again.Visible = True
        Else
            Randomize()
            Dim ZanottosNumber As Integer = ((2 * Rnd()) + 1)
            If ZanottosNumber = 2 And Moveattack = True And successmove = True Then '33.3% chance of defeating the boss
                Main.Text = Main.Text & vbCrLf & vbCrLf & "You slayed the boss" ' Playerwin
                playerwin = True
            Else
                WaitTimReason = "waitplayerreadthennextbossmove"
                Wait_tim.Enabled = True
            End If
        End If

        If playerwin = True Or bosshealth = 0 Then
            TempMenu = "opendirbuttons"
            OC_Menus.Enabled = True
            playerwin = False
            bosslevel = False
            bosshealth = 100
            isbossready = False
            bosspoints = bosspoints + 300
            bossbuttons = "disable"
            For basic As Integer = 0 To 5
                If Form3.darkroomcoords(basic) = room.X.ToString & ", " & room.Y.ToString Then
                    Form3.darkroomcoords(basic) = "cleared"
                    Dim calcx As Integer = 0
                    Dim calcy As Integer = 0
                    Dim finalcalc As Integer = 0

                    'The Exploation part of the game, small and magnificent
                    calcx = room.X + 1
                    calcy = -((room.Y) * 10) 'One of my finest achivments

                    finalcalc = calcx + (calcy + 90) 'This beauty took 30 minutes to work out, i am genius. (It inverts the cardasian plain on the y axis)

                    'This reveals the room in compliance with the randomly generated map
                    If finalcalc >= 1 And finalcalc <= 100 And finalcalc <> 91 Then 'gotta sanatize dem inputs
                        If Form3.TPicBox(finalcalc) Is Nothing Then ' Fix's a wird bug if user tryies to close the form
                        Else
                            Form3.TPicBox(finalcalc).BackgroundImage = My.Resources.EmpRoom
                        End If
                    End If
                End If
            Next

        End If

        Combat_tim.Enabled = False

    End Sub

    Private Sub boss_move_tim_Tick(sender As Object, e As EventArgs) Handles boss_move_tim.Tick

        bosslevel = True

        Main.Text = ""

        Randomize()

        Dim monstermovestring As String = ""
        Dim ARnddNumber As Integer = 0
        ARnddNumber = ((10 * Rnd()) + 1)

        If ARnddNumber <= 1 Then
            monstermove = "leftswing"
        ElseIf ARnddNumber = 2 Then
            monstermove = "rightswing"
        ElseIf ARnddNumber = 3 Then
            monstermove = "upswing"
        ElseIf ARnddNumber = 4 Then
            monstermove = "downswing"
        ElseIf ARnddNumber = 5 Then
            monstermove = "kick"
        ElseIf ARnddNumber = 6 Then
            monstermove = "punch"
        ElseIf ARnddNumber = 7 Then
            monstermove = "lowleftswing"
        ElseIf ARnddNumber = 8 Then
            monstermove = "lowrightswing"
        ElseIf ARnddNumber = 9 Then
            monstermove = "highleftswing"
        ElseIf ARnddNumber >= 10 Then
            monstermove = "highrightswing"
        End If

        If monstermove = "leftswing" Then
            monstermovestring = "swing toward you from your left."
        ElseIf monstermove = "rightswing" Then
            monstermovestring = "swing toward you from your right."
        ElseIf monstermove = "upswing" Then
            monstermovestring = "swing from below you."
        ElseIf monstermove = "downswing" Then
            monstermovestring = "swing from above you."
        ElseIf monstermove = "kick" Then
            monstermovestring = "kick at you."
        ElseIf monstermove = "punch" Then
            monstermovestring = "punch at you."
        ElseIf monstermove = "lowleftswing" Then
            monstermovestring = "low level swing from your left."
        ElseIf monstermove = "lowrightswing" Then
            monstermovestring = "low level swing from your right."
        ElseIf monstermove = "highleftswing" Then
            monstermovestring = "high level swing from your left."
        ElseIf monstermove = "highrightswing" Then
            monstermovestring = "high level swing from your right."
        Else
            monstermovestring = "Error: Boss move not found"
        End If

        Main.Text = "The monster does a " & monstermovestring

        If Combo_backcolor.Visible = False And but_fb.Visible = False Then
            bossbuttons = "open"
        Else
            bossbuttons = "enable" 'DO NOT REMOVE !IMPORTANT
        End If
        OC_Menus.Enabled = True

        boss_move_tim.Enabled = False

    End Sub

    Private Sub Wait_tim_Tick(sender As Object, e As EventArgs) Handles Wait_tim.Tick

        If WaitTimReason = "waitplayerreadthennextbossmove" Then
            If ATempNumber = 5 Then
                ATempNumber = 0
                boss_move_tim.Enabled = True
                Wait_tim.Enabled = False 'Remember to kill me here
                bossbuttons = "enable"
                OC_Menus.Enabled = True
            Else
                ATempNumber = ATempNumber + 1
            End If
        End If

        If WaitTimReason = "startshowboss1" Then

            counting = counting + 1

            Dim TempRND As Integer = ((3 * Rnd()) + 1)

            If counting = 1 Then
                If TempRND = 1 Then
                    Main.Text = "You enter the room."
                ElseIf TempRND = 2 Then
                    Main.Text = "You walk in."
                ElseIf TempRND = 3 Then
                    Main.Text = "Thats strange."
                End If
            ElseIf counting = 3 Then
                If TempRND = 1 Then
                    Main.Text = Main.Text + " The lights are out."
                ElseIf TempRND = 2 Then
                    Main.Text = Main.Text + " Theres no lightswitch."
                ElseIf TempRND = 3 Then
                    Main.Text = Main.Text + " Its dark, theres no lights on in here."
                End If
            ElseIf counting = 5 Then
                If TempRND = 1 Then
                    Main.Text = Main.Text + " The, theres something in here."
                ElseIf TempRND = 2 Then
                    Main.Text = Main.Text + " You hear heavy breathing,"
                ElseIf TempRND = 3 Then
                    Main.Text = Main.Text + " Your not alone."
                End If
            ElseIf counting = 7 Then
                If TempRND = 1 Then
                    Main.Text = Main.Text + " The door is locked behind you."
                ElseIf TempRND = 2 Then
                    Main.Text = Main.Text + " You cant find the door out."
                ElseIf TempRND = 3 Then
                    Main.Text = Main.Text + " Your traped."
                End If
            ElseIf counting = 9 Then
                If TempRND = 1 Then
                    Main.Text = Main.Text + " You hastily turn on your torch."
                ElseIf TempRND = 2 Then
                    Main.Text = Main.Text + " You pull out a torch."
                ElseIf TempRND = 3 Then
                    Main.Text = Main.Text + " You pull out your torch."
                End If
            ElseIf counting = 12 Then
                bossbuttons = "open"
                OC_Menus.Enabled = True
                boss_move_tim.Enabled = True
                counting = 0
                isbossready = True
                Wait_tim.Enabled = False 'Remember to kill me here
            End If

            bosslevel = True
        End If
    End Sub

    Private Sub but_play_again_Click(sender As Object, e As EventArgs) Handles but_play_again.Click
        Form3.Dispose()
        Form1.Dispose()
        Me.Dispose()
    End Sub

    Private Sub Combo_backcolor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combo_backcolor.SelectedIndexChanged

        'change background color

        Dim backcolorreal As Color

        If Combo_backcolor.SelectedItem = "black" Then
            backcolorreal = Color.FromArgb(39, 39, 39) 'Not acual black
        ElseIf Combo_backcolor.SelectedItem = "blue" Then
            backcolorreal = Color.FromArgb(28, 168, 221)
        ElseIf Combo_backcolor.SelectedItem = "pink" Then
            backcolorreal = Color.FromArgb(255, 40, 158)
        ElseIf Combo_backcolor.SelectedItem = "red" Then
            backcolorreal = Color.FromArgb(197, 27, 69)
        ElseIf Combo_backcolor.SelectedItem = "orange" Then
            backcolorreal = Color.FromArgb(255, 120, 71)
        ElseIf Combo_backcolor.SelectedItem = "purple" Then
            backcolorreal = Color.FromArgb(167, 86, 191)
        ElseIf Combo_backcolor.SelectedItem = "yellow" Then
            backcolorreal = Color.FromArgb(255, 255, 102)
        ElseIf Combo_backcolor.SelectedItem = "white" Then
            backcolorreal = Color.FromArgb(255, 255, 255)
        ElseIf Combo_backcolor.SelectedItem = "green" Then
            backcolorreal = Color.FromArgb(53, 107, 0)
        ElseIf Combo_backcolor.SelectedItem = "transparent" Then
            backcolorreal = Color.Transparent
        ElseIf Combo_backcolor.SelectedItem = "default" Then
            backcolorreal = Color.Gainsboro
        End If

        'Start Other

        but_play_again.BackColor = backcolorreal

        but_bac.BackColor = backcolorreal
        but_for.BackColor = backcolorreal
        but_rig.BackColor = backcolorreal
        but_lef.BackColor = backcolorreal

        but_credits.BackColor = backcolorreal
        but_help.BackColor = backcolorreal
        but_settings.BackColor = backcolorreal
        lbl_time.BackColor = backcolorreal
        but_quit.BackColor = backcolorreal
        but_new.BackColor = backcolorreal
        label_loadseed.BackColor = backcolorreal
        Close_Credits.BackColor = backcolorreal
        Close_Settings.BackColor = backcolorreal
        but_hs.BackColor = backcolorreal

        but_mvf.BackColor = backcolorreal
        but_mvb.BackColor = backcolorreal
        but_swings.BackColor = backcolorreal
        but_rollL.BackColor = backcolorreal
        but_jump.BackColor = backcolorreal
        but_rollR.BackColor = backcolorreal
        but_dodge.BackColor = backcolorreal
        but_squat.BackColor = backcolorreal
        but_melee.BackColor = backcolorreal
        but_fb.BackColor = backcolorreal
        but_hysay.BackColor = backcolorreal

        but_no.BackColor = backcolorreal
        but_yes.BackColor = backcolorreal

        Form1.but_back.BackColor = backcolorreal
        Form1.lbl_yourscore.BackColor = backcolorreal
        Form1.lblnames.BackColor = backcolorreal
        Form1.lblscores.BackColor = backcolorreal
        Form1.Label2.BackColor = backcolorreal
        Form1.Label3.BackColor = backcolorreal

        If backcolorreal = Color.Transparent Then
            backcolorreal = Color.WhiteSmoke
        End If

        TxtSeed.BackColor = backcolorreal
        Combo_forecolor.BackColor = backcolorreal
        Combo_backimg.BackColor = backcolorreal
        Combo_backcolor.BackColor = backcolorreal
        Me.BackColor = backcolorreal
        Form3.BackColor = backcolorreal
        Main.BackColor = backcolorreal 'Becuse #TextboxLivesMatter
        Form1.BackColor = backcolorreal
        player_healthbar.BackColor = backcolorreal
        Pro_bosshealth.BackColor = backcolorreal

        form3backcolor = backcolorreal

        backcolorreal = Color.Transparent

        Label_background.BackColor = backcolorreal
        label_text.BackColor = backcolorreal
        Label_health.BackColor = backcolorreal
        label_loadseed.BackColor = backcolorreal
        boss_health.BackColor = backcolorreal

    End Sub

    Private Sub Combo_forecolor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combo_forecolor.SelectedIndexChanged

        'change forecolor

        Dim forecolorreal As Color

        If Combo_forecolor.SelectedItem = "blue" Then
            forecolorreal = Color.FromArgb(28, 168, 221)
        ElseIf Combo_forecolor.SelectedItem = "pink" Then
            forecolorreal = Color.FromArgb(255, 40, 158)
        ElseIf Combo_forecolor.SelectedItem = "red" Then
            forecolorreal = Color.FromArgb(197, 27, 69)
        ElseIf Combo_forecolor.SelectedItem = "orange" Then
            forecolorreal = Color.FromArgb(255, 120, 71)
        ElseIf Combo_forecolor.SelectedItem = "purple" Then
            forecolorreal = Color.FromArgb(167, 86, 191)
        ElseIf Combo_forecolor.SelectedItem = "yellow" Then
            forecolorreal = Color.FromArgb(255, 255, 102)
        ElseIf Combo_forecolor.SelectedItem = "white" Then
            forecolorreal = Color.FromArgb(255, 255, 255)
        ElseIf Combo_forecolor.SelectedItem = "green" Then
            forecolorreal = Color.FromArgb(53, 107, 0)
        ElseIf Combo_forecolor.SelectedItem = "default" Then
            forecolorreal = Color.Black
        End If

        'Massive list incoming:

        but_play_again.ForeColor = forecolorreal

        but_bac.ForeColor = forecolorreal
        but_for.ForeColor = forecolorreal
        but_rig.ForeColor = forecolorreal
        but_lef.ForeColor = forecolorreal

        TxtSeed.ForeColor = forecolorreal
        but_credits.ForeColor = forecolorreal
        but_help.ForeColor = forecolorreal
        but_settings.ForeColor = forecolorreal
        lbl_time.ForeColor = forecolorreal
        but_quit.ForeColor = forecolorreal
        but_new.ForeColor = forecolorreal
        label_loadseed.ForeColor = forecolorreal
        Close_Credits.ForeColor = forecolorreal
        Close_Settings.ForeColor = forecolorreal
        but_hs.ForeColor = forecolorreal

        but_mvf.ForeColor = forecolorreal
        but_mvb.ForeColor = forecolorreal
        but_swings.ForeColor = forecolorreal
        but_rollL.ForeColor = forecolorreal
        but_jump.ForeColor = forecolorreal
        but_rollR.ForeColor = forecolorreal
        but_dodge.ForeColor = forecolorreal
        but_squat.ForeColor = forecolorreal
        but_melee.ForeColor = forecolorreal
        but_fb.ForeColor = forecolorreal
        but_hysay.ForeColor = forecolorreal

        Main.ForeColor = forecolorreal

        Label_background.ForeColor = forecolorreal
        label_text.ForeColor = forecolorreal
        Combo_backcolor.ForeColor = forecolorreal
        Combo_backimg.ForeColor = forecolorreal
        Combo_forecolor.ForeColor = forecolorreal

        Label_health.ForeColor = forecolorreal
        boss_health.ForeColor = forecolorreal

        but_no.ForeColor = forecolorreal
        but_yes.ForeColor = forecolorreal

        player_healthbar.BackColor = forecolorreal
        Pro_bosshealth.BackColor = forecolorreal

        form3forecolor = forecolorreal

        'Form1:
        Form1.but_back.ForeColor = forecolorreal
        Form1.lbl_yourscore.ForeColor = forecolorreal
        Form1.lblnames.ForeColor = forecolorreal
        Form1.lblscores.ForeColor = forecolorreal
        Form1.Label2.ForeColor = forecolorreal
        Form1.Label3.ForeColor = forecolorreal

    End Sub

    Private Sub Combo_backimg_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combo_backimg.SelectedIndexChanged
        Dim forecolorreal As Color = Nothing

        'Just change the background of the form duh

        Dim CloseNyanCat As Boolean = False

        If Combo_backimg.SelectedItem = "Night In A Valley" Then
            Me.BackgroundImage = My.Resources.background1
            CloseNyanCat = True
        ElseIf Combo_backimg.SelectedItem = "Airplane over NYC" Then
            Me.BackgroundImage = My.Resources.background2
            CloseNyanCat = True
        ElseIf Combo_backimg.SelectedItem = "Waterfall" Then
            Me.BackgroundImage = My.Resources.background3
            CloseNyanCat = True
        ElseIf Combo_backimg.SelectedItem = "KDE Desktop" Then
            Me.BackgroundImage = My.Resources.background4
            CloseNyanCat = True
        ElseIf Combo_backimg.SelectedItem = "Android Lollipop" Then
            Me.BackgroundImage = My.Resources.background5
            CloseNyanCat = True
        ElseIf Combo_backimg.SelectedItem = "Nyan Cat" Then
            Me.BackgroundImage = My.Resources.background6
            Nyan_cat.Image = My.Resources.background6 'Otherwise the previus image will ghost onto nyancat
            Nyan_cat.Location = New Point(0, 0)
            Nyan_cat.Size = New Size(264, 351)
            Nyan_cat.Visible = True
            Me.Controls.Add(Nyan_cat)
        ElseIf Combo_backimg.SelectedItem = "Earth From Space" Then
            Me.BackgroundImage = My.Resources.background7
            CloseNyanCat = True
        ElseIf Combo_backimg.SelectedItem = "Nothing" Then
            Me.BackgroundImage = Nothing
            CloseNyanCat = True
        End If

        If CloseNyanCat = True Then 'Makes the transition seamless
            Nyan_cat.Visible = False
        End If

    End Sub

    Private Sub but_yes_Click(sender As Object, e As EventArgs) Handles but_yes.Click

        'button yes

        If Isstairsfound = True Then
            If Level = 2 Then
                Main.Text = "You finished the game, do you want to show high scores?"
                enterhs = True
                Form1.Show()
                Form3.Dispose()
                TempMenu = "closedirbuttons"
                miscbuttons = "closeyesno"
                but_quit.Visible = True
                OC_Menus.Enabled = True
            Else
                miscbuttons = "closeyesno"
                OC_Menus.Enabled = True

                room.X = 0
                room.Y = 0
                Form3.Dispose()
                Form3.Show()
                Level = Level + 1

                Form3.Text = "Map Companion" + " (Level:" + Level.ToString + ")"

                TempMenu = "opendirbuttons"
                miscbuttons = "closeyesno"
                OC_Menus.Enabled = True
                Isstairsfound = False
            End If
        End If

    End Sub

    Private Sub but_no_Click(sender As Object, e As EventArgs) Handles but_no.Click

        'button no

        If Isstairsfound = True Then
            TempMenu = "opendirbuttons"
            miscbuttons = "closeyesno"
            OC_Menus.Enabled = True
            Isstairsfound = False
        End If

    End Sub

    Private Sub but_hs_Click(sender As Object, e As EventArgs) Handles but_hs.Click

        'high score button

        If IsGameStarted = True Then
            hsgoto = "GW"
            Form3.Hide()
        Else
            hsgoto = "MM"
        End If

        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load
        Combo_forecolor.SelectedItem = "white"
        Combo_backcolor.SelectedItem = "black"
        form3backcolor = Color.FromArgb(39, 39, 39)
    End Sub

    ' Thanks for reading yo, heres a cat:

    '    /\_/\
    '  =( °w° )=
    '    )   (  //
    '   (__ __)//

End Class