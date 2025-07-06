Imports System.Drawing.Design
Imports System.Drawing.Imaging
Imports System.IO

Public Class Form1
    Private random As New Random()
    'arrays for starting phase of games blink start loop for blink (ts does NOT work ill fix it later) animation start and timer just for that blink 
    Dim arrBlinkImages() As String = {"C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0017.jpeg", "C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0016.jpeg", "C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0017.jpeg", "C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0018.jpeg"}
    Dim intBlinkFrame As Integer = 0
    Dim intBlinkLoop As Integer = 0
    Dim boolAnimationStarted As Boolean = False
    Dim tmrBlink As New Timer()

    'more arrays and stuff for the brief flicker effect in each part of the breakroom
    Dim arrFlickerImages() As String = {}
    Dim intFlickerFrame As Integer = 0
    Dim tmrFlickerScene As New Timer()
    Dim strNextSceneImage As String = ""


    'integers to keep track of the turning / moving with the arrows
    Dim intCurrentSceneIndex As Integer = 0
    Dim intLeftClicks As Integer = 0
    Dim intRightClicks As Integer = 0


    'boolean and image of the r letter slip so its easier to type
    Dim boolCoffeePlayed As Boolean = False
    Dim strSlipRImage As String = "C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\SlipR.jpeg" ' Replace with actual path


    'main room image / main view of breakroom door for later use
    Dim strMainRoom As String = "C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0019.jpeg"


    'flicker filles for the sides of the room
    Dim strBreakroomSide2Dim As String = "C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0045.JPG"
    Dim arrBreakroomSide2Flicker As String() = {
        "C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0048.JPG",
        "C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0047.JPG"
    }
    'flicker filles for the sides of the room
    Dim strBreakroomSide1Dim As String = "C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0034.jpeg"
    Dim arrBreakroomSide1Flicker As String() = {
        "C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0033.jpeg",
        "C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0035.jpeg"
    }

    'idk why i named this fridge door when its the fridge open
    Dim strFridgeDoor As String = "C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0036.jpeg"


    'formatting for full screen and booleans i can use the conditions for scenes and stuff
    Dim controlLayouts As New Dictionary(Of Control, Rectangle)
    Dim originalFormSize As Size
    Dim boolRacoonClicked As Boolean = False
    Dim boolJobClicked As Boolean = False
    Dim boolYUMClicked As Boolean = False
    Dim boolFinal As Boolean = False
    'storage room in hallway file
    Dim strStorageRoom As String = "C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0057.JPG"

    'boolean i can use for conditions of rooms and escape scene
    Dim boolStorageKP As Boolean = False
    Dim boolWashroomKP As Boolean = False
    Dim boolManagerKP As Boolean = False


    'priv load sub for the blinking aniation
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetBackgroundImage(arrBlinkImages(0))

        tmrBlink.Interval = 500
        AddHandler tmrBlink.Tick, AddressOf BlinkTimer_Tick

        tmrFlickerScene.Interval = 300
        AddHandler tmrFlickerScene.Tick, AddressOf FlickerScene_Tick

        btnFridge.Visible = False
        btnCoffee.Visible = False
        btnBRDoor.Visible = False
        btnGoBack.Visible = False
        btnLeft.Visible = False
        btnRight.Visible = False

        originalFormSize = Me.Size

        'Save layout for all resizable controls
        For Each ctrl As Control In Me.Controls
            controlLayouts(ctrl) = ctrl.Bounds
        Next

        'timer setup
        tmrBlink.Interval = 150
        AddHandler tmrBlink.Tick, AddressOf BlinkTimer_Tick

        tmrFlickerScene.Interval = 300
        AddHandler tmrFlickerScene.Tick, AddressOf FlickerScene_Tick
    End Sub

    'click on form to acc start animation
    Private Sub Form1_Click(sender As Object, e As EventArgs) Handles Me.Click
        If Not boolAnimationStarted Then
            boolAnimationStarted = True
            intBlinkFrame = 0
            intBlinkLoop = 0
            tmrBlink.Start()
        End If
    End Sub

    'speed of animation main breakroom start images
    Private Sub BlinkTimer_Tick(sender As Object, e As EventArgs)
        SetBackgroundImage(arrBlinkImages(intBlinkFrame))
        intBlinkFrame += 1

        If intBlinkFrame >= arrBlinkImages.Length Then
            intBlinkFrame = 0
            intBlinkLoop += 1
        End If

        If intBlinkLoop >= 2 Then
            tmrBlink.Stop()
            SetBackgroundImage(strMainRoom)
            ShowMainButtons()
        End If
    End Sub


    'incase i crash bc my image files are wonky and i dont crashout tryna find out why
    Private Sub SetBackgroundImage(strPath As String)
        If File.Exists(strPath) Then
            Using fs As New FileStream(strPath, FileMode.Open, FileAccess.Read)
                Me.BackgroundImage = Image.FromStream(fs)
            End Using
        Else
            MessageBox.Show("Image not found: " & strPath)
        End If
    End Sub


    'room flickering for the side rooms of the breakroom
    Private Sub StartFlickerTransition(flickerImg1 As String, flickerImg2 As String, finalImg As String)
        arrFlickerImages = {flickerImg1, flickerImg2}
        intFlickerFrame = 0
        strNextSceneImage = finalImg
        tmrFlickerScene.Start()
    End Sub


    'speed of flicjers nd how they run
    Private Sub FlickerScene_Tick(sender As Object, e As EventArgs)
        If intFlickerFrame < arrFlickerImages.Length Then
            SetBackgroundImage(arrFlickerImages(intFlickerFrame))
            intFlickerFrame += 1
        Else
            tmrFlickerScene.Stop()
            SetBackgroundImage(strNextSceneImage)

            'buttons to return to the main room
            If strNextSceneImage = strMainRoom Then
                ShowMainButtons()
            ElseIf strNextSceneImage = strBreakroomSide1Dim Then
                btnYUM.Visible = Not boolYUMClicked
            End If

        End If
    End Sub


    'right turn to move to right sid eof room w diff stuff
    Private Sub btnRight_Click(sender As Object, e As EventArgs) Handles btnRight.Click
        intRightClicks += 1
        intLeftClicks = Math.Max(0, intLeftClicks - 1)

        intCurrentSceneIndex += 1
        If intCurrentSceneIndex > 2 Then intCurrentSceneIndex = 0

        If intCurrentSceneIndex = 0 Then
            SetBackgroundImage(strMainRoom)
            ShowMainButtons()
            btnYUM.Visible = False
            btnJOB.Visible = False
        ElseIf intCurrentSceneIndex = 1 Then
            'transition change the buttons
            btnFridge.Visible = False
            btnCoffee.Visible = False
            btnBRDoor.Visible = False
            btnYUM.Visible = True
            StartFlickerTransition(arrBreakroomSide1Flicker(0), arrBreakroomSide1Flicker(1), strBreakroomSide1Dim)

        ElseIf intCurrentSceneIndex = 2 Then
            'transition change the buttons
            btnFridge.Visible = False
            btnCoffee.Visible = False
            btnBRDoor.Visible = False

            If boolJobClicked Then
                SetBackgroundImage("C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0028.jpeg")
            Else
                btnJOB.Visible = True
                StartFlickerTransition(arrBreakroomSide2Flicker(0), arrBreakroomSide2Flicker(1), strBreakroomSide2Dim)
            End If
        End If

        'always have the arrows visible in breakroom
        btnRight.Visible = True
        btnLeft.Visible = True
    End Sub


    'same stuff as right click for left click
    Private Sub btnLeft_Click(sender As Object, e As EventArgs) Handles btnLeft.Click
        intLeftClicks += 1
        intRightClicks = Math.Max(0, intRightClicks - 1)

        intCurrentSceneIndex -= 1
        If intCurrentSceneIndex < 0 Then intCurrentSceneIndex = 2

        If intCurrentSceneIndex = 0 Then
            SetBackgroundImage(strMainRoom)
            ShowMainButtons()
            btnYUM.Visible = False
            btnJOB.Visible = False
        ElseIf intCurrentSceneIndex = 1 Then
            StartFlickerTransition(arrBreakroomSide1Flicker(0), arrBreakroomSide1Flicker(1), strBreakroomSide1Dim)

        ElseIf intCurrentSceneIndex = 2 Then
            If boolJobClicked Then
                SetBackgroundImage("C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0028.jpeg")
                btnFridge.Visible = False
                btnCoffee.Visible = False
                btnBRDoor.Visible = False
            Else
                btnJOB.Visible = True
                StartFlickerTransition(arrBreakroomSide2Flicker(0), arrBreakroomSide2Flicker(1), strBreakroomSide2Dim)
                btnFridge.Visible = False
                btnCoffee.Visible = False
                btnBRDoor.Visible = False
            End If
        End If

        'dont ask me why this is in here it lowkey breaks if its not i havent slept in a while
        btnRight.Visible = (intCurrentSceneIndex = 2)
        btnRight.Visible = True
        btnLeft.Visible = True

    End Sub


    'another not really useful uh method i used nut forgot abt so stopped using
    Private Sub ToggleBreakroomButtons(boolVisible As Boolean)
        btnFridge.Visible = boolVisible
        btnCoffee.Visible = boolVisible
        btnBRDoor.Visible = boolVisible
        btnLeft.Visible = boolVisible
        btnRight.Visible = boolVisible
        btnRacoon.Visible = False
    End Sub

    'same as previous
    Private Sub ShowMainButtons()
        btnFridge.Visible = True
        btnCoffee.Visible = True
        btnBRDoor.Visible = True
        btnLeft.Visible = True
        btnRight.Visible = True
    End Sub

    'fridge finding clues
    Private Sub btnFridge_Click(sender As Object, e As EventArgs) Handles btnFridge.Click
        If boolRacoonClicked Then
            'only the slip should show after being found os 
            SetBackgroundImage("C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0023.jpeg")
            btnGoBack.Visible = True
            btnRacoon.Visible = False
            btnBRDoor.Visible = False
            btnFridge.Visible = False
            btnCoffee.Visible = False
            btnLeft.Visible = False
            btnRight.Visible = False
        Else
            'if not regular fridge
            SetBackgroundImage(strFridgeDoor)
            btnBRDoor.Visible = False
            btnFridge.Visible = False
            btnCoffee.Visible = False
            btnLeft.Visible = False
            btnRight.Visible = False
            btnGoBack.Visible = True
            btnRacoon.Visible = True
        End If
    End Sub

    'breakroom door interacrion sqc
    Private Sub btnBRDoor_Click(sender As Object, e As EventArgs) Handles btnBRDoor.Click
        'Checks if all slips have been collected to allow the user to attempt the code
        If boolCoffeePlayed AndAlso boolRacoonClicked AndAlso boolJobClicked AndAlso boolYUMClicked Then
            Dim userCode As String = InputBox("Enter the code found on the slips:", "Hint its the most evil Organizer Manager you know", "Door Code")
            If String.IsNullOrEmpty(userCode) Then
                MessageBox.Show("No code entered", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return

            End If

            'Case-insensitive comparison
            If userCode.Trim().Equals("erin", StringComparison.OrdinalIgnoreCase) Then
                'if they get the code move onto the hallway stage
                SetBackgroundImage("C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0051.jpeg")
                btnGoBack.Visible = True
                btnBRDoor.Visible = False
                btnFridge.Visible = False
                btnCoffee.Visible = False
                btnLeft.Visible = False
                btnRight.Visible = False
                btnGoBack.Visible = False
                btnStorage.Visible = True
                btnEscape.Visible = True
                btnManager.Visible = True
                btnWashroom.Visible = True
            Else
                'prompt the u8ser to enter a different answer
                MessageBox.Show("Im so close to getting the code", "Not Yet", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Else
            'prompt the user that they need to collect all the slips even if they can guess the code
            MessageBox.Show("The door is locked I need to find the code maybe I should get some food first or consider getting a different j- jj JO- anyway go look around!")


        End If
    End Sub


    'coffee machine interaction sqc 
    Private Sub btnCoffee_Click(sender As Object, e As EventArgs) Handles btnCoffee.Click
        btnBRDoor.Visible = False
        btnFridge.Visible = False
        btnCoffee.Visible = False
        btnLeft.Visible = False
        btnRight.Visible = False
        If Not boolCoffeePlayed Then
            wmpCoffee.Dock = DockStyle.Fill
            wmpCoffee.Visible = True
            wmpCoffee.URL = "C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\coffee_video.mp4"
            wmpCoffee.Ctlcontrols.play()
            AddHandler wmpCoffee.PlayStateChange, AddressOf wmpCoffee_PlayStateChange
        Else
            'already got the slip so the image of the slip stays but they can go back save
            SetBackgroundImage(strSlipRImage)
            btnGoBack.Visible = True
        End If
    End Sub

    'video animation of the coffee maker 
    Private Sub wmpCoffee_PlayStateChange(sender As Object, e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent)

        If e.newState = 8 Then ' 8 = Media ended
            wmpCoffee.Visible = False
            boolCoffeePlayed = True

            SetBackgroundImage(strSlipRImage)
            btnGoBack.Visible = True
        End If
    End Sub

    'go back button that resets the user to the main door view of the breakroom 
    Private Sub btnGoBack_Click(sender As Object, e As EventArgs) Handles btnGoBack.Click
        SetBackgroundImage(strMainRoom)
        btnGoBack.Visible = False
        ToggleBreakroomButtons(True)
    End Sub


    'i chatgpted this part dont jump me please the resizing was breaking the program :(
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Dim xRatio As Double = Me.Width / originalFormSize.Width
        Dim yRatio As Double = Me.Height / originalFormSize.Height

        For Each ctrl As Control In Me.Controls
            If controlLayouts.ContainsKey(ctrl) Then
                Dim original = controlLayouts(ctrl)
                ctrl.Width = CInt(original.Width * xRatio)
                ctrl.Height = CInt(original.Height * yRatio)
                ctrl.Left = CInt(original.Left * xRatio)
                ctrl.Top = CInt(original.Top * yRatio)

                ' Optional: scale font size too
                ctrl.Font = New Font(ctrl.Font.FontFamily, CInt(ctrl.Font.Size * Math.Min(xRatio, yRatio)))
            End If
        Next
    End Sub

    'finding the fridge slip
    Private Sub btnRacoon_Click(sender As Object, e As EventArgs) Handles btnRacoon.Click
        SetBackgroundImage("C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0023.jpeg")
        boolRacoonClicked = True
        btnRacoon.Visible = False

    End Sub

    'finding the job slip or maybe an actual job who knows
    Private Sub btnJOB_Click(sender As Object, e As EventArgs) Handles btnJOB.Click
        PictureBox1.Visible = True
        btnJOB.Visible = False
    End Sub

    'rename later
    'too lazy to rename but anyway job application AHHH
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PictureBox1.Visible = False
        boolJobClicked = True
        strBreakroomSide2Dim = "C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0028.jpeg"
        SetBackgroundImage(strBreakroomSide2Dim)
    End Sub

    'spilled prob moldy timbits sqc
    Private Sub btnYUM_Click(sender As Object, e As EventArgs) Handles btnYUM.Click
        strBreakroomSide1Dim = "C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0030.jpeg"
        SetBackgroundImage(strBreakroomSide1Dim)

        boolYUMClicked = True
        btnYUM.Visible = False
    End Sub


    'storage room sq (guessiong key boxes) and removes unnecessary items on screen
    Private Sub btnStorage_Click(sender As Object, e As EventArgs) Handles btnStorage.Click
        If boolStorageKP = True Then
            SetBackgroundImage(strStorageRoom)
            btnEmpy1.Visible = False
            btnEmpty2.Visible = False
            btnEmpty3.Visible = False
            btnKeyPt.Visible = False
            btnGB2.Visible = True
            btnStorage.Visible = False
            btnWashroom.Visible = False
            btnManager.Visible = False
            btnEscape.Visible = False
            btnGoBack.Visible = False
        Else
            SetBackgroundImage("C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0056.JPG")
            btnStorage.Visible = False
            btnEscape.Visible = False
            btnManager.Visible = False
            btnWashroom.Visible = False
            btnGoBack.Visible = False
            btnEmpty2.Visible = True
            btnEmpty3.Visible = True
            btnEmpy1.Visible = True
            btnKeyPt.Visible = True
            btnGB2.Visible = True

        End If

    End Sub

    'final boss sequence minus the fighting cuz time crunch js random
    Private Sub btnEscape_Click(sender As Object, e As EventArgs) Handles btnEscape.Click
        'Hide all controls
        For Each ctrl As Control In Me.Controls
            ctrl.Visible = False
        Next

        If boolManagerKP AndAlso boolStorageKP AndAlso boolWashroomKP = True Then
            If Not boolFinal Then
                wmpFinal.Dock = DockStyle.Fill
                wmpFinal.Visible = True

                'Generate a random number between 1 and 10 inclu
                Dim rand As New Random()
                Dim chance As Integer = rand.Next(1, 11)
                Dim jokes As String = InputBox("Erin likes to hear jokes", "Can Humor save you?", "Type here")


                If String.IsNullOrWhiteSpace(jokes) Then
                    ' Auto kill if you dont tell a joke
                    wmpFinal.URL = "C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0025.MOV"
                    SetBackgroundImage("C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0083.jpeg")
                    MessageBox.Show("You said nothing... that's even worse. Erin is disappointed.")
                    wmpFinal.Ctlcontrols.play()
                    AddHandler wmpFinal.PlayStateChange, AddressOf wmpFinal_PlayStateChange
                    Exit Sub
                End If

                'Choose video based on random number
                If chance >= 6 Then
                    'RIP
                    wmpFinal.URL = "C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0025.MOV"
                    SetBackgroundImage("C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0083.jpeg")
                    MessageBox.Show("Really? wow that was bad...")
                Else
                    'Funny
                    wmpFinal.URL = "C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0026.MOV"
                    SetBackgroundImage("C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0083.jpeg")
                    MessageBox.Show("Oh wow you're pretty funny!")
                End If

                wmpFinal.Ctlcontrols.play()
                AddHandler wmpFinal.PlayStateChange, AddressOf wmpFinal_PlayStateChange
            Else
                'final scene alr played
                SetBackgroundImage("C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0083.jpeg")
            End If
        Else
            MessageBox.Show("My key isn't complete. I should check ALL the rooms thoroughly first.")
            SetBackgroundImage("C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0051.jpeg")
            btnEmpy1.Visible = False
            btnEmpty2.Visible = False
            btnEmpty3.Visible = False
            btnKeyPt.Visible = False
            btnManager.Visible = True
            btnWashroom.Visible = True
            btnEscape.Visible = True
            btnStorage.Visible = True
        End If
    End Sub




    'video animation of the coffee maker 
    Private Sub wmpFinal_PlayStateChange(sender As Object, e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent)

        If e.newState = 8 Then
            wmpFinal.Visible = False
            boolFinal = True
            SetBackgroundImage("C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0083.jpeg")


        End If
    End Sub

    'washroom play sqc save scene after finding key remove unnecessary screen items like others
    Private Sub btnWashroom_Click(sender As Object, e As EventArgs) Handles btnWashroom.Click
        If boolWashroomKP = True Then
            SetBackgroundImage("C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0064.JPG")
            btnGB2.Visible = True
            btnStorage.Visible = False
            btnWashroom.Visible = False
            btnManager.Visible = False
            btnEscape.Visible = False
            btnTSeat.Visible = False
            btnDewK.Visible = False
            btnGoBack.Visible = False
        Else
            SetBackgroundImage("C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0063.JPG")
            btnStorage.Visible = False
            btnEscape.Visible = False
            btnManager.Visible = False
            btnWashroom.Visible = False
            btnGoBack.Visible = False
            btnTSeat.Visible = True
            btnGB2.Visible = True

        End If
    End Sub


    'manager room play sqc remove items change screen update necessary variables
    Private Sub btnManager_Click(sender As Object, e As EventArgs) Handles btnManager.Click
        If boolManagerKP = True Then
            SetBackgroundImage("C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0059.JPG")
            btnGB2.Visible = True
            btnStorage.Visible = False
            btnWashroom.Visible = False
            btnManager.Visible = False
            btnEscape.Visible = False
            btnTSeat.Visible = False
            btnDewK.Visible = False
            btnGoBack.Visible = False
        Else
            SetBackgroundImage("C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0058.JPG")
            btnStorage.Visible = False
            btnEscape.Visible = False
            btnManager.Visible = False
            btnWashroom.Visible = False
            btnGoBack.Visible = False
            btnMngKP.Visible = True
            btnGB2.Visible = True

        End If
    End Sub


    'empty box for finding key part in storage
    Private Sub btnEmpy1_Click(sender As Object, e As EventArgs) Handles btnEmpy1.Click
        MessageBox.Show("Empty.")
    End Sub

    'empty box for finding key part in storage
    Private Sub btnEmpty2_Click(sender As Object, e As EventArgs) Handles btnEmpty2.Click
        MessageBox.Show("Nothing to see here")
    End Sub

    'empty box for finding key part in storage
    Private Sub btnEmpty3_Click(sender As Object, e As EventArgs) Handles btnEmpty3.Click
        MessageBox.Show("JACKPOT!! just kidding its empty :)")
    End Sub

    'actual key part in the storage room
    Private Sub btnKeyPt_Click(sender As Object, e As EventArgs) Handles btnKeyPt.Click
        SetBackgroundImage(strStorageRoom)
        btnEmpy1.Visible = False
        btnEmpty2.Visible = False
        btnEmpty3.Visible = False
        btnKeyPt.Visible = False
        btnGB2.Visible = True
        boolStorageKP = True
        btnGoBack.Visible = False
    End Sub

    'second go back button but for hallway area 9it was hard tyring to use the same one as b4 so
    Private Sub btnGB2_Click(sender As Object, e As EventArgs) Handles btnGB2.Click

        SetBackgroundImage("C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0051.jpeg")
        btnEmpy1.Visible = False
        btnEmpty2.Visible = False
        btnEmpty3.Visible = False
        btnKeyPt.Visible = False
        btnManager.Visible = True
        btnWashroom.Visible = True
        btnEscape.Visible = True
        btnStorage.Visible = True
    End Sub

    'toilet seat button interaction
    Private Sub btnTSeat_Click(sender As Object, e As EventArgs) Handles btnTSeat.Click
        btnTSeat.Visible = False
        btnDewK.Visible = True
        SetBackgroundImage("C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0062.JPG")
    End Sub

    'dookie in the toilet se3at button interaction
    Private Sub btnDewK_Click(sender As Object, e As EventArgs) Handles btnDewK.Click
        boolWashroomKP = True
        btnDewK.Visible = False
        SetBackgroundImage("C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0064.JPG")
    End Sub

    'managers room key part simple click
    Private Sub btnMngKP_Click(sender As Object, e As EventArgs) Handles btnMngKP.Click
        SetBackgroundImage("C:\Users\domoi\OneDrive\Desktop\Hackathon\FiveNightsAtTimmies\fixedExpresso\IMG_0059.JPG")
        btnMngKP.Visible = False
        boolManagerKP = True
    End Sub

End Class
