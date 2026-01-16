namespace WinCommands
{
    public class WinCommandOutput
    {
        public string SearchedText { get; set; }
        public string Output { get; set; }
        public string Error { get; set; }

        public WinCommandOutput() { }
        public WinCommandOutput(string output, string error) 
        {
            Output = output;
            Error = error;
        }

    }
}
