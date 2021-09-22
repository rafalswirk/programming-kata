namespace LastDigitLib.IO
{
    public interface IOutputData
    {
        string Buffer { get; }
        void Write(string text);
    }
}