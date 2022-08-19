namespace TheBank.Exceptions
{
    public class OverdraftException : Exception
    {
        public OverdraftException(string msg) : base(msg) { }
    }
}
