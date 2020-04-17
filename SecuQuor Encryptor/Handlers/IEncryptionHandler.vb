Public Interface IEncryptionHandler

    ''' <summary> Encrypts a message of some sort</summary>
    ''' <param name="Message">The message you want to encrypt</param>
    ''' <returns>The message, but encrypted by this encryption handler</returns>
    Function Encrypt(Message As String) As String

    ''' <summary> Decrypts a message of some sort</summary>
    ''' <param name="Message">The message you want to Decrypt (Prefferably one encrypted by this handler)</param>
    ''' <returns>The message, but decrypted</returns>
    Function Decrypt(Message As String) As String

    ''' <summary>Name of this encryption handler</summary>
    ''' <returns>Encryption handler name</returns>
    Function GetName() As String

    ''' <summary>Version of this encryption handler</summary>
    ''' <returns>Encryption handler version</returns>
    Function GetVer() As String

    ''' <summary> Shows the options dialog for this extension </summary>
    Sub ShowOptions()

End Interface
