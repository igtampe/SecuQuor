Public Interface ICodeWheel

    ''' <summary>Encodes a singular character</summary>
    ''' <param name="Character"></param>
    ''' <returns>A segment of an encoded message that represents the current character</returns>
    Function Encode(Character As String) As String

    ''' <summary>Decodes a decodable segment of the message</summary>
    ''' <param name="Segment"></param>
    ''' <returns>A character that represents that segment</returns>
    Function Decode(Segment As String) As String

End Interface
