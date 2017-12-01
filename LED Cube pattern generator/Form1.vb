Imports System.IO
Imports System.Net.Mail

Public Class Form1

    Dim newPoint As New System.Drawing.Point()
    Dim a As Integer
    Dim b As Integer

    ' This program is used to generate and output a .asm file to be used on a PIC16F690 to run the 3x3x3 LED cube
    Private strLayer1 As String
    Private strLayer2 As String
    Private strLayer3 As String
    Private strLayer4 As String
    Private intCount As Integer
    Private tab As String = Chr(9)

    Private strDesktopPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "a" And tbxSub.Focused = False Then addItem()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        addItem()
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If lbxPatternNumber.SelectedIndex > -1 Then remove()
    End Sub


    Private Sub btnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click

        Dim posision As Integer = lbxPatternNumber.SelectedIndex

        insert()
        lbxPatternNumber.SelectedIndex = posision + 1
        remove()
        lbxPatternNumber.SelectedIndex = posision

    End Sub


    Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click

        If lbxPatternNumber.SelectedIndex > -1 Then insert()
    End Sub


    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

        If MessageBox.Show("Are you sure you want to clear the patterns?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            lbxPatternNumber.Items.Clear()
            lbxDisplay1.Items.Clear()
            lbxDisplay2.Items.Clear()
            lbxDisplay3.Items.Clear()
            lbxDisplay4.Items.Clear()
        End If
    End Sub

    Sub Get_Environmental_Variable()

        Dim sHostName As String
        Dim sUserName As String

        sHostName = Environ$("computername")

        sUserName = Environ$("username")

    End Sub

    Private Sub btnOutputCmds_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOutputCmds.Click
        If Not tbxSub.Text = "file name" Then
            outputSubs()
        End If
        If tbxSub.Text = "file name" Then
            Dim res As DialogResult
            res = MessageBox.Show("change file name.", "", MessageBoxButtons.OK)
            If res <> DialogResult.OK Then
            End If
        End If
    End Sub
    Private Sub btnOutput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOutput.Click
        outputTables()
    End Sub


    Private Sub Brightness_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Brightness.ValueChanged

        Select Case Brightness.Value
            Case 1
                Label4.Text = "LOW Brightness"
            Case 2
                Label4.Text = "MID Brightness"
            Case 3
                Label4.Text = "HIGH Brightness"
            Case 4
                Label4.Text = "FULL Brightness"
        End Select
    End Sub


    Private Sub Time_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Time.ValueChanged

        Label5.Text = (Time.Value * 38).ToString & " milli secs"
    End Sub


    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click

        If lbxPatternNumber.SelectedIndex > 0 Then
            lbxPatternNumber.SelectedIndex = lbxPatternNumber.SelectedIndex - 1
        End If
    End Sub


    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click

        If lbxPatternNumber.SelectedIndex < lbxPatternNumber.Items.Count - 1 Then
            lbxPatternNumber.SelectedIndex = lbxPatternNumber.SelectedIndex + 1
        End If
    End Sub




    Private Sub addItem()
        If lbxPatternNumber.Items.Count < 250 Then

            UpdateListBox()

            lbxDisplay1.SelectedIndex = lbxDisplay1.Items.Count - 1
            lbxDisplay2.SelectedIndex = lbxDisplay2.Items.Count - 1
            lbxDisplay3.SelectedIndex = lbxDisplay3.Items.Count - 1
            lbxDisplay4.SelectedIndex = lbxDisplay4.Items.Count - 1

            lbxPatternNumber.SelectedIndex = lbxPatternNumber.Items.Count - 1


        Else
            MessageBox.Show("Maximum of 250 patterns reached", "Maximum", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


    End Sub



    Private Sub UpdateListBox()

        strLayer1 = ""
        strLayer2 = ""
        strLayer3 = ""
        strLayer4 = ""

        ' Layer 1
        If CheckBox1.Checked = True Then
            strLayer1 = strLayer1 + "1"
        Else : strLayer1 = strLayer1 + "0"
        End If

        If CheckBox2.Checked = True Then
            strLayer1 = strLayer1 + "1"
        Else : strLayer1 = strLayer1 + "0"
        End If

        If CheckBox3.Checked = True Then
            strLayer1 = strLayer1 + "1"
        Else : strLayer1 = strLayer1 + "0"
        End If

        If CheckBox4.Checked = True Then
            strLayer1 = strLayer1 + "1"
        Else : strLayer1 = strLayer1 + "0"
        End If

        If CheckBox5.Checked = True Then
            strLayer1 = strLayer1 + "1"
        Else : strLayer1 = strLayer1 + "0"
        End If

        If CheckBox6.Checked = True Then
            strLayer1 = strLayer1 + "1"
        Else : strLayer1 = strLayer1 + "0"
        End If

        If CheckBox7.Checked = True Then
            strLayer1 = strLayer1 + "1"
        Else : strLayer1 = strLayer1 + "0"
        End If

        If CheckBox8.Checked = True Then
            strLayer1 = strLayer1 + "1"
        Else : strLayer1 = strLayer1 + "0"
        End If



        ' Layer 2
        If CheckBox10.Checked = True Then
            strLayer2 = strLayer2 + "1"
        Else : strLayer2 = strLayer2 + "0"
        End If

        If CheckBox11.Checked = True Then
            strLayer2 = strLayer2 + "1"
        Else : strLayer2 = strLayer2 + "0"
        End If

        If CheckBox12.Checked = True Then
            strLayer2 = strLayer2 + "1"
        Else : strLayer2 = strLayer2 + "0"
        End If

        If CheckBox13.Checked = True Then
            strLayer2 = strLayer2 + "1"
        Else : strLayer2 = strLayer2 + "0"
        End If

        If CheckBox14.Checked = True Then
            strLayer2 = strLayer2 + "1"
        Else : strLayer2 = strLayer2 + "0"
        End If

        If CheckBox15.Checked = True Then
            strLayer2 = strLayer2 + "1"
        Else : strLayer2 = strLayer2 + "0"
        End If

        If CheckBox16.Checked = True Then
            strLayer2 = strLayer2 + "1"
        Else : strLayer2 = strLayer2 + "0"
        End If

        If CheckBox17.Checked = True Then
            strLayer2 = strLayer2 + "1"
        Else : strLayer2 = strLayer2 + "0"
        End If



        ' Layer 3
        If CheckBox19.Checked = True Then
            strLayer3 = strLayer3 + "1"
        Else : strLayer3 = strLayer3 + "0"
        End If

        If CheckBox20.Checked = True Then
            strLayer3 = strLayer3 + "1"
        Else : strLayer3 = strLayer3 + "0"
        End If

        If CheckBox21.Checked = True Then
            strLayer3 = strLayer3 + "1"
        Else : strLayer3 = strLayer3 + "0"
        End If

        If CheckBox22.Checked = True Then
            strLayer3 = strLayer3 + "1"
        Else : strLayer3 = strLayer3 + "0"
        End If

        If CheckBox23.Checked = True Then
            strLayer3 = strLayer3 + "1"
        Else : strLayer3 = strLayer3 + "0"
        End If

        If CheckBox24.Checked = True Then
            strLayer3 = strLayer3 + "1"
        Else : strLayer3 = strLayer3 + "0"
        End If

        If CheckBox25.Checked = True Then
            strLayer3 = strLayer3 + "1"
        Else : strLayer3 = strLayer3 + "0"
        End If

        If CheckBox26.Checked = True Then
            strLayer3 = strLayer3 + "1"
        Else : strLayer3 = strLayer3 + "0"
        End If


        ' Layer 4
        If CheckBox9.Checked = True Then
            strLayer4 = strLayer4 + "1"
        Else : strLayer4 = strLayer4 + "0"
        End If

        If CheckBox18.Checked = True Then
            strLayer4 = strLayer4 + "1"
        Else : strLayer4 = strLayer4 + "0"
        End If

        If CheckBox27.Checked = True Then
            strLayer4 = strLayer4 + "1"
        Else : strLayer4 = strLayer4 + "0"
        End If

        If Brightness.Value = 1 Then strLayer4 = strLayer4 + "00"
        If Brightness.Value = 2 Then strLayer4 = strLayer4 + "01"
        If Brightness.Value = 3 Then strLayer4 = strLayer4 + "10"
        If Brightness.Value = 4 Then strLayer4 = strLayer4 + "11"

        If Time.Value = 1 Then strLayer4 = strLayer4 + "000"
        If Time.Value = 2 Then strLayer4 = strLayer4 + "001"
        If Time.Value = 3 Then strLayer4 = strLayer4 + "010"
        If Time.Value = 4 Then strLayer4 = strLayer4 + "011"
        If Time.Value = 5 Then strLayer4 = strLayer4 + "100"
        If Time.Value = 6 Then strLayer4 = strLayer4 + "101"
        If Time.Value = 7 Then strLayer4 = strLayer4 + "110"
        If Time.Value = 8 Then strLayer4 = strLayer4 + "111"


        lbxPatternNumber.Items.Add(lbxPatternNumber.Items.Count + 1)

        lbxDisplay1.Items.Add(strLayer1)
        lbxDisplay2.Items.Add(strLayer2)
        lbxDisplay3.Items.Add(strLayer3)
        lbxDisplay4.Items.Add(strLayer4)


    End Sub



    Private Sub outputTables()
        ' The 4 list boxes each contain a layer of the LED cube, these are saved in 4 tables as an asm file
        ' for use with MPLAB and a PIC

        Dim outputFile As String = strDesktopPath & "\" & "tables.asm"

        Dim tabs As String = ""
        For count As Integer = 1 To 18
            tabs = tabs + tab
        Next

        Try
            Dim objWriter As New StreamWriter(outputFile)

            objWriter.WriteLine(";-----------------------------------------------------------------------------------------------;")
            objWriter.WriteLine("; Tables here at the end" & tabs & ";")
            objWriter.WriteLine(";-----------------------------------------------------------------------------------------------;")
            ' Tabel 1
            objWriter.WriteLine(tab & "org 0x100")
            objWriter.WriteLine("Table1:")

            objWriter.WriteLine(tab & "bsf" & tab & "PCLATH,0" & tab & tab & "; set upper")
            objWriter.WriteLine(tab & "bcf" & tab & "PCLATH,1" & tab & tab & "; program")
            objWriter.WriteLine(tab & "bcf" & tab & "PCLATH,2" & tab & tab & "; counter bits")
            objWriter.WriteLine(tab & "addwf" & tab & "PCL")


            intCount = 16

            For count As Integer = 0 To lbxDisplay1.Items.Count - 1
                objWriter.WriteLine(tab & "retlw" & tab & "b'" & lbxDisplay1.Items(count) & "'")

                intCount = intCount - 1
                If intCount = 0 Then
                    intCount = 16
                    objWriter.WriteLine(tab & ";-----------" & count + 1 & "---")
                End If
            Next

            objWriter.WriteLine(tab & "bsf" & tab & "EndCount,0")
            objWriter.WriteLine(tab & "return")
            objWriter.WriteLine("")
            objWriter.WriteLine("")



            ' Tabel 2
            objWriter.WriteLine(tab & "org 0x300")
            objWriter.WriteLine("Table2:")

            objWriter.WriteLine(tab & "bsf" & tab & "PCLATH,0" & tab & tab & "; set upper")
            objWriter.WriteLine(tab & "bsf" & tab & "PCLATH,1" & tab & tab & "; program")
            objWriter.WriteLine(tab & "bcf" & tab & "PCLATH,2" & tab & tab & "; counter bits")
            objWriter.WriteLine(tab & "addwf" & tab & "PCL")


            intCount = 16

            For count As Integer = 0 To lbxDisplay2.Items.Count - 1
                objWriter.WriteLine(tab & "retlw" & tab & "b'" & lbxDisplay2.Items(count) & "'")

                intCount = intCount - 1
                If intCount = 0 Then
                    intCount = 16
                    objWriter.WriteLine(tab & ";-----------" & count + 1 & "---")
                End If
            Next

            objWriter.WriteLine(tab & "return")
            objWriter.WriteLine("")
            objWriter.WriteLine("")



            ' Tabel 3
            objWriter.WriteLine(tab & "org 0x500")
            objWriter.WriteLine("Table3:")

            objWriter.WriteLine(tab & "bsf" & tab & "PCLATH,0" & tab & tab & "; set upper")
            objWriter.WriteLine(tab & "bcf" & tab & "PCLATH,1" & tab & tab & "; program")
            objWriter.WriteLine(tab & "bsf" & tab & "PCLATH,2" & tab & tab & "; counter bits")
            objWriter.WriteLine(tab & "addwf" & tab & "PCL")

            intCount = 16


            For count As Integer = 0 To lbxDisplay3.Items.Count - 1
                objWriter.WriteLine(tab & "retlw" & tab & "b'" & lbxDisplay3.Items(count) & "'")
                intCount = intCount - 1
                If intCount = 0 Then
                    intCount = 16
                    objWriter.WriteLine(tab & ";-----------" & count + 1 & "---")
                End If
            Next

            objWriter.WriteLine(tab & "return")
            objWriter.WriteLine("")
            objWriter.WriteLine("")



            ' Tabel 4
            objWriter.WriteLine(tab & "org 0x700")
            objWriter.WriteLine("Table4:")

            objWriter.WriteLine(tab & "bsf" & tab & "PCLATH,0" & tab & tab & "; set upper")
            objWriter.WriteLine(tab & "bsf" & tab & "PCLATH,1" & tab & tab & "; program")
            objWriter.WriteLine(tab & "bsf" & tab & "PCLATH,2" & tab & tab & "; counter bits")
            objWriter.WriteLine(tab & "addwf" & tab & "PCL")

            intCount = 16


            For count As Integer = 0 To lbxDisplay4.Items.Count - 1
                objWriter.WriteLine(tab & "retlw" & tab & "b'" & lbxDisplay4.Items(count) & "'")

                intCount = intCount - 1
                If intCount = 0 Then
                    intCount = 16
                    objWriter.WriteLine(tab & ";-----------" & count + 1 & "---")
                End If
            Next

            objWriter.WriteLine(tab & "return")
            objWriter.WriteLine("")
            objWriter.WriteLine("end")


            objWriter.Close()
            objWriter = Nothing

            MessageBox.Show("File saved as 'tables.asm' on the desktop", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)



        Catch ex As Exception
            MessageBox.Show("Error writing file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub




    Private Sub outputSubs()
        ' The 4 list boxes each contain a layer of the LED cube, this output method outputs commands to be
        ' used in a sub routine with MPLAB and a PIC


        If tbxSub.Text <> "" Then

            Dim fileName As String = tbxSub.Text

            Dim outputFile As String = strDesktopPath & "\" & fileName & ".asm"

            Dim tabs As String = ""
            For count As Integer = 1 To 19
                tabs = tabs + tab
            Next

            Try
                Dim objWriter As New StreamWriter(outputFile)

                objWriter.WriteLine(";-----------------------------------------------------------------------------------------------;")
                objWriter.WriteLine(";		LED	cube																				;")
                objWriter.WriteLine(";		--------																				;")
                objWriter.WriteLine(";		Sint-Martinusscholen TSO-BSO															;")
                objWriter.WriteLine(";		vakleerkracht De Meeter Stijn														    ;")
                objWriter.WriteLine(";		Editor Impens Steven																	;")
                objWriter.WriteLine(";																								;")
                objWriter.WriteLine(";	    4MHz internal resonator used 															;")
                objWriter.WriteLine(";	    3 layers of 3 x 3 LEDs																	;")
                objWriter.WriteLine(";	    RB5	-	Top layer common															    ;")
                objWriter.WriteLine(";	    RB6	-	Middle layer common																;")
                objWriter.WriteLine(";	    RB7	-	Bottom layer common																;")
                objWriter.WriteLine(";																								;")
                objWriter.WriteLine(";		RC1			RC0			RB4																;")
                objWriter.WriteLine(";																								;")
                objWriter.WriteLine(";		RC4			RC3			RB2 															;")
                objWriter.WriteLine(";																								;")
                objWriter.WriteLine(";		RC7			RC6			RB5																;")
                objWriter.WriteLine(";																								;")
                objWriter.WriteLine(";-----------------------------------------------------------------------------------------------;")

                objWriter.WriteLine("#include <p16F690.inc>")
                objWriter.WriteLine("    __config (_INTRC_OSC_NOCLKOUT & _WDT_OFF & _PWRTE_OFF & _MCLRE_OFF & _CP_OFF & _BOR_OFF & _IESO_OFF & _FCMEN_OFF)")
                objWriter.WriteLine(" ")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("cblock 0x20")
                objWriter.WriteLine("	Delay1					; delay loop 1")
                objWriter.WriteLine("	Delay2					; delay loop 2")
                objWriter.WriteLine("	Delay3					; delay loop 3")
                objWriter.WriteLine("	TimeDelay				; time delay x 0.001 s")
                objWriter.WriteLine("	EndCount				; used to tell PIC the end of the table is reached")
                objWriter.WriteLine("	Counter					; used as table counter")
                objWriter.WriteLine("	Layer1					; top layer")
                objWriter.WriteLine("	Layer2					; middle layer")
                objWriter.WriteLine("	Layer3					; bottom layer")
                objWriter.WriteLine("	Layer4					; 9th Led on each layer, brightness, and time")
                objWriter.WriteLine("	Brightness				; LED brightness")
                objWriter.WriteLine("	Time					; time for each pattern to stay")
                objWriter.WriteLine("	Temp					; temp register")
                objWriter.WriteLine("endc")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("	org 0")
                objWriter.WriteLine("	goto	Start			; jump to Start")
                objWriter.WriteLine(" ")
                objWriter.WriteLine(" ")
                objWriter.WriteLine(" ")

                objWriter.WriteLine(";-----------------------------------------------------------------------------------------------;")
                objWriter.WriteLine("; " & fileName & " sub routine" & tabs & ";")
                objWriter.WriteLine(";-----------------------------------------------------------------------------------------------;")
                objWriter.WriteLine(fileName & ":")

                For count As Integer = 0 To lbxDisplay1.Items.Count - 1


                    objWriter.WriteLine(tab & "movlw" & tab & "b'" & lbxDisplay1.Items(count) & "'")
                    objWriter.WriteLine(tab & "movwf" & tab & "Layer1")

                    If lbxDisplay2.Items(count) <> lbxDisplay1.Items(count) Then
                        objWriter.WriteLine(tab & "movlw" & tab & "b'" & lbxDisplay2.Items(count) & "'")
                    End If

                    objWriter.WriteLine(tab & "movwf" & tab & "Layer2")

                    If lbxDisplay3.Items(count) <> lbxDisplay2.Items(count) Then
                        objWriter.WriteLine(tab & "movlw" & tab & "b'" & lbxDisplay3.Items(count) & "'")
                    End If

                    objWriter.WriteLine(tab & "movwf" & tab & "Layer3")

                    If lbxDisplay4.Items(count) <> lbxDisplay3.Items(count) Then
                        objWriter.WriteLine(tab & "movlw" & tab & "b'" & lbxDisplay4.Items(count) & "'")
                    End If

                    objWriter.WriteLine(tab & "movwf" & tab & "Layer4")
                    objWriter.WriteLine(tab & "call" & tab & "Output")

                Next
                objWriter.WriteLine(tab & "return")

                objWriter.WriteLine(" ")
                objWriter.WriteLine(" ")
                objWriter.WriteLine(" ")
                objWriter.WriteLine(";-----------------------------------------------------------------------------------------------;")
                objWriter.WriteLine("; Output  	                                                                                    ;")
                objWriter.WriteLine(";-----------------------------------------------------------------------------------------------;")
                objWriter.WriteLine("Output:")
                objWriter.WriteLine("							; set the brightness")
                objWriter.WriteLine("	movfw	Layer4			; put layer 4 into W")
                objWriter.WriteLine("	andlw	b'00011000'		; get just bits 3 and 5")
                objWriter.WriteLine("	movwf	Brightness		; put W into Brightness")
                objWriter.WriteLine("	bcf		STATUS,C		; clear the carry flag")
                objWriter.WriteLine("	rrf		Brightness,1	; rotate Brightness")
                objWriter.WriteLine("	bcf		STATUS,C		; clear the carry flag")
                objWriter.WriteLine("	rrf		Brightness,1	; and again")
                objWriter.WriteLine("	bcf		STATUS,C		; clear the carry flag")
                objWriter.WriteLine("	rrf		Brightness,1	; and again")
                objWriter.WriteLine("	incf	Brightness,1	; add 1 to Brightess")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("	movfw	Layer4			; move layer 4 into W")
                objWriter.WriteLine("	andlw	b'00000111'		; get just bits 0,1 and 2")
                objWriter.WriteLine("	movwf	Time			; put W into Time")
                objWriter.WriteLine("	incf	Time,1			; add 1 to Time")
                objWriter.WriteLine("	bcf		STATUS,C		; clear the carry flag")
                objWriter.WriteLine("	rlf		Time,1")
                objWriter.WriteLine("	bcf		STATUS,C		; clear the carry flag")
                objWriter.WriteLine("	rlf		Time,1")
                objWriter.WriteLine("	bcf		STATUS,C		; clear the carry flag")
                objWriter.WriteLine("	rlf		Time,1")
                objWriter.WriteLine("	bcf		STATUS,C		; clear the carry flag")
                objWriter.WriteLine("	rlf		Time,1")
                objWriter.WriteLine("	bcf		STATUS,C		; clear the carry flag")
                objWriter.WriteLine("	rlf		Time,1")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("Output2:")
                objWriter.WriteLine("							; --- Top Layer ---")
                objWriter.WriteLine("	clrf	PORTB			; clear port B")
                objWriter.WriteLine("	movfw	Layer1			; move layer1 to W")
                objWriter.WriteLine("	movwf	PORTC			; put W onto PortC")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("	btfsc	Layer4,7		; see if LED 9 should be on")
                objWriter.WriteLine("	bsf		PORTB,4			; turn on LED 9")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("	bsf		PORTB,5			; turn on layer 1 buy outputing bit 5 of PortB")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("	movfw	Brightness		; put brightness into W")
                objWriter.WriteLine("	call	Delay			; call the delay")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("							; brightness can be 1,2,3 or 4, so now we have to call the delay again")
                objWriter.WriteLine("							; 4 - brightness with the LEDs off")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("	bcf		PORTB,5			; turn off layer 1")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("	movfw	Brightness		; put Brightness into W")
                objWriter.WriteLine("	sublw	4				; sub W from 4")
                objWriter.WriteLine("	btfss	STATUS,Z		; skip if the zero flag is set")
                objWriter.WriteLine("	call	Delay			; call the delay")
                objWriter.WriteLine(" ")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("							; --- Middle Layer ---")
                objWriter.WriteLine("	clrf	PORTB			; clear port B")
                objWriter.WriteLine("	movfw	Layer2			; move layer2 to W")
                objWriter.WriteLine("	movwf	PORTC			; put W onto PortC")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("	btfsc	Layer4,6		; see if LED 9 should be on")
                objWriter.WriteLine("	bsf		PORTB,4			; turn on LED 9")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("	bsf		PORTB,6			; turn on layer 2 buy outputing bit 6 of PortB")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("	movfw	Brightness		; put brightness into W")
                objWriter.WriteLine("	call	Delay			; call the delay")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("							; brightness can be 1,2,3 or 4, so now we have to call the delay again")
                objWriter.WriteLine("							; 4 - brightness with the LEDs off")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("	bcf		PORTB,6			; turn off layer 2")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("	movfw	Brightness		; put Brightness into W")
                objWriter.WriteLine("	sublw	4				; sub W from 4")
                objWriter.WriteLine("	btfss	STATUS,Z		; skip if the zero flag is set")
                objWriter.WriteLine("	call	Delay			; call the delay")
                objWriter.WriteLine(" ")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("							; --- Bottom Layer ---")
                objWriter.WriteLine("	clrf	PORTB			; clear port B")
                objWriter.WriteLine("	movfw	Layer3			; move layer3 to W")
                objWriter.WriteLine("	movwf	PORTC			; put W onto PortC")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("	btfsc	Layer4,5		; see if LED 9 should be on")
                objWriter.WriteLine("	bsf		PORTB,4			; turn on LED 9")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("	bsf		PORTB,7			; turn on layer 2 buy outputing bit 6 of PortB")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("	movfw	Brightness		; put brightness into W")
                objWriter.WriteLine("	call	Delay			; call the delay")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("							; brightness can be 1,2,3 or 4, so now we have to call the delay again")
                objWriter.WriteLine("							; 4 - brightness with the LEDs off")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("	bcf		PORTB,7			; turn off layer 3")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("	movfw	Brightness		; put Brightness into W")
                objWriter.WriteLine("	sublw	4				; sub W from 4")
                objWriter.WriteLine("	btfss	STATUS,Z		; skip if the zero flag is set")
                objWriter.WriteLine("	call	Delay			; call the delay")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("	decfsz	Time			; decrement the Time regiester")
                objWriter.WriteLine("	goto	Output2			; repeat")
                objWriter.WriteLine("	return")
                objWriter.WriteLine(" ")
                objWriter.WriteLine(" ")
                objWriter.WriteLine(" ")
                objWriter.WriteLine(";-----------------------------------------------------------------------------------------------;")
                objWriter.WriteLine("; The Delay routine is called with a number put into the W register. This is in multiples of	;")
                objWriter.WriteLine("; 100u seconds, (0.1m seconds)																	;")
                objWriter.WriteLine(";-----------------------------------------------------------------------------------------------;")
                objWriter.WriteLine("Delay:")
                objWriter.WriteLine("	movwf	Delay3			; put W into Delay 3")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("Loop1:")
                objWriter.WriteLine("							; After Delay2 decreses to 0, it is reset to..")
                objWriter.WriteLine("	movlw	0x1				; put 1 into W")
                objWriter.WriteLine("	movwf	Delay2			; put W into Delay2")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("Loop2:")
                objWriter.WriteLine("							; After Delay1 decreses to 0, it is reset to E9h")
                objWriter.WriteLine("	movlw	0x1D			; put 80 into W")
                objWriter.WriteLine("	movwf	Delay1			; put W into Delay1")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("Loop3:")
                objWriter.WriteLine("	decfsz	Delay1			; decrement Delay1")
                objWriter.WriteLine("	goto	Loop3			; jump back to Loop3")
                objWriter.WriteLine("	decfsz	Delay2			; decrement Delay2")
                objWriter.WriteLine("	goto	Loop2			; jump back to Loop2")
                objWriter.WriteLine("	decfsz	Delay3			; decrement Delay3")
                objWriter.WriteLine("	goto	Loop1			; jump back to Loop1")
                objWriter.WriteLine("	return")
                objWriter.WriteLine(" ")
                objWriter.WriteLine(" ")
                objWriter.WriteLine(" ")
                objWriter.WriteLine(";-----------------------------------------------------------------------------------------------;")
                objWriter.WriteLine("; Main program starts here																		;")
                objWriter.WriteLine(";-----------------------------------------------------------------------------------------------;")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("Start:")
                objWriter.WriteLine("	bsf		STATUS,RP0			; select register page 1")
                objWriter.WriteLine("	movlw	0					; put 0 into W")
                objWriter.WriteLine("	movwf	TRISC				; set portC all output")
                objWriter.WriteLine("	movwf	TRISB				; set portB all outputs")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("	bsf		STATUS,RP1			; select Page 2,")
                objWriter.WriteLine("	bcf		STATUS,RP0			; by setting RP1 in Status register and clearing RP0")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("	clrf	ANSEL				; select Digital I/O on port C")
                objWriter.WriteLine("    clrf    ANSELH              ;")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("    bcf    STATUS,RP1          ; back to Register Page 0")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("	bcf		EndCount,0			; reset the EndCount bit")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("	clrf	Counter				; clear the Counter register")
                objWriter.WriteLine(" ")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("Loop:")
                objWriter.WriteLine(tab & "call" & tab & fileName)
                objWriter.WriteLine(" ")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("	goto	Loop")
                objWriter.WriteLine(" ")
                objWriter.WriteLine(" ")
                objWriter.WriteLine("end")


                objWriter.Close()
                objWriter = Nothing

                MessageBox.Show("File saved as " & fileName & ".asm' on the desktop", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)


            Catch ex As Exception
                MessageBox.Show("Error writing file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try

        Else
            MessageBox.Show("No file name selected")
        End If

    End Sub





    Private Sub updateDisplay()
        Dim Layer1 As String = lbxDisplay1.Items(lbxPatternNumber.SelectedIndex)
        Dim Layer2 As String = lbxDisplay2.Items(lbxPatternNumber.SelectedIndex)
        Dim Layer3 As String = lbxDisplay3.Items(lbxPatternNumber.SelectedIndex)
        Dim Layer4 As String = lbxDisplay4.Items(lbxPatternNumber.SelectedIndex)

        ' Layer 1
        If Layer1.Substring(0, 1) = 1 Then
            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = False
        End If

        If Layer1.Substring(1, 1) = 1 Then
            CheckBox2.Checked = True
        Else
            CheckBox2.Checked = False
        End If

        If Layer1.Substring(2, 1) = 1 Then
            CheckBox3.Checked = True
        Else
            CheckBox3.Checked = False
        End If

        If Layer1.Substring(3, 1) = 1 Then
            CheckBox4.Checked = True
        Else
            CheckBox4.Checked = False
        End If

        If Layer1.Substring(4, 1) = 1 Then
            CheckBox5.Checked = True
        Else
            CheckBox5.Checked = False
        End If

        If Layer1.Substring(5, 1) = 1 Then
            CheckBox6.Checked = True
        Else
            CheckBox6.Checked = False
        End If

        If Layer1.Substring(6, 1) = 1 Then
            CheckBox7.Checked = True
        Else
            CheckBox7.Checked = False
        End If

        If Layer1.Substring(7, 1) = 1 Then
            CheckBox8.Checked = True
        Else
            CheckBox8.Checked = False
        End If

        ' Layer 2
        If Layer2.Substring(0, 1) = 1 Then
            CheckBox10.Checked = True
        Else
            CheckBox10.Checked = False
        End If

        If Layer2.Substring(1, 1) = 1 Then
            CheckBox11.Checked = True
        Else
            CheckBox11.Checked = False
        End If

        If Layer2.Substring(2, 1) = 1 Then
            CheckBox12.Checked = True
        Else
            CheckBox12.Checked = False
        End If

        If Layer2.Substring(3, 1) = 1 Then
            CheckBox13.Checked = True
        Else
            CheckBox13.Checked = False
        End If

        If Layer2.Substring(4, 1) = 1 Then
            CheckBox14.Checked = True
        Else
            CheckBox14.Checked = False
        End If

        If Layer2.Substring(5, 1) = 1 Then
            CheckBox15.Checked = True
        Else
            CheckBox15.Checked = False
        End If

        If Layer2.Substring(6, 1) = 1 Then
            CheckBox16.Checked = True
        Else
            CheckBox16.Checked = False
        End If

        If Layer2.Substring(7, 1) = 1 Then
            CheckBox17.Checked = True
        Else
            CheckBox17.Checked = False
        End If

        ' Layer 3
        If Layer3.Substring(0, 1) = 1 Then
            CheckBox19.Checked = True
        Else
            CheckBox19.Checked = False
        End If

        If Layer3.Substring(1, 1) = 1 Then
            CheckBox20.Checked = True
        Else
            CheckBox20.Checked = False
        End If

        If Layer3.Substring(2, 1) = 1 Then
            CheckBox21.Checked = True
        Else
            CheckBox21.Checked = False
        End If

        If Layer3.Substring(3, 1) = 1 Then
            CheckBox22.Checked = True
        Else
            CheckBox22.Checked = False
        End If

        If Layer3.Substring(4, 1) = 1 Then
            CheckBox23.Checked = True
        Else
            CheckBox23.Checked = False
        End If

        If Layer3.Substring(5, 1) = 1 Then
            CheckBox24.Checked = True
        Else
            CheckBox24.Checked = False
        End If

        If Layer3.Substring(6, 1) = 1 Then
            CheckBox25.Checked = True
        Else
            CheckBox25.Checked = False
        End If

        If Layer3.Substring(7, 1) = 1 Then
            CheckBox26.Checked = True
        Else
            CheckBox26.Checked = False
        End If

        ' Layer 4
        If Layer4.Substring(0, 1) = 1 Then
            CheckBox9.Checked = True
        Else
            CheckBox9.Checked = False
        End If

        If Layer4.Substring(1, 1) = 1 Then
            CheckBox18.Checked = True
        Else
            CheckBox18.Checked = False
        End If

        If Layer4.Substring(2, 1) = 1 Then
            CheckBox27.Checked = True
        Else
            CheckBox27.Checked = False
        End If

        Dim bright As String = Layer4.Substring(3, 2)
        Dim tim As String = Layer4.Substring(5, 3)

        Select Case bright
            Case "00"
                Brightness.Value = "1"
            Case "01"
                Brightness.Value = "2"
            Case "10"
                Brightness.Value = "3"
            Case "11"
                Brightness.Value = "4"
        End Select

        Select Case tim
            Case "000"
                Time.Value = "1"
            Case "001"
                Time.Value = "2"
            Case "010"
                Time.Value = "3"
            Case "011"
                Time.Value = "4"
            Case "100"
                Time.Value = "5"
            Case "101"
                Time.Value = "6"
            Case "110"
                Time.Value = "7"
            Case "111"
                Time.Value = "8"
        End Select


    End Sub




    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If CheckBox7.Checked = False Then
            CheckBox7.Checked = True
            CheckBox8.Checked = True
            CheckBox9.Checked = True
        Else
            CheckBox7.Checked = False
            CheckBox8.Checked = False
            CheckBox9.Checked = False
        End If
    End Sub



    Private Sub insert()
        ' To insert we have to save the list from where we are at into a tempory list, then delete all the rest of the
        ' list, add the new value then put the rest of the list back

        Dim posision As Integer = lbxPatternNumber.SelectedIndex

        Dim aryTemp1 As New ArrayList
        Dim aryTemp2 As New ArrayList
        Dim aryTemp3 As New ArrayList
        Dim aryTemp4 As New ArrayList

        aryTemp1.Clear()
        aryTemp2.Clear()
        aryTemp3.Clear()
        aryTemp4.Clear()

        Dim item As Integer = lbxPatternNumber.SelectedIndex

        For count As Integer = lbxPatternNumber.SelectedIndex To lbxPatternNumber.Items.Count - 1

            aryTemp1.Add(lbxDisplay1.Items(item))
            lbxDisplay1.Items.RemoveAt(item)

            aryTemp2.Add(lbxDisplay2.Items(item))
            lbxDisplay2.Items.RemoveAt(item)

            aryTemp3.Add(lbxDisplay3.Items(item))
            lbxDisplay3.Items.RemoveAt(item)

            aryTemp4.Add(lbxDisplay4.Items(item))
            lbxDisplay4.Items.RemoveAt(item)
        Next


        UpdateListBox()


        For Each items As String In aryTemp1
            lbxDisplay1.Items.Add(items)
        Next

        For Each items As String In aryTemp2
            lbxDisplay2.Items.Add(items)
        Next

        For Each items As String In aryTemp3
            lbxDisplay3.Items.Add(items)
        Next

        For Each items As String In aryTemp4
            lbxDisplay4.Items.Add(items)
        Next

        lbxPatternNumber.SelectedIndex = posision


    End Sub




    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If CheckBox4.Checked = False Then
            CheckBox4.Checked = True
            CheckBox5.Checked = True
            CheckBox6.Checked = True
        Else
            CheckBox4.Checked = False
            CheckBox5.Checked = False
            CheckBox6.Checked = False
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If CheckBox1.Checked = False Then
            CheckBox1.Checked = True
            CheckBox2.Checked = True
            CheckBox3.Checked = True
        Else
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            CheckBox3.Checked = False
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If CheckBox16.Checked = False Then
            CheckBox16.Checked = True
            CheckBox17.Checked = True
            CheckBox18.Checked = True
        Else
            CheckBox16.Checked = False
            CheckBox17.Checked = False
            CheckBox18.Checked = False
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If CheckBox13.Checked = False Then
            CheckBox13.Checked = True
            CheckBox14.Checked = True
            CheckBox15.Checked = True
        Else
            CheckBox13.Checked = False
            CheckBox14.Checked = False
            CheckBox15.Checked = False
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If CheckBox10.Checked = False Then
            CheckBox10.Checked = True
            CheckBox11.Checked = True
            CheckBox12.Checked = True
        Else
            CheckBox10.Checked = False
            CheckBox11.Checked = False
            CheckBox12.Checked = False
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If CheckBox25.Checked = False Then
            CheckBox25.Checked = True
            CheckBox26.Checked = True
            CheckBox27.Checked = True
        Else
            CheckBox25.Checked = False
            CheckBox26.Checked = False
            CheckBox27.Checked = False
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If CheckBox22.Checked = False Then
            CheckBox22.Checked = True
            CheckBox23.Checked = True
            CheckBox24.Checked = True
        Else
            CheckBox22.Checked = False
            CheckBox23.Checked = False
            CheckBox24.Checked = False
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        If CheckBox19.Checked = False Then
            CheckBox19.Checked = True
            CheckBox20.Checked = True
            CheckBox21.Checked = True
        Else
            CheckBox19.Checked = False
            CheckBox20.Checked = False
            CheckBox21.Checked = False
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If CheckBox1.Checked = False Then
            CheckBox1.Checked = True
            CheckBox4.Checked = True
            CheckBox7.Checked = True
        Else
            CheckBox1.Checked = False
            CheckBox4.Checked = False
            CheckBox7.Checked = False
        End If
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        If CheckBox2.Checked = False Then
            CheckBox2.Checked = True
            CheckBox5.Checked = True
            CheckBox8.Checked = True
        Else
            CheckBox2.Checked = False
            CheckBox5.Checked = False
            CheckBox8.Checked = False
        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        If CheckBox3.Checked = False Then
            CheckBox3.Checked = True
            CheckBox6.Checked = True
            CheckBox9.Checked = True
        Else
            CheckBox3.Checked = False
            CheckBox6.Checked = False
            CheckBox9.Checked = False
        End If
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        If CheckBox10.Checked = False Then
            CheckBox10.Checked = True
            CheckBox13.Checked = True
            CheckBox16.Checked = True
        Else
            CheckBox10.Checked = False
            CheckBox13.Checked = False
            CheckBox16.Checked = False
        End If
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        If CheckBox11.Checked = False Then
            CheckBox11.Checked = True
            CheckBox14.Checked = True
            CheckBox17.Checked = True
        Else
            CheckBox11.Checked = False
            CheckBox14.Checked = False
            CheckBox17.Checked = False
        End If
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        If CheckBox12.Checked = False Then
            CheckBox12.Checked = True
            CheckBox15.Checked = True
            CheckBox18.Checked = True
        Else
            CheckBox12.Checked = False
            CheckBox15.Checked = False
            CheckBox18.Checked = False
        End If
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        If CheckBox19.Checked = False Then
            CheckBox19.Checked = True
            CheckBox22.Checked = True
            CheckBox25.Checked = True
        Else
            CheckBox19.Checked = False
            CheckBox22.Checked = False
            CheckBox25.Checked = False
        End If
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        If CheckBox20.Checked = False Then
            CheckBox20.Checked = True
            CheckBox23.Checked = True
            CheckBox26.Checked = True
        Else
            CheckBox20.Checked = False
            CheckBox23.Checked = False
            CheckBox26.Checked = False
        End If
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        If CheckBox21.Checked = False Then
            CheckBox21.Checked = True
            CheckBox24.Checked = True
            CheckBox27.Checked = True
        Else
            CheckBox21.Checked = False
            CheckBox24.Checked = False
            CheckBox27.Checked = False
        End If
    End Sub





    Private Sub lbxDisplay1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbxDisplay1.SelectedIndexChanged
        lbxDisplay2.SelectedIndex = lbxDisplay1.SelectedIndex
        lbxDisplay3.SelectedIndex = lbxDisplay1.SelectedIndex
        lbxDisplay4.SelectedIndex = lbxDisplay1.SelectedIndex
        lbxPatternNumber.SelectedIndex = lbxDisplay1.SelectedIndex
    End Sub

    Private Sub lbxDisplay2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbxDisplay2.SelectedIndexChanged
        lbxDisplay1.SelectedIndex = lbxDisplay2.SelectedIndex
        lbxDisplay3.SelectedIndex = lbxDisplay2.SelectedIndex
        lbxDisplay4.SelectedIndex = lbxDisplay2.SelectedIndex
        lbxPatternNumber.SelectedIndex = lbxDisplay2.SelectedIndex
    End Sub

    Private Sub lbxDisplay3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbxDisplay3.SelectedIndexChanged
        lbxDisplay1.SelectedIndex = lbxDisplay3.SelectedIndex
        lbxDisplay2.SelectedIndex = lbxDisplay3.SelectedIndex
        lbxDisplay4.SelectedIndex = lbxDisplay3.SelectedIndex
        lbxPatternNumber.SelectedIndex = lbxDisplay3.SelectedIndex
    End Sub

    Private Sub lbxDisplay4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbxDisplay4.SelectedIndexChanged
        lbxDisplay1.SelectedIndex = lbxDisplay4.SelectedIndex
        lbxDisplay2.SelectedIndex = lbxDisplay4.SelectedIndex
        lbxDisplay3.SelectedIndex = lbxDisplay4.SelectedIndex
        lbxPatternNumber.SelectedIndex = lbxDisplay4.SelectedIndex
    End Sub

    Private Sub lbxPatternNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbxPatternNumber.SelectedIndexChanged
        lbxDisplay1.SelectedIndex = lbxPatternNumber.SelectedIndex
        lbxDisplay2.SelectedIndex = lbxPatternNumber.SelectedIndex
        lbxDisplay3.SelectedIndex = lbxPatternNumber.SelectedIndex
        lbxDisplay4.SelectedIndex = lbxPatternNumber.SelectedIndex
        If lbxPatternNumber.SelectedIndex > -1 Then updateDisplay()
    End Sub


    Private Sub remove()

        Dim removeAt As Integer = lbxPatternNumber.SelectedIndex

        If lbxPatternNumber.SelectedIndex > -1 Then
            lbxPatternNumber.Items.RemoveAt(lbxPatternNumber.Items.Count - 1)
            lbxDisplay1.Items.RemoveAt(removeAt)
            lbxDisplay2.Items.RemoveAt(removeAt)
            lbxDisplay3.Items.RemoveAt(removeAt)
            lbxDisplay4.Items.RemoveAt(removeAt)

            lbxDisplay1.SelectedIndex = lbxDisplay1.Items.Count - 1
            lbxDisplay2.SelectedIndex = lbxDisplay2.Items.Count - 1
            lbxDisplay3.SelectedIndex = lbxDisplay3.Items.Count - 1
            lbxDisplay4.SelectedIndex = lbxDisplay4.Items.Count - 1

        End If

        If removeAt = lbxPatternNumber.Items.Count Then
            lbxPatternNumber.SelectedIndex = lbxPatternNumber.Items.Count - 1
        Else
            lbxPatternNumber.SelectedIndex = removeAt
        End If

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub
    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Dim res As DialogResult
        res = MessageBox.Show("Are you sure you want to exit?", "Confirm Close", MessageBoxButtons.YesNo)
        If res <> DialogResult.Yes Then
            e.Cancel = True
        End If

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        a = Control.MousePosition.X - Me.Location.X
        b = Control.MousePosition.Y - Me.Location.Y
    End Sub
    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        If e.Button = MouseButtons.Left Then
            newPoint = Control.MousePosition
            newPoint.X = newPoint.X - (a)
            newPoint.Y = newPoint.Y - (b)
            Me.Location = newPoint
        End If
    End Sub
End Class
