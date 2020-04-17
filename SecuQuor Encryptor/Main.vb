Public Class Secuquor

    '----------------------------[Variables]----------------------------

    Private MyHandlers As IEncryptionHandler()
    Private Mode As SecuQuorFormMode

    Private Enum SecuQuorFormMode As Integer
        Decode = 0
        Encode = 1
    End Enum

    '----------------------------[Initialization]----------------------------

    Private Sub LoadUp() Handles Me.Load

        'Create and register the handlers
        MyHandlers = {
            New MCodeHandler(ResourceToStringArray(My.Resources.MCode)),
            New SecuQuorHandler(ResourceToStringArray(My.Resources.SecuQuor))
        }

        'Add Handlers to combobox
        For Each Handler As IEncryptionHandler In MyHandlers
            ComboBox1.Items.Add(Handler.GetName & " (Version " & Handler.GetVer & ")")
        Next

    End Sub

    ''' <summary>returns a resource as an array of lines</summary>
    ''' <param name="Resource">A resource (preferably a text file of some sort)</param>
    ''' <returns>An array of the lines the resource contains</returns>
    Private Function ResourceToStringArray(Resource As Byte()) As String()
        Dim TheString As String = System.Text.Encoding.ASCII.GetString(Resource)
        Return TheString.Replace(vbLf, "").Split(vbCr)
    End Function

    '----------------------------[User Interaction]----------------------------

    Sub CheckForUntouched()
        If EncodedTXB.ForeColor = Color.DarkGray Then
            EncodedTXB.ForeColor = Color.Black
            DecodedTXB.ForeColor = Color.Black
            EncodedTXB.Clear()
            DecodedTXB.Clear()
        End If
    End Sub

    Private Sub DecodedTXB_GotFocus() Handles DecodedTXB.GotFocus
        Mode = SecuQuorFormMode.Encode
        CheckForUntouched()
    End Sub

    Private Sub EncodedTXB_GotFocus(sender As Object, e As EventArgs) Handles EncodedTXB.GotFocus
        Mode = SecuQuorFormMode.Decode
        CheckForUntouched()
    End Sub

    Private Sub Display() Handles DecodedTXB.TextChanged, EncodedTXB.TextChanged

        'Make sure we don't have nothing selected and try to do anything.
        If ComboBox1.SelectedIndex = -1 Then Return

        Select Case Mode
            Case SecuQuorFormMode.Encode
                If Not String.IsNullOrWhiteSpace(DecodedTXB.Text) Then EncodedTXB.Text = MyHandlers(ComboBox1.SelectedIndex).Encrypt(DecodedTXB.Text)
            Case SecuQuorFormMode.Decode
                If Not String.IsNullOrWhiteSpace(EncodedTXB.Text) Then DecodedTXB.Text = MyHandlers(ComboBox1.SelectedIndex).Decrypt(EncodedTXB.Text)
        End Select

    End Sub

    Private Sub ShowWhatsNew(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        WhatsNew.Show()
    End Sub

    Private Sub ShowHandlerOptions() Handles LinkLabel2.LinkClicked
        MyHandlers(ComboBox1.SelectedIndex).ShowOptions()
        Display()
    End Sub

    Private Sub ChangeHandler(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        DecodedTXB.Enabled = True
        EncodedTXB.Enabled = True
        LinkLabel2.Enabled = True
    End Sub

End Class