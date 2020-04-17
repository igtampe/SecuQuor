Public Class SecuQuorOptions

    '----------------------------[Variables]----------------------------

    Public Master As SecuQuorHandler
    Public commit = False

    Private originalKeyCode As String = "001-001-001"
    Private originalShift As Integer = 0

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
        Dim KeyPart1 As Integer = CInt(Math.Ceiling(Rnd() * 100)) + 899
        Dim KeyPart2 As Integer = CInt(Math.Ceiling(Rnd() * 100)) + 899
        Dim KeyPart3 As Integer = CInt(Math.Ceiling(Rnd() * 100)) + 899
        Dim Checksum As String = Hex(KeyPart1 + KeyPart2 + KeyPart3)
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

        'God this is a lot of Ifs.
        Dim TemporaryKeyCode() As String = KeycodeTXB.Text.Split("-")

        Try
            If TemporaryKeyCode.Count = 3 Then
                'Unsigned keyCode
                If IsValidKeyCode(TemporaryKeyCode) Then
                    Master.SetKey({TemporaryKeyCode(0), TemporaryKeyCode(1), TemporaryKeyCode(2)})
                    KeycodeStatusLBL.Text = "KeyCode Loaded Successfully"
                Else
                    KeycodeStatusLBL.Text = "Invalid KeyCode (Must have 3 numbers per part)"
                End If

            ElseIf TemporaryKeyCode.Count = 4 Then
                'Signed KeyCode
                If IsValidKeyCode(TemporaryKeyCode) Then
                    If TemporaryKeyCode(3) = Hex(CInt(TemporaryKeyCode(0)) + CInt(TemporaryKeyCode(1)) + CInt(TemporaryKeyCode(2))) Then
                        Master.SetKey({TemporaryKeyCode(0), TemporaryKeyCode(1), TemporaryKeyCode(2)})
                        KeycodeStatusLBL.Text = "KeyCode Loaded Successfully"

                    ElseIf TemporaryKeyCode(3).ToUpper = "S" Then
                        'Asked to sign it
                        TemporaryKeyCode(3) = Hex(CInt(TemporaryKeyCode(0)) + CInt(TemporaryKeyCode(1)) + CInt(TemporaryKeyCode(2)))
                        KeycodeTXB.Text = String.Join("-", TemporaryKeyCode)
                    Else
                        KeycodeStatusLBL.Text = "Invalid KeyCode (Checksum doesn't match)"
                    End If
                Else
                    KeycodeStatusLBL.Text = "Invalid KeyCode (Must have 3 numbers per part)"
                End If
            Else
                KeycodeStatusLBL.Text = "Invalid KeyCode (Must have 3 or 4 parts)"
            End If
        Catch ex As Exception
            KeycodeStatusLBL.Text = "Invalid KeyCode"
        End Try

    End Sub

    '----------------------------[Other]----------------------------

    Private Function IsValidKeyCode(Keycode() As String) As Boolean
        If Not (Keycode(0).Count = 3 And Keycode(1).Count = 3 And Keycode(2).Count = 3) Then Return False

        For X = 0 To 2
            For Each Character As Char In Keycode(X)
                If Not Char.IsDigit(Character) Then Return False
            Next
        Next

        Return True
    End Function

End Class