<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        btnFridge = New Button()
        btnBRDoor = New Button()
        btnCoffee = New Button()
        btnLeft = New Button()
        btnRight = New Button()
        wmpCoffee = New AxWMPLib.AxWindowsMediaPlayer()
        btnGoBack = New Button()
        btnRacoon = New Button()
        btnJOB = New Button()
        PictureBox1 = New PictureBox()
        btnYUM = New Button()
        btnStorage = New Button()
        btnWashroom = New Button()
        btnManager = New Button()
        btnEscape = New Button()
        btnEmpy1 = New Button()
        btnEmpty2 = New Button()
        btnKeyPt = New Button()
        btnEmpty3 = New Button()
        btnGB2 = New Button()
        btnTSeat = New Button()
        btnDewK = New Button()
        btnMngKP = New Button()
        wmpFinal = New AxWMPLib.AxWindowsMediaPlayer()
        CType(wmpCoffee, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(wmpFinal, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnFridge
        ' 
        btnFridge.BackColor = Color.Transparent
        btnFridge.FlatStyle = FlatStyle.Flat
        btnFridge.ForeColor = Color.Gray
        btnFridge.Location = New Point(451, 127)
        btnFridge.Name = "btnFridge"
        btnFridge.Size = New Size(112, 189)
        btnFridge.TabIndex = 0
        btnFridge.Text = "Fridge"
        btnFridge.UseVisualStyleBackColor = False
        btnFridge.Visible = False
        ' 
        ' btnBRDoor
        ' 
        btnBRDoor.BackColor = Color.Transparent
        btnBRDoor.FlatStyle = FlatStyle.Flat
        btnBRDoor.Location = New Point(222, 89)
        btnBRDoor.Name = "btnBRDoor"
        btnBRDoor.Size = New Size(156, 227)
        btnBRDoor.TabIndex = 1
        btnBRDoor.Text = "Break Room Door"
        btnBRDoor.UseVisualStyleBackColor = False
        btnBRDoor.Visible = False
        ' 
        ' btnCoffee
        ' 
        btnCoffee.BackColor = Color.Transparent
        btnCoffee.FlatStyle = FlatStyle.Flat
        btnCoffee.Location = New Point(-5, 127)
        btnCoffee.Name = "btnCoffee"
        btnCoffee.Size = New Size(184, 207)
        btnCoffee.TabIndex = 2
        btnCoffee.Text = "Coffee Table"
        btnCoffee.UseVisualStyleBackColor = False
        btnCoffee.Visible = False
        ' 
        ' btnLeft
        ' 
        btnLeft.BackColor = Color.Transparent
        btnLeft.BackgroundImage = My.Resources.Resources.LeftArrow
        btnLeft.BackgroundImageLayout = ImageLayout.Stretch
        btnLeft.FlatStyle = FlatStyle.Flat
        btnLeft.Location = New Point(12, 369)
        btnLeft.Name = "btnLeft"
        btnLeft.Size = New Size(84, 76)
        btnLeft.TabIndex = 3
        btnLeft.UseVisualStyleBackColor = False
        btnLeft.Visible = False
        ' 
        ' btnRight
        ' 
        btnRight.BackColor = Color.Transparent
        btnRight.BackgroundImage = My.Resources.Resources.RightArrow
        btnRight.BackgroundImageLayout = ImageLayout.Stretch
        btnRight.FlatStyle = FlatStyle.Flat
        btnRight.Location = New Point(502, 364)
        btnRight.Name = "btnRight"
        btnRight.Size = New Size(91, 86)
        btnRight.TabIndex = 4
        btnRight.UseVisualStyleBackColor = False
        btnRight.Visible = False
        ' 
        ' wmpCoffee
        ' 
        wmpCoffee.Enabled = True
        wmpCoffee.Location = New Point(-5, 0)
        wmpCoffee.Name = "wmpCoffee"
        wmpCoffee.OcxState = CType(resources.GetObject("wmpCoffee.OcxState"), AxHost.State)
        wmpCoffee.Size = New Size(613, 493)
        wmpCoffee.TabIndex = 5
        wmpCoffee.Visible = False
        ' 
        ' btnGoBack
        ' 
        btnGoBack.BackColor = Color.Transparent
        btnGoBack.BackgroundImage = My.Resources.Resources.LeftArrow
        btnGoBack.BackgroundImageLayout = ImageLayout.Zoom
        btnGoBack.FlatStyle = FlatStyle.Flat
        btnGoBack.Location = New Point(467, 44)
        btnGoBack.Name = "btnGoBack"
        btnGoBack.Size = New Size(86, 77)
        btnGoBack.TabIndex = 6
        btnGoBack.Text = "GO BACK"
        btnGoBack.UseVisualStyleBackColor = False
        ' 
        ' btnRacoon
        ' 
        btnRacoon.BackColor = Color.Transparent
        btnRacoon.FlatStyle = FlatStyle.Flat
        btnRacoon.Location = New Point(484, 232)
        btnRacoon.Name = "btnRacoon"
        btnRacoon.Size = New Size(94, 102)
        btnRacoon.TabIndex = 7
        btnRacoon.UseVisualStyleBackColor = False
        btnRacoon.Visible = False
        ' 
        ' btnJOB
        ' 
        btnJOB.BackColor = Color.Transparent
        btnJOB.FlatStyle = FlatStyle.Flat
        btnJOB.ForeColor = Color.Gray
        btnJOB.Location = New Point(367, 340)
        btnJOB.Name = "btnJOB"
        btnJOB.Size = New Size(129, 70)
        btnJOB.TabIndex = 8
        btnJOB.UseVisualStyleBackColor = False
        btnJOB.Visible = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.BackgroundImage = My.Resources.Resources.JOB
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Location = New Point(174, 33)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(249, 377)
        PictureBox1.TabIndex = 9
        PictureBox1.TabStop = False
        PictureBox1.Visible = False
        ' 
        ' btnYUM
        ' 
        btnYUM.BackColor = Color.Transparent
        btnYUM.FlatStyle = FlatStyle.Flat
        btnYUM.ForeColor = Color.Gray
        btnYUM.Location = New Point(276, 322)
        btnYUM.Name = "btnYUM"
        btnYUM.Size = New Size(137, 57)
        btnYUM.TabIndex = 10
        btnYUM.UseVisualStyleBackColor = False
        btnYUM.Visible = False
        ' 
        ' btnStorage
        ' 
        btnStorage.BackColor = Color.Transparent
        btnStorage.FlatStyle = FlatStyle.Flat
        btnStorage.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(0))
        btnStorage.Location = New Point(34, 138)
        btnStorage.Name = "btnStorage"
        btnStorage.Size = New Size(134, 225)
        btnStorage.TabIndex = 11
        btnStorage.UseVisualStyleBackColor = False
        btnStorage.Visible = False
        ' 
        ' btnWashroom
        ' 
        btnWashroom.BackColor = Color.Transparent
        btnWashroom.FlatStyle = FlatStyle.Flat
        btnWashroom.Location = New Point(419, 138)
        btnWashroom.Name = "btnWashroom"
        btnWashroom.Size = New Size(59, 196)
        btnWashroom.TabIndex = 12
        btnWashroom.UseVisualStyleBackColor = False
        btnWashroom.Visible = False
        ' 
        ' btnManager
        ' 
        btnManager.BackColor = Color.Transparent
        btnManager.FlatStyle = FlatStyle.Flat
        btnManager.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(0))
        btnManager.Location = New Point(511, 89)
        btnManager.Name = "btnManager"
        btnManager.Size = New Size(94, 304)
        btnManager.TabIndex = 13
        btnManager.UseVisualStyleBackColor = False
        btnManager.Visible = False
        ' 
        ' btnEscape
        ' 
        btnEscape.BackColor = Color.Transparent
        btnEscape.FlatStyle = FlatStyle.Flat
        btnEscape.Location = New Point(262, 127)
        btnEscape.Name = "btnEscape"
        btnEscape.Size = New Size(81, 171)
        btnEscape.TabIndex = 14
        btnEscape.UseVisualStyleBackColor = False
        btnEscape.Visible = False
        ' 
        ' btnEmpy1
        ' 
        btnEmpy1.BackColor = Color.Transparent
        btnEmpy1.FlatStyle = FlatStyle.Flat
        btnEmpy1.Location = New Point(0, 0)
        btnEmpy1.Name = "btnEmpy1"
        btnEmpy1.Size = New Size(320, 208)
        btnEmpy1.TabIndex = 15
        btnEmpy1.UseVisualStyleBackColor = False
        btnEmpy1.Visible = False
        ' 
        ' btnEmpty2
        ' 
        btnEmpty2.BackColor = Color.Transparent
        btnEmpty2.FlatStyle = FlatStyle.Flat
        btnEmpty2.Location = New Point(317, 12)
        btnEmpty2.Name = "btnEmpty2"
        btnEmpty2.Size = New Size(291, 208)
        btnEmpty2.TabIndex = 16
        btnEmpty2.UseVisualStyleBackColor = False
        btnEmpty2.Visible = False
        ' 
        ' btnKeyPt
        ' 
        btnKeyPt.BackColor = Color.Transparent
        btnKeyPt.FlatStyle = FlatStyle.Flat
        btnKeyPt.Location = New Point(302, 214)
        btnKeyPt.Name = "btnKeyPt"
        btnKeyPt.Size = New Size(291, 208)
        btnKeyPt.TabIndex = 17
        btnKeyPt.UseVisualStyleBackColor = False
        btnKeyPt.Visible = False
        ' 
        ' btnEmpty3
        ' 
        btnEmpty3.BackColor = Color.Transparent
        btnEmpty3.FlatStyle = FlatStyle.Flat
        btnEmpty3.Location = New Point(12, 214)
        btnEmpty3.Name = "btnEmpty3"
        btnEmpty3.Size = New Size(291, 208)
        btnEmpty3.TabIndex = 18
        btnEmpty3.UseVisualStyleBackColor = False
        btnEmpty3.Visible = False
        ' 
        ' btnGB2
        ' 
        btnGB2.BackColor = Color.Transparent
        btnGB2.BackgroundImage = My.Resources.Resources.RightArrow
        btnGB2.BackgroundImageLayout = ImageLayout.Zoom
        btnGB2.FlatStyle = FlatStyle.Flat
        btnGB2.ForeColor = Color.DimGray
        btnGB2.Location = New Point(511, 0)
        btnGB2.Name = "btnGB2"
        btnGB2.Size = New Size(90, 91)
        btnGB2.TabIndex = 19
        btnGB2.UseVisualStyleBackColor = False
        btnGB2.Visible = False
        ' 
        ' btnTSeat
        ' 
        btnTSeat.BackColor = Color.Transparent
        btnTSeat.FlatStyle = FlatStyle.Flat
        btnTSeat.ForeColor = SystemColors.ButtonFace
        btnTSeat.Location = New Point(126, 260)
        btnTSeat.Name = "btnTSeat"
        btnTSeat.Size = New Size(66, 42)
        btnTSeat.TabIndex = 20
        btnTSeat.UseVisualStyleBackColor = False
        btnTSeat.Visible = False
        ' 
        ' btnDewK
        ' 
        btnDewK.BackColor = Color.Transparent
        btnDewK.FlatStyle = FlatStyle.Flat
        btnDewK.ForeColor = SystemColors.ButtonFace
        btnDewK.Location = New Point(138, 250)
        btnDewK.Name = "btnDewK"
        btnDewK.Size = New Size(41, 53)
        btnDewK.TabIndex = 21
        btnDewK.UseVisualStyleBackColor = False
        btnDewK.Visible = False
        ' 
        ' btnMngKP
        ' 
        btnMngKP.BackColor = Color.Transparent
        btnMngKP.FlatStyle = FlatStyle.Flat
        btnMngKP.ForeColor = Color.FromArgb(CByte(255), CByte(192), CByte(192))
        btnMngKP.Location = New Point(138, 102)
        btnMngKP.Name = "btnMngKP"
        btnMngKP.Size = New Size(90, 48)
        btnMngKP.TabIndex = 22
        btnMngKP.UseVisualStyleBackColor = False
        btnMngKP.Visible = False
        ' 
        ' wmpFinal
        ' 
        wmpFinal.Enabled = True
        wmpFinal.Location = New Point(0, 0)
        wmpFinal.Name = "wmpFinal"
        wmpFinal.OcxState = CType(resources.GetObject("wmpFinal.OcxState"), AxHost.State)
        wmpFinal.Size = New Size(604, 457)
        wmpFinal.TabIndex = 23
        wmpFinal.Visible = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.IMG_0056
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(605, 450)
        Controls.Add(wmpFinal)
        Controls.Add(btnMngKP)
        Controls.Add(btnDewK)
        Controls.Add(btnTSeat)
        Controls.Add(btnGB2)
        Controls.Add(btnEmpty3)
        Controls.Add(btnKeyPt)
        Controls.Add(btnEmpty2)
        Controls.Add(btnEmpy1)
        Controls.Add(btnEscape)
        Controls.Add(btnManager)
        Controls.Add(btnWashroom)
        Controls.Add(btnStorage)
        Controls.Add(btnYUM)
        Controls.Add(PictureBox1)
        Controls.Add(btnJOB)
        Controls.Add(btnRacoon)
        Controls.Add(btnGoBack)
        Controls.Add(wmpCoffee)
        Controls.Add(btnRight)
        Controls.Add(btnLeft)
        Controls.Add(btnCoffee)
        Controls.Add(btnBRDoor)
        Controls.Add(btnFridge)
        DoubleBuffered = True
        Name = "Form1"
        Text = "Form1"
        CType(wmpCoffee, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(wmpFinal, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnFridge As Button
    Friend WithEvents btnBRDoor As Button
    Friend WithEvents btnCoffee As Button
    Friend WithEvents btnLeft As Button
    Friend WithEvents btnRight As Button
    Friend WithEvents wmpCoffee As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents btnGoBack As Button
    Friend WithEvents btnRacoon As Button
    Friend WithEvents btnJOB As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnYUM As Button
    Friend WithEvents btnStorage As Button
    Friend WithEvents btnWashroom As Button
    Friend WithEvents btnManager As Button
    Friend WithEvents btnEscape As Button
    Friend WithEvents btnEmpy1 As Button
    Friend WithEvents btnEmpty2 As Button
    Friend WithEvents btnKeyPt As Button
    Friend WithEvents btnEmpty3 As Button
    Friend WithEvents btnGB2 As Button
    Friend WithEvents btnTSeat As Button
    Friend WithEvents btnDewK As Button
    Friend WithEvents btnMngKP As Button
    Friend WithEvents wmpFinal As AxWMPLib.AxWindowsMediaPlayer

End Class
