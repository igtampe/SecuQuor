Public Class SecuQuorHandler
    Implements IEncryptionHandler

    '----------------------------[Variables]----------------------------

    Private Const HANDLER_VERSION = 3.1
    Private Const HANDLER_NAME = "SecuQour Encryption"
    Private CodeWheel As SecuQuorCodeWheel
    Private ReadOnly myOptionsWindow As SecuQuorOptions

    '----------------------------[Structures]----------------------------

    Private Structure SecuQuorCodeWheelSegment
        Public ReadOnly Character As String
        Public ReadOnly Number As Double
        Public ReadOnly Prefix As String

        Public Sub New(Character As String, Number As Integer, Prefix As String)
            Me.Character = Character
            Me.Number = Number
            Me.Prefix = Prefix
        End Sub

    End Structure

    Private Structure SecuQuorCodeWheel

        '===============[Variables]===============

        Implements ICodeWheel
        Private ReadOnly AllSegments As ArrayList
        Private KeyCode As Double()
        Private Shift As Integer

        '===============[CodeWheel Operations]===============

        Public Function Encode(Character As String) As String Implements ICodeWheel.Encode
            For Each CodeWheelSegment As SecuQuorCodeWheelSegment In AllSegments
                If Character = CodeWheelSegment.Character Then

                    'We found it
                    Select Case CodeWheelSegment.Prefix.Substring(0, 1)
                        Case "A"
                            Return CodeWheelSegment.Prefix & ((CodeWheelSegment.Number + Shift) * KeyCode(0))
                        Case "B"
                            Return CodeWheelSegment.Prefix & ((CodeWheelSegment.Number + Shift) * KeyCode(1))
                        Case "C"
                            Return CodeWheelSegment.Prefix & ((CodeWheelSegment.Number + Shift) * KeyCode(2))
                    End Select

                End If
            Next

            Debug.Print("Could not encode Character " & Character)
            Return "?"
        End Function

        Public Function Decode(Segment As String) As String Implements ICodeWheel.Decode

            Try
                Dim SegmentSection As String = Segment.Substring(0, 2)
                Dim SegmentNumber As Double = Segment.Substring(2)

                Select Case SegmentSection.Substring(0, 1)
                    Case "A"
                        SegmentNumber /= KeyCode(0)
                    Case "B"
                        SegmentNumber /= KeyCode(1)
                    Case "C"
                        SegmentNumber /= KeyCode(2)
                    Case Else
                        Debug.Print("Could not find prefix of segment " & Segment)
                        Return "?"
                End Select

                For Each CodeWheelSegment As SecuQuorCodeWheelSegment In AllSegments
                    If SegmentSection = CodeWheelSegment.Prefix And SegmentNumber = CodeWheelSegment.Number + Shift Then Return CodeWheelSegment.Character
                Next

            Catch ex As Exception
                Debug.Print(ex.StackTrace)
            End Try

            Debug.Print("Could not decode segment " & Segment)
            Return "?"
        End Function

        '===============[Constructor]===============

        Public Sub New(RawCodeWheelSegments As String(), Code As Double())
            KeyCode = Code
            Shift = 0

            AllSegments = New ArrayList

            For Each RawSegment As String In RawCodeWheelSegments
                AllSegments.Add(New SecuQuorCodeWheelSegment(RawSegment.Split("~")(0), RawSegment.Split("~")(1), RawSegment.Split("~")(2)))
            Next

        End Sub

        '===============[Getters and Setters]===============

        Public Sub SetKeyCode(Code As Double())
            If Code.Length < 3 Then Exit Sub
            KeyCode = Code
        End Sub

        Public Function GetKeyCode() As Double()
            Return KeyCode
        End Function

        Public Sub SetShift(Shift As Integer)
            Me.Shift = Shift
        End Sub

        Public Function GetShift() As Integer
            Return Shift
        End Function

    End Structure

    '----------------------------[Constructor]----------------------------

    Public Sub New(RawCodeWheelSegments As String())

        'Create codewheel
        CodeWheel = New SecuQuorCodeWheel(RawCodeWheelSegments, {1, 1, 1})

        'Create My Options Window
        myOptionsWindow = New SecuQuorOptions With {.Master = Me}
        myOptionsWindow.KeycodeTXB.Text = "001-001-001"

    End Sub

    '----------------------------[EncryptionHandler Operations]----------------------------

    Public Function Encrypt(Message As String) As String Implements IEncryptionHandler.Encrypt
        'Hello.
        Dim CharArray As Char() = Message.ToCharArray
        Dim ReturnString As String = ""

        For Each Character As Char In CharArray
            ReturnString &= CodeWheel.Encode(Character) & "-"
        Next

        Return ReturnString.TrimEnd("-")
    End Function

    Public Function Decrypt(Message As String) As String Implements IEncryptionHandler.Decrypt
        'AB6790-AA11640-AA1940-AA1940-AA970-CA5742
        Dim TranslationArray As String() = Message.Split("-")
        Dim ReturnString As String = ""

        For Each Translation As String In TranslationArray
            ReturnString &= CodeWheel.Decode(Translation)
        Next

        Return ReturnString
    End Function

    Public Sub ShowOptions() Implements IEncryptionHandler.ShowOptions

        'Make sure the window is set
        myOptionsWindow.Master = Me
        myOptionsWindow.commit = False

        'show the window
        myOptionsWindow.ShowDialog()

        'If they clicked OK, update the codewheel
        If myOptionsWindow.commit Then
            SetKey(myOptionsWindow.Master.CodeWheel.GetKeyCode)
            SetShift(myOptionsWindow.Master.CodeWheel.GetShift)
        End If

    End Sub

    '----------------------------[Getters and Setters]----------------------------

    Public Function getName() As String Implements IEncryptionHandler.GetName
        Return HANDLER_NAME
    End Function

    Public Function getVer() As String Implements IEncryptionHandler.GetVer
        Return HANDLER_VERSION
    End Function

    Public Sub SetKey(Key As Double())
        CodeWheel.SetKeyCode(Key)
    End Sub

    Public Sub SetShift(Shift As Integer)
        CodeWheel.SetShift(Shift)
    End Sub

End Class
