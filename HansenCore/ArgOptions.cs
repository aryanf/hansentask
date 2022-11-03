using CommandLine;

public class ArgOptions
{
    [Option('h', "help", Required = false, HelpText = "Help how to use this console app")]
    public bool Help { get; set; }

    [Option('v', "version", Required = false, HelpText = "Console app version")]
    public bool Version { get; set; }
}
