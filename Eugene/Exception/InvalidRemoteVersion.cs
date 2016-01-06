namespace Eugene.Exception
{
    class InvalidRemoteVersion:System.Exception
    {
        public InvalidRemoteVersion()
        {
        }

        public InvalidRemoteVersion(string message) : base(message)
        {
        }

        public InvalidRemoteVersion(string message, System.Exception inner) : base(message, inner)
        {
        }
    }
}
