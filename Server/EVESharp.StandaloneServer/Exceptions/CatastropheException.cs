namespace System
{
    /// <summary>
    /// This will disconnect the client and dispose the session
    /// </summary>
    /// <param name="msg"></param>
    internal class CatastropheException (string msg) : Exception (msg) { }
}
