Public Class MCodeHandler
    Implements IEncryptionHandler

    '----------------------------[Variables]----------------------------

    Private Const HANDLER_VERSION = 1.0
    Private Const HANDLER_NAME = "Morse Code"
    Private ReadOnly CodeWheel As MCodeCodeWheel

    '----------------------------[Structures]----------------------------

    Private Structure MCodeCodeWheelSegment
        Public ReadOnly Character As String
        Public ReadOnly Translation As String

        Public Sub New(Character As String, Translation As String)
            Me.Character = Character
            Me.Translation = Translation
        End Sub

    End Structure

    Private Structure MCodeCodeWheel
        Implements ICodeWheel

        '===============[Segments Holder]===============

        Private ReadOnly AllSegments As ArrayList

        '===============[CodeWheel Operations]===============

        Public Function Encode(Character As String) As String Implements ICodeWheel.Encode
            For Each Segment As MCodeCodeWheelSegment In AllSegments
                If Segment.Character.Equals(Character.ToUpper) Then Return Segment.Translation
            Next
            Return "?"
        End Function

        Public Function Decode(Translation As String) As String Implements ICodeWheel.Decode
            For Each Segment As MCodeCodeWheelSegment In AllSegments
                If Segment.Translation.Equals(Translation) Then Return Segment.Character
            Next
            Return "?"
        End Function

        '===============[Constructor]===============

        Public Sub New(MCodeCodewheelFile As String)
            AllSegments = New ArrayList
            FileOpen(1, MCodeCodewheelFile, OpenMode.Input)

            While Not EOF(1)
                Dim CurrentLine As String() = LineInput(1).Split("~")
                AllSegments.Add(New MCodeCodeWheelSegment(CurrentLine(0), CurrentLine(1)))
            End While

            FileClose(1)
        End Sub

    End Structure

    '----------------------------[Constructor]----------------------------

    Public Sub New(MCodeCodewheelFile As String)
        CodeWheel = New MCodeCodeWheel(MCodeCodewheelFile)
    End Sub

    '----------------------------[EncryptionHandler Operations]----------------------------

    Public Function Encrypt(Message As String) As String Implements IEncryptionHandler.Encrypt
        'Hello. This is a cosito.
        Dim CharArray As Char() = Message.ToCharArray
        Dim ReturnString As String = ""

        For Each Character As Char In CharArray
            ReturnString &= CodeWheel.Encode(Character) & " "
        Next

        Return ReturnString.TrimEnd(" ")
    End Function

    Public Function Decrypt(Message As String) As String Implements IEncryptionHandler.Decrypt
        '.... . .-.. .-.. --- + / - .... .. ... / .. ... / .- / -.-. --- ... .. - --- +
        Dim TranslationArray As String() = Message.Split(" ")
        Dim ReturnString As String = ""

        For Each Translation As String In TranslationArray
            ReturnString &= CodeWheel.Decode(Translation)
        Next

        Return ReturnString
    End Function

    Public Sub ShowOptions() Implements IEncryptionHandler.ShowOptions
        MsgBox("This Extension has no options", vbInformation, HANDLER_NAME & " (Version " & HANDLER_VERSION & ")")
    End Sub

    '----------------------------[Getters]----------------------------

    Public Function GetName() As String Implements IEncryptionHandler.GetName
        Return HANDLER_NAME
    End Function

    Public Function GetVer() As String Implements IEncryptionHandler.GetVer
        Return HANDLER_VERSION
    End Function

End Class
