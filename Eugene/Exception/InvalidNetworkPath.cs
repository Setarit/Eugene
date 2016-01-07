namespace Eugene.Exception
{
    class InvalidNetworkPath:System.Exception
    {
        public InvalidNetworkPath()
        {
        }

        public InvalidNetworkPath(string message) : base(message)
        {
        }

        public InvalidNetworkPath(string message, System.Exception inner) : base(message, inner)
        {
        }
    }
}
