namespace NegueApp.Components.Terminal
{
    public class TerminalInput
    {
        public List<string> History { get; private set; } = new();
        public string Command { get; set; }
    }

    public class TerminalOutput
    {
        public List<string> CurrentOutput { get; private set; } = new();
    }
}
