Public Class SecuQuorOptions

    '----------------------------[Variables]----------------------------

    Public Master As SecuQuorHandler
    Public commit = False

    Private originalKeyCode As String = "001-001-001"
    Private originalShift As Integer = 0
    Private KeyValid As Boolean = True

    '----------------------------[Buttons]----------------------------

    Private Sub OKButton_Click() Handles OKButton.Click
        commit = True
        originalKeyCode = KeycodeTXB.Text
        originalShift = ShiftUpDown.Value
        Close()
    End Sub

    Private Sub CancelBTN_Click() Handles CancelBTN.Click
        KeycodeTXB.Text = originalKeyCode
        ShiftUpDown.Value = originalShift
        Close()
    End Sub

    Private Sub UpdateShift() Handles ShiftUpDown.ValueChanged
        Master.SetShift(ShiftUpDown.Value)
    End Sub

    Private Sub GenerateKey() Handles GenKeyButton.Click
        Dim KeyPart1 As Integer = RandomDigit(1) & RandomDigit() & RandomDigit() & RandomDigit()
        Dim KeyPart2 As Integer = RandomDigit(1) & RandomDigit() & RandomDigit() & RandomDigit()
        Dim KeyPart3 As Integer = RandomDigit(1) & RandomDigit() & RandomDigit() & RandomDigit()
        Dim Checksum As String = GenerateKeyCodeSignature({KeyPart1, KeyPart2, KeyPart3})
        KeycodeTXB.Text = KeyPart1 & "-" & KeyPart2 & "-" & KeyPart3 & "-" & Checksum
        KeycodeTXB.ForeColor = Color.Black
    End Sub

    Private Sub KeycodeGotFocus() Handles KeycodeTXB.GotFocus
        If KeycodeTXB.ForeColor = Color.DarkGray Then
            KeycodeTXB.Clear()
            KeycodeTXB.ForeColor = Color.Black
        End If
    End Sub

    Private Sub KeycodeChanged() Handles KeycodeTXB.TextChanged

        'look the try catch does nada so this at least makes it nicer
        'even if its a goto.
        On Error GoTo oops

        'God this is a lot of Ifs.
        Dim TemporaryKeyCode() As String = KeycodeTXB.Text.Split("-")

        If TemporaryKeyCode.Count = 3 Then
            'Unsigned keyCode
            If IsValidKeyCode(TemporaryKeyCode) Then
                Master.SetKey({TemporaryKeyCode(0), TemporaryKeyCode(1), TemporaryKeyCode(2)})
                KeycodeStatusLBL.Text = "KeyCode Loaded Successfully"
                Return
            End If

        ElseIf TemporaryKeyCode.Count = 4 Then

            'Asked to sign it
            If TemporaryKeyCode(3).ToUpper = "S" Then
                TemporaryKeyCode(3) = Hex(CInt(TemporaryKeyCode(0)) + CInt(TemporaryKeyCode(1)) + CInt(TemporaryKeyCode(2)))
                KeycodeTXB.Text = String.Join("-", TemporaryKeyCode)
                Return
            End If

            'Signed KeyCode
            If IsValidSignedKeyCode(TemporaryKeyCode) Then
                Master.SetKey({TemporaryKeyCode(0), TemporaryKeyCode(1), TemporaryKeyCode(2)})
                KeycodeStatusLBL.Text = "KeyCode Loaded Successfully"
                Return
            End If

        End If

oops:
        KeycodeStatusLBL.Text = "Invalid KeyCode"

    End Sub

    '----------------------------[Other]----------------------------

    Private Function IsValidKeyCode(Keycode() As String) As Boolean
        KeyValid = False
        If Not (Keycode(0).Count = 3 And Keycode(1).Count = 3 And Keycode(2).Count = 3) Then Return False

        For X = 0 To 2
            For Each Character As Char In Keycode(X)
                If Not Char.IsDigit(Character) Then Return False
            Next
        Next

        KeyValid = True
        Return True
    End Function

    Private Function IsValidSignedKeyCode(Keycode() As String) As Boolean
        KeyValid = False
        If Not ((Keycode(0).Count = 3 And Keycode(1).Count = 3 And Keycode(2).Count = 3) Or (Keycode(0).Count = 4 And Keycode(1).Count = 4 And Keycode(2).Count = 4)) Then Return False

        For X = 0 To 2
            For Each Character As Char In Keycode(X)
                If Not Char.IsDigit(Character) Then Return False
            Next
        Next


        KeyValid = (Keycode(3) = GenerateKeyCodeSignature(Keycode))
        Return KeyValid

    End Function

    Private Function GenerateKeyCodeSignature(KeyCode() As String) As String
        If (KeyCode(0).Count = 3 And KeyCode(1).Count = 3 And KeyCode(2).Count = 3) Then
            Return Hex(CInt(KeyCode(0)) + CInt(KeyCode(1)) + CInt(KeyCode(2)))
        ElseIf (KeyCode(0).Count = 4 And KeyCode(1).Count = 4 And KeyCode(2).Count = 4) Then
            Return Hex(CInt(KeyCode(0)) + (2 * CInt(KeyCode(1))) + (3 * CInt(KeyCode(2))))
        Else
            Return "000"
        End If
    End Function

    Private Function RandomDigit(Optional Lowerbound As Integer = 0, Optional Upperbound As Integer = 9)
        Return Int((Upperbound - Lowerbound + 1) * Rnd() + Lowerbound)
    End Function

End Class