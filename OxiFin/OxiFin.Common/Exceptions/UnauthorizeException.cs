namespace OxiFin.Common.Exceptions
{
    public class UnauthorizeException : AppBaseException
    {
        public UnauthorizeException(string msg) : base(msg)
        {
        }
        public UnauthorizeException() : base("Unauthorized")
        {
        }
    }
}
